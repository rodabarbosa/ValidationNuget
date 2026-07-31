---
type: req
title: "req-0007 — Mockup CPF — Geração para Testes"
description: "Geração de CPFs válidos para testes, garantindo massa de dados confiável para aplicações .NET que processem documentos brasileiros."
resource: "./requirement/req-0007-mockup-cpf.md"
tags: [documento-brasileiro, geracao, teste]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "req-0007"
  title_pt: "Mockup CPF — Geração para Testes"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "27/07/2026"
  language: pt-BR
---

# req-0007 — Mockup CPF — Geração para Testes

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** `req-0007`
- **Título:** Mockup CPF — Geração para Testes
- **Data de criação:** 27/07/2026
- **Última atualização:** 27/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão:** 1.0.0
- **Status:** Aprovado

## Intenção

- **Problema:** Testes que dependem de CPFs válidos precisam de massa de dados. Gerar CPFs manualmente é propenso a erro e não cobre todos os estados emissores.
- **Impacto:** Testes frágeis e dificuldade de reproduzir cenários reais.
- **Público:** Desenvolvedores .NET escrevendo testes (métodos marcados como `internal`, visíveis apenas para o projeto de teste via `InternalsVisibleTo`).
- **Critério de sucesso:** Geração de CPF válido (que passa por `IsCpfValid`) em < 1 ms, com opção de especificar o estado emissor.

## Requisitos funcionais

| ID | Descrição | Prioridade |
| -- | --------- | ---------- |
| RF-001 | Gerar CPF válido aleatório com 11 dígitos | Média |
| RF-002 | Permitir especificar o estado emissor via parâmetro opcional State | Média |
| RF-003 | CPF gerado deve passar na validação do req-0001 | Média |

## Regras de negócio

| ID | Regra |
| -- | ----- |
| RN-001 | O 9º dígito do CPF identifica o estado emissor; se não especificado, sorteia aleatoriamente entre 0 e 9. |
| RN-002 | Os dígitos verificadores são calculados pelo mesmo algoritmo do req-0001 (módulo 11). |
| RN-003 | A classe é `public`, mas o projeto de teste acessa via `InternalsVisibleTo`. Uso em produção é desencorajado. |

## Critérios de aceitação

```gherkin
Funcionalidade: Geração de CPF para testes
  Cenário: Gerar CPF aleatório
    Dado que Cpf.Generate() é chamado
    Então o resultado deve ser uma string de 11 dígitos
    E CpfValidation.IsValid(resultado) deve retornar True

  Cenário: Gerar CPF para SP
    Dado que Cpf.Generate(State.SP) é chamado
    Então o 9º dígito deve ser 8
    E o CPF deve ser válido
```

## NFRs

| Categoria | Requisito | Métrica |
| --------- | --------- | ------- |
| Desempenho | Geração | < 1 ms |
| Confiabilidade | Validade | 100% dos CPFs gerados devem ser válidos |

## Risco local

| ID | Risco | P | I | Score | Nível |
| -- | ----- | - | - | ----- | ----- |
| RSK-015 | CPF gerado inválido (algoritmo de geração divergente do de validação) | 2 | 4 | 8 | Médio |

## Rastreabilidade

- `Documents/BR/Mockups/Cpf.cs` (método `Generate(State?)`)
- `Documents/BR/Rules/CpfRule.cs` (reutiliza os mesmos pesos)

## Histórico

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 27/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.1.0 | Realinhamento do nível da fatia local à legenda da matriz global: RSK-015 (score 8) Médio |

## Clarification Log (8/8) — OK
