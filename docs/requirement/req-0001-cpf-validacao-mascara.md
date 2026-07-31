---
type: req
title: "req-0001 — CPF — Validação e Máscara"
description: "Validação sintática do dígito verificador do CPF e formatação (máscara) no padrão 000.000.000-00, para uso por aplicações .NET que processem documentos fiscais brasileiros."
resource: "./requirement/req-0001-cpf-validacao-mascara.md"
tags: [documento-brasileiro, validacao, mascara]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "req-0001"
  title_pt: "CPF — Validação e Máscara"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "27/07/2026"
  language: pt-BR
---

# req-0001 — CPF — Validação e Máscara

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** `req-0001`
- **Título:** CPF — Validação e Máscara
- **Data de criação:** 27/07/2026
- **Última atualização:** 27/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão:** 1.0.0
- **Status:** Aprovado
- **Bundle:** Não (requisito isolado)

## Objetivo

Disponibilizar validação sintática do dígito verificador do CPF (Cadastro de Pessoas Físicas) e formatação (máscara) no padrão `000.000.000-00`, para uso por aplicações .NET que processem documentos fiscais brasileiros.

## Escopo

- **In scope:** validação do CPF (11 dígitos, com cálculo dos dígitos verificadores), aplicação de máscara `000.000.000-00`, remoção de máscara (apenas dígitos), obtenção do estado emissor do CPF.
- **Out of scope:** consulta a bases externas (Sefaz, Receita Federal), validação de situação cadastral (CPF regular/irregular), autenticação de usuários, persistência.

## Intenção / Motivação de Negócio (Por quê)

- **Problema de negócio real:** Aplicações brasileiras que processam CPF precisam garantir que o número informado é sintaticamente válido antes de enviá-lo para sistemas externos (Sefaz, bancos, cadastros). CPFs inválidos geram retrabalho, rejeição em integrações e inconsistência de dados cadastrais.
- **Por que importa:** Cada validação incorreta ou ausente pode resultar em transação rejeitada, retrabalho operacional e insatisfação do usuário. A validação local (sem chamada de rede) reduz latência e dependência de serviços externos.
- **Público afetado:** Desenvolvedores .NET que constroem sistemas ERP, e-commerce, fintechs, sistemas públicos ou qualquer aplicação que colete/processe CPF.
- **Critério de sucesso:** Validação executada em memória em < 1 ms (p95), sem dependências externas, com 100% de cobertura de testes nos cenários válidos e inválidos.

## Artefatos relacionados

### Documentos/requisitos que impactam este artefato

- `constituicao.md` — princípios de segurança (SEC-06, SEC-07), performance (PERF-01, PERF-02)
- `architecture-tech-stack.md` — stack tecnológico, fluxo de dados

### Documentos/requisitos impactados por este artefato

- `tec-req-0001-cpf-validacao-mascara.md` — especificação técnica
- `apf/apf-req-0001.md` — pontos de função
- `analise/analise-req-0001.md` — análise cross-artifact
- `checklist/checklist-req-0001.md` — quality checklist
- `system-risk-matrix.md` — riscos do sistema
- `tamanho-aplicacao.md` — consolidado APF

## Descrição geral

- **Contexto:** CPF é o documento primário de identificação do cidadão brasileiro, composto por 11 dígitos numéricos com 2 dígitos verificadores calculados por módulo 11.
- **Problema que resolve:** Evita que CPFs inválidos (com dígitos verificadores incorretos ou sequências obviamente falsas como 000.000.000-00) sejam aceitos pelo sistema.
- **Ator principal:** Desenvolvedor .NET (consumidor da biblioteca).
- **Gatilho:** Chamada ao método `IsCpfValid()` ou `PlaceCpfMask()` em uma string.
- **Resultado esperado:** `true` ou `false` para validação; string formatada para máscara; string apenas com dígitos para remoção de máscara.

## Wireframe da página/interface

### N/A — Biblioteca sem interface de usuário

A biblioteca Sirb.Validation é uma biblioteca de classes .NET (NuGet) puramente computacional, sem interface gráfica. Não há wireframe aplicável.

## Requisitos funcionais

| ID     | Descrição                                                                                                        | Prioridade | Regra de negócio associada |
| ------ | ---------------------------------------------------------------------------------------------------------------- | ---------- | -------------------------- |
| RF-001 | O sistema deve validar CPF calculando os dois dígitos verificadores (10º e 11º dígitos) pelo algoritmo módulo 11 | Alta       | RN-001, RN-002             |
| RF-002 | O sistema deve rejeitar CPFs com todos os dígitos repetidos (ex.: 111.111.111-11)                                | Alta       | RN-003                     |
| RF-003 | O sistema deve aplicar máscara no formato `000.000.000-00`                                                       | Alta       | RN-004                     |
| RF-004 | O sistema deve remover qualquer máscara/documentação, retornando apenas dígitos                                  | Alta       | RN-005                     |
| RF-005 | O sistema deve identificar o estado emissor do CPF a partir do 9º dígito                                         | Média      | RN-006                     |
| RF-006 | O sistema deve validar entradas nulas ou vazias retornando `false`                                               | Alta       | RN-003                     |

## Regras de negócio

| ID     | Regra                                                                                                                                                                                                                  | Origem              | Impacto                |
| ------ | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------- | ---------------------- |
| RN-001 | O CPF possui 11 dígitos, sendo os 2 últimos os dígitos verificadores. O 1º dígito verificador é calculado pelos pesos 10 a 2 sobre os 9 primeiros dígitos; o 2º dígito usa pesos 11 a 2 sobre os 10 primeiros dígitos. | Legislação (IN RFB) | Algoritmo de validação |
| RN-002 | O cálculo do dígito verificador usa módulo 11: soma dos produtos dos dígitos pelos pesos; resto da divisão por 11; se resto < 2, dígito = 0; senão dígito = 11 - resto.                                                | Legislação (IN RFB) | Algoritmo de validação |
| RN-003 | CPFs com sequência de dígitos repetidos (ex.: 000.000.000-00) ou string vazia/nula devem ser rejeitados.                                                                                                               | Boa prática         | Validação de entrada   |
| RN-004 | A máscara do CPF segue o padrão `000.000.000-00`, aplicada via regex.                                                                                                                                                  | Padrão oficial      | Formatação             |
| RN-005 | O 9º dígito do CPF indica a UF de emissão do documento (ex.: 1 = DF/GO/MS/TO, 8 = SP).                                                                                                                                 | Legislação          | RF-005                 |

## Critérios de aceitação

```gherkin
Funcionalidade: Validação de CPF
  Como um desenvolvedor .NET
  Quero validar números de CPF
  Para garantir que apenas CPFs com dígitos verificadores corretos sejam processados

  Cenário: CPF válido com máscara
    Dado que o valor "123.456.789-09" é informado
    Quando o método IsCpfValid() é chamado
    Então o resultado deve ser True

  Cenário: CPF válido sem máscara
    Dado que o valor "12345678909" é informado
    Quando o método IsCpfValid() é chamado
    Então o resultado deve ser True

  Cenário: CPF com dígitos verificadores inválidos
    Dado que o valor "12345678900" é informado
    Quando o método IsCpfValid() é chamado
    Então o resultado deve ser False

  Cenário: CPF com dígitos repetidos
    Dado que o valor "11111111111" é informado
    Quando o método IsCpfValid() é chamado
    Então o resultado deve ser False

  Cenário: CPF com menos de 11 dígitos
    Dado que o valor "123456789" é informado
    Quando o método IsCpfValid() é chamado
    Então o resultado deve ser False

  Cenário: CPF nulo ou vazio
    Dado que o valor null é informado
    Quando o método IsCpfValid() é chamado
    Então o resultado deve ser False

  Cenário: Aplicar máscara em CPF válido
    Dado que o valor "12345678909" é informado
    Quando o método PlaceCpfMask() é chamado
    Então o resultado deve ser "123.456.789-09"

  Cenário: Aplicar máscara em CPF vazio
    Dado que o valor "" é informado
    Quando o método PlaceCpfMask() é chamado
    Então o resultado deve ser null

  Cenário: Obter estado emissor de CPF válido
    Dado que o valor "12345678909" é informado
    Quando o método GetIssuingState() é chamado
    Então o resultado deve ser "RS"

  Cenário: Obter estado emissor de CPF inválido lança exceção
    Dado que o valor "12345678900" é informado
    Quando o método GetIssuingState() é chamado
    Então uma exceção InvalidOperationException deve ser lançada com a mensagem "Invalid number"
```

## Requisitos não funcionais

| Categoria        | Requisito                 | Métrica/critério                                                                   |
| ---------------- | ------------------------- | ---------------------------------------------------------------------------------- |
| Desempenho       | Latência de validação     | p95 < 1 ms, p99 < 5 ms em .NET 8+ (BenchmarkDotNet)                                |
| Desempenho       | Throughput                | > 100.000 validações/segundo por núcleo                                            |
| Desempenho       | Alocação zero no hot path | Métodos IsValid e PlaceMask não devem alocar strings intermediárias desnecessárias |
| Segurança        | Proteção contra ReDoS     | Regex simples, sem backtracking catastrófico                                       |
| Segurança        | Dados sensíveis em logs   | Documentação alerta para não logar CPF bruto; usar PlaceMask() antes de logar      |
| Usabilidade      | API fluente               | Métodos de extensão sobre `string` para descoberta via IntelliSense                |
| Manutenibilidade | Cobertura de testes       | 100% de cobertura de linha/branch nos cenários de validação                        |
| Compatibilidade  | Multi-target              | Compatível com .NET 8, 9 e 10                                                      |

## Matriz de risco do requisito (recorte)

| ID      | Risco                                             | Probabilidade (1-5) | Impacto (1-5) | Score | Nível | Mitigação                                                                |
| ------- | ------------------------------------------------- | ------------------- | ------------- | ----- | ----- | ------------------------------------------------------------------------ |
| RSK-001 | Algoritmo de validação incorreto (falso positivo) | 2                   | 5             | 10    | Alto  | Testes exaustivos com massa de CPFs válidos e inválidos; benchmark em CI |
| RSK-002 | Regex de máscara com erro de formatação           | 1                   | 3             | 3     | Baixo | Testes unitários para PlaceMask com vários formatos de entrada           |
| RSK-003 | Performance degradada por alocação excessiva      | 2                   | 3             | 6     | Médio | BenchmarkDotNet com MemoryDiagnoser, gate de regressão > 10%             |

## Análise de Pontos de Função (APF) vinculada

- **Documento APF obrigatório:** `apf-req-0001.md`
- **Localização:** `docs/requirement/apf/apf-req-0001.md`

## Impactos técnicos

### Backend / Biblioteca

- Classe `CpfValidation` com métodos `IsValid()`, `PlaceMask()`, `GetIssuingState()`
- Classe `CpfRule` com pesos de cálculo dos dígitos
- Extension method `CpfExtension` com `IsCpfValid()`, `PlaceCpfMask()`
- Todas em `Sirb.Validation.Documents.BR.Validation` e `Sirb.Validation.Extensions`

### Frontend / UI

- N/A — biblioteca sem interface

### Banco de dados

- N/A — biblioteca stateless sem persistência

### Integrações externas

- N/A — biblioteca sem dependências externas

### Design / UX

- N/A — biblioteca sem interface

## Validações realizadas para esta documentação

- [x] README do projeto analisado
- [x] Código principal e subfunções analisados (CpfValidation.cs, CpfRule.cs, CpfExtension.cs)
- [x] Documentações relacionadas revisadas (constituicao.md, architecture-tech-stack.md)
- [x] Matriz global de risco do sistema atualizada
- [x] Documento APF do requisito criado
- [x] Wireframe: N/A (biblioteca sem interface)

## Histórico de alterações

| Data       | Autor                  | Versão | Alteração            |
| ---------- | ---------------------- | ------ | -------------------- |
| 27/07/2026 | Rodrigo Araujo Barbosa | 1.0.0  | Criação do documento |

## Clarification Log

| Data       | Pergunta                                                | Resposta                                                                                                            | Status (Resolvido/Pendente) | Origem (Criação/Implementação) | Impacto no requisito                                       |
| ---------- | ------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------- | --------------------------- | ------------------------------ | ---------------------------------------------------------- |
| 27/07/2026 | A validação de CPF deve consultar base externa (Sefaz)? | Não. Validação apenas sintática (dígito verificador). Consulta externa é responsabilidade da aplicação consumidora. | Resolvido                   | Criação                        | Define escopo do requisito como validação local apenas.    |
| 27/07/2026 | Deve haver método de geração de CPF para testes?        | Sim, mas como requisito separado (req-0007 — Mockup CPF).                                                           | Resolvido                   | Criação                        | Separação entre req-0001 (validação) e req-0007 (geração). |
| 27/07/2026 | Qual o comportamento esperado para CPF vazio/nulo?      | Retornar `false` para IsValid, `null` para PlaceMask.                                                               | Resolvido                   | Criação                        | Define critério de aceitação para entradas vazias.         |
| 27/07/2026 | A biblioteca precisa logar tentativas de validação?     | Não. Observabilidade é responsabilidade da aplicação consumidora (constituição ARCH-03).                            | Resolvido                   | Criação                        | Remove requisito de logging; alinhado à constituição.      |
| 27/07/2026 | GetIssuingState deve funcionar para CPF inválido?       | Não. Deve lançar InvalidOperationException se CPF inválido (comportamento atual do código).                         | Resolvido                   | Criação                        | Define cenário de exceção em GetIssuingState.              |
| 27/07/2026 | Existe máscara para Renavam?                            | Não. Renavam não possui máscara (requisito req-0005 apenas validação).                                              | Resolvido                   | Criação                        | Define que req-0005 não tem PlaceMask.                     |
| 27/07/2026 | O CPF aceita entrada com caracteres não numéricos?      | Sim. RemoveMask (OnlyNumbers) é chamado internamente antes da validação.                                            | Resolvido                   | Criação                        | Define comportamento de entrada com pontuação.             |
| 27/07/2026 | Qual a métrica de sucesso para performance?             | p95 < 1 ms, p99 < 5 ms, > 100k validações/s por núcleo. Benchmarks em CI.                                           | Resolvido                   | Criação                        | Define NFRs mensuráveis (PERF-01, PERF-02).                |

### Cobertura do Clarification (8 áreas)

| #   | Área                                  | Status    | Ref. entrada no Log                                                                 | Justificativa (se N/A)                                       |
| --- | ------------------------------------- | --------- | ----------------------------------------------------------------------------------- | ------------------------------------------------------------ |
| 1   | Atores e personas                     | Resolvido | Desenvolvedor .NET, contexto de uso da biblioteca                                   | —                                                            |
| 2   | Fluxos principais e alternativos      | Resolvido | RF-001 a RF-006, cenários Gherkin                                                   | —                                                            |
| 3   | Exceções e erros                      | Resolvido | Entrada nula/vazia retorna false; GetIssuingState lança exceção para CPF inválido   | —                                                            |
| 4   | Integrações externas                  | Resolvido | N/A — biblioteca sem dependências externas                                          | Justificativa: biblioteca stateless, puramente computacional |
| 5   | Requisitos não-funcionais             | Resolvido | Performance (p95 < 1 ms), segurança (sem logging), compatibilidade multi-target     | —                                                            |
| 6   | Dados e privacidade                   | Resolvido | CPF é dado sensível (LGPD); não logar valores brutos; usar mask antes de serializar | —                                                            |
| 7   | Validações e regras de negócio        | Resolvido | RN-001 a RN-006, algoritmo módulo 11, rejeição de dígitos repetidos                 | —                                                            |
| 8   | Critérios de aceite e mensurabilidade | Resolvido | Cenários Gherkin com Given/When/Then; NFRs com métricas                             | —                                                            |

**Cobertura atual:** 8/8. **Meta:** 8/8 (OK).
