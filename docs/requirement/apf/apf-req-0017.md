---
type: apf
title: "apf-req-0017 — Título de Eleitor — Máscara (Análise de Pontos de Função)"
description: "Análise de Pontos de Função para o requisito req-0017-titulo-eleitor-mascara"
resource: "./requirement/apf/apf-req-0017.md"
tags: [apf, mascara, titulo-eleitor]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-31"
verified:
  by: "Rodrigo Araujo Barbosa"
  timestamp: "2026-07-31T02:00:00Z"
  method: "validação com PO"
status: approved
domain:
  artifact_id: "apf-req-0017"
  title_pt: "Título de Eleitor — Máscara — APF"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "31/07/2026"
  updated: "31/07/2026"
  bundle: "flat"
  language: pt-BR
  fpa_total_pf: 3
---

# apf-req-0017 — Título de Eleitor — Máscara (Análise de Pontos de Função)

## Metadados

| Campo | Valor |
|---|---|
| **Requisito associado** | `req-0017-titulo-eleitor-mascara.md` v1.0.0 |
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

### EE-01: Aplicar Máscara Título de Eleitor
- **Descrição:** Processa entrada de string (Título com/sem formatação), normaliza via `StringExtension.OnlyNumbers()`, aplica regex `(\d{4})(\d{4})(\d{4})` → `$1.$2.$3` (formato `0000.0000.0000`), retorna string formatada ou null.
- **DERs:** value (entrada), normalized (12 dígitos), formatted (saída) = 3 DERs
- **RLRs:** 1
- **Complexidade:** Baixa (3 DERs, 1 RLR → EE Baixa = 3 PF)

### CE-01: Consultar Formato de Máscara Título
- **Descrição:** Operação idempotente.
- **Complexidade:** Baixa = 3 PF

## Cálculo do PF

| Função | Tipo | Complexidade | PF |
|--------|------|--------------|----|
| EE-01 | Entrada Externa | Baixa | 3 |
| CE-01 | Consulta Externa | Baixa | 3 |
| **Total PFNA** | | | **6** |

**PF Total = 3 PF**

## Fator de Ajuste

VAF = 1.00 → **PF Ajustado = 3 PF**

## Rastreabilidade

| Item | Referência |
|------|------------|
| Requisito de negócio | `req-0017-titulo-eleitor-mascara.md` |
| Especificação técnica | `tec-req-0017-titulo-eleitor-mascara.md` |
| Análise cross-artifact | `analise/analise-req-0017.md` |
| Quality checklist | `checklist/checklist-req-0017.md` |
| Matriz de risco global | `system-risk-matrix.md` (RSK-020, RSK-021) |
| Consolidado APF | `tamanho-aplicacao.md` |

## Histórico

| Data | Autor | Versão | Alteração |
|------|-------|--------|-----------|
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação |