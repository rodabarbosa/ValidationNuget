---
type: apf
title: "apf-req-0016 — PIS — Máscara (Análise de Pontos de Função)"
description: "Análise de Pontos de Função para o requisito req-0016-pis-mascara"
resource: "./requirement/apf/apf-req-0016.md"
tags: [apf, mascara, pis]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-31"
verified:
  by: "Rodrigo Araujo Barbosa"
  timestamp: "2026-07-31T02:00:00Z"
  method: "validação com PO"
status: approved
domain:
  artifact_id: "apf-req-0016"
  title_pt: "PIS — Máscara — APF"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "31/07/2026"
  updated: "31/07/2026"
  bundle: "flat"
  language: pt-BR
  fpa_total_pf: 3
---

# apf-req-0016 — PIS — Máscara (Análise de Pontos de Função)

## Metadados

| Campo | Valor |
|---|---|
| **Requisito associado** | `req-0016-pis-mascara.md` v1.0.0 |
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

### EE-01: Aplicar Máscara PIS
- **Descrição:** Processa entrada de string (PIS com/sem formatação), normaliza removendo não-dígitos via `PisValidation.RemoveMask()` → `OnlyNumbers()`, aplica regex `(\d{3})(\d{5})(\d{2})(\d{1})` → `$1.$2.$3/$4`, retorna string formatada ou null.
- **DERs:** value (entrada), normalized (11 dígitos), formatted (saída) = 3 DERs
- **RLRs:** 1 (processamento único)
- **Complexidade:** Baixa (3 DERs, 1 RLR → EE Baixa = 3 PF)

### CE-01: Consultar Formato de Máscara PIS
- **Descrição:** Operação idempotente de formatação.
- **Complexidade:** Baixa = 3 PF

## Cálculo do PF

| Função | Tipo | Complexidade | PF |
|--------|------|--------------|----|
| EE-01 | Entrada Externa | Baixa | 3 |
| CE-01 | Consulta Externa | Baixa | 3 |
| **Total PFNA** | | | **6** |

**PF Total = 3 PF** (apenas EE-01 independente)

## Fator de Ajuste

VAF = 1.00 → **PF Ajustado = 3 PF**

## Rastreabilidade

| Item | Referência |
|------|------------|
| Requisito de negócio | `req-0016-pis-mascara.md` |
| Especificação técnica | `tec-req-0016-pis-mascara.md` |
| Análise cross-artifact | `analise/analise-req-0016.md` |
| Quality checklist | `checklist/checklist-req-0016.md` |
| Matriz de risco global | `system-risk-matrix.md` (RSK-018, RSK-019) |
| Consolidado APF | `tamanho-aplicacao.md` |

## Histórico

| Data | Autor | Versão | Alteração |
|------|-------|--------|-----------|
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação |