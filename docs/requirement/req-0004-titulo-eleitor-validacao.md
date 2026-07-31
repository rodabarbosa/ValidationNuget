---
type: req
title: "req-0004 — Título de Eleitor — Validação"
description: "Validação sintática do Título de Eleitor para uso por aplicações .NET que processem documentos eleitorais brasileiros. Formatação (máscara) é tratada no req-0017."
resource: "./requirement/req-0004-titulo-eleitor-validacao.md"
tags: [documento-brasileiro, validacao]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "req-0004"
  title_pt: "Título de Eleitor — Validação"
  version: "1.1.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "31/07/2026"
  language: pt-BR
---

# req-0004 — Título de Eleitor — Validação

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** `req-0004`
- **Título:** Título de Eleitor — Validação
- **Data de criação:** 27/07/2026
- **Última atualização:** 31/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão:** 1.1.0
- **Status:** Aprovado

## Intenção

- **Problema:** O Título de Eleitor é exigido em cadastros civis, concursos públicos e sistemas governamentais. A validação sintática previne erros de digitação em sistemas que processam documentos eleitorais.
- **Impacto:** Títulos inválidos geram rejeição em integrações com TSE, retrabalho e inconsistência cadastral.
- **Público:** Desenvolvedores .NET de sistemas governamentais, RH, concursos e cadastro civil.
- **Critério de sucesso:** Validação em < 1 ms, 100% de cobertura de testes.

## Escopo

- **In scope:** validação do Título de Eleitor (12 dígitos, 2 DVs + UF 01-28), normalização de entrada via `OnlyNumbers`.
- **Out of scope:** formatação/máscara (coberta em `req-0017`), consulta a bases externas (TSE), persistência.

## Requisitos funcionais

| ID | Descrição | Prioridade |
| -- | --------- | ---------- |
| RF-001 | Validar Título de Eleitor (12 dígitos) com 2 dígitos verificadores: 1º DV (pesos 2..9 sobre 8 primeiros), 2º DV (pesos 7,8,9 sobre dígitos 9-11) | Alta |
| RF-002 | Validar que o dígito da UF (9º e 10º dígitos) está entre 01 e 28 | Alta |
| RF-003 | Tratar entradas nulas/vazias retornando false | Alta |

## Regras de negócio

| ID | Regra |
| -- | ----- |
| RN-001 | Título tem 12 dígitos: 8 de sequência, 2 de UF (01-28), 2 DV. |
| RN-002 | 1º DV: soma dos 8 primeiros dígitos × (2..9); resto % 11; se > 9, DV = 0. |
| RN-003 | 2º DV: soma dos dígitos 9-11 × (7,8,9); resto % 11; se > 9, DV = 0. |
| RN-004 | UF (dígitos 9-10) deve ser entre 01 e 28. |

## Critérios de aceitação

```gherkin
Funcionalidade: Validação de Título de Eleitor
  Cenário: Título válido com pontuação
    Dado que o valor "1234.5678.9012" é informado
    Quando o método IsTituloEleitorValid() é chamado
    Então o resultado deve ser True (quando os DVs e a UF conferem)
  Cenário: Título com menos de 12 dígitos
    Dado que o valor "1234567890" é informado
    Quando o método IsTituloEleitorValid() é chamado
    Então o resultado deve ser False
  Cenário: Título com UF fora do range 01-28
    Dado que o valor com UF 99 é informado
    Quando o método IsTituloEleitorValid() é chamado
    Então o resultado deve ser False
  Cenário: Título nulo ou vazio
    Dado que o valor null é informado
    Quando o método IsTituloEleitorValid() é chamado
    Então o resultado deve ser False
```

## NFRs

| Categoria | Requisito | Métrica |
| --------- | --------- | ------- |
| Desempenho | Latência | p95 < 1 ms |
| Cobertura | Testes | 100% |
| Compatibilidade | Multi-target | .NET 8, 9, 10 |

## Matriz de risco local

| ID | Risco | P | I | Score | Nível |
| -- | ----- | - | - | ----- | ----- |
| RSK-008 | Algoritmo de DV incorreto | 2 | 4 | 8 | Médio |
| RSK-009 | Validação de UF com range errado | 1 | 3 | 3 | Baixo |

## Histórico

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 27/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.1.0 | Remoção do conteúdo de máscara (formatação transferida para req-0017); escopo reduzido a validação pura; RF/RN renumerados; APF recalculado para 3 PF |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.1.0 | Realinhamento do nível da fatia local à legenda da matriz global: RSK-008 (score 8) Médio |

## Clarification Log

| Data | Pergunta | Resposta | Status | Origem | Impacto |
| ---- | -------- | -------- | ------ | ------ | ------- |
| 27/07/2026 | O Título tem máscara própria? | Sim, PlaceTituloEleitorMask (0000.0000.0000). | Resolvido | Criação | Confirma transferência para req-0017. |
| 31/07/2026 | Onde fica a formatação (máscara) do Título após a revisão? | No requisito independente req-0017 (PlaceTituloEleitorMask). Este requisito passa a descrever apenas validação. | Resolvido | Implementação | Escopo reduzido; RF/RN de máscara removidos e renumerados. |

### Cobertura 8/8

| # | Área | Status |
| - | ---- | ------ |
| 1 | Atores | Resolvido |
| 2 | Fluxos | Resolvido |
| 3 | Exceções | Resolvido |
| 4 | Integrações | N/A |
| 5 | NFRs | Resolvido |
| 6 | Dados | Resolvido |
| 7 | Regras (RN-001 a RN-004) | Resolvido |
| 8 | Critérios | Resolvido |
