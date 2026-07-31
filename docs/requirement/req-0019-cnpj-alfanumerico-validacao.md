---
type: req
title: "req-0019 — CNPJ Alfanumérico — Validação"
description: "Validação sintática do dígito verificador do CNPJ Alfanumérico (novo formato RFB) para uso por aplicações .NET que processem documentos fiscais brasileiros. Formatação (máscara) é tratada em requisito separado."
resource: "./requirement/req-0019-cnpj-alfanumerico-validacao.md"
tags: [documento-brasileiro, validacao, cnpj-alfanumerico]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-31"
status: rascunho
domain:
  artifact_id: "req-0019"
  title_pt: "CNPJ Alfanumérico — Validação"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "31/07/2026"
  updated: "31/07/2026"
  language: pt-BR
---

# req-0019 — CNPJ Alfanumérico — Validação

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** `req-0019`
- **Título:** CNPJ Alfanumérico — Validação
- **Data de criação:** 31/07/2026
- **Última atualização:** 31/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão:** 1.0.0
- **Status:** Rascunho
- **Bundle:** Não (requisito isolado)

## Objetivo

Disponibilizar validação sintática do dígito verificador do CNPJ Alfanumérico (novo formato estabelecido pela Instrução Normativa RFB nº 2.229/2024), para uso por aplicações .NET que processem documentos fiscais brasileiros. A formatação (máscara) `XX.XXX.XXX/XXXX-XX` é tratada em requisito independente. O novo formato permite letras (A-Z) nas 12 primeiras posições, mantendo os 2 dígitos verificadores como numéricos.

## Escopo

- **In scope:** validação do CNPJ Alfanumérico (14 caracteres, 12 alfanuméricos + 2 dígitos verificadores numéricos), cálculo dos dígitos verificadores pelo algoritmo módulo 11 com conversão ASCII-48, normalização de entrada via `OnlyNumbers` (aceita CNPJ com pontuação), coexistência com validação numérica existente (`IsCnpjValid`).
- **Out of scope:** formatação/máscara (requisito separado), consulta a bases externas (Sefaz, Receita Federal), validação de situação cadastral, validação de CPF/outros documentos, persistência, geração de CNPJ alfanumérico (mockup — requisito separado).

## Intenção / Motivação de Negócio (Por quê)

- **Problema de negócio real:** A partir de julho de 2026, a Receita Federal iniciará a emissão de novos CNPJs no formato alfanumérico. Aplicações empresariais brasileiras que processam CNPJ precisam validar sintaticamente ambos os formatos (numérico legado e alfanumérico novo) antes de emitir NF-e, cadastrar fornecedores ou integrar com ERPs. CNPJs alfanuméricos inválidos gerarão rejeição fiscal e retrabalho administrativo.
- **Por que importa:** A validação local (sem chamada de rede) elimina latência de consulta a serviços externos, reduz custos operacionais e acelera o fluxo de cadastro e faturamento. O algoritmo mantém a mesma estrutura de pesos do CNPJ numérico, mudando apenas a conversão de caracteres (ASCII - 48).
- **Público afetado:** Desenvolvedores .NET que constroem sistemas ERP, e-commerce, fintechs, contabilidade e sistemas fiscais que precisam suportar o novo formato a partir de julho/2026.
- **Critério de sucesso:** Validação executada em < 1 ms (p95), com 100% de cobertura de testes, rejeitando CNPJs alfanuméricos com dígitos verificadores incorretos, sequências repetidas, e aceitando CNPJs numéricos legados.

## Artefatos relacionados

### Impactantes

- `constituicao.md` — SEC-06, SEC-07, PERF-01
- `architecture-tech-stack.md`
- `req-0002-cnpj-validacao.md` — validação CNPJ numérico (coexistência)

### Impactados

- `tec-req-0019-cnpj-alfanumerico-validacao.md`
- `apf/apf-req-0019.md`
- `analise/analise-req-0019.md`
- `checklist/checklist-req-0019.md`
- `system-risk-matrix.md`
- `tamanho-aplicacao.md`

## Requisitos funcionais

| ID     | Descrição                                                                                                                                 | Prioridade | RN associada   |
| ------ | ----------------------------------------------------------------------------------------------------------------------------------------- | ---------- | -------------- |
| RF-001 | Validar CNPJ Alfanumérico calculando os dois dígitos verificadores (13º e 14º caracteres) pelo algoritmo módulo 11 com conversão ASCII-48 | Alta       | RN-001, RN-002 |
| RF-002 | Rejeitar CNPJs Alfanuméricos com todos os caracteres repetidos (ex.: AAAAAAAAAAAAAA)                                                      | Alta       | RN-003         |
| RF-003 | Tratar entradas nulas/vazias retornando `false`                                                                                           | Alta       | RN-003         |
| RF-004 | Aceitar CNPJ numérico legado (14 dígitos) como entrada válida — retrocompatibilidade                                                      | Alta       | RN-004         |
| RF-005 | Normalizar entrada removendo máscara (pontuação) via `OnlyNumbers` antes da validação                                                     | Alta       | RN-005         |

## Regras de negócio

| ID     | Regra                                                                                                                                                                                                                                                                                                                                              | Origem                                                                  | Impacto      |
| ------ | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------- | ------------ |
| RN-001 | O CNPJ Alfanumérico possui 14 caracteres: 12 primeiros alfanuméricos (0-9, A-Z) e 2 últimos numéricos (dígitos verificadores). O 1º DV usa pesos 5,4,3,2,9,8,7,6,5,4,3,2 sobre os 12 primeiros; o 2º DV usa pesos 6,5,4,3,2,9,8,7,6,5,4,3,2 sobre os 13 primeiros.                                                                                 | Legislação (IN RFB 2.229/2024, Nota Técnica COCAD/SUARA/RFB nº 49/2024) | Algoritmo    |
| RN-002 | Conversão de caracteres para cálculo: cada caractere (dígito ou letra) é convertido pelo seu valor decimal ASCII subtraído de 48. Dígitos 0-9 (ASCII 48-57) → valores 0-9; Letras A-Z (ASCII 65-90) → valores 17-42. Cálculo do DV por módulo 11: soma dos produtos; resto da divisão por 11; se resto < 2, dígito = 0; senão dígito = 11 - resto. | Legislação (IN RFB 2.229/2024)                                          | Algoritmo    |
| RN-003 | CNPJs Alfanuméricos com sequência de caracteres repetidos ou nulo/vazio rejeitados.                                                                                                                                                                                                                                                                | Boa prática                                                             | Validação    |
| RN-004 | CNPJs numéricos legados (apenas dígitos 0-9) devem continuar sendo validados corretamente — o algoritmo ASCII-48 é retrocompatível (dígitos 0-9 mantêm seus valores originais).                                                                                                                                                                    | Retrocompatibilidade                                                    | Coexistência |
| RN-005 | A normalização de entrada remove caracteres não alfanuméricos (pontuação: `.`, `/`, `-`) antes da validação, via `StringExtension.OnlyNumbers()`.                                                                                                                                                                                                  | Boa prática / Implementação                                             | Entrada      |

## Critérios de aceitação

```gherkin
Funcionalidade: Validação de CNPJ Alfanumérico

  Cenário: CNPJ Alfanumérico válido com pontuação
    Dado que o valor "12.ABC.345/01DE-35" é informado
    Quando o método IsCnpjAlfanumericoValid() é chamado
    Então o resultado deve ser True

  Cenário: CNPJ Alfanumérico válido sem pontuação
    Dado que o valor "12ABC34501DE35" é informado
    Quando o método IsCnpjAlfanumericoValid() é chamado
    Então o resultado deve ser True

  Cenário: CNPJ Alfanumérico com dígitos verificadores inválidos
    Dado que o valor "12ABC34501DE00" é informado
    Quando o método IsCnpjAlfanumericoValid() é chamado
    Então o resultado deve ser False

  Cenário: CNPJ Alfanumérico com caracteres repetidos
    Dado que o valor "AAAAAAAAAAAAAA" é informado
    Quando o método IsCnpjAlfanumericoValid() é chamado
    Então o resultado deve ser False

  Cenário: CNPJ Alfanumérico com menos de 14 caracteres
    Dado que o valor "12ABC34501DE" é informado
    Quando o método IsCnpjAlfanumericoValid() é chamado
    Então o resultado deve ser False

  Cenário: CNPJ Alfanumérico nulo ou vazio
    Dado que o valor null é informado
    Quando o método IsCnpjAlfanumericoValid() é chamado
    Então o resultado deve ser False

  Cenário: CNPJ numérico legado válido (retrocompatibilidade)
    Dado que o valor "12345678000195" é informado
    Quando o método IsCnpjAlfanumericoValid() é chamado
    Então o resultado deve ser True

  Cenário: CNPJ numérico legado com pontuação (retrocompatibilidade)
    Dado que o valor "12.345.678/0001-95" é informado
    Quando o método IsCnpjAlfanumericoValid() é chamado
    Então o resultado deve ser True
```

## Requisitos não funcionais

| Categoria        | Requisito               | Métrica                                                                |
| ---------------- | ----------------------- | ---------------------------------------------------------------------- |
| Desempenho       | Latência                | p95 < 1 ms, p99 < 5 ms                                                 |
| Desempenho       | Throughput              | > 100.000 validações/s por núcleo                                      |
| Segurança        | ReDoS                   | Regex simples (OnlyNumbers), sem backtracking catastrófico             |
| Segurança        | Dados sensíveis em logs | Documentação alerta para não logar CNPJ bruto; mascarar antes de logar |
| Manutenibilidade | Cobertura               | 100% linha/branch                                                      |
| Compatibilidade  | Multi-target            | .NET 8, 9, 10                                                          |
| Compatibilidade  | Retrocompatibilidade    | Aceita CNPJ numérico legado sem breaking changes                       |

## Matriz de risco local

| ID      | Risco                                                      | P   | I   | Score | Nível | Mitigação                                                                                                   |
| ------- | ---------------------------------------------------------- | --- | --- | ----- | ----- | ----------------------------------------------------------------------------------------------------------- |
| RSK-019 | Algoritmo de validação incorreto (falso positivo/negativo) | 2   | 5   | 10    | Alto  | Testes exaustivos com massa de CNPJs alfanuméricos válidos/inválidos; benchmark em CI; casos de borda ASCII |
| RSK-020 | Quebra de retrocompatibilidade com CNPJ numérico           | 2   | 5   | 10    | Alto  | Testes de regressão abrangentes cobrindo formato numérico legado                                            |
| RSK-021 | Performance degradada por conversão ASCII por caractere    | 2   | 3   | 6     | Médio | BenchmarkDotNet com MemoryDiagnoser, gate de regressão > 10%                                                |

## Histórico de alterações

| Data       | Autor                  | Versão | Alteração            |
| ---------- | ---------------------- | ------ | -------------------- |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.0.0  | Criação do documento |

## Clarification Log

| Data       | Pergunta                                                                                                | Resposta                                                                                                                                 | Status    | Origem  | Impacto                     |
| ---------- | ------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------- | --------- | ------- | --------------------------- |
| 31/07/2026 | O método IsCnpjValid() existente deve detectar automaticamente o formato ou deve haver método separado? | Método separado `IsCnpjAlfanumericoValid()` para clareza; `IsCnpjValid()` mantém comportamento atual (apenas numérico). Ambos coexistem. | Resolvido | Criação | Define API pública          |
| 31/07/2026 | As letras I, O, Q, F devem ser rejeitadas?                                                              | Não. A Receita Federal recomenda evitar, mas não proíbe. Validação aceita todas A-Z. Controle de combinações proibidas é interno à RFB.  | Resolvido | Criação | Define escopo de validação  |
| 31/07/2026 | A máscara do CNPJ alfanumérico muda?                                                                    | Não. Mesma máscara visual: `XX.XXX.XXX/XXXX-XX` (req separado para máscara).                                                             | Resolvido | Criação | Confirma formato visual     |
| 31/07/2026 | Existe método GetIssuingState para CNPJ alfanumérico?                                                   | Não. CNPJ não tem estado emissor (diferente do CPF).                                                                                     | Resolvido | Criação | Remove método não aplicável |

### Cobertura do Clarification (8 áreas)

| #   | Área                             | Status    | Justificativa                                |
| --- | -------------------------------- | --------- | -------------------------------------------- |
| 1   | Atores e personas                | Resolvido | Desenvolvedor .NET                           |
| 2   | Fluxos principais e alternativos | Resolvido | Happy path + rejeição + retrocompatibilidade |
| 3   | Exceções e erros                 | Resolvido | Entrada inválida/vazia retorna false         |
| 4   | Integrações externas             | N/A       | Stateless                                    |
| 5   | NFRs                             | Resolvido | p95 < 1ms                                    |
| 6   | Dados e privacidade              | Resolvido | CNPJ é dado sensível (LGPD)                  |
| 7   | Validações                       | Resolvido | RN-001 a RN-005                              |
| 8   | Critérios de aceite              | Resolvido | Gherkin + NFRs                               |

**Cobertura atual:** 8/8. **Meta:** 8/8 (OK).
