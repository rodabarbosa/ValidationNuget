---
type: req
title: "req-0018 — Inscrição Estadual (27 UFs + DF) — Máscaras"
description: "Aplicação de máscaras específicas por estado para Inscrição Estadual (IE) dos 27 estados brasileiros + DF, com roteamento via enum State e remoção automática de caracteres não numéricos."
resource: "./requirement/req-0018-inscricao-estadual-mascara.md"
tags: [documento-brasileiro, mascara, inscricao-estadual]
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
  artifact_id: "req-0018"
  title_pt: "Inscrição Estadual (27 UFs + DF) — Máscaras"
  version: "1.1.0"
  author: "Rodrigo Araujo Barbosa"
  created: "31/07/2026"
  updated: "31/07/2026"
  bundle: "flat"
  language: pt-BR
  coverage_clarification: "8/8"
  cross_artifact_status: "APROVADO"
  quality_checklist: "APROVADO"
  risk_recorte: ["RSK-022", "RSK-023", "RSK-024"]
  fpa_pf: 12
---

# req-0018 — Inscrição Estadual (27 UFs + DF) — Máscaras

## Metadados

> Esta tabela é uma **reflexão** do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

| Campo | Valor |
|---|---|
| **Código do documento** | `req-0018` |
| **Título** | Inscrição Estadual (27 UFs + DF) — Máscaras |
| **Versão** | 1.1.0 |
| **Autor** | Rodrigo Araujo Barbosa |
| **Data de criação** | 31/07/2026 |
| **Última atualização** | 31/07/2026 |
| **Status** | Aprovado |
| **Bundle** | `flat` |
| **Cobertura Clarification** | 8/8 |
| **Análise Cross-Artifact** | APROVADO |
| **Quality Checklist** | APROVADO |
| **APF** | 12 PF |
| **Tipo OKF** | `req` |

## Objetivo

Disponibilizar formatação (máscara) de Inscrição Estadual nos padrões oficiais de cada uma das 27 unidades federativas brasileiras + DF, com roteamento automático via enum `State`, para uso por aplicações .NET que processem documentos fiscais (NF-e, cadastro de fornecedores, obrigações acessórias).

## Escopo

### In scope
- Aplicação de máscara específica por UF (27 estados + DF) via `InscricaoEstadualValidation.PlaceMask(State, value)`
- Remoção automática de caracteres não numéricos antes da formatação (via `RemoveMask`/`OnlyNumbers`)
- Retorno de `null` para entradas nulas ou vazias
- Lançamento de `StateNotFoundException` para estado não suportado
- 27 extension methods estaduais (`AcreExtension.PlaceMask`, `SaoPauloExtension.PlaceMask`, etc.)

### Out of scope
- Validação de IE por estado (coberto em `req-0006`)
- Consulta a bases externas (Sefaz estaduais)
- Persistência ou armazenamento
- Geração de IE para testes (coberto em `req-0012`)

## Intenção / Motivação de Negócio (Por quê)

- **Problema de negócio real:** Cada estado brasileiro tem formato único de Inscrição Estadual (quantidade de dígitos, posicionamento de pontos, barras, traços). Sistemas fiscais e ERPs precisam formatar IE corretamente por UF para emissão de NF-e, cadastro de fornecedores interestaduais e obrigações acessórias (SPED, DIEF, GIA).
- **Por que importa:** IE mal formatada gera rejeição de NF-e pela Sefaz do estado destino, impossibilidade de comercializar interestadualmente, multas fiscais e retrabalho administrativo. Uma máscara centralizada por UF garante conformidade com cada legislação estadual.
- **Público afetado:** Desenvolvedores .NET de sistemas ERP, contabilidade, fiscal, e-commerce B2B, emissores de NF-e.
- **Critério de sucesso:** Máscara aplicada corretamente por UF em < 1 ms (p95), 100% de cobertura de testes para todas as 27 UFs + DF, compatível com .NET 8/9/10.

## Artefatos relacionados

### Documentos/requisitos que impactam este artefato
- `constituicao.md` — performance (PERF-01, PERF-02), segurança (SEC-06, SEC-07), extensibilidade
- `architecture-tech-stack.md` — stack tecnológico, padrão de roteamento por estado
- `req-0006-inscricao-estadual-validacao.md` — validação de IE (requisito base)

### Documentos/requisitos impactados por este artefato
- `tec-req-0018-inscricao-estadual-mascara.md` — especificação técnica
- `apf/apf-req-0018.md` — pontos de função
- `analise/analise-req-0018.md` — análise cross-artifact
- `checklist/checklist-req-0018.md` — quality checklist
- `system-risk-matrix.md` — riscos do sistema
- `tamanho-aplicacao.md` — consolidado APF

## Descrição geral

- **Contexto:** Inscrição Estadual (IE) é o cadastro de contribuintes do ICMS em cada estado. Cada UF define seu próprio formato (ex.: SP: 12 dígitos com máscara `000.000.000.123`, MG: 13 dígitos `000.000.000/0000`, etc.). O roteamento é feito pelo enum `State` (27 valores + DF).
- **Problema que resolve:** Centraliza as 27+ máscaras estaduais em um ponto único de entrada (`InscricaoEstadualValidation.PlaceMask`), eliminando formatação manual inconsistente por estado.
- **Ator principal:** Desenvolvedor .NET (consumidor da biblioteca).
- **Gatilho:** Chamada a `InscricaoEstadualValidation.PlaceMask(State.UF, value)` ou extension method estadual (ex.: `value.PlaceMask(State.SP)` via `SaoPauloExtension`).
- **Resultado esperado:** String formatada no padrão oficial da UF informada, ou `null` para entrada vazia/nula, ou `StateNotFoundException` para UF inválida.

## Wireframe da página/interface

### N/A — Biblioteca sem interface de usuário

A biblioteca Sirb.Validation é uma biblioteca de classes .NET (NuGet) puramente computacional, sem interface gráfica. Não há wireframe aplicável.

## Requisitos funcionais

| ID | Descrição | Prioridade | Regra de negócio associada |
| -- | --------- | ---------- | -------------------------- |
| RF-001 | O sistema deve aplicar máscara específica da UF informada via enum `State` | Alta | RN-001 |
| RF-002 | O sistema deve remover caracteres não numéricos antes de aplicar a máscara | Alta | RN-002 |
| RF-003 | O sistema deve retornar `null` para entradas nulas ou vazias | Alta | RN-003 |
| RF-004 | O sistema deve lançar `StateNotFoundException` para UF não suportada | Alta | RN-004 |
| RF-005 | O sistema deve expor 27 extension methods estaduais (`XExtension.PlaceMask`) | Média | RN-005 |
| RF-006 | O roteamento deve usar dicionário estático `_mask` com `Func<string, string>` por UF | Alta | RN-006 |

## Regras de negócio

| ID | Regra | Origem | Impacto |
| -- | ----- | ------ | ------- |
| RN-001 | Cada UF tem máscara própria (regex e formato específicos). Roteamento via enum `State` (27 + DF). | Legislação estadual (Sefaz) | Formatação por UF |
| RN-002 | Normalização: `RemoveMask()` = `OnlyNumbers()` = regex `[^\d]` remove não-dígitos antes da máscara | Boa prática / Código existente | Normalização |
| RN-003 | Entrada null/vazia/whitespace → `null` | Comportamento atual | Tratamento de borda |
| RN-004 | UF inválida (fora do enum `State`) → `StateNotFoundException` | Design da biblioteca | Tratamento de erro |
| RN-005 | 27 classes de extension estaduais (`AcreExtension`...`TocantinsExtension`) com método `PlaceMask(string)` | Design da biblioteca | Descoberta IntelliSense por UF |
| RN-006 | Dicionário estático `_mask` em `InscricaoEstadualValidation` mapeia `State` → `Func<string, string>` | Arquitetura atual | Roteamento performático |

## Critérios de aceitação

```gherkin
Funcionalidade: Máscara de Inscrição Estadual
  Como um desenvolvedor .NET
  Quero aplicar máscara em IE por UF
  Para exibir IEs no formato oficial de cada estado

  Cenário: Aplicar máscara em IE de SP válida
    Dado que o valor "123456789123" e UF State.SP são informados
    Quando InscricaoEstadualValidation.PlaceMask(State.SP, value) é chamado
    Então o resultado deve seguir o formato oficial de SP (ex.: "123.456.789.123")

  Cenário: Aplicar máscara em IE de MG válida
    Dado que o valor "1234567890123" e UF State.MG são informados
    Quando InscricaoEstadualValidation.PlaceMask(State.MG, value) é chamado
    Então o resultado deve seguir o formato oficial de MG (ex.: "123.456.789/0123")

  Cenário: Aplicar máscara via extension method estadual
    Dado que o valor "123456789123" é informado
    Quando "123456789123".PlaceMask(State.SP) é chamado (via SaoPauloExtension)
    Então o resultado deve ser idêntico ao roteamento central

  Cenário: IE com UF inválida
    Dado State inválido (valor fora do enum State)
    Quando InscricaoEstadualValidation.PlaceMask(..., value) é chamado
    Então StateNotFoundException deve ser lançada

  Cenário: IE nula
    Dado null e State.SP
    Quando PlaceMask é chamado
    Então o resultado deve ser null

  Cenário: IE vazia
    Dado "" e State.RJ
    Quando PlaceMask é chamado
    Então o resultado deve ser null

  Cenário: IE com caracteres mistos
    Dado "12a3.45b6.78c9.1d23" e State.SP
    Quando PlaceMask é chamado
    Então o resultado deve ser "123.456.789.123" (normalizado e formatado)
```

## Requisitos não funcionais

| Categoria | Requisito | Métrica/critério |
| --------- | --------- | ---------------- |
| Desempenho | Latência de máscara | p95 < 1 ms por validação, p99 < 5 ms |
| Desempenho | Throughput | > 100.000 operações/segundo por núcleo |
| Desempenho | Alocação zero no hot path | PlaceMask não deve alocar strings intermediárias desnecessárias |
| Segurança | Proteção contra ReDoS | Regex simples por estado, sem backtracking catastrófico |
| Segurança | Dados sensíveis em logs | Documentação alerta para não logar IE bruta; usar PlaceMask() antes de logar |
| Usabilidade | API fluente | Extension methods estaduais + roteamento central para descoberta via IntelliSense |
| Manutenibilidade | Cobertura de testes | 100% de cobertura de linha/branch para cada UF |
| Extensibilidade | Nova UF | Adicionar nova entry no dicionário `_mask` + extension method estadual |
| Compatibilidade | Multi-target | Compatível com .NET 8, 9 e 10 |

## Matriz de risco do requisito (recorte)

| ID | Risco | Probabilidade (1-5) | Impacto (1-5) | Score | Nível | Mitigação |
| -- | ----- | ------------------- | ------------- | ----- | ----- | --------- |
| RSK-022 | Máscara de estado específico com formato errado | 2 | 5 | 10 | Alto | Testes de PlaceMask por estado; consulta documentação oficial Sefaz |
| RSK-023 | Exceção para estado não mapeado não tratada | 1 | 4 | 4 | Baixo | StateNotFoundException lançada antes da formatação; teste para UF inválida |
| RSK-024 | Performance degradada por dicionário de 27+ funções | 1 | 3 | 3 | Baixo | BenchmarkDotNet; dicionário estático O(1) lookup |

## Análise de Pontos de Função (APF) vinculada

- **Documento APF obrigatório:** `apf-req-0018.md`
- **Localização:** `docs/requirement/apf/apf-req-0018.md`

## Impactos técnicos

### Backend / Biblioteca
- Método `PlaceMask(State, string)` em `InscricaoEstadualValidation.cs` (roteamento central)
- Dicionário estático `_mask` com 27+ `Func<string, string>` (uma por UF)
- 27 classes de extension em `Extensions/*Extension.cs` (`AcreExtension`...`TocantinsExtension`)
- Enum `State` em `Documents/BR/Enumeration/State.cs` (27 valores + DF)
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
| Requisito de validação base | `req-0006-inscricao-estadual-validacao.md` |
| Classe de roteamento central | `Sirb.Validation/Documents/BR/Validation/InscricaoEstadualValidation.cs` |
| Extensions estaduais | `Sirb.Validation/Extensions/AcreExtension.cs` ... `TocantinsExtension.cs` (27 arquivos) |
| Enum de estados | `Sirb.Validation/Documents/BR/Enumeration/State.cs` |
| Interface de validação | `Sirb.Validation/Documents/BR/Interfaces/IInscricaoEstadualValidation.cs` |
| Testes | `Sirb.Validation.Test/Extensions/*ExtensionTest.cs` (27 arquivos de teste) |
| Mockups (geração) | `Sirb.Validation/Documents/BR/Mockups/Ie/` (27 classes, req-0012) |

## Validações realizadas para esta documentação

- [x] README do projeto analisado
- [x] Código principal analisado (`InscricaoEstadualValidation.cs`, extensions estaduais, `State.cs`)
- [x] Testes existentes analisados (ex.: `SaoPauloExtensionTest.cs`, `AcreExtensionTest.cs`)
- [x] Documentações relacionadas revisadas (`constituicao.md`, `architecture-tech-stack.md`, `req-0006`)
- [x] Matriz global de risco do sistema atualizada
- [x] Documento APF do requisito criado
- [x] Wireframe: N/A (biblioteca sem interface)

## Histórico de alterações

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação do documento |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.1.0 | Atualização de referência ao requisito base renomeado (`req-0006-inscricao-estadual-validacao.md`) |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.1.0 | Realinhamento do nível da fatia local à legenda da matriz global: RSK-023 (score 4) Baixo |

## Clarification Log

| Data | Pergunta | Resposta | Status (Resolvido/Pendente) | Origem (Criação/Implementação) | Impacto no requisito |
| ---- | -------- | -------- | --------------------------- | ------------------------------ | --------------------- |
| 31/07/2026 | O PlaceMask deve validar a IE antes de mascarar? | Não. Apenas formata. Validação é IsValid (req-0006). | Resolvido | Criação | Define escopo: máscara pura. |
| 31/07/2026 | Qual o comportamento para string com dígitos insuficientes para a UF? | Regex não casa, retorna string normalizada sem máscara (comportamento atual). | Resolvido | Criação | Cenário de borda por UF. |
| 31/07/2026 | As extensions estaduais estão no namespace correto? | Sim, `Sirb.Validation.Extensions` (todas as 27). | Resolvido | Criação | Consistência confirmada. |
| 31/07/2026 | O método deve lançar exceção para entrada inválida? | Não para vazio/nulo (retorna null); sim para UF inválida (StateNotFoundException). | Resolvido | Criação | Dois tipos de erro distintos. |
| 31/07/2026 | Existe método RemoveMask específico para IE? | Não. Usa `StringExtension.OnlyNumbers()` (regex `[^\d]`). | Resolvido | Criação | Reuso de utilitário global. |
| 31/07/2026 | Como é feito o roteamento por UF? | Dicionário estático `_mask: Dictionary<State, Func<string, string>>` em `InscricaoEstadualValidation`. | Resolvido | Criação | O(1) lookup, performático. |
| 31/07/2026 | Quantas UFs têm máscara definida? | 27 estados + DF = 28 entries no dicionário `_mask`. | Resolvido | Criação | Cobertura completa. |
| 31/07/2026 | O código atual trata whitespace-only como vazio? | Sim. Verifica `string.IsNullOrEmpty(value?.Trim())` nas máscaras estaduais. | Resolvido | Criação | Comportamento consistente. |

### Cobertura do Clarification (8 áreas)

| # | Área | Status | Ref. entrada no Log | Justificativa (se N/A) |
| - | ---- | ------ | ------------------- | ---------------------- |
| 1 | Atores e personas | Resolvido | Desenvolvedor .NET de sistemas fiscais | — |
| 2 | Fluxos principais e alternativos | Resolvido | Cenários Gherkin (roteamento central + extension estadual) | — |
| 3 | Exceções e erros | Resolvido | Null para vazio; StateNotFoundException para UF inválida | — |
| 4 | Integrações externas | Resolvido | N/A — stateless | Justificativa: sem dependências |
| 5 | Requisitos não-funcionais | Resolvido | Performance, segurança, extensibilidade | — |
| 6 | Dados e privacidade | Resolvido | IE sensível; não logar bruta | — |
| 7 | Validações e regras de negócio | Resolvido | RN-001 a RN-006, 28 máscaras | — |
| 8 | Critérios de aceite e mensurabilidade | Resolvido | Gherkin + NFRs métricas | — |

**Cobertura atual:** 8/8. **Meta:** 8/8 (OK).