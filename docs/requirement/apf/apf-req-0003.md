---
type: apf
title: "APF — req-0003 — PIS — Validação"
description: "Análise de Pontos de Função do requisito req-0003: 3 PF em 1 função de transação."
resource: "./requirement/apf/apf-req-0003.md"
tags: [apf, pontos-de-funcao]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "apf-req-0003"
  title_pt: "APF — req-0003"
  version: "1.1.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "31/07/2026"
  language: pt-BR
---

# APF — req-0003 (PIS — Validação)

## Contagem

| Tipo | Função | Comp. | DERs | PF |
| ---- | ------ | ----- | ---- | -- |
| EE | IsPisValid(string) → bool | Baixa | 2 | 3 |
| **Total** | | | | **3 PF** |

## Justificativa

- 1 função de entrada: validação.
- A função de máscara (PlacePisMask) foi removida deste requisito e é contabilizada em `apf-req-0016` (máscara).
- RemoveMask (OnlyNumbers) é normalização interna → contado em req-0013.

## Histórico

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 27/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.1.0 | Remoção da função de máscara (PlacePisMask) — transferida para req-0016; total 6→3 PF |
