---
type: tec-req
title: "tec-req-0002 — CNPJ — Validação e Máscara (Especificação Técnica)"
description: "Especificação técnica da validação sintática do CNPJ, algoritmo módulo 11 com pesos específicos e máscara 00.000.000/0000-00."
resource: "./requirement/tec/tec-req-0002-cnpj-validacao-mascara.md"
tags: [documento-brasileiro, especificacao-tecnica]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "tec-req-0002"
  title_pt: "CNPJ — Validação e Máscara — Especificação Técnica"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "27/07/2026"
  language: pt-BR
---

# tec-req-0002 — CNPJ — Validação e Máscara (Especificação Técnica)

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** `tec-req-0002`
- **Título:** CNPJ — Validação e Máscara — Especificação Técnica
- **Data de criação:** 27/07/2026
- **Última atualização:** 27/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão:** 1.0.0
- **Status:** Aprovado
- **Requisito de negócio relacionado:** `req-0002-cnpj-validacao-mascara.md` (v1.0.0)

## 1. Resumo do requisito de negócio

Validar sintaticamente CNPJ (14 dígitos, módulo 11 com pesos específicos) e aplicar/remover máscara `00.000.000/0000-00`.

## 2. Detalhamento técnico

### Camadas

```
Extensions → CnpjExtension.cs (IsCnpjValid, PlaceCnpjMask)
Validation → CnpjValidation.cs (IsValid, PlaceMask)
Rules → CnpjRule.cs (internal) — CalculateBeforeLastDigitWeight, CalculateLastDigitWeight, CalculateDigitValue
```

### Algoritmo de validação

**1º dígito verificador (13ª posição):** pesos 5,4,3,2,9,8,7,6,5,4,3,2 sobre 12 primeiros dígitos
**2º dígito verificador (14ª posição):** pesos 6,5,4,3,2,9,8,7,6,5,4,3,2 sobre 13 primeiros dígitos

`CalculateBeforeLastDigitWeight(index)`: se index < 4 retorna 5 - index, senão 13 - index
`CalculateLastDigitWeight(index)`: se index < 5 retorna 6 - index, senão 14 - index

### Validações de entrada

- String vazia/nula → `false`
- Tamanho ≠ 14 → `false`
- Sequências repetidas → `false`

### Máscara

`00.000.000/0000-00` via regex `(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})` → `$1.$2.$3/$4-$5`

## 3. RFs e RNs

| ID | Descrição | Prioridade | RN |
| -- | --------- | ---------- | -- |
| RF-001 | Validar CNPJ com módulo 11 e pesos específicos (12+13 dígitos) | Alta | RN-001, RN-002 |
| RF-002 | Rejeitar sequências repetidas | Alta | RN-003 |
| RF-003 | Aplicar máscara `00.000.000/0000-00` | Alta | RN-004 |
| RF-004 | Tratar entradas nulas/vazias → false/null | Alta | RN-003 |

## 4. Diagrama de fluxo

```mermaid
flowchart TD
    A[Entrada: string CNPJ] --> B[RemoveMask]
    B --> C{Tamanho == 14?}
    C -->|Não| D[return false]
    C -->|Sim| E{Sequência repetida?}
    E -->|Sim| D
    E -->|Não| F[Calcular 1º DV - pesos 5..2\n sobre 12 primeiros dígitos]
    F --> G{Cálculo módulo 11}
    G --> H{1º DV confere?}
    H -->|Não| D
    H -->|Sim| I[Calcular 2º DV - pesos 6..2\n sobre 13 primeiros dígitos]
    I --> J{Cálculo módulo 11}
    J -->|Não| D
    J -->|Sim| K[return true]
```

## 5. Exemplos

```csharp
// Validação
bool v1 = "12.345.678/0001-95".IsCnpjValid();      // true
bool v2 = "12345678000195".IsCnpjValid();            // true
bool i1 = "11111111111111".IsCnpjValid();            // false
bool i2 = "".IsCnpjValid();                           // false

// Máscara
string m = "12345678000195".PlaceCnpjMask();          // "12.345.678/0001-95"
```

## 6. Rastreabilidade

| Item | Referência |
| ---- | ---------- |
| Classe validação | `Documents/BR/Validation/CnpjValidation.cs` |
| Regras | `Documents/BR/Rules/CnpjRule.cs` |
| Extension | `Extensions/CnpjExtension.cs` |

## 7. Histórico

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 27/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação |

## 8. Clarification Log

| Data | Pergunta | Resposta | Status | Origem | Impacto |
| ---- | -------- | -------- | ------ | ------ | ------- |
| 27/07/2026 | Pesos do CNPJ estão em CnpjRule? | Sim, em CalculateBeforeLastDigitWeight e CalculateLastDigitWeight. | Resolvido | Criação | Confirma algoritmo. |

### Cobertura 8/8

| # | Área | Status | Justificativa |
| - | ---- | ------ | ------------- |
| 1 | Atores | Resolvido | Desenvolvedor .NET |
| 2 | Fluxos | Resolvido | Happy path + falha |
| 3 | Exceções | Resolvido | Entrada inválida retorna false |
| 4 | Integrações | N/A | Stateless |
| 5 | NFRs | Resolvido | p95 < 1ms |
| 6 | Dados | Resolvido | CNPJ sensível |
| 7 | Regras | Resolvido | RN-001 a RN-004 |
| 8 | Critérios | Resolvido | Gherkin + NFRs |
