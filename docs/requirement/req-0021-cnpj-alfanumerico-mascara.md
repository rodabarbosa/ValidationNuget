---
type: req
title: "req-0021 — CNPJ Alfanumérico — Máscara"
description: "Aplicação de máscara no formato XX.XXX.XXX/XXXX-XX para CNPJs Alfanuméricos válidos, com remoção automática de caracteres de pontuação (., /, -) antes da formatação."
resource: "./requirement/req-0021-cnpj-alfanumerico-mascara.md"
tags: [documento-brasileiro, mascara, cnpj-alfanumerico]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-31"
status: rascunho
domain:
  artifact_id: "req-0021"
  title_pt: "CNPJ Alfanumérico — Máscara"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "31/07/2026"
  updated: "31/07/2026"
  language: pt-BR
---

# req-0021 — CNPJ Alfanumérico — Máscara

## Metadados

> Esta tabela é uma **reflexão** do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

| Campo | Valor |
|---|---|
| **Código do documento** | `req-0021` |
| **Título** | CNPJ Alfanumérico — Máscara |
| **Versão** | 1.0.0 |
| **Autor** | Rodrigo Araujo Barbosa |
| **Data de criação** | 31/07/2026 |
| **Última atualização** | 31/07/2026 |
| **Status** | Rascunho |

## Objetivo

Disponibilizar formatação (máscara) de CNPJ Alfanumérico no padrão brasileiro `XX.XXX.XXX/XXXX-XX` para uso por aplicações .NET que precisem exibir ou armazenar CNPJs Alfanuméricos formatados (novo formato RFB IN 2.229/2024).

## Escopo

### In scope
- Aplicação de máscara `XX.XXX.XXX/XXXX-XX` em strings contendo 14 caracteres alfanuméricos (12 alfanuméricos + 2 dígitos verificadores numéricos)
- Remoção automática de caracteres de pontuação (`.`, `/`, `-`) antes da formatação (via `RemoveCnpjMask`)
- Retorno de `null` para entradas nulas ou vazias
- Método de extensão `PlaceCnpjAlfanumericoMask()` disponível sobre `string`
- Método de extensão `RemoveCnpjAlfanumericoMask()` para remoção de máscara

### Out of scope
- Validação de dígitos verificadores (coberto em `req-0019`)
- Consulta a bases externas (Sefaz, Receita Federal)
- Persistência ou armazenamento
- Geração de CNPJ Alfanumérico para testes (coberto em `req-0020`)

## Intenção / Motivação de Negócio (Por quê)

- **Problema de negócio real:** A partir de julho de 2026, a Receita Federal iniciará a emissão de novos CNPJs no formato alfanumérico. Aplicações empresariais brasileiras precisam exibir CNPJs Alfanuméricos no formato oficial com pontos, barra e traço (`XX.XXX.XXX/XXXX-XX`) em notas fiscais (NF-e), relatórios, cadastros de fornecedores e integrações com ERPs. A formatação manual é propensa a erros e inconsistências.
- **Por que importa:** CNPJs Alfanuméricos mal formatados gerarão rejeição em layouts fiscais (SPED, NF-e), inconsistência em documentos oficiais e retrabalho em integrações contábeis e fiscais. Uma máscara centralizada garante padrão único.
- **Público afetado:** Desenvolvedores .NET que constroem sistemas ERP, e-commerce, fintechs, contabilidade, sistemas fiscais e qualquer aplicação que emita NF-e e precise suportar o novo formato a partir de julho/2026.
- **Critério de sucesso:** Máscara aplicada corretamente em < 1 ms (p95), sem alocação desnecessária, compatível com .NET 8/9/10, 100% de cobertura de testes.

## Artefatos relacionados

### Documentos/requisitos que impactam este artefato
- `constituicao.md` — princípios de performance (PERF-01, PERF-02), segurança (SEC-06, SEC-07)
- `architecture-tech-stack.md` — stack tecnológico, fluxo de dados
- `req-0019-cnpj-alfanumerico-validacao.md` — validação de CNPJ Alfanumérico (requisito base)

### Documentos/requisitos impactados por este artefato
- `tec-req-0021-cnpj-alfanumerico-mascara.md` — especificação técnica
- `apf/apf-req-0021.md` — pontos de função
- `analise/analise-req-0021.md` — análise cross-artifact
- `checklist/checklist-req-0021.md` — quality checklist
- `system-risk-matrix.md` — riscos do sistema
- `tamanho-aplicacao.md` — consolidado APF

## Descrição geral

- **Contexto:** CNPJ Alfanumérico é o novo formato de identificação de pessoas jurídicas no Brasil (IN RFB 2.229/2024), composto por 14 caracteres (12 alfanuméricos + 2 dígitos verificadores numéricos). O padrão oficial de exibição usa máscara `XX.XXX.XXX/XXXX-XX` (mesmo visual do CNPJ numérico).
- **Problema que resolve:** Padroniza a formatação de CNPJ Alfanumérico em toda a aplicação, removendo a necessidade de formatação manual repetida e inconsistente.
- **Ator principal:** Desenvolvedor .NET (consumidor da biblioteca).
- **Gatilho:** Chamada ao método `PlaceCnpjAlfanumericoMask()` (extension method) ou `CnpjAlfanumericoValidation.PlaceMask()`.
- **Resultado esperado:** String formatada no padrão `XX.XXX.XXX/XXXX-XX` ou `null` para entrada vazia/nula.

## Wireframe da página/interface

### N/A — Biblioteca sem interface de usuário

A biblioteca Sirb.Validation é uma biblioteca de classes .NET (NuGet) puramente computacional, sem interface gráfica. Não há wireframe aplicável.

## Requisitos funcionais

| ID | Descrição | Prioridade | Regra de negócio associada |
| -- | --------- | ---------- | -------------------------- |
| RF-001 | O sistema deve aplicar máscara no formato `XX.XXX.XXX/XXXX-XX` a strings com 14 caracteres alfanuméricos | Alta | RN-001 |
| RF-002 | O sistema deve remover caracteres de pontuação (`.`, `/`, `-`) antes de aplicar a máscara | Alta | RN-002 |
| RF-003 | O sistema deve retornar `null` para entradas nulas ou vazias | Alta | RN-003 |
| RF-004 | O método deve estar disponível como extension method `PlaceCnpjAlfanumericoMask()` sobre `string` | Alta | RN-004 |
| RF-005 | O método deve estar disponível como extension method `RemoveCnpjAlfanumericoMask()` para remover máscara | Alta | RN-005 |

## Regras de negócio

| ID | Regra | Origem | Impacto |
| -- | ----- | ------ | ------- |
| RN-001 | A máscara do CNPJ Alfanumérico segue o padrão `XX.XXX.XXX/XXXX-XX`, aplicada via regex `(.{2})(.{3})(.{3})(.{4})(.{2})` → `$1.$2.$3/$4-$5` (mesmo padrão visual do CNPJ numérico) | Padrão oficial (IN RFB) | Formatação |
| RN-002 | Caracteres de pontuação (`.`, `/`, `-`) são removidos via `RemoveCnpjMask()` (regex `[./-]`) antes da aplicação da máscara, preservando letras e dígitos | Boa prática / Código existente | Normalização de entrada |
| RN-003 | Entrada nula, vazia ou apenas whitespace retorna `null` (não string vazia) | Comportamento atual do código | Tratamento de borda |
| RN-004 | API pública exposta como extension method `PlaceCnpjAlfanumericoMask()` em `CnpjAlfanumericoExtension` (namespace `Sirb.Validation.Extensions`) | Design da biblioteca | Descoberta via IntelliSense |
| RN-005 | API pública exposta como extension method `RemoveCnpjAlfanumericoMask()` em `CnpjAlfanumericoExtension` para remover apenas pontuação | Design da biblioteca | Descoberta via IntelliSense |

## Critérios de aceitação

```gherkin
Funcionalidade: Máscara de CNPJ Alfanumérico
  Como um desenvolvedor .NET
  Quero aplicar máscara em números de CNPJ Alfanumérico
  Para exibir CNPJs no formato oficial brasileiro (IN RFB 2.229/2024)

  Cenário: Aplicar máscara em CNPJ Alfanumérico sem formatação
    Dado que o valor "12ABC34501DE35" é informado
    Quando o método PlaceCnpjAlfanumericoMask() é chamado
    Então o resultado deve ser "12.ABC.345/01DE-35"

  Cenário: Aplicar máscara em CNPJ Alfanumérico já formatado
    Dado que o valor "12.ABC.345/01DE-35" é informado
    Quando o método PlaceCnpjAlfanumericoMask() é chamado
    Então o resultado deve ser "12.ABC.345/01DE-35"

  Cenário: Aplicar máscara em CNPJ Alfanumérico com caracteres mistos
    Dado que o valor "12a.BC3-45/01dE35" é informado
    Quando o método PlaceCnpjAlfanumericoMask() é chamado
    Então o resultado deve ser "12.ABC.345/01DE-35"

  Cenário: Aplicar máscara em string vazia
    Dado que o valor "" é informado
    Quando o método PlaceCnpjAlfanumericoMask() é chamado
    Então o resultado deve ser null

  Cenário: Aplicar máscara em valor nulo
    Dado que o valor null é informado
    Quando o método PlaceCnpjAlfanumericoMask() é chamado
    Então o resultado deve ser null

  Cenário: Aplicar máscara em string com apenas whitespace
    Dado que o valor "   " é informado
    Quando o método PlaceCnpjAlfanumericoMask() é chamado
    Então o resultado deve ser null

  Cenário: Remover máscara de CNPJ Alfanumérico
    Dado que o valor "12.ABC.345/01DE-35" é informado
    Quando o método RemoveCnpjAlfanumericoMask() é chamado
    Então o resultado deve ser "12ABC34501DE35"

  Cenário: Extension method descobrível via IntelliSense
    Dado uma variável string cnpj = "12ABC34501DE35"
    Quando o desenvolvedor digita "cnpj."
    Então PlaceCnpjAlfanumericoMask() deve aparecer nas sugestões do IntelliSense
```

## Requisitos não funcionais

| Categoria | Requisito | Métrica/critério |
| --------- | --------- | ---------------- |
| Desempenho | Latência de máscara | p95 < 1 ms, p99 < 5 ms em .NET 8+ |
| Desempenho | Throughput | > 100.000 operações/segundo por núcleo |
| Desempenho | Alocação zero no hot path | PlaceMask não deve alocar strings intermediárias desnecessárias |
| Segurança | Proteção contra ReDoS | Regex simples, sem backtracking catastrófico |
| Segurança | Dados sensíveis em logs | Documentação alerta para não logar CNPJ bruto; usar PlaceMask() antes de logar |
| Usabilidade | API fluente | Extension method sobre `string` para descoberta via IntelliSense |
| Manutenibilidade | Cobertura de testes | 100% de cobertura de linha/branch nos cenários de máscara |
| Compatibilidade | Multi-target | Compatível com .NET 8, 9 e 10 |

## Matriz de risco do requisito (recorte)

| ID | Risco | Probabilidade (1-5) | Impacto (1-5) | Score | Nível | Mitigação |
| -- | ----- | ------------------- | ------------- | ----- | ----- | --------- |
| RSK-035 | Regex de máscara com erro de formatação CNPJ Alfanumérico | 1 | 3 | 3 | Baixo | Testes unitários para PlaceMask com vários formatos de entrada alfanumérica |
| RSK-036 | Performance degradada por alocação excessiva | 2 | 3 | 6 | Médio | BenchmarkDotNet com MemoryDiagnoser, gate de regressão > 10% |

## Análise de Pontos de Função (APF) vinculada

- **Documento APF obrigatório:** `apf-req-0021.md`
- **Localização:** `docs/requirement/apf/apf-req-0021.md`

## Impactos técnicos

### Backend / Biblioteca
- Método `PlaceMask` em `CnpjAlfanumericoValidation.cs` (já implementado)
- Extension method `PlaceCnpjAlfanumericoMask` em `CnpjAlfanumericoExtension.cs` (já implementado)
- Extension method `RemoveCnpjAlfanumericoMask` em `CnpjAlfanumericoExtension.cs` (já implementado)
- Usa `CnpjAlfanumericoValidation.RemoveMask()` / `RemoveCnpjMask()` para normalização

### Frontend / UI
- N/A — biblioteca sem interface

### Banco de dados
- N/A — biblioteca stateless sem persistência

### Integrações externas
- N/A — biblioteca sem dependências externas

### Design / UX
- N/A — biblioteca sem interface

## Rastreabilidade

| Item | Referência |
| ---- | ---------- |
| Requisito de validação base | `req-0019-cnpj-alfanumerico-validacao.md` |
| Classe de validação | `Sirb.Validation/Documents/BR/Validation/CnpjAlfanumericoValidation.cs` (método `PlaceMask`) |
| Extension method API pública | `Sirb.Validation/Extensions/CnpjAlfanumericoExtension.cs` (métodos `PlaceCnpjAlfanumericoMask`, `RemoveCnpjAlfanumericoMask`) |
| Testes | `Sirb.Validation.Test/Extensions/CnpjAlfanumericoExtensionTest.cs` |

## Validações realizadas para esta documentação

- [ ] README do projeto analisado
- [ ] Código principal analisado (`CnpjAlfanumericoValidation.cs`, `CnpjAlfanumericoExtension.cs`)
- [ ] Testes existentes analisados
- [ ] Documentações relacionadas revisadas (`constituicao.md`, `architecture-tech-stack.md`, `req-0019`)
- [ ] Matriz global de risco do sistema atualizada
- [ ] Documento APF do requisito criado
- [ ] Wireframe: N/A (biblioteca sem interface)

## Histórico de alterações

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação do documento |

## Clarification Log

| Data | Pergunta | Resposta | Status (Resolvido/Pendente) | Origem (Criação/Implementação) | Impacto no requisito |
| ---- | -------- | -------- | --------------------------- | ------------------------------ | --------------------- |
| 31/07/2026 | O PlaceMask deve validar o CNPJ Alfanumérico antes de mascarar? | Não. Apenas formata. Validação é responsabilidade de IsValid (req-0019). | Resolvido | Criação | Define escopo: máscara pura, sem validação. |
| 31/07/2026 | Qual o comportamento para string com menos de 14 caracteres? | A regex não casa, retorna a string normalizada (sem máscara). | Resolvido | Criação | Define cenário de borda. |
| 31/07/2026 | O método deve lançar exceção para entrada inválida? | Não. Retorna null para vazio/nulo; outros casos aplicam regex. | Resolvido | Criação | Comportamento defensivo. |
| 31/07/2026 | Existe método RemoveMask específico para CNPJ Alfanumérico? | Sim. `CnpjAlfanumericoValidation.RemoveMask()` usa regex `[./-]` removendo apenas pontuação, preservando letras. | Resolvido | Criação | Confirma API específica. |
| 31/07/2026 | A máscara deve preservar letras minúsculas? | Não. A normalização remove pontuação mas não converte case. A regex de máscara casa qualquer char. | Resolvido | Criação | Comportamento de normalização. |
| 31/07/2026 | Qual a diferença entre PlaceMask e PlaceCnpjAlfanumericoMask? | PlaceMask interno em CnpjAlfanumericoValidation; PlaceCnpjAlfanumericoMask extension público. | Resolvido | Criação | Define arquitetura de camadas. |
| 31/07/2026 | O código atual trata whitespace-only como vazio? | Sim. `value?.Trim()` + `string.IsNullOrEmpty` no PlaceMask. | Resolvido | Criação | Confirma comportamento. |
| 31/07/2026 | A máscara visual é igual à do CNPJ numérico? | Sim. Mesmo padrão `XX.XXX.XXX/XXXX-XX` (req-0015). | Resolvido | Criação | Consistência visual. |

### Cobertura do Clarification (8 áreas)

| # | Área | Status | Ref. entrada no Log | Justificativa (se N/A) |
| - | ---- | ------ | ------------------- | ---------------------- |
| 1 | Atores e personas | Resolvido | Desenvolvedor .NET consumidor | — |
| 2 | Fluxos principais e alternativos | Resolvido | Cenários Gherkin | — |
| 3 | Exceções e erros | Resolvido | Entrada vazia/nula retorna null | — |
| 4 | Integrações externas | Resolvido | N/A — stateless | Justificativa: sem dependências |
| 5 | Requisitos não-funcionais | Resolvido | Performance, segurança, usabilidade | — |
| 6 | Dados e privacidade | Resolvido | CNPJ sensível; não logar bruto | — |
| 7 | Validações e regras de negócio | Resolvido | RN-001 a RN-005 | — |
| 8 | Critérios de aceite e mensurabilidade | Resolvido | Gherkin + NFRs métricas | — |

**Cobertura atual:** 8/8. **Meta:** 8/8 (OK).