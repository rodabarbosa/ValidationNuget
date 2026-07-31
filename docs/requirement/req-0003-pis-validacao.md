---
type: req
title: "req-0003 — PIS — Validação"
description: "Validação sintática do PIS (Programa de Integração Social) para uso por aplicações .NET que processem documentos trabalhistas brasileiros. Formatação (máscara) é tratada no req-0016."
resource: "./requirement/req-0003-pis-validacao.md"
tags: [documento-brasileiro, validacao]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "req-0003"
  title_pt: "PIS — Validação"
  version: "1.1.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "31/07/2026"
  language: pt-BR
---

# req-0003 — PIS — Validação

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** `req-0003`
- **Título:** PIS — Validação
- **Data de criação:** 27/07/2026
- **Última atualização:** 31/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão:** 1.1.0
- **Status:** Aprovado

## Intenção

- **Problema:** O PIS (Programa de Integração Social) é usado para identificar trabalhadores brasileiros. Aplicações de RH precisam validar o número antes de processar folha de pagamento, admissão ou integrações com eSocial.
- **Impacto:** PIS inválido gera rejeição em sistemas governamentais (eSocial, CAGED), multas trabalhistas e retrabalho no departamento pessoal.
- **Público:** Desenvolvedores .NET de sistemas de RH, folha de pagamento, benefícios.
- **Critério de sucesso:** Validação em < 1 ms (p95), 100% de cobertura, rejeição de PIS com dígito verificador incorreto.

## Escopo

- **In scope:** validação do PIS (11 dígitos, módulo 11), normalização de entrada via `OnlyNumbers` (aceita PIS com pontuação).
- **Out of scope:** formatação/máscara (coberta em `req-0016`), consulta a bases externas (Caixa, eSocial), persistência.

## Requisitos funcionais

| ID | Descrição | Prioridade |
| -- | --------- | ---------- |
| RF-001 | Validar PIS (11 dígitos) com cálculo do dígito verificador (módulo 11, pesos 3..11) | Alta |
| RF-002 | Tratar entradas nulas/vazias retornando false | Alta |

## Regras de negócio

| ID | Regra |
| -- | ----- |
| RN-001 | PIS tem 11 dígitos; o último é o dígito verificador. Pesos: 3,2,9,8,7,6,5,4,3,2 sobre os 10 primeiros dígitos. |
| RN-002 | Cálculo: soma dos produtos; resto % 11; se resto < 2, dígito = 0; senão dígito = 11 - resto. |

## Critérios de aceitação

```gherkin
Funcionalidade: Validação de PIS
  Cenário: PIS válido sem máscara
    Dado que o valor "12345678901" é informado
    Quando o método IsPisValid() é chamado
    Então o resultado deve ser True
  Cenário: PIS válido com pontuação
    Dado que o valor "123.45678.90-1" é informado
    Quando o método IsPisValid() é chamado
    Então o resultado deve ser True
  Cenário: PIS com dígito verificador inválido
    Dado que o valor "12345678900" é informado
    Quando o método IsPisValid() é chamado
    Então o resultado deve ser False
  Cenário: PIS com menos de 11 dígitos
    Dado que o valor "1234567890" é informado
    Quando o método IsPisValid() é chamado
    Então o resultado deve ser False
  Cenário: PIS nulo ou vazio
    Dado que o valor "" ou null é informado
    Quando o método IsPisValid() é chamado
    Então o resultado deve ser False
```

## NFRs

| Categoria | Requisito | Métrica |
| --------- | --------- | ------- |
| Desempenho | Latência | p95 < 1 ms |
| Desempenho | Throughput | > 100k/s |
| Segurança | ReDoS | Regex simples (OnlyNumbers) |
| Cobertura | Testes | 100% |
| Compatibilidade | Multi-target | .NET 8, 9, 10 |

## Matriz de risco local

| ID | Risco | P | I | Score | Nível |
| -- | ----- | - | - | ----- | ----- |
| RSK-006 | Algoritmo incorreto | 2 | 4 | 8 | Médio |

## Histórico

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 27/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.1.0 | Remoção do conteúdo de máscara (formatação transferida para req-0016); escopo reduzido a validação pura; RF/RN renumerados; APF recalculado para 3 PF |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.1.0 | Realinhamento do nível da fatia local à legenda da matriz global: RSK-006 (score 8) Médio |

## Clarification Log

| Data | Pergunta | Resposta | Status | Origem | Impacto |
| ---- | -------- | -------- | ------ | ------ | ------- |
| 27/07/2026 | O PIS usa pesos específicos? | Sim. PisRule.CalculateWeight: index ≤ 1 → 3-index, senão 11-index. | Resolvido | Criação | Confirma algoritmo. |
| 27/07/2026 | O PIS tem método RemoveMask próprio? | Sim, PisValidation.RemoveMask (delega para OnlyNumbers). | Resolvido | Criação | Remove RF separada de máscara. |
| 31/07/2026 | Onde fica a formatação (máscara) do PIS após a revisão? | No requisito independente req-0016 (PlacePisMask). Este requisito passa a descrever apenas validação. | Resolvido | Implementação | Escopo reduzido; RF/RN de máscara removidos e renumerados. |

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
