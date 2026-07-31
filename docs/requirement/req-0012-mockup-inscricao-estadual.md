---
type: req
title: "req-0012 — Mockup Inscrição Estadual — Geração para Testes (27 UFs + DF)"
description: "Geração de Inscrições Estaduais válidas para todas as UFs para testes, garantindo massa de dados confiável para aplicações .NET que processem documentos fiscais."
resource: "./requirement/req-0012-mockup-inscricao-estadual.md"
tags: [documento-brasileiro, geracao, teste, inscricao-estadual]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "req-0012"
  title_pt: "Mockup Inscrição Estadual — Geração para Testes"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "27/07/2026"
  language: pt-BR
---

# req-0012 — Mockup Inscrição Estadual — Geração para Testes (27 UFs + DF)

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** `req-0012`
- **Título:** Mockup Inscrição Estadual — Geração para Testes
- **Data de criação:** 27/07/2026
- **Última atualização:** 27/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão:** 1.0.0
- **Status:** Aprovado

## Intenção

Gerar IEs válidas para todas as UFs para testes de integração fiscal e NF-e.

## RF

| ID | Descrição | Prioridade |
| -- | --------- | ---------- |
| RF-001 | Gerar IE válida para qualquer UF especificada via enum State | Média |
| RF-002 | IE gerada deve passar em InscricaoEstadualValidation.IsValid para a UF correspondente | Média |

## RN

| ID | Regra |
| -- | ----- |
| RN-001 | Cada UF tem seu próprio gerador implementando `IInscricaoEstadualInternal`. |
| RN-002 | O roteamento é feito por dicionário `_generator[state].Generate()`. |
| RN-003 | **Nota:** O gerador do Acre (AC) está com erro conhecido e em avaliação (conforme comentário no código). |

## Critérios

```gherkin
Cenário: Gerar IE de SP
  Dado InscricaoEstadual.Generate(State.SP)
  Então string válida que passa em IsValid(State.SP, value)
```

## NFRs

| Categoria | Métrica |
| --------- | ------- |
| Geração | < 1 ms |
| Cobertura | 27 UFs + DF |

## Risco: RSK-017 — Gerador do AC com erro conhecido (P2 I4 Score 8 — Alto)

## Rastreabilidade

- `Documents/BR/Mockups/InscricaoEstadual.cs`
- `Documents/BR/Mockups/Ie/` (27 classes geradoras)

## Histórico: 27/07/2026, v1.0.0
