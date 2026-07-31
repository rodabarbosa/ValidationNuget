---
type: apf
title: "APF — req-0004 — Título de Eleitor — Validação"
description: "Análise de Pontos de Função do requisito req-0004: 3 PF em 1 função de transação."
resource: "./requirement/apf/apf-req-0004.md"
tags: [apf, pontos-de-funcao]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "apf-req-0004"
  title_pt: "APF — req-0004"
  version: "1.1.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "31/07/2026"
  language: pt-BR
---

# APF — req-0004 (Título de Eleitor — Validação)

## Contagem

| Tipo | Função | Comp. | PF |
| ---- | ------ | ----- | -- |
| EE | IsTituloEleitorValid(string) → bool | Baixa | 3 |
| **Total** | | | **3 PF** |

## Justificativa

- 1 função de entrada: validação.
- A função de máscara (PlaceTituloEleitorMask) foi removida deste requisito e é contabilizada em `apf-req-0017` (máscara).

## Histórico

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 27/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.1.0 | Remoção da função de máscara (PlaceTituloEleitorMask) — transferida para req-0017; total 6→3 PF |
