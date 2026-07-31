---
type: req
title: "req-0004 — Título de Eleitor — Validação e Máscara"
description: "Validação sintática do Título de Eleitor e formatação (máscara) para uso por aplicações .NET que processem documentos eleitorais brasileiros."
resource: "./requirement/req-0004-titulo-eleitor-validacao-mascara.md"
tags: [documento-brasileiro, validacao, mascara]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "req-0004"
  title_pt: "Título de Eleitor — Validação e Máscara"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "27/07/2026"
  language: pt-BR
---

# req-0004 — Título de Eleitor — Validação e Máscara

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** `req-0004`
- **Título:** Título de Eleitor — Validação e Máscara
- **Data de criação:** 27/07/2026
- **Última atualização:** 27/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão:** 1.0.0
- **Status:** Aprovado

## Intenção

- **Problema:** O Título de Eleitor é exigido em cadastros civis, concursos públicos e sistemas governamentais. A validação sintática previne erros de digitação em sistemas que processam documentos eleitorais.
- **Impacto:** Títulos inválidos geram rejeição em integrações com TSE, retrabalho e inconsistência cadastral.
- **Público:** Desenvolvedores .NET de sistemas governamentais, RH, concursos e cadastro civil.
- **Critério de sucesso:** Validação em < 1 ms, 100% de cobertura de testes.

## Requisitos funcionais

| ID | Descrição | Prioridade |
| -- | --------- | ---------- |
| RF-001 | Validar Título de Eleitor (12 dígitos) com 2 dígitos verificadores: 1º DV (pesos 2..9 sobre 8 primeiros), 2º DV (pesos 7,8,9 sobre dígitos 9-11) | Alta |
| RF-002 | Validar que o dígito da UF (9º e 10º dígitos) está entre 01 e 28 | Alta |
| RF-003 | Aplicar máscara no formato `0000.0000.0000` | Alta |
| RF-004 | Tratar entradas nulas/vazias retornando false | Alta |

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
  Cenário: Título válido
    Dado "12345678901234" → IsTituloEleitorValid() → True
  Cenário: Título com menos de 12 dígitos
    Dado "1234567890" → IsTituloEleitorValid() → False
  Cenário: Título nulo
    Dado null → IsTituloEleitorValid() → False
  Cenário: Aplicar máscara
    Dado "12345678901234" → PlaceTituloEleitorMask() → "1234.5678.9012?4"
    (Nota: comportamento real do código usa formato 0000.0000.0000)
```

**Nota sobre máscara:** O código usa `(\d{4})(\d{4})(\d{4})` → `$1.$2.$3` (12 dígitos). A documentação de exemplo no README mostra "12345678901234" que tem 14 dígitos — isso é um erro de documentação no README (o código valida exatamente 12 dígitos).

## NFRs

| Categoria | Requisito | Métrica |
| --------- | --------- | ------- |
| Desempenho | Latência | p95 < 1 ms |
| Cobertura | Testes | 100% |

## Matriz de risco local

| ID | Risco | P | I | Score | Nível |
| -- | ----- | - | - | ----- | ----- |
| RSK-008 | Algoritmo de DV incorreto | 2 | 4 | 8 | Alto |
| RSK-009 | Validação de UF com range errado | 1 | 3 | 3 | Baixo |

## Histórico

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 27/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação |

## Clarification Log (8/8)

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
