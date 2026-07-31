---
type: req
title: "req-0014 — CPF — Máscara"
description: "Aplicação de máscara no formato 000.000.000-00 para números de CPF válidos, com remoção automática de caracteres não numéricos antes da formatação."
resource: "./requirement/req-0014-cpf-mascara.md"
tags: [documento-brasileiro, mascara, cpf]
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
  artifact_id: "req-0014"
  title_pt: "CPF — Máscara"
  version: "1.1.0"
  author: "Rodrigo Araujo Barbosa"
  created: "31/07/2026"
  updated: "31/07/2026"
  bundle: "flat"
  language: pt-BR
  coverage_clarification: "8/8"
  cross_artifact_status: "APROVADO"
  quality_checklist: "APROVADO"
  risk_recorte: ["RSK-014", "RSK-015"]
  fpa_pf: 3
---

# req-0014 — CPF — Máscara

## Metadados

> Esta tabela é uma **reflexão** do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

| Campo | Valor |
|---|---|
| **Código do documento** | `req-0014` |
| **Título** | CPF — Máscara |
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

Disponibilizar formatação (máscara) de CPF no padrão brasileiro `000.000.000-00` para uso por aplicações .NET que precisem exibir ou armazenar CPFs formatados.

## Escopo

### In scope
- Aplicação de máscara `000.000.000-00` em strings contendo 11 dígitos numéricos
- Remoção automática de caracteres não numéricos antes da formatação (via `RemoveMask`/`OnlyNumbers`)
- Retorno de `null` para entradas nulas ou vazias
- Método de extensão `PlaceCpfMask()` disponível sobre `string`

### Out of scope
- Validação de dígitos verificadores (coberto em `req-0001`)
- Consulta a bases externas (Sefaz, Receita Federal)
- Persistência ou armazenamento
- Geração de CPF para testes (coberto em `req-0007`)

## Intenção / Motivação de Negócio (Por quê)

- **Problema de negócio real:** Aplicações brasileiras precisam exibir CPFs no formato oficial com pontos e traço (`000.000.000-00`) em relatórios, telas, documentos fiscais e integrações. A formatação manual é propensa a erros e inconsistências.
- **Por que importa:** CPFs mal formatados geram rejeição em layouts fiscais (SPED, NF-e), inconsistência visual em interfaces de usuário e retrabalho em integrações com ERPs e sistemas bancários. Uma máscara centralizada garante padrão único.
- **Público afetado:** Desenvolvedores .NET que constroem sistemas ERP, e-commerce, fintechs, sistemas públicos ou qualquer aplicação que exiba/processe CPF.
- **Critério de sucesso:** Máscara aplicada corretamente em < 1 ms (p95), sem alocação desnecessária, compatível com .NET 8/9/10, 100% de cobertura de testes.

## Artefatos relacionados

### Documentos/requisitos que impactam este artefato
- `constituicao.md` — princípios de performance (PERF-01, PERF-02), segurança (SEC-06, SEC-07)
- `architecture-tech-stack.md` — stack tecnológico, fluxo de dados
- `req-0001-cpf-validacao.md` — validação de CPF (requisito base)

### Documentos/requisitos impactados por este artefato
- `tec-req-0014-cpf-mascara.md` — especificação técnica
- `apf/apf-req-0014.md` — pontos de função
- `analise/analise-req-0014.md` — análise cross-artifact
- `checklist/checklist-req-0014.md` — quality checklist
- `system-risk-matrix.md` — riscos do sistema
- `tamanho-aplicacao.md` — consolidado APF

## Descrição geral

- **Contexto:** CPF é o documento primário de identificação do cidadão brasileiro. O padrão oficial de exibição usa máscara `000.000.000-00`.
- **Problema que resolve:** Padroniza a formatação de CPF em toda a aplicação, removendo a necessidade de formatação manual repetida e inconsistente.
- **Ator principal:** Desenvolvedor .NET (consumidor da biblioteca).
- **Gatilho:** Chamada ao método `PlaceCpfMask()` (extension method) ou `CpfValidation.PlaceMask()`.
- **Resultado esperado:** String formatada no padrão `000.000.000-00` ou `null` para entrada vazia/nula.

## Wireframe da página/interface

### N/A — Biblioteca sem interface de usuário

A biblioteca Sirb.Validation é uma biblioteca de classes .NET (NuGet) puramente computacional, sem interface gráfica. Não há wireframe aplicável.

## Requisitos funcionais

| ID | Descrição | Prioridade | Regra de negócio associada |
| -- | --------- | ---------- | -------------------------- |
| RF-001 | O sistema deve aplicar máscara no formato `000.000.000-00` a strings com 11 dígitos | Alta | RN-001 |
| RF-002 | O sistema deve remover caracteres não numéricos antes de aplicar a máscara | Alta | RN-002 |
| RF-003 | O sistema deve retornar `null` para entradas nulas ou vazias | Alta | RN-003 |
| RF-004 | O método deve estar disponível como extension method `PlaceCpfMask()` sobre `string` | Alta | RN-004 |

## Regras de negócio

| ID | Regra | Origem | Impacto |
| -- | ----- | ------ | ------- |
| RN-001 | A máscara do CPF segue o padrão `000.000.000-00`, aplicada via regex `(\d{3})(\d{3})(\d{3})(\d{2})` → `$1.$2.$3-$4` | Padrão oficial (IN RFB) | Formatação |
| RN-002 | Caracteres não numéricos são removidos via `RemoveMask()` (alias para `OnlyNumbers()`, regex `[^\d]`) antes da aplicação da máscara | Boa prática / Código existente | Normalização de entrada |
| RN-003 | Entrada nula, vazia ou apenas whitespace retorna `null` (não string vazia) | Comportamento atual do código | Tratamento de borda |
| RN-004 | API pública exposta como extension method `PlaceCpfMask()` em `CpfExtension` (namespace `Sirb.Validation.Exceptions`) | Design da biblioteca | Descoberta via IntelliSense |

## Critérios de aceitação

```gherkin
Funcionalidade: Máscara de CPF
  Como um desenvolvedor .NET
  Quero aplicar máscara em números de CPF
  Para exibir CPFs no formato oficial brasileiro

  Cenário: Aplicar máscara em CPF sem formatação
    Dado que o valor "12345678909" é informado
    Quando o método PlaceCpfMask() é chamado
    Então o resultado deve ser "123.456.789-09"

  Cenário: Aplicar máscara em CPF já formatado
    Dado que o valor "123.456.789-09" é informado
    Quando o método PlaceCpfMask() é chamado
    Então o resultado deve ser "123.456.789-09"

  Cenário: Aplicar máscara em CPF com caracteres mistos
    Dado que o valor "12a3.45b6.78c9-0d9" é informado
    Quando o método PlaceCpfMask() é chamado
    Então o resultado deve ser "123.456.789-09"

  Cenário: Aplicar máscara em string vazia
    Dado que o valor "" é informado
    Quando o método PlaceCpfMask() é chamado
    Então o resultado deve ser null

  Cenário: Aplicar máscara em valor nulo
    Dado que o valor null é informado
    Quando o método PlaceCpfMask() é chamado
    Então o resultado deve ser null

  Cenário: Aplicar máscara em string com apenas whitespace
    Dado que o valor "   " é informado
    Quando o método PlaceCpfMask() é chamado
    Então o resultado deve ser null

  Cenário: Extension method descobrível via IntelliSense
    Dado uma variável string cpf = "12345678909"
    Quando o desenvolvedor digita "cpf."
    Então PlaceCpfMask() deve aparecer nas sugestões do IntelliSense
```

## Requisitos não funcionais

| Categoria | Requisito | Métrica/critério |
| --------- | --------- | ---------------- |
| Desempenho | Latência de máscara | p95 < 1 ms, p99 < 5 ms em .NET 8+ |
| Desempenho | Throughput | > 100.000 operações/segundo por núcleo |
| Desempenho | Alocação zero no hot path | PlaceMask não deve alocar strings intermediárias desnecessárias |
| Segurança | Proteção contra ReDoS | Regex simples, sem backtracking catastrófico |
| Segurança | Dados sensíveis em logs | Documentação alerta para não logar CPF bruto; usar PlaceMask() antes de logar |
| Usabilidade | API fluente | Extension method sobre `string` para descoberta via IntelliSense |
| Manutenibilidade | Cobertura de testes | 100% de cobertura de linha/branch nos cenários de máscara |
| Compatibilidade | Multi-target | Compatível com .NET 8, 9 e 10 |

## Matriz de risco do requisito (recorte)

| ID | Risco | Probabilidade (1-5) | Impacto (1-5) | Score | Nível | Mitigação |
| -- | ----- | ------------------- | ------------- | ----- | ----- | --------- |
| RSK-014 | Regex de máscara com erro de formatação | 1 | 3 | 3 | Baixo | Testes unitários para PlaceMask com vários formatos de entrada |
| RSK-015 | Performance degradada por alocação excessiva | 2 | 3 | 6 | Médio | BenchmarkDotNet com MemoryDiagnoser, gate de regressão > 10% |

## Análise de Pontos de Função (APF) vinculada

- **Documento APF obrigatório:** `apf-req-0014.md`
- **Localização:** `docs/requirement/apf/apf-req-0014.md`

## Impactos técnicos

### Backend / Biblioteca
- Método `PlaceMask` em `CpfValidation.cs` (já implementado)
- Extension method `PlaceCpfMask` em `CpfExtension.cs` (já implementado)
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
| Requisito de validação base | `req-0001-cpf-validacao.md` |
| Classe de validação | `Sirb.Validation/Documents/BR/Validation/CpfValidation.cs` (método `PlaceMask`) |
| Extension method API pública | `Sirb.Validation/Extensions/CpfExtension.cs` (método `PlaceCpfMask`) |
| Testes | `Sirb.Validation.Test/Extensions/CpfExtensionTest.cs` (método `PlaceMask`) |

## Validações realizadas para esta documentação

- [x] README do projeto analisado
- [x] Código principal analisado (`CpfValidation.cs`, `CpfExtension.cs`, `CnpjValidation.cs` para comparação)
- [x] Testes existentes analisados (`CpfExtensionTest.cs`)
- [x] Documentações relacionadas revisadas (`constituicao.md`, `architecture-tech-stack.md`, `req-0001`)
- [x] Matriz global de risco do sistema atualizada
- [x] Documento APF do requisito criado
- [x] Wireframe: N/A (biblioteca sem interface)

## Histórico de alterações

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação do documento |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.1.0 | Atualização de referência ao requisito base renomeado (`req-0001-cpf-validacao.md`) |

## Clarification Log

| Data | Pergunta | Resposta | Status (Resolvido/Pendente) | Origem (Criação/Implementação) | Impacto no requisito |
| ---- | -------- | -------- | --------------------------- | ------------------------------ | --------------------- |
| 31/07/2026 | O PlaceMask deve validar o CPF antes de mascarar? | Não. Apenas formata. Validação é responsabilidade de IsValid (req-0001). PlaceMask formata qualquer 11 dígitos. | Resolvido | Criação | Define escopo: máscara pura, sem validação. |
| 31/07/2026 | Qual o comportamento para string com menos de 11 dígitos? | A regex não casa, retorna a string original sem máscara (comportamento atual do Regex.Replace). | Resolvido | Criação | Define cenário de borda não coberto por testes atuais. |
| 31/07/2026 | PlaceCpfMask está em namespace Exceptions ou Extensions? | Atualmente em `Sirb.Validation.Exceptions` (CpfExtension.cs). Deveria ser `Sirb.Validation.Extensions`. | Resolvido | Criação | Identifica inconsistência de namespace no código atual. |
| 31/07/2026 | O método deve lançar exceção para entrada inválida? | Não. Retorna null para vazio/nulo; para outros casos, aplica regex (pode retornar string sem máscara se não casar). | Resolvido | Criação | Comportamento defensivo, sem exceções. |
| 31/07/2026 | Existe método RemoveMask específico para CPF? | Não. Usa `StringExtension.OnlyNumbers()` (regex `[^\d]`). | Resolvido | Criação | Confirma reuso de utilitário existente. |
| 31/07/2026 | A máscara deve preservar caracteres não numéricos? | Não. Remove todos os não-dígitos antes de formatar. | Resolvido | Criação | Comportamento de normalização. |
| 31/07/2026 | Qual a diferença entre PlaceMask e PlaceCpfMask? | PlaceMask é o método interno em CpfValidation; PlaceCpfMask é o extension method público em CpfExtension. | Resolvido | Criação | Define arquitetura de camadas. |
| 31/07/2026 | O código atual trata whitespace-only como vazio? | Sim. `value?.Trim()` no PlaceMask verifica string.IsNullOrEmpty após Trim. | Resolvido | Criação | Confirma comportamento para whitespace. |

### Cobertura do Clarification (8 áreas)

| # | Área | Status | Ref. entrada no Log | Justificativa (se N/A) |
| - | ---- | ------ | ------------------- | ---------------------- |
| 1 | Atores e personas | Resolvido | Desenvolvedor .NET consumidor da biblioteca | — |
| 2 | Fluxos principais e alternativos | Resolvido | Cenários Gherkin (formatação, normalização, bordas) | — |
| 3 | Exceções e erros | Resolvido | Entrada vazia/nula retorna null; sem exceções | — |
| 4 | Integrações externas | Resolvido | N/A — biblioteca sem dependências | Justificativa: stateless |
| 5 | Requisitos não-funcionais | Resolvido | Performance p95 < 1ms, segurança ReDoS, usabilidade API fluente | — |
| 6 | Dados e privacidade | Resolvido | CPF sensível; não logar sem máscara | — |
| 7 | Validações e regras de negócio | Resolvido | RN-001 a RN-004, regex, normalização | — |
| 8 | Critérios de aceite e mensurabilidade | Resolvido | Gherkin completo + NFRs métricas | — |

**Cobertura atual:** 8/8. **Meta:** 8/8 (OK).