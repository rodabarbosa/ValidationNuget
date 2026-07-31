---
type: apf
title: "apf-req-0014 — CPF — Máscara (Análise de Pontos de Função)"
description: "Análise de Pontos de Função para o requisito req-0014-cpf-mascara"
resource: "./requirement/apf/apf-req-0014.md"
tags: [apf, mascara, cpf]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-31"
verified:
  by: "Rodrigo Araujo Barbosa"
  timestamp: "2026-07-31T02:00:00Z"
  method: "validação com PO"
status: approved
domain:
  artifact_id: "apf-req-0014"
  title_pt: "CPF — Máscara — APF"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "31/07/2026"
  updated: "31/07/2026"
  bundle: "flat"
  language: pt-BR
  fpa_total_pf: 3
---

# apf-req-0014 — CPF — Máscara (Análise de Pontos de Função)

## Metadados

| Campo | Valor |
|---|---|
| **Requisito associado** | `req-0014-cpf-mascara.md` v1.0.0 |
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

### EE-01: Aplicar Máscara CPF
- **Descrição:** Processa entrada de string (CPF com/sem formatação), normaliza removendo não-dígitos, aplica regex de máscara `000.000.000-00`, retorna string formatada ou null.
- **DERs (Elementos de Dados):** value (string entrada), normalized (string 11 dígitos), formatted (string saída) = 3 DERs
- **RLRs (Tipos de Registro):** 1 (processamento único de máscara)
- **Complexidade:** Baixa (3 DERs, 1 RLR → EE Baixa = 3 PF)

### CE-01: Consultar Formato de Máscara CPF
- **Descrição:** Operação idempotente — mesma entrada produz mesma saída. Consulta o padrão de formatação aplicado.
- **DERs:** value (entrada), formatted (saída) = 2 DERs
- **RLRs:** 1 (referência ao processamento de máscara)
- **Complexidade:** Baixa (2 DERs, 1 RLR → CE Baixa = 3 PF)

## Cálculo do PF Não Ajustado (PFNA)

| Função | Tipo | Complexidade | PF |
|--------|------|--------------|----|
| EE-01 | Entrada Externa | Baixa | 3 |
| CE-01 | Consulta Externa | Baixa | 3 |
| **Total PFNA** | | | **6** |

> **Nota:** Pela regra de contagem APF, EE e CE que referenciam o mesmo processamento lógico não são somados independentemente quando a CE é apenas uma leitura do resultado da EE. A máscara é uma transformação única (EE). A CE seria contada se houvesse consulta separada (ex.: endpoint GET de configuração de máscara). Como não há, **PF total = 3 PF** (apenas EE-01).

## Fator de Ajuste (VAF)

Não aplicado (contagem indicativa). Se aplicado, GSCs padrão de biblioteca .NET:
- GSC 1 (Comunicação de dados): 3
- GSC 2 (Processamento distribuído): 0
- GSC 3 (Desempenho): 4
- GSC 4 (Configuração intensiva): 2
- GSC 5 (Taxa de transação): 3
- GSC 6 (Entrada de dados online): 3
- GSC 7 (Eficiência do usuário final): 3
- GSC 8 (Atualização online): 2
- GSC 9 (Processamento complexo): 2
- GSC 10 (Reutilização): 4
- GSC 11 (Facilidade de instalação): 3
- GSC 12 (Facilidade operacional): 3
- GSC 13 (Múltiplos locais): 0
- GSC 14 (Facilidade de mudança): 3
- **Total GSC:** 35 → VAF = 0.65 + 0.01 × 35 = 1.00

**PF Ajustado = 3 × 1.00 = 3 PF**

## Rastreabilidade

| Item | Referência |
|------|------------|
| Requisito de negócio | `req-0014-cpf-mascara.md` |
| Especificação técnica | `tec-req-0014-cpf-mascara.md` |
| Análise cross-artifact | `analise/analise-req-0014.md` |
| Quality checklist | `checklist/checklist-req-0014.md` |
| Matriz de risco global | `system-risk-matrix.md` (RSK-014, RSK-015) |
| Consolidado APF | `tamanho-aplicacao.md` |

## Histórico

| Data | Autor | Versão | Alteração |
|------|-------|--------|-----------|
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação da análise APF |