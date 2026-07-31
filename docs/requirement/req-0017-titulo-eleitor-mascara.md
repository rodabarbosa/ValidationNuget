---
type: req
title: "req-0017 — Título de Eleitor — Máscara"
description: "Aplicação de máscara no formato 0000.0000.0000 para números de Título de Eleitor, com remoção automática de caracteres não numéricos antes da formatação."
resource: "./requirement/req-0017-titulo-eleitor-mascara.md"
tags: [documento-brasileiro, mascara, titulo-eleitor]
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
  artifact_id: "req-0017"
  title_pt: "Título de Eleitor — Máscara"
  version: "1.1.0"
  author: "Rodrigo Araujo Barbosa"
  created: "31/07/2026"
  updated: "31/07/2026"
  bundle: "flat"
  language: pt-BR
  coverage_clarification: "8/8"
  cross_artifact_status: "APROVADO"
  quality_checklist: "APROVADO"
  risk_recorte: ["RSK-020", "RSK-021"]
  fpa_pf: 3
---

# req-0017 — Título de Eleitor — Máscara

## Metadados

> Esta tabela é uma **reflexão** do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

| Campo | Valor |
|---|---|
| **Código do documento** | `req-0017` |
| **Título** | Título de Eleitor — Máscara |
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

Disponibilizar formatação (máscara) de Título de Eleitor no padrão brasileiro `0000.0000.0000` para uso por aplicações .NET que precisem exibir ou armazenar títulos formatados.

## Escopo

### In scope
- Aplicação de máscara `0000.0000.0000` em strings contendo 12 dígitos numéricos
- Remoção automática de caracteres não numéricos antes da formatação (via `RemoveMask`/`OnlyNumbers`)
- Retorno de `null` para entradas nulas ou vazias
- Método de extensão `PlaceTituloEleitorMask()` disponível sobre `string`

### Out of scope
- Validação de dígitos verificadores e UF (coberto em `req-0004`)
- Consulta a bases externas (TSE)
- Persistência ou armazenamento
- Geração de Título para testes (coberto em `req-0010`)

## Intenção / Motivação de Negócio (Por quê)

- **Problema de negócio real:** Sistemas governamentais, concursos públicos, RH e cadastro civil precisam exibir Título de Eleitor no formato oficial `0000.0000.0000` em documentos, relatórios e integrações. Formatação manual é inconsistente.
- **Por que importa:** Títulos mal formatados geram rejeição em integrações com TSE, inconsistência em documentos oficiais e retrabalho administrativo.
- **Público afetado:** Desenvolvedores .NET de sistemas governamentais, RH, concursos, cadastro civil.
- **Critério de sucesso:** Máscara aplicada corretamente em < 1 ms (p95), compatível com .NET 8/9/10, 100% de cobertura de testes.

## Artefatos relacionados

### Documentos/requisitos que impactam este artefato
- `constituicao.md` — performance (PERF-01, PERF-02), segurança (SEC-06, SEC-07)
- `architecture-tech-stack.md` — stack tecnológico
- `req-0004-titulo-eleitor-validacao.md` — validação de Título (requisito base)

### Documentos/requisitos impactados por este artefato
- `tec-req-0017-titulo-eleitor-mascara.md` — especificação técnica
- `apf/apf-req-0017.md` — pontos de função
- `analise/analise-req-0017.md` — análise cross-artifact
- `checklist/checklist-req-0017.md` — quality checklist
- `system-risk-matrix.md` — riscos do sistema
- `tamanho-aplicacao.md` — consolidado APF

## Descrição geral

- **Contexto:** Título de Eleitor tem 12 dígitos (8 de sequência + 2 de UF + 2 dígitos verificadores). Padrão oficial: `0000.0000.0000`.
- **Problema que resolve:** Padroniza formatação de Título em toda a aplicação, removendo necessidade de formatação manual inconsistente.
- **Ator principal:** Desenvolvedor .NET (consumidor da biblioteca).
- **Gatilho:** Chamada ao método `PlaceTituloEleitorMask()` (extension method) ou `TituloEleitorValidation.PlaceMask()`.
- **Resultado esperado:** String formatada no padrão `0000.0000.0000` ou `null` para entrada vazia/nula.

## Wireframe da página/interface

### N/A — Biblioteca sem interface de usuário

A biblioteca Sirb.Validation é uma biblioteca de classes .NET (NuGet) puramente computacional, sem interface gráfica. Não há wireframe aplicável.

## Requisitos funcionais

| ID | Descrição | Prioridade | Regra de negócio associada |
| -- | --------- | ---------- | -------------------------- |
| RF-001 | O sistema deve aplicar máscara no formato `0000.0000.0000` a strings com 12 dígitos | Alta | RN-001 |
| RF-002 | O sistema deve remover caracteres não numéricos antes de aplicar a máscara | Alta | RN-002 |
| RF-003 | O sistema deve retornar `null` para entradas nulas ou vazias | Alta | RN-003 |
| RF-004 | O método deve estar disponível como extension method `PlaceTituloEleitorMask()` sobre `string` | Alta | RN-004 |

## Regras de negócio

| ID | Regra | Origem | Impacto |
| -- | ----- | ------ | ------- |
| RN-001 | A máscara do Título segue o padrão `0000.0000.0000`, aplicada via regex `(\d{4})(\d{4})(\d{4})` → `$1.$2.$3` | Padrão oficial (TSE) | Formatação |
| RN-002 | Caracteres não numéricos são removidos via `RemoveMask()` (delega para `OnlyNumbers()`, regex `[^\d]`) antes da máscara | Boa prática / Código existente | Normalização |
| RN-003 | Entrada nula, vazia ou apenas whitespace retorna `null` | Comportamento atual do código | Tratamento de borda |
| RN-004 | API pública exposta como extension method `PlaceTituloEleitorMask()` em `TituloEleitorExtension` (namespace `Sirb.Validation.Extensions`) | Design da biblioteca | Descoberta via IntelliSense |

## Critérios de aceitação

```gherkin
Funcionalidade: Máscara de Título de Eleitor
  Como um desenvolvedor .NET
  Quero aplicar máscara em números de Título de Eleitor
  Para exibir títulos no formato oficial brasileiro

  Cenário: Aplicar máscara em Título sem formatação
    Dado que o valor "123456789012" é informado
    Quando o método PlaceTituloEleitorMask() é chamado
    Então o resultado deve ser "1234.5678.9012"

  Cenário: Aplicar máscara em Título já formatado
    Dado que o valor "1234.5678.9012" é informado
    Quando o método PlaceTituloEleitorMask() é chamado
    Então o resultado deve ser "1234.5678.9012"

  Cenário: Aplicar máscara em Título com caracteres mistos
    Dado que o valor "12a3.45b6.78c9.0d12" é informado
    Quando o método PlaceTituloEleitorMask() é chamado
    Então o resultado deve ser "1234.5678.9012"

  Cenário: Aplicar máscara em string vazia
    Dado que o valor "" é informado
    Quando o método PlaceTituloEleitorMask() é chamado
    Então o resultado deve ser null

  Cenário: Aplicar máscara em valor nulo
    Dado que o valor null é informado
    Quando o método PlaceTituloEleitorMask() é chamado
    Então o resultado deve ser null

  Cenário: Aplicar máscara em string com apenas whitespace
    Dado que o valor "   " é informado
    Quando o método PlaceTituloEleitorMask() é chamado
    Então o resultado deve ser null

  Cenário: Extension method descobrível via IntelliSense
    Dado uma variável string titulo = "123456789012"
    Quando o desenvolvedor digita "titulo."
    Então PlaceTituloEleitorMask() deve aparecer nas sugestões do IntelliSense
```

## Requisitos não funcionais

| Categoria | Requisito | Métrica/critério |
| --------- | --------- | ---------------- |
| Desempenho | Latência de máscara | p95 < 1 ms, p99 < 5 ms em .NET 8+ |
| Desempenho | Throughput | > 100.000 operações/segundo por núcleo |
| Desempenho | Alocação zero no hot path | PlaceMask não deve alocar strings intermediárias desnecessárias |
| Segurança | Proteção contra ReDoS | Regex simples, sem backtracking catastrófico |
| Segurança | Dados sensíveis em logs | Documentação alerta para não logar Título bruto; usar PlaceMask() antes de logar |
| Usabilidade | API fluente | Extension method sobre `string` para descoberta via IntelliSense |
| Manutenibilidade | Cobertura de testes | 100% de cobertura de linha/branch nos cenários de máscara |
| Compatibilidade | Multi-target | Compatível com .NET 8, 9 e 10 |

## Matriz de risco do requisito (recorte)

| ID | Risco | Probabilidade (1-5) | Impacto (1-5) | Score | Nível | Mitigação |
| -- | ----- | ------------------- | ------------- | ----- | ----- | --------- |
| RSK-020 | Regex de máscara com erro de formatação | 1 | 3 | 3 | Baixo | Testes unitários para PlaceMask com vários formatos |
| RSK-021 | Performance degradada por alocação excessiva | 2 | 3 | 6 | Médio | BenchmarkDotNet com MemoryDiagnoser, gate regressão > 10% |

## Análise de Pontos de Função (APF) vinculada

- **Documento APF obrigatório:** `apf-req-0017.md`
- **Localização:** `docs/requirement/apf/apf-req-0017.md`

## Impactos técnicos

### Backend / Biblioteca
- Método `PlaceMask` em `TituloEleitorValidation.cs` (já implementado)
- Extension method `PlaceTituloEleitorMask` em `TituloEleitorExtension.cs` (já implementado)
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
| Requisito de validação base | `req-0004-titulo-eleitor-validacao.md` |
| Classe de validação | `Sirb.Validation/Documents/BR/Validation/TituloEleitorValidation.cs` (método `PlaceMask`) |
| Extension method API pública | `Sirb.Validation/Extensions/TituloEleitorExtension.cs` (método `PlaceTituloEleitorMask`) |
| Testes | `Sirb.Validation.Test/Extensions/TituloEleitorExtensionTest.cs` (método `PlaceMask`) |

## Validações realizadas para esta documentação

- [x] README do projeto analisado
- [x] Código principal analisado (`TituloEleitorValidation.cs`, `TituloEleitorExtension.cs`)
- [x] Testes existentes analisados (`TituloEleitorExtensionTest.cs`)
- [x] Documentações relacionadas revisadas (`constituicao.md`, `architecture-tech-stack.md`, `req-0004`)
- [x] Matriz global de risco do sistema atualizada
- [x] Documento APF do requisito criado
- [x] Wireframe: N/A (biblioteca sem interface)

## Histórico de alterações

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação do documento |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.1.0 | Atualização de referência ao requisito base renomeado (`req-0004-titulo-eleitor-validacao.md`) |

## Clarification Log

| Data | Pergunta | Resposta | Status (Resolvido/Pendente) | Origem (Criação/Implementação) | Impacto no requisito |
| ---- | -------- | -------- | --------------------------- | ------------------------------ | --------------------- |
| 31/07/2026 | O PlaceMask deve validar o Título antes de mascarar? | Não. Apenas formata. Validação é IsValid (req-0004). | Resolvido | Criação | Define escopo: máscara pura. |
| 31/07/2026 | Qual o comportamento para string com menos de 12 dígitos? | Regex não casa, retorna string normalizada sem máscara. | Resolvido | Criação | Cenário de borda. |
| 31/07/2026 | PlaceTituloEleitorMask está em namespace Extensions? | Sim, `Sirb.Validation.Extensions` (correto). | Resolvido | Criação | Consistência confirmada. |
| 31/07/2026 | O método deve lançar exceção para entrada inválida? | Não. Retorna null para vazio/nulo; outros aplicam regex. | Resolvido | Criação | Comportamento defensivo. |
| 31/07/2026 | Existe método RemoveMask específico para Título? | Não. Usa `StringExtension.OnlyNumbers()` (regex `[^\d]`). | Resolvido | Criação | Reuso de utilitário. |
| 31/07/2026 | A máscara deve preservar caracteres não numéricos? | Não. Remove todos não-dígitos antes de formatar. | Resolvido | Criação | Normalização. |
| 31/07/2026 | Qual a diferença entre PlaceMask e PlaceTituloEleitorMask? | PlaceMask interno em TituloEleitorValidation; PlaceTituloEleitorMask extension público. | Resolvido | Criação | Arquitetura de camadas. |
| 31/07/2026 | O código atual trata whitespace-only como vazio? | Sim. `value?.Trim()` + `string.IsNullOrEmpty` no PlaceMask. | Resolvido | Criação | Comportamento confirmado. |

### Cobertura do Clarification (8 áreas)

| # | Área | Status | Ref. entrada no Log | Justificativa (se N/A) |
| - | ---- | ------ | ------------------- | ---------------------- |
| 1 | Atores e personas | Resolvido | Desenvolvedor .NET consumidor | — |
| 2 | Fluxos principais e alternativos | Resolvido | Cenários Gherkin | — |
| 3 | Exceções e erros | Resolvido | Entrada vazia/nula retorna null | — |
| 4 | Integrações externas | Resolvido | N/A — stateless | Justificativa: sem dependências |
| 5 | Requisitos não-funcionais | Resolvido | Performance, segurança, usabilidade | — |
| 6 | Dados e privacidade | Resolvido | Título sensível; não logar bruto | — |
| 7 | Validações e regras de negócio | Resolvido | RN-001 a RN-004 | — |
| 8 | Critérios de aceite e mensurabilidade | Resolvido | Gherkin + NFRs métricas | — |

**Cobertura atual:** 8/8. **Meta:** 8/8 (OK).