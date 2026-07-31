---
type: req
title: "req-0002 — CNPJ — Validação"
description: "Validação sintática do dígito verificador do CNPJ para uso por aplicações .NET que processem documentos fiscais brasileiros. Formatação (máscara) é tratada no req-0015."
resource: "./requirement/req-0002-cnpj-validacao.md"
tags: [documento-brasileiro, validacao]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "req-0002"
  title_pt: "CNPJ — Validação"
  version: "1.1.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "31/07/2026"
  language: pt-BR
---

# req-0002 — CNPJ — Validação

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** `req-0002`
- **Título:** CNPJ — Validação
- **Data de criação:** 27/07/2026
- **Última atualização:** 31/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão:** 1.1.0
- **Status:** Aprovado
- **Bundle:** Não (requisito isolado)

## Objetivo

Disponibilizar validação sintática do dígito verificador do CNPJ (Cadastro Nacional da Pessoa Jurídica), para uso por aplicações .NET que processem documentos fiscais brasileiros. A formatação (máscara) `00.000.000/0000-00` é tratada no requisito independente `req-0015`.

## Escopo

- **In scope:** validação do CNPJ (14 dígitos, com cálculo dos dígitos verificadores), normalização de entrada via `OnlyNumbers` (aceita CNPJ com pontuação).
- **Out of scope:** formatação/máscara (coberta em `req-0015`), consulta a bases externas (Sefaz, Receita Federal), validação de situação cadastral, validação de CPF/outros documentos, persistência.

## Intenção / Motivação de Negócio (Por quê)

- **Problema de negócio real:** Aplicações empresariais brasileiras que processam CNPJ precisam garantir a validade sintática do número antes de emitir NF-e, cadastrar fornecedores ou integrar com ERPs. CNPJs inválidos geram rejeição fiscal e retrabalho administrativo.
- **Por que importa:** A validação local (sem chamada de rede) elimina latência de consulta a serviços externos, reduz custos operacionais e acelera o fluxo de cadastro e faturamento.
- **Público afetado:** Desenvolvedores .NET que constroem sistemas ERP, e-commerce, fintechs, contabilidade e sistemas fiscais.
- **Critério de sucesso:** Validação executada em < 1 ms (p95), com 100% de cobertura de testes, rejeitando CNPJs de sequências repetidas e com dígitos verificadores incorretos.

## Artefatos relacionados

### Impactantes

- `constituicao.md` — SEC-06, SEC-07, PERF-01
- `architecture-tech-stack.md`

### Impactados

- `tec-req-0002-cnpj-validacao.md`
- `apf/apf-req-0002.md`
- `analise/analise-req-0002.md`
- `checklist/checklist-req-0002.md`
- `system-risk-matrix.md`
- `tamanho-aplicacao.md`
- `req-0015-cnpj-mascara.md` — máscara do CNPJ (requisito base de formatação)

## Requisitos funcionais

| ID | Descrição | Prioridade | RN associada |
| -- | --------- | ---------- | ------------ |
| RF-001 | Validar CNPJ calculando os dois dígitos verificadores (13º e 14º dígitos) pelo algoritmo módulo 11 | Alta | RN-001, RN-002 |
| RF-002 | Rejeitar CNPJs com todos os dígitos repetidos (ex.: 11.111.111/1111-11) | Alta | RN-003 |
| RF-003 | Tratar entradas nulas/vazias retornando `false` | Alta | RN-003 |

## Regras de negócio

| ID | Regra | Origem | Impacto |
| -- | ----- | ------ | ------- |
| RN-001 | O CNPJ possui 14 dígitos, sendo os 2 últimos dígitos verificadores. O 1º DV usa pesos 5,4,3,2,9,8,7,6,5,4,3,2 sobre os 12 primeiros; o 2º DV usa pesos 6,5,4,3,2,9,8,7,6,5,4,3,2 sobre os 13 primeiros. | Legislação (IN RFB) | Algoritmo |
| RN-002 | Cálculo do DV por módulo 11: soma dos produtos; resto da divisão por 11; se resto < 2, dígito = 0; senão dígito = 11 - resto. | Legislação | Algoritmo |
| RN-003 | CNPJs com sequência repetida ou nulo/vazio rejeitados. | Boa prática | Validação |

## Critérios de aceitação

```gherkin
Funcionalidade: Validação de CNPJ

  Cenário: CNPJ válido com pontuação
    Dado que o valor "12.345.678/0001-95" é informado
    Quando o método IsCnpjValid() é chamado
    Então o resultado deve ser True

  Cenário: CNPJ válido sem pontuação
    Dado que o valor "12345678000195" é informado
    Quando o método IsCnpjValid() é chamado
    Então o resultado deve ser True

  Cenário: CNPJ com dígitos verificadores inválidos
    Dado que o valor "12345678000100" é informado
    Quando o método IsCnpjValid() é chamado
    Então o resultado deve ser False

  Cenário: CNPJ com dígitos repetidos
    Dado que o valor "11111111111111" é informado
    Quando o método IsCnpjValid() é chamado
    Então o resultado deve ser False

  Cenário: CNPJ com menos de 14 dígitos
    Dado que o valor "12345678" é informado
    Quando o método IsCnpjValid() é chamado
    Então o resultado deve ser False

  Cenário: CNPJ nulo ou vazio
    Dado que o valor null é informado
    Quando o método IsCnpjValid() é chamado
    Então o resultado deve ser False
```

## Requisitos não funcionais

| Categoria | Requisito | Métrica |
| --------- | --------- | ------- |
| Desempenho | Latência | p95 < 1 ms, p99 < 5 ms |
| Desempenho | Throughput | > 100.000 validações/s por núcleo |
| Segurança | ReDoS | Regex simples (OnlyNumbers), sem backtracking catastrófico |
| Manutenibilidade | Cobertura | 100% linha/branch |
| Compatibilidade | Multi-target | .NET 8, 9, 10 |

## Matriz de risco local

| ID | Risco | P | I | Score | Nível | Mitigação |
| -- | ----- | - | - | ----- | ----- | --------- |
| RSK-004 | Algoritmo de validação incorreto | 2 | 5 | 10 | Alto | Testes exaustivos, benchmark em CI |

## Histórico de alterações

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 27/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação do documento |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.1.0 | Remoção do conteúdo de máscara (formatação transferida para req-0015); escopo reduzido a validação pura; RF/RN renumerados; APF recalculado para 3 PF |

## Clarification Log

| Data | Pergunta | Resposta | Status | Origem | Impacto |
| ---- | -------- | -------- | ------ | ------ | ------- |
| 27/07/2026 | O CNPJ deve ter método GetIssuingState como o CPF? | Não. O CNPJ não tem estado emissor no algoritmo de validação. | Resolvido | Criação | Remove método não existente no código. |
| 27/07/2026 | Existe método RemoveMask específico para CNPJ? | Não. A normalização usa StringExtension.OnlyNumbers(). | Resolvido | Criação | Remove RF separada para RemoveMask. |
| 27/07/2026 | Entrada com caracteres especiais é válida? | Sim. OnlyNumbers é chamado internamente para normalizar. | Resolvido | Criação | Define comportamento. |
| 31/07/2026 | Onde fica a formatação (máscara) do CNPJ após a revisão? | No requisito independente req-0015 (PlaceCnpjMask/PlaceMask). Este requisito passa a descrever apenas validação. | Resolvido | Implementação | Escopo reduzido; RF/RN de máscara removidos e renumerados. |

### Cobertura do Clarification (8 áreas)

| # | Área | Status | Justificativa |
| - | ---- | ------ | ------------- |
| 1 | Atores e personas | Resolvido | Desenvolvedor .NET |
| 2 | Fluxos principais e alternativos | Resolvido | Happy path + rejeição |
| 3 | Exceções e erros | Resolvido | Entrada inválida/vazia retorna false |
| 4 | Integrações externas | N/A | Stateless |
| 5 | NFRs | Resolvido | p95 < 1ms |
| 6 | Dados e privacidade | Resolvido | CNPJ é dado sensível |
| 7 | Validações | Resolvido | RN-001 a RN-003 |
| 8 | Critérios de aceite | Resolvido | Gherkin + NFRs |

**Cobertura atual:** 8/8.
