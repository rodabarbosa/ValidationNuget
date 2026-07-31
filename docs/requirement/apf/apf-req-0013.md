---
type: apf
title: "APF — req-0013 — String Utils"
description: "Análise de Pontos de Função do requisito req-0013: 21 PF em 7 funções de transação."
resource: "./requirement/apf/apf-req-0013.md"
tags: [apf, pontos-de-funcao]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "apf-req-0013"
  title_pt: "APF — req-0013"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "27/07/2026"
  language: pt-BR
---

# APF — req-0013 (String Utils)

## Contagem

| Tipo | Função | Comp. | DERs | PF |
| ---- | ------ | ----- | ---- | -- |
| CE | OnlyNumbers(string) → string | Baixa | 2 | 3 |
| CE | RemoveMask(string) → string | Baixa | 2 | 3 |
| CE | NoNumbers(string) → string | Baixa | 2 | 3 |
| CE | ToCapitalizeAll(string) → string | Baixa | 2 | 3 |
| CE | ToCapitalize(string) → string | Baixa | 2 | 3 |
| CE | RemoveLatinCharacters(string) → string | Baixa | 2 | 3 |
| CE | Reverse(string) → string | Baixa | 2 | 3 |

## Resumo

| Tipo | Qtd | PF Unit | Subtotal |
| ---- | --- | ------- | -------- |
| CE | 7 | 3 | 21 |
| **Total** | **7** | | **21 PF** |

**Justificativa:** 7 funções de consulta independentes (External Inquiry). Cada uma recebe string e retorna string transformada.

## Histórico: 27/07/2026, v1.0.0
