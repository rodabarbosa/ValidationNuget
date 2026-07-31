---
type: apf
title: "APF — req-0019 — CNPJ Alfanumérico — Validação"
description: "Análise de Pontos de Função do requisito req-0019: 3 PF em 1 função de transação."
resource: "./requirement/apf/apf-req-0019.md"
tags: [apf, pontos-de-funcao, cnpj-alfanumerico]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-31"
status: rascunho
domain:
  artifact_id: "apf-req-0019"
  title_pt: "APF — req-0019"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "31/07/2026"
  updated: "31/07/2026"
  language: pt-BR
---

# APF — req-0019 (CNPJ Alfanumérico — Validação)

## Contagem

### Funções

| Tipo | Função | Comp. | DERs | ARs | PF |
| ---- | ------ | ----- | ---- | --- | -- |
| EE | IsCnpjAlfanumericoValid(string) → bool | Baixa | 2 | 0 | 3 |

### Resumo

| Tipo | Qtd | PF Unit | Subtotal |
| ---- | --- | ------- | -------- |
| EE | 1 | 3 | 3 |
| **Total** | **1** | | **3 PF** |

### Justificativa

- 1 função de entrada: validação do CNPJ Alfanumérico (inclui retrocompatibilidade com numérico).
- A função de máscara (PlaceCnpjAlfanumericoMask/PlaceMask) será contabilizada em requisito separado de formatação.
- Sem RemoveMask próprio (normalização via StringExtension → contado em req-0013).
- Sem estado, sem UI, sem banco.
- Mesma complexidade "Baixa" do req-0002 (CNPJ numérico) — algoritmo conceitualmente similar, apenas conversão ASCII-48 adicional.

## Histórico

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação — 3 PF (1 EE Baixa) |