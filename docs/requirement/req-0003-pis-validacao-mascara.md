---
type: req
title: "req-0003 — PIS — Validação e Máscara"
description: "Validação sintática do PIS (Programa de Integração Social) e formatação (máscara) para uso por aplicações .NET que processem documentos trabalhistas brasileiros."
resource: "./requirement/req-0003-pis-validacao-mascara.md"
tags: [documento-brasileiro, validacao, mascara]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "req-0003"
  title_pt: "PIS — Validação e Máscara"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "27/07/2026"
  language: pt-BR
---

# req-0003 — PIS — Validação e Máscara

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** `req-0003`
- **Título:** PIS — Validação e Máscara
- **Data de criação:** 27/07/2026
- **Última atualização:** 27/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão:** 1.0.0
- **Status:** Aprovado

## Intenção

- **Problema:** O PIS (Programa de Integração Social) é usado para identificar trabalhadores brasileiros. Aplicações de RH precisam validar o número antes de processar folha de pagamento, admissão ou integrações com eSocial.
- **Impacto:** PIS inválido gera rejeição em sistemas governamentais (eSocial, CAGED), multas trabalhistas e retrabalho no departamento pessoal.
- **Público:** Desenvolvedores .NET de sistemas de RH, folha de pagamento, benefícios.
- **Critério de sucesso:** Validação em < 1 ms (p95), 100% de cobertura, rejeição de PIS com dígito verificador incorreto.

## Requisitos funcionais

| ID | Descrição | Prioridade |
| -- | --------- | ---------- |
| RF-001 | Validar PIS (11 dígitos) com cálculo do dígito verificador (módulo 11, pesos 3..11) | Alta |
| RF-002 | Aplicar máscara no formato `000.00000.00-0` | Alta |
| RF-003 | Tratar entradas nulas/vazias retornando false | Alta |

## Regras de negócio

| ID | Regra |
| -- | ----- |
| RN-001 | PIS tem 11 dígitos; o último é o dígito verificador. Pesos: 3,2,9,8,7,6,5,4,3,2 sobre os 10 primeiros dígitos. |
| RN-002 | Cálculo: soma dos produtos; resto % 11; se resto < 2, dígito = 0; senão dígito = 11 - resto. |
| RN-003 | Máscara: `000.00000.00-0` via regex. |

## Critérios de aceitação

```gherkin
Funcionalidade: Validação de PIS
  Cenário: PIS válido sem máscara
    Dado "12345678901" → IsPisValid() → True
  Cenário: PIS com dígito verificador inválido
    Dado "12345678900" → IsPisValid() → False
  Cenário: PIS com menos de 11 dígitos
    Dado "1234567890" → IsPisValid() → False
  Cenário: PIS nulo ou vazio
    Dado "" ou null → IsPisValid() → False
  Cenário: Aplicar máscara
    Dado "12345678901" → PlacePisMask() → "123.45678.90-1"
```

## NFRs

| Categoria | Requisito | Métrica |
| --------- | --------- | ------- |
| Desempenho | Latência | p95 < 1 ms |
| Desempenho | Throughput | > 100k/s |
| Segurança | ReDoS | Regex simples |
| Cobertura | Testes | 100% |

## Matriz de risco local

| ID | Risco | P | I | Score | Nível |
| -- | ----- | - | - | ----- | ----- |
| RSK-006 | Algoritmo incorreto | 2 | 4 | 8 | Alto |
| RSK-007 | Regex de máscara | 1 | 3 | 3 | Baixo |

## Histórico

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 27/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação |

## Clarification Log

| Pergunta | Resposta | Status |
| -------- | -------- | ------ |
| O PIS usa pesos específicos? | Sim. PisRule.CalculateWeight: index ≤ 1 → 3-index, senão 11-index. | Resolvido |
| O PIS tem método RemoveMask próprio? | Sim, PisValidation.RemoveMask (delega para OnlyNumbers). | Resolvido |

### Cobertura 8/8

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
