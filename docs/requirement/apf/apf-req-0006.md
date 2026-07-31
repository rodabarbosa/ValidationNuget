---
type: apf
title: "APF — req-0006 — Inscrição Estadual — Validação e Máscara"
description: "Análise de Pontos de Função do requisito req-0006: 11 PF em 3 funções de transação com complexidade média."
resource: "./requirement/apf/apf-req-0006.md"
tags: [apf, pontos-de-funcao]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "apf-req-0006"
  title_pt: "APF — req-0006"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "27/07/2026"
  language: pt-BR
---

# APF — req-0006 (Inscrição Estadual)

## Contagem

| Tipo | Função | Comp. | DERs | PF |
| ---- | ------ | ----- | ---- | -- |
| EE | IsValid(State, string) → bool | Média | 3 | 4 |
| EE | PlaceMask(State, string) → string | Média | 3 | 4 |
| CE | RemoveMask(string) → string | Baixa | 2 | 3 |

**Justificativa de complexidade Média:** a função recebe 2 parâmetros (State + string) e roteia para 27 implementações diferentes. 3 DERs (State, string entrada, retorno).

## Resumo

| Tipo | Qtd | PF Unit | Subtotal |
| ---- | --- | ------- | -------- |
| EE | 2 | 4 | 8 |
| CE | 1 | 3 | 3 |
| **Total** | **3** | | **11 PF** |

## Histórico

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 27/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação |
