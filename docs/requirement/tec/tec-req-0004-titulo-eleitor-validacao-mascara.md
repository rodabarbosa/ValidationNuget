---
type: tec-req
title: "tec-req-0004 — Título de Eleitor — Validação e Máscara (Especificação Técnica)"
description: "Especificação técnica da validação sintática do Título de Eleitor, 2 dígitos verificadores, validação de UF (01-28) e máscara 0000.0000.0000."
resource: "./requirement/tec/tec-req-0004-titulo-eleitor-validacao-mascara.md"
tags: [documento-brasileiro, especificacao-tecnica]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "tec-req-0004"
  title_pt: "Título de Eleitor — Validação e Máscara — Especificação Técnica"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "27/07/2026"
  language: pt-BR
---

# tec-req-0004 — Título de Eleitor — Validação e Máscara (Especificação Técnica)

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** `tec-req-0004`
- **Título:** Título de Eleitor — Validação e Máscara — Especificação Técnica
- **Data de criação:** 27/07/2026
- **Última atualização:** 27/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão:** 1.0.0
- **Status:** Aprovado
- **Requisito de negócio relacionado:** req-0004-titulo-eleitor-validacao-mascara.md

## 1. Resumo

Validar Título de Eleitor (12 dígitos, 2 DVs + UF 01-28) e aplicar máscara `0000.0000.0000`.

## 2. Detalhamento técnico

### Camadas
```
Extensions → TituloEleitorExtension.cs
  ├── IsTituloEleitorValid(this string) → bool
  └── PlaceTituloEleitorMask(this string) → string

Validation → TituloEleitorValidation.cs
  ├── IsValid(string) → bool
  └── PlaceMask(string) → string
```

### Algoritmo
1. RemoveMask (OnlyNumbers)
2. Tamanho == 12? senão false
3. **1º DV** (11ª posição, índice 10):
   - Soma dígitos[0..7] × (2,3,4,5,6,7,8,9)
   - resto % 11; se > 9, DV = 0
4. **2º DV** (12ª posição, índice 11):
   - Soma dígitos[8..10] × (7,8,9)
   - resto % 11; se > 9, DV = 0
5. **UF** (dígitos 9-10, índices 8-9): valor entre 1 e 28
6. Comparar DVs calculados com os dígitos reais

### Máscara
Regex: `(\d{4})(\d{4})(\d{4})` → `$1.$2.$3`

## 3. Diagrama

```mermaid
flowchart TD
    A[Entrada string Título] --> B[RemoveMask → 12 dígitos?]
    B -->|Não| C[return false]
    B -->|Sim| D[UF entre 01 e 28?]
    D -->|Não| C
    D -->|Sim| E[1º DV: pesos 2..9 × dígitos 0..7]
    E --> F[2º DV: pesos 7,8,9 × dígitos 8..10]
    F --> G{DVs conferem?}
    G -->|Sim| H[return true]
    G -->|Não| C
```

## 4. Exemplos

```csharp
bool v = "12345678901234".IsTituloEleitorValid();  // true/false depende do DV
bool i = "".IsTituloEleitorValid();                  // false
string m = "123456789012".PlaceTituloEleitorMask();  // "1234.5678.9012"
```

## 5. Rastreabilidade

| Item | Arquivo |
| ---- | ------- |
| Validation | `Documents/BR/Validation/TituloEleitorValidation.cs` |
| Extension | `Extensions/TituloEleitorExtension.cs` |

## 6. Histórico

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 27/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação |
