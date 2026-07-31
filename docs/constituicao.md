---
type: constituicao
title: "Constituição do Projeto — Sirb.Validation"
description: "Princípios de governança, valores e regras do projeto Sirb.Validation."
resource: "./constituicao.md"
tags: [governanca, principios, constituicao]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-26"
status: approved
domain:
  artifact_id: "constituicao"
  title_pt: "Constituição do Projeto — Sirb.Validation"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "26/07/2026"
  updated: "26/07/2026"
  language: pt-BR
---

# Constituição do Projeto — Sirb.Validation

> **Arquivo de destino:** `docs/constituicao.md` (na raiz de `/docs`).
> Este documento é **obrigatório e não negociável** — registra os princípios de governança do projeto usados como **filtro de aceite** dos requisitos. Deve ser criado **antes do início da documentação de requisitos** (Fase 2) e mantido em toda a evolução do projeto.

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** `constituicao`
- **Título:**** Constituição do Projeto — Sirb.Validation
- **Data de criação:** 26/07/2026
- **Última atualização:** 26/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Aprovador:** Rodrigo Araujo Barbosa (mantenedor do projeto)
- **Versão:** 1.0.0
- **Status:** Aprovado

> Sempre que este documento for atualizado, incremente a **Versão** e registre a alteração no histórico. Emendas à constituição exigem aprovação formal e devem ser refletidas nos requisitos impactados.

## Propósito

A Constituição é o **filtro de aceite** dos requisitos do projeto. Ela define os princípios não negociáveis de governança — segurança, performance, qualidade, UX, dados, arquitetura e processo — contra os quais cada par `req-XXXX` / `tec-req-XXXX` deve ser avaliado antes de ser considerado fechado.

- Toda nova funcionalidade deve ser **compatível** com a constituição vigente.
- Em caso de **conflito** entre um requisito e a constituição, prevalece a constituição: o requisito deve ser ajustado ou a constituição emendada formalmente (ver seção **Governance**).
- A constituição é **versionada** (SemVer) e qualquer mudança é rastreável no histórico de alterações.
- O preenchimento deste template é orientado pelo `writer` em conjunto com o `orchestrator`. Se o usuário tiver dificuldade em fornecer os princípios, oferecer no mínimo 3 sugestões concretas baseadas na investigação do código, dependências, ferramentas e domínio; explicar o impacto da ausência; registrar sugestões rejeitadas na seção de **Clarification Log**.

## Princípios de Segurança

| ID | Princípio | Descrição |
|----|-----------|-----------|
| SEC-01 | **Autenticação e autorização** | Esta biblioteca não implementa autenticação/autorização própria (é uma biblioteca de validação stateless). Qualquer consumo deve integrar-se ao mecanismo de identidade da aplicação host (OAuth 2.0, OIDC, JWT, SSO). |
| SEC-02 | **Criptografia em trânsito** | A biblioteca não gerencia transporte. Aplicações consumidoras **devem** usar TLS 1.2+ com HSTS. |
| SEC-03 | **Criptografia em repouso** | A biblioteca não persiste dados. Dados sensíveis (CPF, CNPJ, IE) manipulados pela biblioteca **não devem** ser logados em texto plano. Aplicações consumidoras devem implementar mascaramento em logs. |
| SEC-04 | **Gestão de segredos** | A biblioteca não armazena segredos. Nenhuma chave, token ou certificado deve ser incluído no pacote NuGet. |
| SEC-05 | **Auditoria e logging** | A biblioteca não emite logs. Aplicações consumidoras devem auditar validações de documentos sensíveis (LGPD Art. 37). |
| SEC-06 | **Tratamento de dados sensíveis (LGPD)** | A biblioteca processa dados pessoais (CPF, CNPJ, Título de Eleitor, IE, Renavam, PIS). **Proibido** logar valores brutos. **Obrigatório** usar métodos de máscara (`PlaceMask`, `RemoveMask`) antes de qualquer serialização/log. Base legal: consentimento ou legítimo interesse da aplicação consumidora. |
| SEC-07 | **OWASP Top 10** | Mitigações aplicáveis: A03:2021 (Injection) — validação estrita de entrada via regex e algoritmos matemáticos; A01:2021 (Broken Access Control) — N/A (stateless); A05:2021 (Security Misconfiguration) — configuração via código, sem arquivos de config sensíveis. |
| SEC-08 | **Testes de segurança** | SAST via `dotnet build` com analisadores Roslyn; SCA via `dotnet list package --vulnerable` em CI; Dependabot habilitado no GitHub. |

## Princípios de Performance e Disponibilidade

| ID | Princípio | Meta / SLO |
|----|-----------|------------|
| PERF-01 | **Latência (SLO)** | Validação de CPF/CNPJ/PIS/Título/IE/Renavam: **p95 < 1 ms**, **p99 < 5 ms** em .NET 8+ (benchmarks com `BenchmarkDotNet`). |
| PERF-02 | **Throughput** | Sustentar **> 100.000 validações/segundo** por núcleo em hardware moderno (x64, .NET 8+). |
| PERF-03 | **Alocação zero (hot path)** | Métodos de validação e máscara **não devem alocar** no caminho crítico (usar `Span<char>`, `stackalloc`, evitar `string` intermediárias). |
| PERF-04 | **Disponibilidade** | Biblioteca pura (sem I/O, sem rede, sem estado) — disponibilidade herdada da aplicação host. |
| PERF-05 | **RTO / RPO** | N/A (biblioteca stateless). |
| PERF-06 | **Error Budget** | Taxa de exceções não tratadas **= 0** (todas as validações retornam `bool`, não lançam exceções por entrada inválida). |
| PERF-07 | **Observabilidade de performance** | Benchmarks automatizados no projeto `Sirb.Validation.Benchmark` executados em CI a cada PR. Regressão > 10% falha o build. |
| PERF-08 | **Testes de carga** | `BenchmarkDotNet` com `MemoryDiagnoser`, `DisassemblyDiagnoser` (opcional), executado em `Release`, `AnyCPU`. |

## Princípios de Qualidade de Código

| ID | Princípio | Detalhamento |
|----|-----------|--------------|
| QUAL-01 | **Cobertura mínima de testes** | **100%** de cobertura de linha/branch em código público (`Sirb.Validation`). Testes em `Sirb.Validation.Test` com xUnit. |
| QUAL-02 | **Complexidade ciclomática máxima** | ≤ **10** por método. Métodos complexos devem ser decompostos (ex.: `CpfValidation.GetSum`). |
| QUAL-03 | **Code review obrigatório** | Mínimo **1 aprovação** de mantenedor. `CODEOWNERS` define revisores por área. Branches protegidas (`main`, `release/*`). |
| QUAL-04 | **Lint e type-check obrigatórios** | `dotnet format --verify-no-changes`, `dotnet build` com `TreatWarningsAsErrors=true`, `Nullable=enable`. Zero warnings em código novo. |
| QUAL-05 | **Branching** | **Trunk-based development**: `main` protegida; `feature/*` de vida curta; `release/*` para estabilização. Convenção: `feature/req-XXXX-descricao`, `fix/req-XXXX-descricao`. |
| QUAL-06 | **Conventional Commits** | Obrigatório: `feat:`, `fix:`, `docs:`, `refactor:`, `perf:`, `test:`, `chore:`. Versionamento automático via `GitVersion` ou similar. |
| QUAL-07 | **Análise estática** | Roslyn Analyzers (`Microsoft.CodeAnalysis.NetAnalyzers`, `StyleCop.Analyzers`); `SonarCloud` ou `CodeQL` em CI. |
| QUAL-08 | **Gestão de dívida técnica** | `TODO`/`FIXME` com issue vinculada (`// TODO(#123): ...`). Priorização trimestral. |
| QUAL-09 | **Documentação de código** | **XML Documentation obrigatório** para todo membro `public`/`protected`/`internal` (classes, métodos, propriedades, enums). Geração de XML em build (`GenerateDocumentationFile=true`). |
| QUAL-10 | **SOLID / Clean Code** | Princípios aplicados: SRP (cada validação isolada), OCP (extensível via `IInscricaoEstadualValidation`), DIP (injeção não necessária — biblioteca stateless). |

## Princípios de UX e Acessibilidade

| ID | Princípio | Detalhamento |
|----|-----------|--------------|
| UX-01 | **WCAG 2.1** | N/A — biblioteca sem UI. Aplicações consumidoras devem atingir **AA** mínimo. |
| UX-02 | **Responsividade** | N/A — biblioteca sem UI. |
| UX-03 | **Navegação por teclado** | N/A — biblioteca sem UI. |
| UX-04 | **Contraste mínimo** | N/A — biblioteca sem UI. |
| UX-05 | **Tamanhos mínimos de alvo** | N/A — biblioteca sem UI. |
| UX-06 | **Texto alternativo e ARIA** | N/A — biblioteca sem UI. |
| UX-07 | **Testes com usuários** | N/A — biblioteca sem UI. |
| UX-08 | **Consistência visual** | N/A — biblioteca sem UI. Referenciar `padrao-visual.md` apenas para documentação do site/pacote NuGet. |
| UX-09 | **Internacionalização (i18n)** | Mensagens de exceção em **inglês** (código). Documentação externa (README, docs) em **português (pt-BR)**. |

## Princípios de Dados e Privacidade

| ID | Princípio | Detalhamento |
|----|-----------|--------------|
| DATA-01 | **Classificação de dados** | Dados processados: **Pessoais Sensíveis** (CPF, CNPJ, Título de Eleitor, IE, PIS, Renavam) — LGPD Art. 5º, II. |
| DATA-02 | **Retenção** | A biblioteca **não persiste** dados. Aplicação consumidora define retenção conforme base legal. |
| DATA-03 | **Backup e DR** | N/A — stateless. |
| DATA-04 | **Anonimização e pseudonimização** | Métodos `RemoveMask()` e `PlaceMask()` permitem exibição segura. **Obrigatório** usar `RemoveMask()` antes de enviar para logs/analytics. |
| DATA-05 | **Consentimento (LGPD)** | Responsabilidade da aplicação consumidora. Biblioteca não coleta consentimento. |
| DATA-06 | **Direitos dos titulares** | Biblioteca não armazena — não há atendimento direto. Aplicação consumidora deve prover APIs de exclusão/portabilidade. |
| DATA-07 | **Transferência internacional** | N/A — biblioteca não transfere dados. |
| DATA-08 | **DPO/Encarregado** | Responsabilidade da organização que consome a biblioteca. |

## Princípios de Arquitetura

| ID | Princípio | Detalhamento |
|----|-----------|--------------|
| ARCH-01 | **Separação de camadas** | `Documents/BR/Rules` (regras puras, sem I/O) → `Documents/BR/Validation` (orquestração, máscara) → `Extensions` (API fluente para consumidor). Proibido: dependência reversa. |
| ARCH-02 | **Contratos estáveis** | API pública via `Extensions/*Extension.cs` (métodos de extensão). Quebra de contrato exige **MAJOR** version bump. |
| ARCH-03 | **Observabilidade** | Biblioteca não emite logs/métricas. Aplicação consumidora implementa `ILogger`, `ActivitySource`, `Meter`. |
| ARCH-04 | **Idempotência** | Validações são funções puras — idempotentes por natureza. |
| ARCH-05 | **Tolerância a falhas** | Entrada inválida → `false` (não exceção). Exceções apenas para erros de programação (`ArgumentNullException`, `StateNotFoundException`). |
| ARCH-06 | **12-Factor App** | Config via código (sem arquivos de config), dependências explícitas (`System.Globalization` apenas), build/release/run separados, stateless. |
| ARCH-07 | **Resiliência de dados** | N/A — sem persistência. |
| ARCH-08 | **Multi-tenancy** | N/A — biblioteca stateless. |
| ARCH-09 | **Estratégia de mensageria** | N/A. |
| ARCH-10 | **Gateways e BFFs** | N/A. |

## Princípios de Processo

| ID | Princípio | Detalhamento |
|----|-----------|--------------|
| PROC-01 | **Rastreabilidade requisito→código→teste** | Cada funcionalidade pública mapeada a: `req-XXXX` (se aplicável), classe/método em `Sirb.Validation`, testes em `Sirb.Validation.Test`. |
| PROC-02 | **Versionamento SemVer** | `MAJOR`: breaking change na API pública; `MINOR`: nova funcionalidade compatível; `PATCH`: bugfix. Changelog em `README.md` (seção Histórico de versões). |
| PROC-03 | **Gestão de mudanças** | PRs obrigatórios para `main`. `release/*` para estabilização. Hotfix em `release/*` com cherry-pick para `main`. |
| PROC-04 | **CODEOWNERS** | `@rodabarbosa` (owner único). Reviews obrigatórios. |
| PROC-05 | **ADRs (Architecture Decision Records)** | Obrigatório para decisões significativas (ex.: mudança de target framework, nova dependência, alteração de algoritmo de validação). Local: `docs/architecture/adrs/`. Template em `constituicao.md` seção **Governance**. |
| PROC-06 | **Análise Cross-Artifact** | Executar `analise-req-XXXX.md` antes do fechamento de cada requisito (ver regra 8 de `regras.md`). |
| PROC-07 | **Clarification Log** | Ativo em todo requisito, com itens pendentes bloqueando aceite quando impactam escopo. |
| PROC-08 | **Post-mortem e lições aprendidas** | Obrigatório para incidentes de segurança, regressão de performance > 20%, ou breaking change não planejado. |
| PROC-09 | **Templates e padrões** | Uso obrigatório dos templates da skill `documentation` para todos os artefatos. |

## Governance

- **Quem pode alterar a constituição:** Mantenedor do projeto (`Rodrigo Araujo Barbosa`).
- **Quórum de aprovação:** Decisão unilateral do mantenedor (projeto de único mantenedor). Em caso de múltiplos mantenedores: 2 aprovações técnicas + 1 de produto.
- **Como propor emendas:**
  1. Abrir issue/RFC descrevendo a mudança, impacto nos princípios vigentes e nos requisitos ativos.
  2. Submeter para revisão dos aprovadores designados.
  3. Após aprovação, atualizar versão:
     - **MAJOR** — mudanças incompatíveis ou que invalidem requisitos existentes.
     - **MINOR** — adição de novos princípios ou ampliação de existentes.
     - **PATCH** — ajustes editoriais, esclarecimentos, correções de referência.
  4. Propagar a mudança para os artefatos impactados e atualizar o `README.md` (TOC raiz).
- **Periodicidade de revisão:** Semestral (janeiro e julho) ou em marcos significativos (nova versão major, mudança de arquitetura, incidente crítico).
- **Situações especiais:** Mudanças emergenciais em produção devem ser aplicadas com registro retroativo e justificativa formal.
- **Divergência entre constituição e requisito:** Prevalece a constituição; o requisito deve ser ajustado ou a constituição emendada formalmente **antes** de o requisito ser considerado fechado.

## Template de ADR (Architecture Decision Record)

> Arquivos ADR devem ser criados em `docs/architecture/adrs/ADR-NNN-titulo-kebab-case.md`.

```markdown
# ADR-NNN: Título da Decisão

## Status
Proposto | Aceito | Superado por ADR-XXX | Obsoleto

## Data
DD/MM/AAAA

## Contexto
Por que esta decisão é necessária? Quais são as restrições?
Quais requisitos devem ser satisfeitos?

## Decisão
O que foi decidido e por quê.

## Alternativas Consideradas
- Opção A: Prós, contras, por que rejeitada
- Opção B: Prós, contras, por que rejeitada

## Consequências
- O que muda como resultado desta decisão
- Quais trade-offs foram aceitos
```

**Ciclo de vida do ADR:** `PROPOSTO → ACEITO → (SUPERADO ou OBSOLETO)`
- Nunca deletar ADRs antigos — capturam contexto histórico.
- Quando uma decisão muda, escrever novo ADR que supere o anterior.

## Histórico de alterações

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 26/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação do documento |

## Clarification Log

Esta seção registra **toda pergunta, resposta, status, origem e impacto** identificada ao longo do ciclo de vida da constituição, em conformidade com o **Mecanismo de Clarification** definido em `requisitos.md`. Decisões sobre os princípios do projeto também passam por clarification quando uma ambiguidade surge (ex.: conflito entre dois princípios, valor de SLO não fornecido pelo usuário, indefinição sobre nível de criptografia). Marca `Origem=Criação` para decisões iniciais; `Origem=Implementação` para ajustes surfaced durante a evolução do projeto.

| Data | Pergunta | Resposta | Status (Resolvido/Pendente) | Origem (Criação/Implementação) | Impacto no requisito |
| ---- | -------- | -------- | --------------------------- | ------------------------------ | --------------------- |
| 26/07/2026 | Qual o nível mínimo de WCAG para a biblioteca? | N/A — biblioteca sem UI. Aplicações consumidoras devem atingir WCAG 2.1 AA. | Resolvido | Criação | Define princípio UX-01 como N/A para este projeto. |
| 26/07/2026 | A biblioteca deve implementar logging interno? | Não. Biblioteca stateless sem I/O. Observabilidade é responsabilidade da aplicação consumidora. | Resolvido | Criação | Define princípios ARCH-03 e SEC-05. |
| 26/07/2026 | Qual a meta de latência para validações? | p95 < 1 ms, p99 < 5 ms em .NET 8+ (benchmarks automatizados). | Resolvido | Criação | Define SLOs mensuráveis em PERF-01. |
| 26/07/2026 | Cobertura de testes alvo? | 100% linha/branch em código público. | Resolvido | Criação | Define QUAL-01. |
| 26/07/2026 | Como versionar a API pública? | SemVer via Conventional Commits. Breaking change = MAJOR. | Resolvido | Criação | Define PROC-02 e ARCH-02. |