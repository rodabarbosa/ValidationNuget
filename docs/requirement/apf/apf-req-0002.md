---
type: apf
title: "APF — req-0002 — CNPJ — Validação e Máscara"
description: "Análise de Pontos de Função do requisito req-0002: 6 PF em 2 funções de transação."
resource: "./requirement/apf/apf-req-0002.md"
tags: [apf, pontos-de-funcao]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "apf-req-0002"
  title_pt: "APF — req-0002"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "27/07/2026"
  language: pt-BR
---

# APF — req-0002 (CNPJ — Validação e Máscara)

## Contagem

### Funções

| Tipo | Função | Comp. | DERs | ARs | PF |
| ---- | ------ | ----- | ---- | --- | -- |
| EE | IsCnpjValid(string) → bool | Baixa | 2 | 0 | 3 |
| EE | PlaceCnpjMask(string) → string | Baixa | 2 | 0 | 3 |

### Resumo

| Tipo | Qtd | PF Unit | Subtotal |
| ---- | --- | ------- | -------- |
| EE | 2 | 3 | 6 |
| **Total** | **2** | | **6 PF** |

### Justificativa

- 2 funções de entrada: validação e máscara.
- Sem RemoveMask próprio (herdado de StringExtension → contado em req-0013).
- Sem estado, sem UI, sem banco.

## Histórico

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 27/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação |
