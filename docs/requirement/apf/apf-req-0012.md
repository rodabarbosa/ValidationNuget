---
type: apf
title: "APF — req-0012 — Mockup Inscrição Estadual"
description: "Análise de Pontos de Função do requisito req-0012: 5 PF em 1 função de transação com complexidade média."
resource: "./requirement/apf/apf-req-0012.md"
tags: [apf, pontos-de-funcao]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "apf-req-0012"
  title_pt: "APF — req-0012"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "27/07/2026"
  language: pt-BR
---

# APF — req-0012 (Mockup Inscrição Estadual)

| Tipo | Função | Comp. | DERs | PF |
| ---- | ------ | ----- | ---- | -- |
| EO | InscricaoEstadual.Generate(State) → string | Média | 3 | 5 |
| **Total** | | | | **5 PF** |

**Justificativa:** Complexidade Média por aceitar parâmetro State e rotear para 27 implementações.

## Histórico: 27/07/2026, v1.0.0
