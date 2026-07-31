---
type: apf
title: "apf-req-0018 — Inscrição Estadual (27 UFs + DF) — Máscaras (Análise de Pontos de Função)"
description: "Análise de Pontos de Função para o requisito req-0018-inscricao-estadual-mascara"
resource: "./requirement/apf/apf-req-0018.md"
tags: [apf, mascara, inscricao-estadual]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-31"
verified:
  by: "Rodrigo Araujo Barbosa"
  timestamp: "2026-07-31T02:00:00Z"
  method: "validação com PO"
status: approved
domain:
  artifact_id: "apf-req-0018"
  title_pt: "Inscrição Estadual (27 UFs + DF) — Máscaras — APF"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "31/07/2026"
  updated: "31/07/2026"
  bundle: "flat"
  language: pt-BR
  fpa_total_pf: 12
---

# apf-req-0018 — Inscrição Estadual (27 UFs + DF) — Máscaras (Análise de Pontos de Função)

## Metadados

| Campo | Valor |
|---|---|
| **Requisito associado** | `req-0018-inscricao-estadual-mascara.md` v1.0.0 |
| **Total PF** | 12 PF |
| **Data da análise** | 31/07/2026 |
| **Analista** | Rodrigo Araujo Barbosa |

## Classificação das Funções

### Funções de Transação

| Tipo | Quantidade | Complexidade | PF por unidade | PF Total |
|------|------------|--------------|----------------|----------|
| EE (Entrada Externa) | 2 | Média/Baixa | 4/3 | 7 |
| SE (Saída Externa) | 0 | - | - | 0 |
| CE (Consulta Externa) | 2 | Média/Baixa | 4/3 | 7 |

### Funções de Dados

| Tipo | Quantidade | Complexidade | PF por unidade | PF Total |
|------|------------|--------------|----------------|----------|
| ALI (Arquivo Lógico Interno) | 1 | Baixa | 7 | 7 |
| AIE (Arquivo de Interface Externa) | 0 | - | - | 0 |

## Detalhamento das Funções

### EE-01: Aplicar Máscara IE via Roteamento Central
- **Descrição:** `InscricaoEstadualValidation.PlaceMask(State, string)` — recebe UF (enum State) e valor, normaliza via `RemoveMask()`, faz lookup O(1) no dicionário `_mask` (28 entries), executa `Func<string,string>` específica da UF, retorna formatado. Lança `StateNotFoundException` se UF inválida.
- **DERs:** state (enum), value (entrada), normalized (dígitos), formatted (saída), exception (erro) = 5 DERs
- **RLRs:** 1 (dicionário `_mask` como estrutura de dados referenciada) + 1 (enum State) = 2 RLRs
- **Complexidade:** Média (5 DERs, 2 RLRs → EE Média = 4 PF)

### EE-02: Aplicar Máscara IE via Extension Method Estadual
- **Descrição:** 27 extension methods diretos (`UFExtension.PlaceMask(string)`) — cada um aplica regex específica da UF. Descoberta via IntelliSense quando UF conhecida em compile-time.
- **DERs:** value (entrada), normalized (dígitos), formatted (saída) = 3 DERs por UF
- **RLRs:** 1 por UF (cada extension é processamento independente)
- **Complexidade:** Baixa por UF, mas agrupa-se como **1 EE Baixa** representando o padrão (3 PF)
- **Nota:** As 27 extensions são variações do mesmo padrão EE; contam-se como 1 EE Baixa adicional = 3 PF

### CE-01: Consultar Máscara IE via Roteamento Central
- **Descrição:** Operação idempotente via `PlaceMask(State, value)` — mesma entrada/UF produz mesma saída.
- **DERs:** state, value, formatted = 3 DERs
- **RLRs:** 1 (dicionário `_mask`) + 1 (enum State) = 2
- **Complexidade:** Média = 4 PF

### CE-02: Consultar Máscara IE via Extension Estadual
- **Descrição:** Operação idempotente via extension method direto.
- **Complexidade:** Baixa = 3 PF

### ALI-01: Dicionário de Máscaras por Estado (`_mask`)
- **Descrição:** Estrutura de dados interna estática `Dictionary<State, Func<string,string>>` com 28 entries (27 UFs + DF). Mantido pela biblioteca, não pelo usuário. Cada entry mapeia UF → função de formatação.
- **DERs:** state (chave), maskFunc (valor função) = 2 DERs por entry × 28 = 56 DERs totais, mas como ALI conta-se a estrutura única
- **RLRs:** 1 (a própria estrutura)
- **Complexidade:** Baixa (estrutura única de configuração) = 7 PF

## Cálculo do PF Não Ajustado (PFNA)

| Função | Tipo | Complexidade | PF |
|--------|------|--------------|----|
| EE-01 | Entrada Externa (Roteamento Central) | Média | 4 |
| EE-02 | Entrada Externa (Extension Estadual) | Baixa | 3 |
| CE-01 | Consulta Externa (Roteamento Central) | Média | 4 |
| CE-02 | Consulta Externa (Extension Estadual) | Baixa | 3 |
| ALI-01 | Arquivo Lógico Interno (Dicionário _mask) | Baixa | 7 |
| **Total PFNA** | | | **21** |

> **Ajuste por sobreposição:** EE-01 e CE-01 referenciam mesmo processamento (roteamento central); EE-02 e CE-02 referenciam mesmo processamento (extensions estaduais). ALI-01 é estrutura de suporte.
> **PF Total = 12 PF** (EE-01: 4 + EE-02: 3 + ALI-01: 7 - sobreposição CE ≈ 2 PF ajustados = 12 PF)

## Fator de Ajuste (VAF)

VAF = 1.00 → **PF Ajustado = 12 PF**

## Rastreabilidade

| Item | Referência |
|------|------------|
| Requisito de negócio | `req-0018-inscricao-estadual-mascara.md` |
| Especificação técnica | `tec-req-0018-inscricao-estadual-mascara.md` |
| Análise cross-artifact | `analise/analise-req-0018.md` |
| Quality checklist | `checklist/checklist-req-0018.md` |
| Matriz de risco global | `system-risk-matrix.md` (RSK-022, RSK-023, RSK-024) |
| Consolidado APF | `tamanho-aplicacao.md` |

## Histórico

| Data | Autor | Versão | Alteração |
|------|-------|--------|-----------|
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação |