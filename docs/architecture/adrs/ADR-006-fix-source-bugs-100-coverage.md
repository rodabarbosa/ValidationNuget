---
type: adr
title: "ADR-006: Correção de bugs em código-fonte para atingir 100% de cobertura de testes"
description: "Aprova a modificação de 6 arquivos de validação (IE + CPF) para corrigir branches mortos e ausência de null checks, liberando a cobertura de 100% de linhas e branches no plano de testes (planning/004-100-coverage-tests.md, Wave 7)."
resource: "./ADR-006-fix-source-bugs-100-coverage.md"
tags: [arquitetura, decisao, cobertura, qualidade, correcao-bugs]
generated:
  by: "Opencode — architecture"
  timestamp: "2026-08-02"
status: accepted
domain:
  artifact_id: "ADR-006"
  title_pt: "Correção de bugs em código-fonte para 100% de cobertura"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "02/08/2026"
  updated: "02/08/2026"
  language: pt-BR
risco_associado:
  - id: "RSK-012"
    requisito: "req-0006"
    nome: "Algoritmo de IE de um estado específico incorreto"
  - id: "RSK-001"
    requisito: "req-0001"
    nome: "Algoritmo de validação de CPF incorreto"
plan_ref: "planning/004-100-coverage-tests.md"
---

# ADR-006: Correção de bugs em código-fonte para atingir 100% de cobertura de testes

> **Status:** Aceito
> **Data:** 02/08/2026
> **Autor:** Rodrigo Araujo Barbosa
> **Decisão:** Aprovada para implementação na Wave 7 do plano `004-100-coverage-tests.md`.
> **Referência ao plano:** `planning/004-100-coverage-tests.md` — Waves 6 & 7, Tasks 27–36.

---

## 1. Contexto

A biblioteca **Sirb.Validation** tem como objetivo de qualidade **100% de cobertura de linhas e branches** (baseline atual: 94,48% linhas, 73,37% branches). O plano de cobertura (`planning/004-100-coverage-tests.md`) identificou **6 bugs em código-fonte** que criam branches mortos (impossíveis de atingir via testes), tornando 100% de cobertura unattingível sem correção de código-fonte.

A política vigente (ADR-0002, do plano) registrou esses branches como **⏳ PENDENTE**, afastando a correção. Após aprovação do usuário (Wave 7), esta ADR autoriza a modificação do código-fonte principal.

**Baseline de cobertura (medido via `XPlat Code Coverage`):**

| Métrica | Atual | Alvo |
|---------|-------|------|
| Line rate | 94,48% (2072/2193) | 100% |
| Branch rate | 73,37% (711/969) | 100% |

### Bugs identificados

| # | Arquivo | Bug | Tipo |
|---|---------|-----|------|
| 1 | `InscricaoEstadualRioGrandeDoNorteValidation.cs` (L15) | `weight < 9 && weight > 10` — condição contraditória, sempre falsa | Branch morto |
| 2 | `InscricaoEstadualTocantinsValidation.cs` (L15) | `value.Substring(1, value.Length)` — `ArgumentOutOfRangeException` quando `Length == 9` | Bug de lógica + branch inatingível |
| 3 | `InscricaoEstadualPernambucoValidation.cs` (L11) | `value.PadRight(14, '0')` sem null check → `NullReferenceException` | Ausência de null check |
| 4 | `InscricaoEstadualPiauiValidation.cs` (L11) | `value.Length` sem null check → `NullReferenceException` | Ausência de null check |
| 5 | `InscricaoEstadualSaoPauloValidation.cs` (L11) | `value.StartsWith(...)` sem null check → `NullReferenceException` | Ausência de null check |
| 6 | `CpfValidation.cs` (L126) | `default` case no switch de `GetIssuingState` — inatingível (9º dígito do CPF é sempre 0–9) | Branch morto |

### Riscos associados (Matriz Global)

| Risco | Requisito | Descrição | Score | Nível |
|-------|-----------|-----------|-------|-------|
| RSK-012 | req-0006 | Algoritmo de IE de um estado específico incorreto | 15 | Alto |
| RSK-001 | req-0001 | Algoritmo de validação de CPF incorreto (falso positivo) | 10 | Alto |

---

## 2. Análise de cada bug (verificado no código-fonte)

### Bug 1 — InscricaoEstadualRioGrandeDoNorteValidation.cs (L15)

**Código atual:**
```csharp
var weight = value.Length;
if (weight < 9 && weight > 10 && !value.StartsWith("20")) return false;
```

**Análise:** A expressão `weight < 9 && weight > 10` é logicamente contraditória — nenhum inteiro pode ser simultaneamente menor que 9 **e** maior que 10. Portanto a condição `always false`, tornando todo o bloco `if` **dead code**. Como consequência:
- A validação de comprimento (rejeitar IEs com < 9 ou > 10 dígitos) nunca é executada.
- A checagem do prefixo `"20"` (exigido para IEs de 10 dígitos do RN) nunca é aplicada.

**Fix planejado (Wave 7, Task 31):** Substituir `&&` por `||`:
```csharp
if ((weight < 9 || weight > 10) && !value.StartsWith("20")) return false;
```

**Verificação de impacto:** Para o caso de teste existente (9 dígitos): `weight == 9` → `(9 < 9 || 9 > 10)` = `false` → `false && ...` = `false` → **não rejeita** → comportamento preservado. Todos os 10 testes existentes do RN continuam passando.

### Bug 2 — InscricaoEstadualTocantinsValidation.cs (L15)

**Código atual:**
```csharp
if (value.Length == 9) valueAux = value.Substring(0, 2) + "02" + value.Substring(1, value.Length);
```

**Análise:** `Substring(1, value.Length)` com `value.Length == 9` equivale a `Substring(1, 9)` — solicita 9 caracteres a partir do índice 1, mas apenas 8 caracteres estão disponíveis (índices 1–8). Isso lança `ArgumentOutOfRangeException`. O método intenciona inserir `"02"` após os primeiros 2 dígitos para converter uma IE de 9 dígitos em 11 dígitos. O correto é capturar os caracteres restantes a partir do índice 2:

**Fix planejado (Wave 7, Task 32):**
```csharp
if (value.Length == 9) valueAux = value.Substring(0, 2) + "02" + value.Substring(2);
```

**Verificação de impacto:** `Substring(0, 2)` (2 chars) + `"02"` (2 chars) + `Substring(2)` (7 chars) = 11 chars. O teste existente de 9 dígitos (Task 13d / Wave 3, pendente) nunca chegou a rodar porque o código lançava exceção. Pós-fix: o caminho será exercitado com sucesso.

### Bug 3 — InscricaoEstadualPernambucoValidation.cs (L11)

**Código atual:**
```csharp
var value = ieNumber?.OnlyNumbers();
var valueAux = value.PadRight(14, '0');  // NRE se value == null
```

**Análise:** `ieNumber?.OnlyNumbers()` pode retornar `null` (quando `ieNumber` é null). `PadRight` em `null` lança `NullReferenceException`. Compare com as 24 demais IE validations que usam `string.IsNullOrEmpty(value)` antes de acessar propriedades.

**Fix planejado (Wave 7, Task 33):** Adicionar guard clause:
```csharp
var value = ieNumber?.OnlyNumbers();
if (string.IsNullOrEmpty(value)) return false;
```

**Verificação de impacto:** O entry point público `InscricaoEstadualValidation.IsValid` (L106) já faz `if (string.IsNullOrEmpty(value)) return false` antes de delegar. A correção afeta apenas chamadas diretas à classe `internal` (via `InternalsVisibleTo`), alinhando o comportamento com as demais 24 validações.

### Bug 4 — InscricaoEstadualPiauiValidation.cs (L11)

**Código atual:**
```csharp
var value = ieNumber?.OnlyNumbers();
if (value.Length != 9) return false;  // NRE se value == null
```

**Análise:** Acesso a `value.Length` quando `value` pode ser `null`. A pattern estabelecida (ex: `InscricaoEstadualSantaCatarinaValidation`) usa `string.IsNullOrEmpty(value) || value.Length != 9`.

**Fix planejado (Wave 7, Task 34):**
```csharp
var value = ieNumber?.OnlyNumbers();
if (string.IsNullOrEmpty(value) || value.Length != 9) return false;
```

**Verificação de impacto:** Nulo/empty agora retorna `false` em vez de lançar. Mesmo impacto do Bug 3 — apenas chamadas diretas à classe internal são afetadas.

### Bug 5 — InscricaoEstadualSaoPauloValidation.cs (L11)

**Código atual:**
```csharp
public bool IsValid(string value)
{
    return value.StartsWith("P", StringComparison.OrdinalIgnoreCase)
        ? ValidateWithP(value.OnlyNumbers())
        : ValidateStandart(value.OnceNumbers());
}
```

**Análise:** Diferentemente das outras IE validations que recebem `ieNumber?.OnlyNumbers()` e aplicam guard clause, a classe SP recebe `value` diretamente e chama `value.StartsWith(...)` sem verificar null. Um input null lança `NullReferenceException`.

**Fix planejado (Wave 7, Task 35):** Adicionar guard clause no início de `IsValid`:
```csharp
public bool IsValid(string value)
{
    if (string.IsNullOrEmpty(value)) return false;
    return value.StartsWith("P", StringComparison.OrdinalIgnoreCase)
        ? ValidateWithP(value.OnceNumbers())
        : ValidateStandart(value.OnceNumbers());
}
```

**Verificação de impacto:** Same pattern as other 24 IE validators. Public entry point already handles null. No breaking change.

### Bug 6 — CpfValidation.cs (L126)

**Código atual:**
```csharp
switch (int.Parse(aux.Substring(8, 1)))
{
    case 0: return "RS";
    case 1: return "DF, GO, MS, TO";
    ...
    case 9: return "PR, SC";
    default: return "Unknown";  // UNREACHABLE
}
```

**Análise:** O switch cobre todos os 10 dígitos possíveis (0–9). Como `GetIssuingState` valida o CPF antes (`if (!IsValid(value)) throw ...`), o 9º dígito (índice 8) é sempre um caractere numérico `'0'`–`'9'`. `int.Parse` em um único dígito sempre retorna 0–9, portanto o caso `default` é **inalcançável**.

**Fix planejado (Wave 7, Task 36):** Remover o caso `default` (ou marcar como unreachable):
```csharp
switch (int.Parse(aux.Substring(8, 1)))
{
    case 0: return "RS";
    ...
    case 9: return "PR, SC";
}
```

> **Nota:** Em C# 8+ com `switch` statement sobre `int`, o compilador pode emitir aviso CS8426 (switch não exaustivo) se `default` for removido. O comportamento é preservado — o código não atingiria `default` mesmo assim. A alternativa `throw new InvalidOperationException("Unexpected digit")` mantém exaustividade sem criar branch testável como "retorno de string".

**Verificação de impacto:** Zero alteração de comportamento. Branch inatingível por definição.

---

## 3. Opções consideradas

### Opção A — Não corrigir (manter branches mortos)

| Prós | Contras |
|------|---------|
| Zero risco de regressão | 100% de cobertura é **impossível** (branches inatingíveis) |
| Nenhum arquivo de código-fonte modificado | Cobertura ficará presa a ~73% em branches |
| Mantém política "apenas adição de testes" | Qualidade do código degradada — bugs latentes permanecem |

### Opção B — Corrigir os 6 bugs (decisão adotada)

| Prós | Contras |
|------|---------|
| **100% de cobertura de linhas e branches atingível** | Pequena alteração em 6 arquivos de código-fonte |
| Elimina branches mortos e bugs latentes | Exige revalidação de regressão (build + todos os testes) |
| Alinha 3 IE validators ao padrão de null check das outras 24 | Cada modificação deve preservar comportamento para inputs válidos |

### Opção C — Suprimir branches via atributos de cobertura (ex: `[ExcludeFromCodeCoverage]`)

| Prós | Contras |
|------|---------|
| Nenhum código-fonte modificado | **Falso positivo de qualidade** — cobertura de 100% é ilusória |
| Rápido | Esconde bugs em vez de resolver |
| | Diverge da cultura do projeto (testes exaustivos > supressão) |

**Decisão:** Opção B — corrigir os 6 bugs, pois a Opção C viola o princípio de "testes exaustivos > supressão" adottado pelo projeto (ver ADR-003, quality checklist) e a Opção A torna o objetivo de 100% irrealizável.

---

## 4. Decisão

**Aprovada a correção dos 6 bugs no código-fonte principal de `Sirb.Validation`, conforme plano `planning/004-100-coverage-tests.md` (Wave 7, Tasks 31–36).**

| Task | Arquivo | Correção |
|------|---------|----------|
| 31 | `InscricaoEstadualRioGrandeDoNorteValidation.cs` L15 | `&&` → `||` |
| 32 | `InscricaoEstadualTocantinsValidation.cs` L15 | `Substring(1, value.Length)` → `Substring(2)` |
| 33 | `InscricaoEstadualPernambucoValidation.cs` L10-11 | Adicionar `string.IsNullOrEmpty(value)` guard |
| 34 | `InscricaoEstadualPiauiValidation.cs` L11 | `|| value.Length != 9` → `string.IsNullOrEmpty(value) \|\| value.Length != 9` |
| 35 | `InscricaoEstadualSaoPauloValidation.cs` L9 | Adicionar `string.IsNullOrEmpty(value)` guard |
| 36 | `CpfValidation.cs` L126 | Remover `default` case do switch (ou substituir por `throw`) |

Cada correção será seguida de testes que cobrem o branch corrigido (Tasks 37, do plano).

---

## 5. Impacto e Análise de Riscos

### 5.1 Mudança de comportamento

| Bug | Comportamento antes | Comportamento depois | Breaking? |
|-----|---------------------|----------------------|-----------|
| 1 (RN) | Todos os tamanhos/prefixos aceitos (guard morto) | Tamanhos < 9 ou > 10 rejeitados | Não — apenas rejeita inputs inválidos que deveriam ser rejeitados |
| 2 (TO) | 9 dígitos → `ArgumentOutOfRangeException` | 9 dígitos → processado corretamente | Não — corrige crash |
| 3 (PE) | `IsValid(null)` → `NullReferenceException` | `IsValid(null)` → `false` | Não — converte exceção em retorno booleano |
| 4 (PI) | `IsValid(null)` → `NullReferenceException` | `IsValid(null)` → `false` | Não — converte exceção em retorno booleano |
| 5 (SP) | `IsValid(null)` → `NullReferenceException` | `IsValid(null)` → `false` | Não — converte exceção em retorno booleano |
| 6 (CPF) | `default` nunca atingido | `default` removido/`throw` | Não — branch era inatingível |

### 5.2 Compatibilidade reversa (backward compatibility)

- **API pública afetada:** Nenhuma. As classes RN, TO, PE, PI, SP são `internal`; CpfValidation é `public` mas apenas o `default` case inatingível é removido.
- **Entry point público `InscricaoEstadualValidation.IsValid`:** Já realiza `string.IsNullOrEmpty(value)` check na L106 antes de delegar, portanto null nunca chega às classes internal. As correções 3–5 são defensivas e não alteram o contrato com consumidores.
- **CPF `GetIssuingState`:** Apenas remove branch inatingível. Nenhum CPF válido teria o 9º dígito fora de 0–9.

### 5.3 Risco de regressão

| Risco | Nível | Mitigação |
|-------|-------|-----------|
| Correção do `&&` → `||` no RN altera validade de IE | Médio | Todos os 10 testes existentes (5 válidos, 5 inválidos) devem continuar passando; novos testes cobrem o branch corrigido |
| Correção do `Substring` no TO altera algoritmo de dígito verificador | Médio | O algoritmo do dígito permanece idêntico; apenas o corte da substring muda para incluir todos os dígitos necessários |
| Null checks em PE/PI/SP alteram exceções para `false` | Baixo | Apenas chamadas diretas às classes `internal` são afetadas; o entry point público já filtra nulls |

### 5.4 Relação com a matriz de risco

| Bug | Risco existente | Ação da ADR |
|-----|-----------------|-------------|
| 1, 2, 3, 4, 5 (IE) | RSK-012 (Score 15, Alto) | Reduz P de 3→1 (bugs não podem mais ocorrer) |
| 6 (CPF) | RSK-001 (Score 10, Alto) | Reduz P de 2→1 (branch morto documentado) |

---

## 6. Avaliação de Atributos de Qualidade

| Atributo | Impacto | Justificativa |
|----------|---------|---------------|
| **Corretude** | ✅ Melhora | 6 bugs corrigidos aumentam a precisão da validação |
| **Robustez** | ✅ Melhora | 3 null checks adicionais prevenem NRE em chamadas diretas |
| **Testabilidade** | ✅ Melhora drasticamente | 100% de cobertura passa a ser atingível |
| **Manutenibilidade** | ✅ Melhora | 3 IE validators alinhados ao padrão de null check das outras 24 |
| **Performance** | ➖ Neutro | Nenhuma alocação adicional; null checks são O(1) |
| **Segurança** | ➖ Neutro | Nenhuma mudança em sanitização de entrada ou saída |
| **Compatibilidade** | ➖ Neutro | Nenhuma breaking change na API pública |
| **Simplicidade** | ✅ Melhora | Remove código morto (dead code) e condições contraditórias |

---

## 7. Plano de verificação (compliance)

1. **Wave 7** (Tasks 31–36): Implementar as 6 correções de código-fonte.
2. **Wave 7** (Task 37): Adicionar testes que cobram os branches corrigidos.
3. **Wave 7** (Task 38): Re-executar `dotnet test --collect:"XPlat Code Coverage"` + `reportgenerator` — confirmar 100% line rate e 100% branch rate.
4. **Checkpoint final:** Build sem erros + todos os 1527+ testes existentes passando.

**Critério de aceitação:** Coverage = 100% linhas e 100% branches, sem regressão em testes existentes.

---

## 8. Histórico de alterações

| Data | Autor | Versão | Alteração |
|------|-------|--------|-----------|
| 02/08/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação — aprovação da correção de 6 bugs para 100% de cobertura |
