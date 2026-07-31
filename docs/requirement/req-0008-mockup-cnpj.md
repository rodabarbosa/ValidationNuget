---
type: req
title: "req-0008 — Mockup CNPJ — Geração para Testes"
description: "Geração de CNPJs válidos para testes, garantindo massa de dados confiável para aplicações .NET que processem documentos fiscais brasileiros."
resource: "./requirement/req-0008-mockup-cnpj.md"
tags: [documento-brasileiro, geracao, teste]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "req-0008"
  title_pt: "Mockup CNPJ — Geração para Testes"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "27/07/2026"
  language: pt-BR
---

# req-0008 — Mockup CNPJ — Geração para Testes

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** `req-0008`
- **Título:** Mockup CNPJ — Geração para Testes
- **Data de criação:** 27/07/2026
- **Última atualização:** 27/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão:** 1.0.0
- **Status:** Aprovado

## Intenção

- **Problema:** Gerar CNPJs válidos para testes sem depender de massa externa.
- **Impacto:** Agilidade na escrita de testes, cenários mais realistas.
- **Público:** Desenvolvedores (uso interno para testes).
- **Critério de sucesso:** CNPJ gerado passa em `IsCnpjValid()`.

## Requisitos funcionais

| ID | Descrição |
| -- | --------- |
| RF-001 | Gerar CNPJ válido aleatório com 14 dígitos |

## Regras de negócio

| ID | Regra |
| -- | ----- |
| RN-001 | Os 12 primeiros dígitos são aleatórios; os 2 DV são calculados com o mesmo algoritmo de CnpjRule. |

## Critérios de aceitação

```gherkin
Cenário: Gerar CNPJ aleatório
  Dado Cnpj.Generate() chamado
  Então string de 14 dígitos retornada
  E CnpjValidation.IsValid(resultado) == True
```

## NFRs

| Categoria | Métrica |
| --------- | ------- |
| Geração | < 1 ms |
| Validade | 100% |

## Risco local: RSK-016 (Algoritmo divergente) — P2 I3 Score 6 — Médio

## Rastreabilidade

- `Documents/BR/Mockups/Cnpj.cs`

## Histórico

| Data | Autor | Versão |
| ---- | ----- | ------ |
| 27/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 |
