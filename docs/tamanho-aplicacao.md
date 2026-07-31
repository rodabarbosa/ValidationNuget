---
type: apf
title: "Tamanho da Aplicação — APF Consolidado"
description: "Consolidado de APF: 90 PF, 13 requisitos."
resource: "./tamanho-aplicacao.md"
tags: [apf, consolidado, tamanho]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "tamanho-aplicacao"
  title_pt: "Tamanho da Aplicação — APF Consolidado"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "27/07/2026"
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
- **Última atualização:** 27/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão:** 1.0.0
- **Status:** Aprovado

## Resumo por Requisito

| Requisito | Nome | EE | CE | EO | Total PF |
| --------- | ---- | -- | -- | -- | -------- |
| req-0001 | CPF — Validação e Máscara | 3 | 1 | 0 | **12** |
| req-0002 | CNPJ — Validação e Máscara | 2 | 0 | 0 | **6** |
| req-0003 | PIS — Validação e Máscara | 2 | 0 | 0 | **6** |
| req-0004 | Título de Eleitor — Validação e Máscara | 2 | 0 | 0 | **6** |
| req-0005 | Renavam — Validação | 1 | 0 | 0 | **3** |
| req-0006 | Inscrição Estadual (27 UFs) — Validação e Máscara | 2 | 1 | 0 | **11** |
| req-0007 | Mockup CPF | 0 | 0 | 1 | **4** |
| req-0008 | Mockup CNPJ | 0 | 0 | 1 | **4** |
| req-0009 | Mockup PIS | 0 | 0 | 1 | **4** |
| req-0010 | Mockup Título de Eleitor | 0 | 0 | 1 | **4** |
| req-0011 | Mockup Renavam | 0 | 0 | 1 | **4** |
| req-0012 | Mockup Inscrição Estadual (27 UFs) | 0 | 0 | 1 | **5** |
| req-0013 | String Utils | 0 | 7 | 0 | **21** |
| **Total** | | **12** | **9** | **6** | **90 PF** |

## Distribuição por Tipo de Função

| Tipo de Função | Quantidade | PF Total |
| -------------- | ---------- | -------- |
| EE (External Input) | 12 | 34 |
| CE (External Inquiry) | 9 | 27 |
| EO (External Output) | 6 | 29 |
| ALI (Arquivo Lógico Interno) | 0 | 0 |
| AIE (Arquivo de Interface Externa) | 0 | 0 |
| **Total** | **27** | **90 PF** |

## Estimativa de Esforço

Considerando a métrica histórica de ~8-12 horas/PF para bibliotecas .NET (fator de ajuste: baixa complexidade por ser stateless):

| Métrica | Valor |
| ------- | ----- |
| PF Total | 90 |
| Fator de ajuste (projeto maduro, sem UI, sem DB) | 0,85 |
| PF Ajustados | ~77 |
| Horas estimadas (10 h/PF) | ~770 h |
| Dias úteis estimados (8 h/dia) | ~96 dias |

**Nota:** Estimativa preliminar. O fator de ajuste pode variar conforme a maturidade do time e a complexidade dos algoritmos por estado (IE).

## Histórico de alterações

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 27/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação do consolidado com 13 requisitos e total de 90 PF |
