---
type: tec-req
title: "tec-req-0015 — CNPJ — Máscara (Especificação Técnica)"
description: "Especificação técnica da aplicação de máscara CNPJ no formato 00.000.000/0000-00, normalização de entrada via RemoveMask/OnlyNumbers, extension method PlaceCnpjMask."
resource: "./requirement/tec/tec-req-0015-cnpj-mascara.md"
tags: [documento-brasileiro, especificacao-tecnica, mascara, cnpj]
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
  artifact_id: "tec-req-0015"
  title_pt: "CNPJ — Máscara — Especificação Técnica"
  version: "1.1.0"
  author: "Rodrigo Araujo Barbosa"
  created: "31/07/2026"
  updated: "31/07/2026"
  bundle: "flat"
  language: pt-BR
  req_origem: "req-0015-cnpj-mascara.md"
  coverage_clarification: "8/8"
---

# tec-req-0015 — CNPJ — Máscara (Especificação Técnica)

## Metadados

> Esta tabela é uma **reflexão** do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

| Campo | Valor |
|---|---|
| **Código do documento** | `tec-req-0015` |
| **Título** | CNPJ — Máscara — Especificação Técnica |
| **Versão** | 1.1.0 |
| **Autor** | Rodrigo Araujo Barbosa |
| **Data de criação** | 31/07/2026 |
| **Última atualização** | 31/07/2026 |
| **Status** | Aprovado |
| **Bundle** | `flat` |
| **Requisito de negócio** | `req-0015-cnpj-mascara.md` |
| **Cobertura Clarification** | 8/8 |
| **Tipo OKF** | `tec-req` |

## 1. Resumo do requisito de negócio

- **Requisito de origem:** `req-0015-cnpj-mascara.md` (versão 1.0.0)
- **Síntese do "o quê":** Aplicar máscara `00.000.000/0000-00` a strings contendo CNPJ, com normalização prévia (remoção de não-dígitos) e tratamento de bordas (null/vazio → null).
- **Síntese do "por quê":** Padronizar formatação de CNPJ em aplicações .NET, evitando formatação manual inconsistente e garantindo conformidade com layout oficial brasileiro.

## 2. Detalhamento técnico completo

### 2.1 Arquitetura de camadas

```
Extensions (API Pública)
  └── CnpjExtension.cs                   (PlaceCnpjMask via extension method)
Validation (Orquestração)
  └── CnpjValidation.cs                  (PlaceMask, RemoveMask delega para StringExtension)
Extensions (Utilitários)
  └── StringExtension.cs                 (OnlyNumbers — regex [^\d])
```

### 2.2 Algoritmo de máscara

**Formato:** `00.000.000/0000-00`

**Regex:** `(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})` → substituição `$1.$2.$3/$4-$5`

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
| `"12345678000195"` (14 dígitos) | Retorna `"12.345.678/0001-95"` |
| `"12.345.678/0001-95"` (já formatado) | Retorna `"12.345.678/0001-95"` (idempotente) |
| `"12a.34b5.67c8/00d0-1e95"` (com letras) | Retorna `"12.345.678/0001-95"` (normaliza) |
| `"1234567800019"` (13 dígitos) | Retorna `"1234567800019"` (regex não casa, normalizado) |

**Nota importante:** O método **não valida** o CNPJ (dígitos verificadores). Apenas formata. Validação é responsabilidade de `IsValid` (`req-0002`).

### 2.4 Normalização (RemoveMask)

- Delegado para `StringExtension.OnlyNumbers()`
- Implementação: `Regex.Replace(value, "[^\\d]", "")`
- Remove: pontos, traços, barras, espaços, letras, quaisquer caracteres não numéricos

### 2.5 Namespace e localização

| Componente | Namespace | Arquivo |
|------------|-----------|---------|
| `CnpjValidation.PlaceMask` | `Sirb.Validation.Documents.BR.Validation` | `Documents/BR/Validation/CnpjValidation.cs` |
| `CnpjExtension.PlaceCnpjMask` | `Sirb.Validation.Exceptions` | `Extensions/CnpjExtension.cs` |
| `StringExtension.OnlyNumbers` / `RemoveMask` | `Sirb.Validation.Extensions` | `Extensions/StringExtension.cs` |

**Observação:** `CnpjExtension` está atualmente em `Sirb.Validation.Exceptions` (provável typo histórico; deveria ser `Sirb.Validation.Extensions` para consistência).

## 3. Regras funcionais e regras de negócio numeradas

### Regras funcionais (RF)

| ID | Descrição | Prioridade | Regra de negócio associada |
| -- | --------- | ---------- | -------------------------- |
| RF-001 | Aplicar máscara `00.000.000/0000-00` via regex em string normalizada (apenas dígitos) | Alta | RN-001 |
| RF-002 | Normalizar entrada removendo todos caracteres não numéricos antes da máscara | Alta | RN-002 |
| RF-003 | Retornar `null` para entrada null, vazia ou apenas whitespace | Alta | RN-003 |
| RF-004 | Expor como extension method `PlaceCnpjMask()` sobre `string` | Alta | RN-004 |

### Regras de negócio (RN)

| ID | Regra | Origem | Impacto |
| -- | ----- | ------ | ------- |
| RN-001 | Máscara CNPJ: padrão `00.000.000/0000-00`, regex `(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})` → `$1.$2.$3/$4-$5` | Padrão oficial (IN RFB) | Formatação |
| RN-002 | Normalização: `RemoveMask()` = `OnlyNumbers()` = regex `[^\d]` remove não-dígitos | Boa prática / Código existente | Normalização |
| RN-003 | Entrada null/vazia/whitespace → `null` (não string vazia) | Comportamento atual | Tratamento de borda |
| RN-004 | API pública: extension method em `CnpjExtension` (namespace `Sirb.Validation.Exceptions`) | Design da biblioteca | Descoberta IntelliSense |

## 4. Diagramas técnicos

### 4.1 Diagrama de fluxo — Aplicação de máscara CNPJ

```mermaid
flowchart TD
    A[Entrada: string value] --> B{string.IsNullOrEmpty(value?.Trim())?}
    B -->|Sim| C[return default (null)]
    B -->|Não| D[normalized = value.RemoveMask()]
    D --> E[Regex.Replace(normalized, '(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})', '$1.$2.$3/$4-$5')]
    E --> F[return formatted]
```

### 4.2 Diagrama de sequência

```mermaid
sequenceDiagram
    participant App as Aplicação
    participant Ext as CnpjExtension
    participant Val as CnpjValidation
    participant StrExt as StringExtension

    App->>Ext: "12345678000195".PlaceCnpjMask()
    Ext->>Val: CnpjValidation.PlaceMask("12345678000195")
    Val->>StrExt: value.RemoveMask() → OnlyNumbers()
    StrExt-->>Val: "12345678000195"
    Val->>Val: Regex.Replace → "12.345.678/0001-95"
    Val-->>Ext: "12.345.678/0001-95"
    Ext-->>App: "12.345.678/0001-95"
```

## 5. Exemplos técnicos

### 5.1 Exemplos de código C#

```csharp
using Sirb.Validation.Extensions;
using Sirb.Validation.Documents.BR.Validation;
using Sirb.Validation.Exceptions; // namespace atual do CnpjExtension

// --- Extension method (API pública recomendada) ---
string mascarado1 = "12345678000195".PlaceCnpjMask();         // "12.345.678/0001-95"
string mascarado2 = "12.345.678/0001-95".PlaceCnpjMask();     // "12.345.678/0001-95" (idempotente)
string mascarado3 = "12a.34b5.67c8/00d0-1e95".PlaceCnpjMask();// "12.345.678/0001-95" (normaliza)
string nulo1 = "".PlaceCnpjMask();                            // null
string nulo2 = ((string)null).PlaceCnpjMask();                // null
string nulo3 = "   ".PlaceCnpjMask();                         // null

// --- Método interno (camada de validação) ---
string mascarado4 = CnpjValidation.PlaceMask("12345678000195"); // "12.345.678/0001-95"

// --- Normalização direta ---
string apenasDigitos = "12.345.678/0001-95".RemoveMask();      // "12345678000195"
string apenasDigitos2 = "abc123def".OnlyNumbers();             // "123"
```

### 5.2 Cenários de borda e exceções

| Cenário | Entrada | Resultado | Motivo |
| ------- | ------- | --------- | ------ |
| CNPJ 13 dígitos | `"1234567800019"` | `"1234567800019"` | Regex não casa (precisa 14), retorna normalizado |
| CNPJ 15 dígitos | `"123456780001950"` | `"123456780001950"` | Regex não casa, retorna normalizado |
| Apenas letras | `"abcdefghijklmn"` | `""` (vazio) | OnlyNumbers remove tudo, regex não casa em string vazia |
| Caracteres especiais | `"!@#$%^&*()_+"` | `""` (vazio) | OnlyNumbers remove tudo |

## 6. Rastreabilidade

| Item | Referência |
| ---- | ---------- |
| Requisito de negócio | `req-0015-cnpj-mascara.md` |
| Requisito de validação base | `req-0002-cnpj-validacao.md` |
| Classe de validação | `Sirb.Validation/Documents/BR/Validation/CnpjValidation.cs` (linhas 66-78) |
| Regras de cálculo (não usadas aqui) | `Sirb.Validation/Documents/BR/Rules/CnpjRule.cs` |
| Extension method API pública | `Sirb.Validation/Extensions/CnpjExtension.cs` (linhas 1-16) |
| Utilitário de normalização | `Sirb.Validation/Extensions/StringExtension.cs` (`OnlyNumbers`, `RemoveMask`) |
| Testes | `Sirb.Validation.Test/Extensions/CnpjExtensionTest.cs` (método `PlaceMask`) |
| Mockup (geração) | `Sirb.Validation/Documents/BR/Mockups/Cnpj.cs` (req-0008) |

## 7. Validações realizadas para esta documentação

- [x] `README.md` do projeto analisado
- [x] `req-0015` correspondente lido e referenciado
- [x] Código-fonte analisado: `CnpjValidation.cs`, `CnpjExtension.cs`, `StringExtension.cs`
- [x] Diagramas Mermaid validados (sintaxe)
- [x] Documentações correlatas revisadas (`constituicao.md`, `architecture-tech-stack.md`, `req-0002`)
- [x] Matriz global de risco do sistema atualizada (`system-risk-matrix.md`)
- [x] APF do requisito criado (`apf-req-0015.md`)
- [x] Clarification Log preenchido e sincronizado com o `req-0015` correspondente
- [x] Nenhum item Pendente no Clarification Log que impacte aceite/escopo
- [x] Frontmatter YAML validado: `type` preenchido, `domain.version` incrementado, `domain.author` é nome de usuário
- [x] Tabela `## Metadados` reflete os valores do frontmatter YAML

## 8. Histórico de alterações e Clarification Log

### 8.1 Histórico de alterações

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação do documento |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.1.0 | Atualização de referência ao requisito base renomeado (`req-0002-cnpj-validacao.md`) |

### 8.2 Clarification Log

| Data | Pergunta | Resposta | Status | Origem | Impacto |
| ---- | -------- | -------- | ------ | ------ | ------- |
| 31/07/2026 | O PlaceMask deve validar o CNPJ antes de mascarar? | Não. Apenas formata. Validação é IsValid (req-0002). | Resolvido | Criação | Define escopo: máscara pura. |
| 31/07/2026 | Qual o comportamento para string com menos de 14 dígitos? | Regex não casa, retorna string normalizada sem máscara. | Resolvido | Criação | Cenário de borda. |
| 31/07/2026 | PlaceCnpjMask está em namespace Exceptions ou Extensions? | Atualmente em `Sirb.Validation.Exceptions`. Deveria ser `Extensions`. | Resolvido | Criação | Inconsistência de namespace. |
| 31/07/2026 | O método deve lançar exceção para entrada inválida? | Não. Retorna null para vazio/nulo; outros casos aplicam regex. | Resolvido | Criação | Comportamento defensivo. |
| 31/07/2026 | Existe método RemoveMask específico para CNPJ? | Não. Usa `StringExtension.OnlyNumbers()` (regex `[^\d]`). | Resolvido | Criação | Reuso de utilitário. |
| 31/07/2026 | A máscara deve preservar caracteres não numéricos? | Não. Remove todos não-dígitos antes de formatar. | Resolvido | Criação | Normalização. |
| 31/07/2026 | Qual a diferença entre PlaceMask e PlaceCnpjMask? | PlaceMask interno em CnpjValidation; PlaceCnpjMask extension público. | Resolvido | Criação | Arquitetura de camadas. |
| 31/07/2026 | O código atual trata whitespace-only como vazio? | Sim. `value?.Trim()` + `string.IsNullOrEmpty`. | Resolvido | Criação | Comportamento para whitespace. |

### Cobertura do Clarification (8 áreas)

| # | Área | Status | Ref. entrada no Log | Justificativa (se N/A) |
| - | ---- | ------ | ------------------- | ---------------------- |
| 1 | Atores e personas | Resolvido | Desenvolvedor .NET consumidor | — |
| 2 | Fluxos principais e alternativos | Resolvido | Cenários Gherkin | — |
| 3 | Exceções e erros | Resolvido | Entrada inválida retorna null | — |
| 4 | Integrações externas | Resolvido | N/A — sem dependências | Stateless |
| 5 | Requisitos não-funcionais | Resolvido | p95 < 1ms, ReDoS, API fluente | — |
| 6 | Dados e privacidade | Resolvido | CNPJ sensível; não logar bruto | — |
| 7 | Validações e regras de negócio | Resolvido | RN-001 a RN-004 | — |
| 8 | Critérios de aceite e mensurabilidade | Resolvido | Gherkin + NFRs métricas | — |

**Cobertura atual:** 8/8. **Meta:** 8/8 (OK).