---
type: req
title: "req-0015 — CNPJ — Máscara"
description: "Aplicação de máscara no formato 00.000.000/0000-00 para números de CNPJ válidos, com remoção automática de caracteres não numéricos antes da formatação."
resource: "./requirement/req-0015-cnpj-mascara.md"
tags: [documento-brasileiro, mascara, cnpj]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-31"
verified:
  by: "Rodrigo Araujo Barbosa"
  timestamp: "2026-07-31T02:00:00Z"
  method: "validação com PO"
status: approved
stale_after: "2027-01-31"
domain:
  artifact_id: "req-0015"
  title_pt: "CNPJ — Máscara"
  version: "1.1.0"
  author: "Rodrigo Araujo Barbosa"
  created: "31/07/2026"
  updated: "31/07/2026"
  bundle: "flat"
  language: pt-BR
  coverage_clarification: "8/8"
  cross_artifact_status: "APROVADO"
  quality_checklist: "APROVADO"
  risk_recorte: ["RSK-016", "RSK-017"]
  fpa_pf: 3
---

# req-0015 — CNPJ — Máscara

## Metadados

> Esta tabela é uma **reflexão** do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

| Campo | Valor |
|---|---|
| **Código do documento** | `req-0015` |
| **Título** | CNPJ — Máscara |
| **Versão** | 1.1.0 |
| **Autor** | Rodrigo Araujo Barbosa |
| **Data de criação** | 31/07/2026 |
| **Última atualização** | 31/07/2026 |
| **Status** | Aprovado |
| **Bundle** | `flat` |
| **Cobertura Clarification** | 8/8 |
| **Análise Cross-Artifact** | APROVADO |
| **Quality Checklist** | APROVADO |
| **APF** | 3 PF |
| **Tipo OKF** | `req` |

## Objetivo

Disponibilizar formatação (máscara) de CNPJ no padrão brasileiro `00.000.000/0000-00` para uso por aplicações .NET que precisem exibir ou armazenar CNPJs formatados.

## Escopo

### In scope
- Aplicação de máscara `00.000.000/0000-00` em strings contendo 14 dígitos numéricos
- Remoção automática de caracteres não numéricos antes da formatação (via `RemoveMask`/`OnlyNumbers`)
- Retorno de `null` para entradas nulas ou vazias
- Método de extensão `PlaceCnpjMask()` disponível sobre `string`

### Out of scope
- Validação de dígitos verificadores (coberto em `req-0002`)
- Consulta a bases externas (Sefaz, Receita Federal)
- Persistência ou armazenamento
- Geração de CNPJ para testes (coberto em `req-0008`)

## Intenção / Motivação de Negócio (Por quê)

- **Problema de negócio real:** Aplicações empresariais brasileiras precisam exibir CNPJs no formato oficial com pontos, barra e traço (`00.000.000/0000-00`) em notas fiscais (NF-e), relatórios, cadastros de fornecedores e integrações com ERPs. A formatação manual é propensa a erros e inconsistências.
- **Por que importa:** CNPJs mal formatados geram rejeição em layouts fiscais (SPED, NF-e), inconsistência em documentos oficiais e retrabalho em integrações contábeis e fiscais. Uma máscara centralizada garante padrão único.
- **Público afetado:** Desenvolvedores .NET que constroem sistemas ERP, e-commerce, fintechs, contabilidade, sistemas fiscais e qualquer aplicação que emita NF-e.
- **Critério de sucesso:** Máscara aplicada corretamente em < 1 ms (p95), sem alocação desnecessária, compatível com .NET 8/9/10, 100% de cobertura de testes.

## Artefatos relacionados

### Documentos/requisitos que impactam este artefato
- `constituicao.md` — princípios de performance (PERF-01, PERF-02), segurança (SEC-06, SEC-07)
- `architecture-tech-stack.md` — stack tecnológico, fluxo de dados
- `req-0002-cnpj-validacao.md` — validação de CNPJ (requisito base)

### Documentos/requisitos impactados por este artefato
- `tec-req-0015-cnpj-mascara.md` — especificação técnica
- `apf/apf-req-0015.md` — pontos de função
- `analise/analise-req-0015.md` — análise cross-artifact
- `checklist/checklist-req-0015.md` — quality checklist
- `system-risk-matrix.md` — riscos do sistema
- `tamanho-aplicacao.md` — consolidado APF

## Descrição geral

- **Contexto:** CNPJ é o documento de identificação de pessoas jurídicas no Brasil, composto por 14 dígitos. O padrão oficial de exibição usa máscara `00.000.000/0000-00`.
- **Problema que resolve:** Padroniza a formatação de CNPJ em toda a aplicação, removendo a necessidade de formatação manual repetida e inconsistente.
- **Ator principal:** Desenvolvedor .NET (consumidor da biblioteca).
- **Gatilho:** Chamada ao método `PlaceCnpjMask()` (extension method) ou `CnpjValidation.PlaceMask()`.
- **Resultado esperado:** String formatada no padrão `00.000.000/0000-00` ou `null` para entrada vazia/nula.

## Wireframe da página/interface

### N/A — Biblioteca sem interface de usuário

A biblioteca Sirb.Validation é uma biblioteca de classes .NET (NuGet) puramente computacional, sem interface gráfica. Não há wireframe aplicável.

## Requisitos funcionais

| ID | Descrição | Prioridade | Regra de negócio associada |
| -- | --------- | ---------- | -------------------------- |
| RF-001 | O sistema deve aplicar máscara no formato `00.000.000/0000-00` a strings com 14 dígitos | Alta | RN-001 |
| RF-002 | O sistema deve remover caracteres não numéricos antes de aplicar a máscara | Alta | RN-002 |
| RF-003 | O sistema deve retornar `null` para entradas nulas ou vazias | Alta | RN-003 |
| RF-004 | O método deve estar disponível como extension method `PlaceCnpjMask()` sobre `string` | Alta | RN-004 |

## Regras de negócio

| ID | Regra | Origem | Impacto |
| -- | ----- | ------ | ------- |
| RN-001 | A máscara do CNPJ segue o padrão `00.000.000/0000-00`, aplicada via regex `(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})` → `$1.$2.$3/$4-$5` | Padrão oficial (IN RFB) | Formatação |
| RN-002 | Caracteres não numéricos são removidos via `RemoveMask()` (alias para `OnlyNumbers()`, regex `[^\d]`) antes da aplicação da máscara | Boa prática / Código existente | Normalização de entrada |
| RN-003 | Entrada nula, vazia ou apenas whitespace retorna `null` (não string vazia) | Comportamento atual do código | Tratamento de borda |
| RN-004 | API pública exposta como extension method `PlaceCnpjMask()` em `CnpjExtension` (namespace `Sirb.Validation.Exceptions`) | Design da biblioteca | Descoberta via IntelliSense |

## Critérios de aceitação

```gherkin
Funcionalidade: Máscara de CNPJ
  Como um desenvolvedor .NET
  Quero aplicar máscara em números de CNPJ
  Para exibir CNPJs no formato oficial brasileiro

  Cenário: Aplicar máscara em CNPJ sem formatação
    Dado que o valor "12345678000195" é informado
    Quando o método PlaceCnpjMask() é chamado
    Então o resultado deve ser "12.345.678/0001-95"

  Cenário: Aplicar máscara em CNPJ já formatado
    Dado que o valor "12.345.678/0001-95" é informado
    Quando o método PlaceCnpjMask() é chamado
    Então o resultado deve ser "12.345.678/0001-95"

  Cenário: Aplicar máscara em CNPJ com caracteres mistos
    Dado que o valor "12a.34b5.67c8/00d0-1e95" é informado
    Quando o método PlaceCnpjMask() é chamado
    Então o resultado deve ser "12.345.678/0001-95"

  Cenário: Aplicar máscara em string vazia
    Dado que o valor "" é informado
    Quando o método PlaceCnpjMask() é chamado
    Então o resultado deve ser null

  Cenário: Aplicar máscara em valor nulo
    Dado que o valor null é informado
    Quando o método PlaceCnpjMask() é chamado
    Então o resultado deve ser null

  Cenário: Aplicar máscara em string com apenas whitespace
    Dado que o valor "   " é informado
    Quando o método PlaceCnpjMask() é chamado
    Então o resultado deve ser null

  Cenário: Extension method descobrível via IntelliSense
    Dado uma variável string cnpj = "12345678000195"
    Quando o desenvolvedor digita "cnpj."
    Então PlaceCnpjMask() deve aparecer nas sugestões do IntelliSense
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
| RSK-016 | Regex de máscara com erro de formatação | 1 | 3 | 3 | Baixo | Testes unitários para PlaceMask com vários formatos de entrada |
| RSK-017 | Performance degradada por alocação excessiva | 2 | 3 | 6 | Médio | BenchmarkDotNet com MemoryDiagnoser, gate de regressão > 10% |

## Análise de Pontos de Função (APF) vinculada

- **Documento APF obrigatório:** `apf-req-0015.md`
- **Localização:** `docs/requirement/apf/apf-req-0015.md`

## Impactos técnicos

### Backend / Biblioteca
- Método `PlaceMask` em `CnpjValidation.cs` (já implementado)
- Extension method `PlaceCnpjMask` em `CnpjExtension.cs` (já implementado)
- Usa `StringExtension.RemoveMask()` / `OnlyNumbers()` para normalização

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
| Requisito de validação base | `req-0002-cnpj-validacao.md` |
| Classe de validação | `Sirb.Validation/Documents/BR/Validation/CnpjValidation.cs` (método `PlaceMask`) |
| Extension method API pública | `Sirb.Validation/Extensions/CnpjExtension.cs` (método `PlaceCnpjMask`) |
| Testes | `Sirb.Validation.Test/Extensions/CnpjExtensionTest.cs` (método `PlaceMask`) |

## Validações realizadas para esta documentação

- [x] README do projeto analisado
- [x] Código principal analisado (`CnpjValidation.cs`, `CnpjExtension.cs`)
- [x] Testes existentes analisados (`CnpjExtensionTest.cs`)
- [x] Documentações relacionadas revisadas (`constituicao.md`, `architecture-tech-stack.md`, `req-0002`)
- [x] Matriz global de risco do sistema atualizada
- [x] Documento APF do requisito criado
- [x] Wireframe: N/A (biblioteca sem interface)

## Histórico de alterações

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação do documento |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.1.0 | Atualização de referência ao requisito base renomeado (`req-0002-cnpj-validacao.md`) |

## Clarification Log

| Data | Pergunta | Resposta | Status (Resolvido/Pendente) | Origem (Criação/Implementação) | Impacto no requisito |
| ---- | -------- | -------- | --------------------------- | ------------------------------ | --------------------- |
| 31/07/2026 | O PlaceMask deve validar o CNPJ antes de mascarar? | Não. Apenas formata. Validação é responsabilidade de IsValid (req-0002). | Resolvido | Criação | Define escopo: máscara pura, sem validação. |
| 31/07/2026 | Qual o comportamento para string com menos de 14 dígitos? | A regex não casa, retorna a string original normalizada (sem máscara). | Resolvido | Criação | Define cenário de borda. |
| 31/07/2026 | PlaceCnpjMask está em namespace Exceptions ou Extensions? | Atualmente em `Sirb.Validation.Exceptions` (CnpjExtension.cs). Deveria ser `Extensions`. | Resolvido | Criação | Identifica inconsistência de namespace. |
| 31/07/2026 | O método deve lançar exceção para entrada inválida? | Não. Retorna null para vazio/nulo; outros casos aplicam regex. | Resolvido | Criação | Comportamento defensivo. |
| 31/07/2026 | Existe método RemoveMask específico para CNPJ? | Não. Usa `StringExtension.OnlyNumbers()` (regex `[^\d]`). | Resolvido | Criação | Confirma reuso de utilitário. |
| 31/07/2026 | A máscara deve preservar caracteres não numéricos? | Não. Remove todos não-dígitos antes de formatar. | Resolvido | Criação | Comportamento de normalização. |
| 31/07/2026 | Qual a diferença entre PlaceMask e PlaceCnpjMask? | PlaceMask interno em CnpjValidation; PlaceCnpjMask extension público. | Resolvido | Criação | Define arquitetura de camadas. |
| 31/07/2026 | O código atual trata whitespace-only como vazio? | Sim. `value?.Trim()` + `string.IsNullOrEmpty` no PlaceMask. | Resolvido | Criação | Confirma comportamento. |

### Cobertura do Clarification (8 áreas)

| # | Área | Status | Ref. entrada no Log | Justificativa (se N/A) |
| - | ---- | ------ | ------------------- | ---------------------- |
| 1 | Atores e personas | Resolvido | Desenvolvedor .NET consumidor | — |
| 2 | Fluxos principais e alternativos | Resolvido | Cenários Gherkin | — |
| 3 | Exceções e erros | Resolvido | Entrada vazia/nula retorna null | — |
| 4 | Integrações externas | Resolvido | N/A — stateless | Justificativa: sem dependências |
| 5 | Requisitos não-funcionais | Resolvido | Performance, segurança, usabilidade | — |
| 6 | Dados e privacidade | Resolvido | CNPJ sensível; não logar bruto | — |
| 7 | Validações e regras de negócio | Resolvido | RN-001 a RN-004 | — |
| 8 | Critérios de aceite e mensurabilidade | Resolvido | Gherkin + NFRs métricas | — |

**Cobertura atual:** 8/8. **Meta:** 8/8 (OK).