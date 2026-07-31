---
type: apf
title: "APF — req-0021 — CNPJ Alfanumérico Máscara"
description: "Análise de Pontos de Função do requisito req-0021: 3 PF em 1 função de transação."
resource: "./requirement/apf/apf-req-0021.md"
tags: [apf, pontos-de-funcao, cnpj-alfanumerico]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-31"
status: rascunho
domain:
  artifact_id: "apf-req-0021"
  title_pt: "APF — req-0021"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "31/07/2026"
  updated: "31/07/2026"
  language: pt-BR
---

# APF — req-0021 (CNPJ Alfanumérico Máscara)

## Contagem

| Tipo | Função | Comp. | PF |
| ---- | ------ | ----- | -- |
| EE | PlaceCnpjAlfanumericoMask / PlaceMask | Baixa | 3 |

**Total** | | | **3 PF**

**Justificativa:** EE (External Input) porque recebe entrada do usuário (string) e retorna saída processada (string formatada). Complexidade Baixa: uma única entrada, uma saída, lógica simples de regex. Mesmo padrão do req-0015 (CNPJ — Máscara = 3 PF).

## Histórico

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação da análise APF |