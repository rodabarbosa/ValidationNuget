---
type: req
title: "req-0006 — Inscrição Estadual (27 UFs + DF) — Validação e Máscara"
description: "Validação sintática da Inscrição Estadual de todos os 27 estados brasileiros + DF e formatação (máscara) por estado, para uso por aplicações .NET que processem documentos fiscais."
resource: "./requirement/req-0006-inscricao-estadual-validacao-mascara.md"
tags: [documento-brasileiro, validacao, mascara, inscricao-estadual]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "req-0006"
  title_pt: "Inscrição Estadual (27 UFs + DF) — Validação e Máscara"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "27/07/2026"
  language: pt-BR
---

# req-0006 — Inscrição Estadual (27 UFs + DF) — Validação e Máscara

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** `req-0006`
- **Título:** Inscrição Estadual (27 UFs + DF) — Validação e Máscara
- **Data de criação:** 27/07/2026
- **Última atualização:** 27/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão:** 1.0.0
- **Status:** Aprovado

## Intenção

- **Problema:** Cada estado brasileiro tem seu próprio formato e algoritmo de validação de Inscrição Estadual (IE). Sistemas fiscais e ERPs precisam validar IE de todos os 27 estados + DF para emissão de NF-e, cadastro de fornecedores e obrigações acessórias.
- **Impacto:** IE inválida gera rejeição de NF-e pela Sefaz, impossibilidade de comercializar com o estado, multas fiscais e retrabalho administrativo.
- **Público:** Desenvolvedores .NET de sistemas ERP, contabilidade, fiscal, e-commerce B2B.
- **Critério de sucesso:** Validação em < 1 ms por estado, 100% de cobertura de testes para todas as 27 UFs + DF.

## Requisitos funcionais

| ID | Descrição | Prioridade |
| -- | --------- | ---------- |
| RF-001 | Validar IE de qualquer UF utilizando o algoritmo específico do estado, via roteamento pelo enum State | Alta |
| RF-002 | Aplicar máscara específica por estado (formato varia conforme a UF) | Alta |
| RF-003 | Remover máscara da IE (apenas dígitos) | Alta |
| RF-004 | Lançar StateNotFoundException para estado não suportado | Alta |
| RF-005 | Tratar entradas nulas/vazias retornando false | Alta |

## Regras de negócio

| ID | Regra |
| -- | ----- |
| RN-001 | Cada UF tem seu próprio algoritmo de validação (quantidade de dígitos, pesos, módulo). O roteamento é feito pelo enum State (27 valores + DF). |
| RN-002 | Os validadores por estado implementam a interface `IInscricaoEstadualValidation` com método `IsValid(string)`. |
| RN-003 | As máscaras por estado são funções `Func<string, string>` registradas em dicionário estático `_mask`. |
| RN-004 | Estado inválido/não suportado → `StateNotFoundException`. |
| RN-005 | A validação remove máscara internamente antes de aplicar o algoritmo. |

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

  Cenário: Aplicar máscara em IE de SP
    Dado "123456789123" e State.SP
    Quando PlaceMask(State.SP, value) é chamado
    Então o resultado deve seguir o formato específico de SP
```

## NFRs

| Categoria | Requisito | Métrica |
| --------- | --------- | ------- |
| Desempenho | Latência | p95 < 1 ms por validação |
| Cobertura | Testes | 100% para cada UF |
| Extensibilidade | Nova UF | Adicionar nova implementação de IInscricaoEstadualValidation + entry nos dicionários |

## Matriz de risco local

| ID | Risco | P | I | Score | Nível | Mitigação |
| -- | ----- | - | - | ----- | ----- | --------- |
| RSK-012 | Algoritmo de IE de um estado específico incorreto | 3 | 5 | 15 | Crítico | Testes exaustivos por estado; consulta a documentação oficial da Sefaz |
| RSK-013 | Máscara de estado específico com formato errado | 2 | 3 | 6 | Médio | Testes de PlaceMask por estado |
| RSK-014 | Exceção para estado não mapeado não tratada | 1 | 4 | 4 | Médio | StateNotFoundException lançada antes da validação |

## Rastreabilidade no código

- 27 classes de validação em `Documents/BR/Validation/Ie/`
- 27 extension methods de máscara em `Extensions/*Extension.cs` (AcreExtension, SaoPauloExtension, etc.)
- Dicionário de roteamento em `InscricaoEstadualValidation.cs`
- Geração em `Mockups/Ie/` (27 classes)
- Enum `State` em `Documents/BR/Enumeration/State.cs`
- Interface `IInscricaoEstadualValidation` e `IInscricaoEstadualInternal`

## Histórico

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 27/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação |

## Clarification Log (8/8)

| # | Área | Status | Justificativa |
| - | ---- | ------ | ------------- |
| 1 | Atores | Resolvido | Desenvolvedores de sistemas fiscais |
| 2 | Fluxos | Resolvido | Roteamento por estado |
| 3 | Exceções | Resolvido | StateNotFoundException, entrada inválida false |
| 4 | Integrações | N/A | Stateless |
| 5 | NFRs | Resolvido | p95 < 1ms, extensibilidade |
| 6 | Dados | Resolvido | IE é dado sensível |
| 7 | Regras | Resolvido | RN-001 a RN-005, 27 algoritmos |
| 8 | Critérios | Resolvido | Gherkin por estado |
