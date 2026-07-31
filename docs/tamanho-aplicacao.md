---
type: apf
title: "Tamanho da Aplicação — APF Consolidado"
description: "Consolidado de APF: 102 PF, 21 requisitos."
resource: "./tamanho-aplicacao.md"
tags: [apf, consolidado, tamanho]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-31"
status: approved
domain:
  artifact_id: "tamanho-aplicacao"
  title_pt: "Tamanho da Aplicação — APF Consolidado"
  version: "1.4.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "31/07/2026"
  language: pt-BR
---

# Tamanho da Aplicação — APF Consolidado

> **Arquivo de destino:** `docs/tamanho-aplicacao.md` (raiz de `/docs`).
> Consolidado de Análise de Pontos de Função (APF) de todos os requisitos.

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** `tamanho-aplicacao`
- **Título:** Tamanho da Aplicação — APF Consolidado
- **Data de criação:** 27/07/2026
- **Última atualização:** 31/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão:** 1.3.0
- **Status:** Aprovado

## Resumo por Requisito

| Requisito | Nome | EE | CE | EO | ALI | Total PF |
| --------- | ---- | -- | -- | -- | --- | -------- |
| req-0001 | CPF — Validação | 2 | 0 | 0 | 0 | **6** |
| req-0002 | CNPJ — Validação | 1 | 0 | 0 | 0 | **3** |
| req-0003 | PIS — Validação | 1 | 0 | 0 | 0 | **3** |
| req-0004 | Título de Eleitor — Validação | 1 | 0 | 0 | 0 | **3** |
| req-0005 | Renavam — Validação | 1 | 0 | 0 | 0 | **3** |
| req-0006 | Inscrição Estadual (27 UFs) — Validação | 1 | 0 | 0 | 0 | **4** |
| req-0007 | Mockup CPF | 0 | 0 | 1 | 0 | **4** |
| req-0008 | Mockup CNPJ | 0 | 0 | 1 | 0 | **4** |
| req-0009 | Mockup PIS | 0 | 0 | 1 | 0 | **4** |
| req-0010 | Mockup Título de Eleitor | 0 | 0 | 1 | 0 | **4** |
| req-0011 | Mockup Renavam | 0 | 0 | 1 | 0 | **4** |
| req-0012 | Mockup Inscrição Estadual (27 UFs) | 0 | 0 | 1 | 0 | **5** |
| req-0013 | String Utils | 0 | 7 | 0 | 0 | **21** |
| req-0014 | CPF — Máscara | 1 | 0 | 0 | 0 | **3** |
| req-0015 | CNPJ — Máscara | 1 | 0 | 0 | 0 | **3** |
| req-0016 | PIS — Máscara | 1 | 0 | 0 | 0 | **3** |
| req-0017 | Título de Eleitor — Máscara | 1 | 0 | 0 | 0 | **3** |
| req-0018 | Inscrição Estadual (27 UFs + DF) — Máscaras | 2 | 0 | 0 | 1 | **12**\* |
| req-0019 | CNPJ Alfanumérico — Validação | 1 | 0 | 0 | 0 | **3** |
| req-0020 | Mockup CNPJ Alfanumérico | 0 | 0 | 1 | 0 | **4** |
| req-0021 | CNPJ Alfanumérico — Máscara | 1 | 0 | 0 | 0 | **3** |
| **Total** | | **15** | **7** | **7** | **1** | **102 PF** |

> \* Linha do req-0018 copiada do `apf-req-0018` (EE 2 + ALI 1 = 12 PF declarados), que usa ajuste por sobreposição (PFNA 21 → 12). Pré-existente; ver nota em `apf-req-0018`.

## Distribuição por Tipo de Função

| Tipo de Função | Quantidade | PF Total |
| -------------- | ---------- | -------- |
| EE (External Input) | 15 | 45 |
| CE (External Inquiry) | 7 | 21 |
| EO (External Output) | 7 | 29 |
| ALI (Arquivo Lógico Interno) | 1 | 7 |
| AIE (Arquivo de Interface Externa) | 0 | 0 |
| **Total** | **30** | **102 PF** |

## Estimativa de Esforço

Considerando a métrica histórica de ~8-12 horas/PF para bibliotecas .NET (fator de ajuste: baixa complexidade por ser stateless):

| Métrica | Valor |
| ------- | ----- |
| PF Total | 102 |
| Fator de ajuste (projeto maduro, sem UI, sem DB) | 0,85 |
| PF Ajustados | ~87 |
| Horas estimadas (10 h/PF) | ~870 h |
| Dias úteis estimados (8 h/dia) | ~109 dias |

**Nota:** Estimativa preliminar. O fator de ajuste pode variar conforme a maturidade do time e a complexidade dos algoritmos por estado (IE). Os requisitos req-0020 (Mockup CNPJ Alfanumérico: 1 EO Baixa = 4 PF) e req-0021 (CNPJ Alfanumérico — Máscara: 1 EE Baixa = 3 PF) adicionaram 7 PF ao total anterior de 95 PF.

## Histórico de alterações

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 27/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação do consolidado com 13 requisitos e total de 90 PF |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.1.0 | Adicionados 5 novos requisitos (req-0014 a req-0018 — máscaras), totalizando 18 requisitos e 126 PF |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.2.0 | Remoção do conteúdo de máscara de req-0001..0006; APFs recalculados (114→92); correção da inconsistência pré-existente 126 vs 114; componentes EE/CE/EO/ALI reconstruídos (13/7/6/1) |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.3.0 | Adicionado req-0019 (CNPJ Alfanumérico — Validação): +1 EE Baixa = 3 PF; total 92→95 PF; EE 13→14; total funções 27→28 |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.4.0 | Adicionados req-0020 (Mockup CNPJ Alfanumérico: 4 PF, EO) e req-0021 (CNPJ Alfanumérico — Máscara: 3 PF, EE); total 95→102 PF; EE 14→15; EO 6→7; total funções 28→30 |
