---
type: req
title: "req-0009 — Mockup PIS — Geração para Testes"
description: "Geração de PIS válidos para testes, garantindo massa de dados confiável para aplicações .NET que processem documentos trabalhistas brasileiros."
resource: "./requirement/req-0009-mockup-pis.md"
tags: [documento-brasileiro, geracao, teste]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "req-0009"
  title_pt: "Mockup PIS — Geração para Testes"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "27/07/2026"
  language: pt-BR
---

# req-0009 — Mockup PIS — Geração para Testes

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** `req-0009`
- **Título:** Mockup PIS — Geração para Testes
- **Data de criação:** 27/07/2026
- **Última atualização:** 27/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão:** 1.0.0
- **Status:** Aprovado

## Resumo

Gerar PIS válido para testes.

## RF

| ID | Descrição |
| -- | --------- |
| RF-001 | Gerar PIS aleatório de 11 dígitos que passa em PisValidation.IsValid |

## RN

| ID | Regra |
| -- | ----- |
| RN-001 | 10 primeiros dígitos aleatórios; 11º calculado via PisRule (módulo 11). |

## Critérios

```gherkin
Cenário: Gerar PIS válido
  Dado Pis.Generate()
  Então string de 11 dígitos válida
```

## Rastreabilidade: `Documents/BR/Mockups/Pis.cs`

## Histórico: 27/07/2026, v1.0.0
