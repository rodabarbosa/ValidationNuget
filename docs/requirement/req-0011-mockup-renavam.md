---
type: req
title: "req-0011 — Mockup Renavam — Geração para Testes"
description: "Geração de Renavams válidos para testes, garantindo massa de dados confiável para aplicações .NET que processem documentos veiculares brasileiros."
resource: "./requirement/req-0011-mockup-renavam.md"
tags: [documento-brasileiro, geracao, teste]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "req-0011"
  title_pt: "Mockup Renavam — Geração para Testes"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "27/07/2026"
  language: pt-BR
---

# req-0011 — Mockup Renavam — Geração para Testes

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** `req-0011`
- **Título:** Mockup Renavam — Geração para Testes
- **Data de criação:** 27/07/2026
- **Última atualização:** 27/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão:** 1.0.0
- **Status:** Aprovado

## RF

| ID | Descrição |
| -- | --------- |
| RF-001 | Gerar Renavam aleatório de 11 dígitos que passa em RenavamValidation.IsValid |

## RN

| ID | Regra |
| -- | ----- |
| RN-001 | 10 primeiros dígitos aleatórios (0-8); 11º calculado via RenavanRules. |

## Critérios

```gherkin
Cenário: Gerar Renavam válido
  Dado Renavam.Generate()
  Então string de 11 dígitos
  E RenavamValidation.IsValid(resultado) == True
```

## Rastreabilidade: `Documents/BR/Mockups/Renavam.cs`

## Histórico: 27/07/2026, v1.0.0
