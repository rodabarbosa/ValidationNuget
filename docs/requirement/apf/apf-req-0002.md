---
type: apf
title: "APF — req-0002 — CNPJ — Validação"
description: "Análise de Pontos de Função do requisito req-0002: 3 PF em 1 função de transação."
resource: "./requirement/apf/apf-req-0002.md"
tags: [apf, pontos-de-funcao]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "apf-req-0002"
  title_pt: "APF — req-0002"
  version: "1.1.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "31/07/2026"
  language: pt-BR
---

# APF — req-0002 (CNPJ — Validação)

## Contagem

### Funções

| Tipo | Função | Comp. | DERs | ARs | PF |
| ---- | ------ | ----- | ---- | --- | -- |
| EE | IsCnpjValid(string) → bool | Baixa | 2 | 0 | 3 |

### Resumo

| Tipo | Qtd | PF Unit | Subtotal |
| ---- | --- | ------- | -------- |
| EE | 1 | 3 | 3 |
| **Total** | **1** | | **3 PF** |

### Justificativa

- 1 função de entrada: validação.
- A função de máscara (PlaceCnpjMask/PlaceMask) foi removida deste requisito e é contabilizada em `apf-req-0015` (máscara).
- Sem RemoveMask próprio (normalização via StringExtension → contado em req-0013).
- Sem estado, sem UI, sem banco.

## Histórico

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 27/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.1.0 | Remoção da função de máscara (PlaceCnpjMask) — transferida para req-0015; total 6→3 PF |
