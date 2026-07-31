---
type: req
title: "req-0010 — Mockup Título de Eleitor — Geração para Testes"
description: "Geração de Títulos de Eleitor válidos para testes, garantindo massa de dados confiável para aplicações .NET que processem documentos eleitorais brasileiros."
resource: "./requirement/req-0010-mockup-titulo-eleitor.md"
tags: [documento-brasileiro, geracao, teste]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "req-0010"
  title_pt: "Mockup Título de Eleitor — Geração para Testes"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "27/07/2026"
  language: pt-BR
---

# req-0010 — Mockup Título de Eleitor — Geração para Testes

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** `req-0010`
- **Título:** Mockup Título de Eleitor — Geração para Testes
- **Data de criação:** 27/07/2026
- **Última atualização:** 27/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão:** 1.0.0
- **Status:** Aprovado

## RF

| ID | Descrição |
| -- | --------- |
| RF-001 | Gerar Título de Eleitor aleatório de 12 dígitos que passa em TituloEleitorValidation.IsValid |

## RN

| ID | Regra |
| -- | ----- |
| RN-001 | 8 primeiros dígitos aleatórios; 2 dígitos de UF (01-28); 2 DV calculados. |
| RN-002 | O gerador garante que a UF esteja entre 01 e 28. |

## Critérios

```gherkin
Cenário: Gerar Título válido
  Dado TituloEleitor.Generate()
  Então string de 12 dígitos
  E TituloEleitorValidation.IsValid(resultado) == True
```

## Rastreabilidade: `Documents/BR/Mockups/TituloEleitor.cs`

## Histórico: 27/07/2026, v1.0.0
