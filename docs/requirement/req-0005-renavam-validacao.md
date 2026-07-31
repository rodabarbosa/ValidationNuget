---
type: req
title: "req-0005 — Renavam — Validação"
description: "Validação sintática do Renavam (Registro Nacional de Veículos Automotores) para uso por aplicações .NET que processem documentos veiculares brasileiros."
resource: "./requirement/req-0005-renavam-validacao.md"
tags: [documento-brasileiro, validacao]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "req-0005"
  title_pt: "Renavam — Validação"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "27/07/2026"
  language: pt-BR
---

# req-0005 — Renavam — Validação

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** `req-0005`
- **Título:** Renavam — Validação
- **Data de criação:** 27/07/2026
- **Última atualização:** 27/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão:** 1.0.0
- **Status:** Aprovado

## Intenção

- **Problema:** O Renavam (Registro Nacional de Veículos Automotores) é usado em sistemas de trânsito, seguros e financiamentos. A validação sintática previne erros de digitação em cadastros veiculares.
- **Impacto:** Renavam inválido gera rejeição em integrações com Detran, seguros e financiamentos.
- **Público:** Desenvolvedores .NET de sistemas automotivos, seguros, finanças e governo.
- **Critério de sucesso:** Validação em < 1 ms, 100% de cobertura. Renavam **não tem máscara**.

## Requisitos funcionais

| ID | Descrição | Prioridade |
| -- | --------- | ---------- |
| RF-001 | Validar Renavam (9 ou 11 dígitos) com cálculo do dígito verificador (módulo 11, pesos 2..9) | Alta |
| RF-002 | Tratar entradas nulas/vazias retornando false | Alta |

## Regras de negócio

| ID | Regra |
| -- | ----- |
| RN-001 | Renavam aceito com 9 ou 11 dígitos. Se 9 dígitos, normalizar para 11 com left-pad zeros. |
| RN-002 | Reverter os 10 primeiros dígitos (WorkValue). Aplicar pesos 2..9 sobre posições 0..7 + 2,3 sobre posições 8,9. |
| RN-003 | Soma += valores[i] × peso[i]. resto % 11. DV = 11 - resto; se ≥ 10, DV = 0. Comparar com último dígito. |

## Critérios de aceitação

```gherkin
Funcionalidade: Validação de Renavam
  Cenário: Renavam válido (11 dígitos)
    Dado "12345678901" → IsRenavamValid() → True
  Cenário: Renavam válido (9 dígitos - normalizado)
    Dado "123456789" → IsRenavamValid() → True (normalizado para 11)
  Cenário: Renavam nulo
    Dado null → IsRenavamValid() → False
```

## NFRs

| Categoria | Requisito | Métrica |
| --------- | --------- | ------- |
| Desempenho | Latência | p95 < 1 ms |
| Cobertura | Testes | 100% |

## Risco local

| ID | Risco | P | I | Score | Nível |
| -- | ----- | - | - | ----- | ----- |
| RSK-010 | Algoritmo incorreto | 2 | 4 | 8 | Alto |
| RSK-011 | Normalização 9→11 dígitos incorreta | 1 | 3 | 3 | Baixo |

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
| 7 | Regras | Resolvido |
| 8 | Critérios | Resolvido |
