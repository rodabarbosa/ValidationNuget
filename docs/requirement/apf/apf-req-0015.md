---
type: apf
title: "apf-req-0015 — CNPJ — Máscara (Análise de Pontos de Função)"
description: "Análise de Pontos de Função para o requisito req-0015-cnpj-mascara"
resource: "./requirement/apf/apf-req-0015.md"
tags: [apf, mascara, cnpj]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-31"
verified:
  by: "Rodrigo Araujo Barbosa"
  timestamp: "2026-07-31T02:00:00Z"
  method: "validação com PO"
status: approved
domain:
  artifact_id: "apf-req-0015"
  title_pt: "CNPJ — Máscara — APF"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "31/07/2026"
  updated: "31/07/2026"
  bundle: "flat"
  language: pt-BR
  fpa_total_pf: 3
---

# apf-req-0015 — CNPJ — Máscara (Análise de Pontos de Função)

## Metadados

| Campo | Valor |
|---|---|
| **Requisito associado** | `req-0015-cnpj-mascara.md` v1.0.0 |
| **Total PF** | 3 PF |
| **Data da análise** | 31/07/2026 |
| **Analista** | Rodrigo Araujo Barbosa |

## Classificação das Funções

### Funções de Transação

| Tipo | Quantidade | Complexidade | PF por unidade | PF Total |
|------|------------|--------------|----------------|----------|
| EE (Entrada Externa) | 1 | Baixa | 3 | 3 |
| SE (Saída Externa) | 0 | - | - | 0 |
| CE (Consulta Externa) | 1 | Baixa | 3 | 3 |

### Funções de Dados

| Tipo | Quantidade | Complexidade | PF por unidade | PF Total |
|------|------------|--------------|----------------|----------|
| ALI (Arquivo Lógico Interno) | 0 | - | - | 0 |
| AIE (Arquivo de Interface Externa) | 0 | - | - | 0 |

## Detalhamento das Funções

### EE-01: Aplicar Máscara CNPJ
- **Descrição:** Processa entrada de string (CNPJ com/sem formatação), normaliza removendo não-dígitos, aplica regex de máscara `00.000.000/0000-00`, retorna string formatada ou null.
- **DERs:** value (string entrada), normalized (string 14 dígitos), formatted (string saída) = 3 DERs
- **RLRs:** 1 (processamento único de máscara)
- **Complexidade:** Baixa (3 DERs, 1 RLR → EE Baixa = 3 PF)

### CE-01: Consultar Formato de Máscara CNPJ
- **Descrição:** Operação idempotente — mesma entrada produz mesma saída.
- **DERs:** value (entrada), formatted (saída) = 2 DERs
- **RLRs:** 1 (referência ao processamento de máscara)
- **Complexidade:** Baixa (2 DERs, 1 RLR → CE Baixa = 3 PF)

## Cálculo do PF Não Ajustado (PFNA)

| Função | Tipo | Complexidade | PF |
|--------|------|--------------|----|
| EE-01 | Entrada Externa | Baixa | 3 |
| CE-01 | Consulta Externa | Baixa | 3 |
| **Total PFNA** | | | **6** |

> **Nota:** Mesma lógica do CPF — apenas EE-01 é contado independentemente. **PF total = 3 PF**.

## Fator de Ajuste (VAF)

Não aplicado (contagem indicativa). VAF = 1.00 padrão.

**PF Ajustado = 3 × 1.00 = 3 PF**

## Rastreabilidade

| Item | Referência |
|------|------------|
| Requisito de negócio | `req-0015-cnpj-mascara.md` |
| Especificação técnica | `tec-req-0015-cnpj-mascara.md` |
| Análise cross-artifact | `analise/analise-req-0015.md` |
| Quality checklist | `checklist/checklist-req-0015.md` |
| Matriz de risco global | `system-risk-matrix.md` (RSK-016, RSK-017) |
| Consolidado APF | `tamanho-aplicacao.md` |

## Histórico

| Data | Autor | Versão | Alteração |
|------|-------|--------|-----------|
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação da análise APF |