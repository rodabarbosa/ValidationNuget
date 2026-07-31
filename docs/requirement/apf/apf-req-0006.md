---
type: apf
title: "APF — req-0006 — Inscrição Estadual — Validação"
description: "Análise de Pontos de Função do requisito req-0006: 4 PF em 1 função de transação de complexidade média."
resource: "./requirement/apf/apf-req-0006.md"
tags: [apf, pontos-de-funcao]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "apf-req-0006"
  title_pt: "APF — req-0006"
  version: "1.1.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "31/07/2026"
  language: pt-BR
---

# APF — req-0006 (Inscrição Estadual — Validação)

## Contagem

| Tipo | Função | Comp. | DERs | PF |
| ---- | ------ | ----- | ---- | -- |
| EE | IsValid(State, string) → bool | Média | 3 | 4 |

**Justificativa de complexidade Média:** a função recebe 2 parâmetros (State + string) e roteia para 27 implementações diferentes. 3 DERs (State, string entrada, retorno).

## Resumo

| Tipo | Qtd | PF Unit | Subtotal |
| ---- | --- | ------- | -------- |
| EE | 1 | 4 | 4 |
| **Total** | **1** | | **4 PF** |

## Justificativa

- 1 função de entrada: validação com roteamento por estado.
- As funções de máscara (PlaceMask por estado) foram removidas deste requisito e são contabilizadas em `apf-req-0018` (máscara).
- RemoveMask (OnlyNumbers) é normalização interna → contado em req-0013.

## Histórico

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 27/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.1.0 | Remoção das funções de máscara (PlaceMask por estado) e RemoveMask — transferidas para req-0018/contadas em req-0013; total 11→4 PF |
