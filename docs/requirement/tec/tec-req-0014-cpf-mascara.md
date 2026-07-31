---
type: tec-req
title: "tec-req-0014 — CPF — Máscara (Especificação Técnica)"
description: "Especificação técnica da aplicação de máscara CPF no formato 000.000.000-00, normalização de entrada via RemoveMask/OnlyNumbers, extension method PlaceCpfMask."
resource: "./requirement/tec/tec-req-0014-cpf-mascara.md"
tags: [documento-brasileiro, especificacao-tecnica, mascara, cpf]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-31"
verified:
  by: "Rodrigo Araujo Barbosa"
  timestamp: "2026-07-31T02:00:00Z"
  method: "validação com PO"
status: approved
stale_after: "2027-01-31"
domain:
  artifact_id: "tec-req-0014"
  title_pt: "CPF — Máscara — Especificação Técnica"
  version: "1.1.0"
  author: "Rodrigo Araujo Barbosa"
  created: "31/07/2026"
  updated: "31/07/2026"
  bundle: "flat"
  language: pt-BR
  req_origem: "req-0014-cpf-mascara.md"
  coverage_clarification: "8/8"
---

# tec-req-0014 — CPF — Máscara (Especificação Técnica)

## Metadados

> Esta tabela é uma **reflexão** do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

| Campo | Valor |
|---|---|
| **Código do documento** | `tec-req-0014` |
| **Título** | CPF — Máscara — Especificação Técnica |
| **Versão** | 1.1.0 |
| **Autor** | Rodrigo Araujo Barbosa |
| **Data de criação** | 31/07/2026 |
| **Última atualização** | 31/07/2026 |
| **Status** | Aprovado |
| **Bundle** | `flat` |
| **Requisito de negócio** | `req-0014-cpf-mascara.md` |
| **Cobertura Clarification** | 8/8 |
| **Tipo OKF** | `tec-req` |

> Sempre que este documento for atualizado, incremente a **Versão** (campo `domain.version` no frontmatter) e registre a alteração no histórico. Mantenha este arquivo **sincronizado** com o `req-0014` correspondente em conteúdo, versão e no Clarification Log.

## 1. Resumo do requisito de negócio

- **Requisito de origem:** `req-0014-cpf-mascara.md` (versão 1.0.0)
- **Síntese do "o quê":** Aplicar máscara `000.000.000-00` a strings contendo CPF, com normalização prévia (remoção de não-dígitos) e tratamento de bordas (null/vazio → null).
- **Síntese do "por quê":** Padronizar formatação de CPF em aplicações .NET, evitando formatação manual inconsistente e garantindo conformidade com layout oficial brasileiro.

## 2. Detalhamento técnico completo

### 2.1 Arquitetura de camadas

```
Extensions (API Pública)
  └── CpfExtension.cs                    (PlaceCpfMask via extension method)
Validation (Orquestração)
  └── CpfValidation.cs                   (PlaceMask, RemoveMask delega para StringExtension)
Extensions (Utilitários)
  └── StringExtension.cs                 (OnlyNumbers — regex [^\d])
```

### 2.2 Algoritmo de máscara

**Formato:** `000.000.000-00`

**Regex:** `(\d{3})(\d{3})(\d{3})(\d{2})` → substituição `$1.$2.$3-$4`

**Fluxo:**
1. Verifica se entrada é null, vazia ou whitespace → retorna `default` (null)
2. Chama `value.RemoveMask()` → `StringExtension.OnlyNumbers()` → regex `[^\d]` remove tudo que não é dígito
3. Aplica `Regex.Replace` com padrão acima
4. Retorna string formatada

### 2.3 Validações de entrada

| Entrada | Comportamento |
|---------|---------------|
| `null` | Retorna `null` |
| `""` (vazio) | Retorna `null` |
| `"   "` (whitespace) | Retorna `null` (Trim + IsNullOrEmpty) |
| `"12345678909"` (11 dígitos) | Retorna `"123.456.789-09"` |
| `"123.456.789-09"` (já formatado) | Retorna `"123.456.789-09"` (idempotente) |
| `"12a3.45b6.78c9-0d9"` (com letras) | Retorna `"123.456.789-09"` (normaliza) |
| `"123456789"` (9 dígitos) | Retorna `"123456789"` (regex não casa, string original normalizada retornada) |

**Nota importante:** O método **não valida** o CPF (dígitos verificadores). Apenas formata. Validação é responsabilidade de `IsValid` (`req-0001`).

### 2.4 Normalização (RemoveMask)

- Delegado para `StringExtension.OnlyNumbers()`
- Implementação: `value?.Replace("[^\\d]", "")` via `Regex.Replace(value, "[^\\d]", "")`
- Remove: pontos, traços, barras, espaços, letras, quaisquer caracteres não numéricos

### 2.5 Namespace e localização

| Componente | Namespace | Arquivo |
|------------|-----------|---------|
| `CpfValidation.PlaceMask` | `Sirb.Validation.Documents.BR.Validation` | `Documents/BR/Validation/CpfValidation.cs` |
| `CpfExtension.PlaceCpfMask` | `Sirb.Validation.Exceptions` | `Extensions/CpfExtension.cs` |
| `StringExtension.OnlyNumbers` / `RemoveMask` | `Sirb.Validation.Extensions` | `Extensions/StringExtension.cs` |

**Observação:** `CpfExtension` está atualmente em `Sirb.Validation.Exceptions` (provável typo histórico; deveria ser `Sirb.Validation.Extensions` para consistência com demais extensions).

## 3. Regras funcionais e regras de negócio numeradas

### Regras funcionais (RF)

| ID | Descrição | Prioridade | Regra de negócio associada |
| -- | --------- | ---------- | -------------------------- |
| RF-001 | Aplicar máscara `000.000.000-00` via regex em string normalizada (apenas dígitos) | Alta | RN-001 |
| RF-002 | Normalizar entrada removendo todos caracteres não numéricos antes da máscara | Alta | RN-002 |
| RF-003 | Retornar `null` para entrada null, vazia ou apenas whitespace | Alta | RN-003 |
| RF-004 | Expor como extension method `PlaceCpfMask()` sobre `string` | Alta | RN-004 |

### Regras de negócio (RN)

| ID | Regra | Origem | Impacto |
| -- | ----- | ------ | ------- |
| RN-001 | Máscara CPF: padrão `000.000.000-00`, regex `(\d{3})(\d{3})(\d{3})(\d{2})` → `$1.$2.$3-$4` | Padrão oficial (IN RFB) | Formatação |
| RN-002 | Normalização: `RemoveMask()` = `OnlyNumbers()` = regex `[^\d]` remove não-dígitos | Boa prática / Código existente | Normalização |
| RN-003 | Entrada null/vazia/whitespace → `null` (não string vazia) | Comportamento atual | Tratamento de borda |
| RN-004 | API pública: extension method em `CpfExtension` (namespace `Sirb.Validation.Exceptions`) | Design da biblioteca | Descoberta IntelliSense |

## 4. Diagramas técnicos

### 4.1 Diagrama de fluxo — Aplicação de máscara CPF

```mermaid
flowchart TD
    A[Entrada: string value] --> B{string.IsNullOrEmpty(value?.Trim())?}
    B -->|Sim| C[return default (null)]
    B -->|Não| D[normalized = value.RemoveMask()]
    D --> E[Regex.Replace(normalized, '(\d{3})(\d{3})(\d{3})(\d{2})', '$1.$2.$3-$4')]
    E --> F[return formatted]
```

### 4.2 Diagrama de sequência

```mermaid
sequenceDiagram
    participant App as Aplicação
    participant Ext as CpfExtension
    participant Val as CpfValidation
    participant StrExt as StringExtension

    App->>Ext: "12345678909".PlaceCpfMask()
    Ext->>Val: CpfValidation.PlaceMask("12345678909")
    Val->>StrExt: value.RemoveMask() → OnlyNumbers()
    StrExt-->>Val: "12345678909"
    Val->>Val: Regex.Replace → "123.456.789-09"
    Val-->>Ext: "123.456.789-09"
    Ext-->>App: "123.456.789-09"
```

## 5. Exemplos técnicos

### 5.1 Exemplos de código C#

```csharp
using Sirb.Validation.Extensions;
using Sirb.Validation.Documents.BR.Validation;
using Sirb.Validation.Exceptions; // namespace atual do CpfExtension

// --- Extension method (API pública recomendada) ---
string mascarado1 = "12345678909".PlaceCpfMask();           // "123.456.789-09"
string mascarado2 = "123.456.789-09".PlaceCpfMask();        // "123.456.789-09" (idempotente)
string mascarado3 = "12a3.45b6.78c9-0d9".PlaceCpfMask();    // "123.456.789-09" (normaliza)
string nulo1 = "".PlaceCpfMask();                           // null
string nulo2 = ((string)null).PlaceCpfMask();               // null
string nulo3 = "   ".PlaceCpfMask();                        // null

// --- Método interno (camada de validação) ---
string mascarado4 = CpfValidation.PlaceMask("12345678909"); // "123.456.789-09"

// --- Normalização direta ---
string apenasDigitos = "123.456.789-09".RemoveMask();       // "12345678909"
string apenasDigitos2 = "abc123def".OnlyNumbers();          // "123"
```

### 5.2 Cenários de borda e exceções

| Cenário | Entrada | Resultado | Motivo |
| ------- | ------- | --------- | ------ |
| CPF 9 dígitos | `"123456789"` | `"123456789"` | Regex não casa (precisa 11 dígitos), retorna normalizado |
| CPF 12 dígitos | `"123456789012"` | `"123456789012"` | Regex não casa, retorna normalizado |
| Apenas letras | `"abcdefghijk"` | `""` (vazio) | OnlyNumbers remove tudo, regex não casa em string vazia |
| Caracteres especiais | `"!@#$%^&*()"` | `""` (vazio) | OnlyNumbers remove tudo |

## 6. Rastreabilidade

| Item | Referência |
| ---- | ---------- |
| Requisito de negócio | `req-0014-cpf-mascara.md` |
| Requisito de validação base | `req-0001-cpf-validacao.md` |
| Classe de validação | `Sirb.Validation/Documents/BR/Validation/CpfValidation.cs` (linhas 83-94) |
| Regras de cálculo (não usadas aqui) | `Sirb.Validation/Documents/BR/Rules/CpfRule.cs` |
| Extension method API pública | `Sirb.Validation/Extensions/CpfExtension.cs` (linhas 1-16) |
| Utilitário de normalização | `Sirb.Validation/Extensions/StringExtension.cs` (`OnlyNumbers`, `RemoveMask`) |
| Testes | `Sirb.Validation.Test/Extensions/CpfExtensionTest.cs` (método `PlaceMask`) |
| Mockup (geração) | `Sirb.Validation/Documents/BR/Mockups/Cpf.cs` (req-0007) |

## 7. Validações realizadas para esta documentação

- [x] `README.md` do projeto analisado
- [x] `req-0014` correspondente lido e referenciado
- [x] Código-fonte analisado: `CpfValidation.cs`, `CpfExtension.cs`, `StringExtension.cs`
- [x] Diagramas Mermaid validados (sintaxe)
- [x] Documentações correlatas revisadas (`constituicao.md`, `architecture-tech-stack.md`, `req-0001`)
- [x] Matriz global de risco do sistema atualizada (`system-risk-matrix.md`)
- [x] APF do requisito criado (`apf-req-0014.md`)
- [x] Clarification Log preenchido e sincronizado com o `req-0014` correspondente
- [x] Nenhum item Pendente no Clarification Log que impacte aceite/escopo
- [x] Frontmatter YAML validado: `type` preenchido, `domain.version` incrementado, `domain.author` é nome de usuário
- [x] Tabela `## Metadados` reflete os valores do frontmatter YAML

## 8. Histórico de alterações e Clarification Log

### 8.1 Histórico de alterações

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação do documento |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.1.0 | Atualização de referência ao requisito base renomeado (`req-0001-cpf-validacao.md`) |

### 8.2 Clarification Log

| Data | Pergunta | Resposta | Status | Origem | Impacto |
| ---- | -------- | -------- | ------ | ------ | ------- |
| 31/07/2026 | O PlaceMask deve validar o CPF antes de mascarar? | Não. Apenas formata. Validação é IsValid (req-0001). | Resolvido | Criação | Define escopo: máscara pura. |
| 31/07/2026 | Qual o comportamento para string com menos de 11 dígitos? | Regex não casa, retorna string normalizada sem máscara. | Resolvido | Criação | Cenário de borda não coberto por testes. |
| 31/07/2026 | PlaceCpfMask está em namespace Exceptions ou Extensions? | Atualmente em `Sirb.Validation.Exceptions`. Deveria ser `Extensions`. | Resolvido | Criação | Inconsistência de namespace identificada. |
| 31/07/2026 | O método deve lançar exceção para entrada inválida? | Não. Retorna null para vazio/nulo; outros casos aplicam regex. | Resolvido | Criação | Comportamento defensivo. |
| 31/07/2026 | Existe método RemoveMask específico para CPF? | Não. Usa `StringExtension.OnlyNumbers()` (regex `[^\d]`). | Resolvido | Criação | Reuso de utilitário. |
| 31/07/2026 | A máscara deve preservar caracteres não numéricos? | Não. Remove todos não-dígitos antes de formatar. | Resolvido | Criação | Normalização. |
| 31/07/2026 | Qual a diferença entre PlaceMask e PlaceCpfMask? | PlaceMask interno em CpfValidation; PlaceCpfMask extension público. | Resolvido | Criação | Arquitetura de camadas. |
| 31/07/2026 | O código atual trata whitespace-only como vazio? | Sim. `value?.Trim()` + `string.IsNullOrEmpty`. | Resolvido | Criação | Comportamento para whitespace. |

### Cobertura do Clarification (8 áreas)

| # | Área | Status | Ref. entrada no Log | Justificativa (se N/A) |
| - | ---- | ------ | ------------------- | ---------------------- |
| 1 | Atores e personas | Resolvido | Desenvolvedor .NET consumidor | — |
| 2 | Fluxos principais e alternativos | Resolvido | Cenários Gherkin | — |
| 3 | Exceções e erros | Resolvido | Entrada inválida retorna null | — |
| 4 | Integrações externas | Resolvido | N/A — sem dependências | Stateless |
| 5 | Requisitos não-funcionais | Resolvido | p95 < 1ms, ReDoS, API fluente | — |
| 6 | Dados e privacidade | Resolvido | CPF sensível; não logar bruto | — |
| 7 | Validações e regras de negócio | Resolvido | RN-001 a RN-004 | — |
| 8 | Critérios de aceite e mensurabilidade | Resolvido | Gherkin + NFRs métricas | — |

**Cobertura atual:** 8/8. **Meta:** 8/8 (OK).