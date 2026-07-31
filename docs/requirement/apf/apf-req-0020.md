---
type: apf
title: "APF — req-0020 — Mockup CNPJ Alfanumérico"
description: "Análise de Pontos de Função do requisito req-0020: 4 PF em 1 função de transação."
resource: "./requirement/apf/apf-req-0020.md"
tags: [apf, pontos-de-funcao, cnpj-alfanumerico]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-31"
status: rascunho
domain:
  artifact_id: "apf-req-0020"
  title_pt: "APF — req-0020"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "31/07/2026"
  updated: "31/07/2026"
  language: pt-BR
---

# APF — req-0020 (Mockup CNPJ Alfanumérico)

## Contagem

| Tipo | Função | Comp. | PF |
| ---- | ------ | ----- | -- |
| EO | CnpjAlfanumerico.Generate() → string | Baixa | 4 |
| **Total** | | | **4 PF** |

**Justificativa:** EO (External Output) porque gera uma saída processada (CNPJ Alfanumérico válido) sem entrada do usuário (parâmetros opcionais não configuram EE). O `GenerateWithMask()` é variação de saída do mesmo EO, não conta PF adicional.

## Histórico

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação da análise APF |