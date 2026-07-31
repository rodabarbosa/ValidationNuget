---
type: req
title: "req-0006 — Inscrição Estadual (27 UFs + DF) — Validação"
description: "Validação sintática da Inscrição Estadual de todos os 27 estados brasileiros + DF, para uso por aplicações .NET que processem documentos fiscais. Formatação (máscara) por estado é tratada no req-0018."
resource: "./requirement/req-0006-inscricao-estadual-validacao.md"
tags: [documento-brasileiro, validacao, inscricao-estadual]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "req-0006"
  title_pt: "Inscrição Estadual (27 UFs + DF) — Validação"
  version: "1.1.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "31/07/2026"
  language: pt-BR
---

# req-0006 — Inscrição Estadual (27 UFs + DF) — Validação

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** `req-0006`
- **Título:** Inscrição Estadual (27 UFs + DF) — Validação
- **Data de criação:** 27/07/2026
- **Última atualização:** 31/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão:** 1.1.0
- **Status:** Aprovado

## Intenção

- **Problema:** Cada estado brasileiro tem seu próprio formato e algoritmo de validação de Inscrição Estadual (IE). Sistemas fiscais e ERPs precisam validar IE de todos os 27 estados + DF para emissão de NF-e, cadastro de fornecedores e obrigações acessórias.
- **Impacto:** IE inválida gera rejeição de NF-e pela Sefaz, impossibilidade de comercializar com o estado, multas fiscais e retrabalho administrativo.
- **Público:** Desenvolvedores .NET de sistemas ERP, contabilidade, fiscal, e-commerce B2B.
- **Critério de sucesso:** Validação em < 1 ms por estado, 100% de cobertura de testes para todas as 27 UFs + DF.

## Escopo

- **In scope:** validação da IE por UF (27 algoritmos + DF), roteamento pelo enum `State`, exceção para estado não suportado, normalização de entrada via `OnlyNumbers`.
- **Out of scope:** formatação/máscara por estado (coberta em `req-0018`), consulta a bases externas (Sefaz), persistência.

## Requisitos funcionais

| ID | Descrição | Prioridade |
| -- | --------- | ---------- |
| RF-001 | Validar IE de qualquer UF utilizando o algoritmo específico do estado, via roteamento pelo enum State | Alta |
| RF-002 | Lançar StateNotFoundException para estado não suportado | Alta |
| RF-003 | Tratar entradas nulas/vazias retornando false | Alta |

## Regras de negócio

| ID | Regra |
| -- | ----- |
| RN-001 | Cada UF tem seu próprio algoritmo de validação (quantidade de dígitos, pesos, módulo). O roteamento é feito pelo enum State (27 valores + DF). |
| RN-002 | Os validadores por estado implementam a interface `IInscricaoEstadualValidation` com método `IsValid(string)`. |
| RN-003 | Estado inválido/não suportado → `StateNotFoundException`. |
| RN-004 | A validação normaliza a entrada internamente (OnlyNumbers) antes de aplicar o algoritmo. |

## Critérios de aceitação

```gherkin
Funcionalidade: Validação de Inscrição Estadual
  Cenário: IE de SP válida
    Dado que o valor "123.456.789.123" e UF State.SP são informados
    Quando InscricaoEstadualValidation.IsValid(State.SP, value) é chamado
    Então o resultado deve ser True ou False (depende do valor específico)

  Cenário: IE com UF inválida
    Dado State inválido (ex.: valor fora do enum)
    Quando InscricaoEstadualValidation.IsValid(..., value) é chamado
    Então StateNotFoundException deve ser lançada

  Cenário: IE nula
    Dado null e State.SP
    Quando IsValid é chamado
    Então o resultado deve ser False
```

## NFRs

| Categoria | Requisito | Métrica |
| --------- | --------- | ------- |
| Desempenho | Latência | p95 < 1 ms por validação |
| Cobertura | Testes | 100% para cada UF |
| Extensibilidade | Nova UF | Adicionar nova implementação de IInscricaoEstadualValidation + entry no dicionário de validação |
| Compatibilidade | Multi-target | .NET 8, 9, 10 |

## Matriz de risco local

| ID | Risco | P | I | Score | Nível | Mitigação |
| -- | ----- | - | - | ----- | ----- | --------- |
| RSK-012 | Algoritmo de IE de um estado específico incorreto | 3 | 5 | 15 | Alto | Testes exaustivos por estado; consulta a documentação oficial da Sefaz |
| RSK-014 | Exceção para estado não mapeado não tratada | 1 | 4 | 4 | Baixo | StateNotFoundException lançada antes da validação |

## Rastreabilidade no código

- 27 classes de validação em `Documents/BR/Validation/Ie/`
- Dicionário de roteamento em `InscricaoEstadualValidation.cs`
- Geração em `Mockups/Ie/` (27 classes)
- Enum `State` em `Documents/BR/Enumeration/State.cs`
- Interface `IInscricaoEstadualValidation` e `IInscricaoEstadualInternal`
- Máscaras por estado em `req-0018` (removidas deste requisito)

## Histórico

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 27/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.1.0 | Remoção do conteúdo de máscara (formatação transferida para req-0018); escopo reduzido a validação pura; RF/RN renumerados; APF recalculado para 4 PF |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.1.0 | Realinhamento dos níveis da fatia local à legenda da matriz global: RSK-012 (score 15) Alto; RSK-014 (score 4) Baixo |

## Clarification Log

| Data | Pergunta | Resposta | Status | Origem | Impacto |
| ---- | -------- | -------- | ------ | ------ | ------- |
| 27/07/2026 | A máscara de IE é por estado? | Sim, cada UF tem formato próprio (dicionário _mask). | Resolvido | Criação | Confirma transferência para req-0018. |
| 31/07/2026 | Onde fica a formatação (máscara) da IE após a revisão? | No requisito independente req-0018 (máscaras por estado). Este requisito passa a descrever apenas validação e roteamento. | Resolvido | Implementação | Escopo reduzido; RF/RN de máscara removidos e renumerados. |

### Cobertura 8/8

| # | Área | Status | Justificativa |
| - | ---- | ------ | ------------- |
| 1 | Atores | Resolvido | Desenvolvedores de sistemas fiscais |
| 2 | Fluxos | Resolvido | Roteamento por estado |
| 3 | Exceções | Resolvido | StateNotFoundException, entrada inválida false |
| 4 | Integrações | N/A | Stateless |
| 5 | NFRs | Resolvido | p95 < 1ms, extensibilidade |
| 6 | Dados | Resolvido | IE é dado sensível |
| 7 | Regras | Resolvido | RN-001 a RN-004, 27 algoritmos |
| 8 | Critérios | Resolvido | Gherkin por estado |
