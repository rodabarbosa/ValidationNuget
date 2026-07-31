# Implementation Plan: Fase 2 — Onda 1 (Alta) — Documentação de Requisitos

**Status:** APPROVED - Em execução

## Overview

Documentar 3 requisitos de alta prioridade do projeto **Sirb.Validation** (biblioteca .NET NuGet para validação, formatação e geração de documentos brasileiros): **CPF (req-0001)**, **CNPJ (req-0002)** e **Inscrição Estadual unificada para 27 estados + DF (req-0006)**.

Cada requisito produz 5 artefatos obrigatórios (req, tec-req, apf, analise, checklist), totalizando 15 arquivos, mais 3 artefatos globais (system-mapping, system-risk-matrix, tamanho-aplicacao) e a atualização do `docs/README.md` (TOC). **Total: 18 novos arquivos + 1 atualização.**

**Contexto importante do projeto:**
- **Sem UI**: Class library (NuGet). Wireframes e padrão visual são N/A.
- **Sem banco de dados**: Biblioteca stateless sem persistência. DB sections são N/A.
- **API pública**: Extension Methods em C# (não REST). Documentar API code-level.
- **Autor**: Todos os documentos usam "Rodrigo Araujo Barbosa".
- **Status inicial**: "Rascunho" (Draft).
- **Versão inicial**: 1.0.0.
- **Idioma**: req-XXXX e tec-req-XXXX em português (pt-BR).
- **Estrutura**: Flat sob `/docs/requirement/` (sem bundle — 3 requisitos independentes).

## Arquitetura / Estrutura de Diretórios

```
docs/
├── README.md (ATUALIZAR — adicionar TOC)
├── system-mapping.md (CRIAR)
├── system-risk-matrix.md (CRIAR)
├── tamanho-aplicacao.md (CRIAR)
└── requirement/
    ├── req-0001-cpf.md
    ├── tec-req-0001-cpf.md
    ├── req-0002-cnpj.md
    ├── tec-req-0002-cnpj.md
    ├── req-0006-inscricao-estadual.md
    ├── tec-req-0006-inscricao-estadual.md
    ├── apf/
    │   ├── apf-req-0001.md
    │   ├── apf-req-0002.md
    │   └── apf-req-0006.md
    ├── analise/
    │   ├── analise-req-0001.md
    │   ├── analise-req-0002.md
    │   └── analise-req-0006.md
    └── checklist/
        ├── checklist-req-0001.md
        ├── checklist-req-0002.md
        └── checklist-req-0006.md
```

## Architecture Decisions

- **N/A para esta onda**: Nenhuma decisão arquitetural significativa precisa ser registrada (os requisitos documentam funcionalidades já implementadas). Caso surja alguma divergência entre documentação e código, registrar ADR específico.
- **Template base**: Usar templates da skill `documentation` em `/home/rodbarbosa/.config/opencode/skills/documentation/template/` como referência obrigatória (regra PROC-09 da constituição).
- **Flat structure**: Os 3 requisitos são independentes entre si (cada um documenta uma funcionalidade distinta), portanto não há bundle — estrutura flat em `/docs/requirement/` é suficiente.

## Task List

### Fase 0: Preparação

- [ ] **Task 0.1: Criar estrutura de diretórios**
  - **Descrição:** Garantir que todos os diretórios necessários existam antes de iniciar a documentação.
  - **Acceptance criteria:**
    - [ ] Diretório `docs/requirement/` existe
    - [ ] Diretório `docs/requirement/apf/` existe
    - [ ] Diretório `docs/requirement/analise/` existe
    - [ ] Diretório `docs/requirement/checklist/` existe
  - **Verificação:**
    - [ ] `ls -la docs/requirement/` mostra todas as subpastas criadas
  - **Dependencies:** Nenhuma
  - **Files likely touched:**
    - `docs/requirement/` (criação de diretórios)
  - **Estimated scope:** XS
  - **Assigned agent:** planner / writer

### Fase 1: Documentação do CPF (req-0001)

**Investigação base (já realizada):**
- `CpfRule.cs` — cálculos de peso para 10º e 11º dígitos (Módulo 11)
- `CpfValidation.cs` — `IsValid()`, `PlaceMask()`, `GetIssuingState()`
- `CpfExtension.cs` — `IsCpfValid()`, `PlaceCpfMask()`
- `Cpf.cs` (Mockup) — `Generate(State?)` para geração de dados de teste
- Formato máscara: `###.###.###-##` | Tamanho: 11 dígitos | Rejeita sequências repetidas

- [ ] **Task 1.1: Criar `req-0001-cpf.md`** — Requisito de negócio CPF
  - **Description:** Documentar o requisito de negócio para validação, formatação e geração de CPF. Incluir seção "Intenção / Motivação de Negócio (Por quê)", requisitos funcionais, critérios de aceitação Gherkin, NFRs mensuráveis, matriz de risco local e Clarification Log com cobertura 8/8.
  - **Acceptance criteria:**
    - [ ] Seção "Intenção / Motivação de Negócio (Por quê)" presente com problema, impacto, público e critério de sucesso mensurável
    - [ ] RFs e RNs numeradas incrementalmente
    - [ ] Critérios de aceitação em Gherkin cobrindo validação, máscara e geração
    - [ ] NFRs alinhados com a constituição (PERF-01: p95 < 1ms, SEC-06: dados sensíveis)
    - [ ] Wireframe section marcado como N/A (sem UI)
    - [ ] Banco de dados section marcado como N/A (stateless)
    - [ ] Matriz de risco local com riscos específicos do CPF
    - [ ] Clarification Log com cobertura 8/8
  - **Verification:**
    - [ ] Arquivo criado em `docs/requirement/req-0001-cpf.md`
    - [ ] Template `req-template.md` seguido (seções obrigatórias presentes)
    - [ ] Autor = "Rodrigo Araujo Barbosa"
    - [ ] Versão = 1.0.0, Status = "Rascunho"
  - **Dependencies:** Task 0.1
  - **Files likely touched:**
    - `docs/requirement/req-0001-cpf.md` (novo)
  - **Estimated scope:** M
  - **Assigned agent:** writer

- [ ] **Task 1.2: Criar `tec-req-0001-cpf.md`** — Requisito técnico CPF
  - **Description:** Documentar o detalhamento técnico do CPF: algoritmos de validação (Módulo 11 com pesos 10-2 e 11-2), métodos de máscara, extensões públicas, geração de dados de teste, diagramas de sequência Mermaid.
  - **Acceptance criteria:**
    - [ ] Algoritmo de validação documentado com pesos, soma e comparação de dígitos
    - [ ] API pública mapeada: `IsCpfValid()`, `PlaceCpfMask()`, `RemoveMask()`, `Generate()`
    - [ ] Diagrama de sequência Mermaid do fluxo de validação
    - [ ] Regras de negócio numeradas (rejeição de sequências repetidas, validação de dígitos)
    - [ ] Exemplos de CPF válido e inválido
    - [ ] Clarification Log sincronizado com req-0001
  - **Verification:**
    - [ ] Arquivo criado em `docs/requirement/tec-req-0001-cpf.md`
    - [ ] Template `tec-req-template.md` seguido
    - [ ] Rastreabilidade: código-fonte referenciado (CpfRule.cs, CpfValidation.cs, CpfExtension.cs)
  - **Dependencies:** Task 1.1 (req-0001 deve existir)
  - **Files likely touched:**
    - `docs/requirement/tec-req-0001-cpf.md` (novo)
  - **Estimated scope:** M
  - **Assigned agent:** writer

- [ ] **Task 1.3: Criar `apf-req-0001.md`** — Análise de Pontos de Função CPF
  - **Description:** Contagem de pontos de função para o requisito CPF: classificar funções (ALI, AIE, EE, SE, CE), determinar complexidade, aplicar pesos IFPUG.
  - **Acceptance criteria:**
    - [ ] Funções identificadas e classificadas (validação como CE, geração como EE, etc.)
    - [ ] Complexidade (Low/Medium/High) determinada por DERs e RLRs
    - [ ] Pesos IFPUG aplicados
    - [ ] PFNA (Pontos de Função Não-Ajustados) calculado
  - **Verification:**
    - [ ] Arquivo criado em `docs/requirement/apf/apf-req-0001.md`
    - [ ] Totais calculados corretamente
  - **Dependencies:** Tasks 1.1 e 1.2 (req + tec-req para identificar funções)
  - **Files likely touched:**
    - `docs/requirement/apf/apf-req-0001.md` (novo)
  - **Estimated scope:** S
  - **Assigned agent:** writer

- [ ] **Task 1.4: Criar `analise-req-0001.md`** — Análise Cross-Artifact CPF
  - **Description:** Verificar consistência entre req-0001, tec-req-0001, apf-req-0001, constituição e demais artefatos. Validar RFs/RNs consistentes, alinhamento com a constituição, Clarification Log sem pendentes bloqueantes.
  - **Acceptance criteria:**
    - [ ] req-0001 e tec-req-0001 com mesmo XXXX e versão
    - [ ] "Por quê" do req alinhado com resumo do tec-req
    - [ ] RFs/RNs consistentes entre os dois documentos
    - [ ] APF cobre todas as funções do requisito
    - [ ] Alinhamento com constituição (segurança, performance, qualidade, dados, arquitetura, processo)
    - [ ] Clarification Log sem Status=Pendente bloqueante
    - [ ] Resultado: APROVADO ou APROVADO COM RESSALVAS
  - **Verification:**
    - [ ] Arquivo criado em `docs/requirement/analise/analise-req-0001.md`
    - [ ] Template `analise-cross-artifact-template.md` seguido
  - **Dependencies:** Tasks 1.1, 1.2, 1.3 (req, tec-req, apf completos)
  - **Files likely touched:**
    - `docs/requirement/analise/analise-req-0001.md` (novo)
  - **Estimated scope:** S
  - **Assigned agent:** writer

- [ ] **Task 1.5: Criar `checklist-req-0001.md`** — Quality Checklist CPF
  - **Description:** Gate final de qualidade textual e técnica para o par req-0001/tec-req-0001. Avaliar 8 dimensões: Clareza, Completude, Testabilidade, Rastreabilidade, Conformidade com a Constituição, Consistência Cross-Artifact, Acessibilidade, Manutenibilidade.
  - **Acceptance criteria:**
    - [ ] 8 dimensões avaliadas com verificações práticas (3-5 por dimensão)
    - [ ] Veredito: APROVADO ou APROVADO COM RESSALVAS
    - [ ] Ações corretivas listadas para eventuais Fails
  - **Verification:**
    - [ ] Arquivo criado em `docs/requirement/checklist/checklist-req-0001.md`
    - [ ] Template `checklist-req-template.md` seguido
  - **Dependencies:** Task 1.4 (análise cross-artifact completa)
  - **Files likely touched:**
    - `docs/requirement/checklist/checklist-req-0001.md` (novo)
  - **Estimated scope:** S
  - **Assigned agent:** writer

### Checkpoint: CPF (req-0001)

- [ ] Todos os 5 artefatos do CPF criados
- [ ] `req-0001-cpf.md` e `tec-req-0001-cpf.md` com versão e status consistentes
- [ ] `apf-req-0001.md` com PFNA calculado
- [ ] `analise-req-0001.md` com resultado APROVADO ou APROVADO COM RESSALVAS
- [ ] `checklist-req-0001.md` com veredito APROVADO ou APROVADO COM RESSALVAS

### Fase 2: Documentação do CNPJ (req-0002)

**Investigação base (já realizada):**
- `CnpjRule.cs` — cálculos de peso para 13º e 14º dígitos (Módulo 11)
- `CnpjValidation.cs` — `IsValid()`, `PlaceMask()`
- `CnpjExtension.cs` — `IsCnpjValid()`, `PlaceCnpjMask()`
- `Cnpj.cs` (Mockup) — `Generate()` para testes
- Formato máscara: `##.###.###/####-##` | Tamanho: 14 dígitos | Rejeita sequências repetidas

- [ ] **Task 2.1: Criar `req-0002-cnpj.md`** — Requisito de negócio CNPJ
  - **Description:** Documentar o requisito de negócio para validação, formatação e geração de CNPJ. Mesma estrutura do req-0001, adaptada para CNPJ.
  - **Acceptance criteria:** (mesma estrutura do Task 1.1, adaptada para CNPJ)
  - **Verification:** Arquivo criado em `docs/requirement/req-0002-cnpj.md`
  - **Dependencies:** Task 0.1
  - **Files likely touched:**
    - `docs/requirement/req-0002-cnpj.md` (novo)
  - **Estimated scope:** M
  - **Assigned agent:** writer

- [ ] **Task 2.2: Criar `tec-req-0002-cnpj.md`** — Requisito técnico CNPJ
  - **Description:** Documentar o detalhamento técnico do CNPJ: algoritmo Módulo 11 com pesos 5-2 (13º dígito) e 6-2 (14º dígito), métodos de máscara, extensões públicas, geração de dados de teste, diagramas.
  - **Acceptance criteria:** Algoritmo documentado, API mapeada, diagrama Mermaid
  - **Verification:** Arquivo criado em `docs/requirement/tec-req-0002-cnpj.md`
  - **Dependencies:** Task 2.1
  - **Files likely touched:**
    - `docs/requirement/tec-req-0002-cnpj.md` (novo)
  - **Estimated scope:** M
  - **Assigned agent:** writer

- [ ] **Task 2.3: Criar `apf-req-0002.md`** — Análise de Pontos de Função CNPJ
  - **Description:** Contagem APF para o requisito CNPJ.
  - **Acceptance criteria:** Funções classificadas, complexidade determinada, PFNA calculado
  - **Verification:** Arquivo criado em `docs/requirement/apf/apf-req-0002.md`
  - **Dependencies:** Tasks 2.1 e 2.2
  - **Files likely touched:**
    - `docs/requirement/apf/apf-req-0002.md` (novo)
  - **Estimated scope:** S
  - **Assigned agent:** writer

- [ ] **Task 2.4: Criar `analise-req-0002.md`** — Análise Cross-Artifact CNPJ
  - **Description:** Verificar consistência entre artefatos do CNPJ.
  - **Acceptance criteria:** Resultado APROVADO ou APROVADO COM RESSALVAS
  - **Verification:** Arquivo criado em `docs/requirement/analise/analise-req-0002.md`
  - **Dependencies:** Tasks 2.1, 2.2, 2.3
  - **Files likely touched:**
    - `docs/requirement/analise/analise-req-0002.md` (novo)
  - **Estimated scope:** S
  - **Assigned agent:** writer

- [ ] **Task 2.5: Criar `checklist-req-0002.md`** — Quality Checklist CNPJ
  - **Description:** Gate final de qualidade para CNPJ.
  - **Acceptance criteria:** Veredito APROVADO ou APROVADO COM RESSALVAS
  - **Verification:** Arquivo criado em `docs/requirement/checklist/checklist-req-0002.md`
  - **Dependencies:** Task 2.4
  - **Files likely touched:**
    - `docs/requirement/checklist/checklist-req-0002.md` (novo)
  - **Estimated scope:** S
  - **Assigned agent:** writer

### Checkpoint: CNPJ (req-0002)

- [ ] Todos os 5 artefatos do CNPJ criados
- [ ] Checkpoint similar ao CPF

### Fase 3: Documentação da Inscrição Estadual (req-0006)

**Investigação base (já realizada):**
- `IInscricaoEstadualValidation` (interface) + `IInscricaoEstadualInternal` (interface)
- `InscricaoEstadualValidation.cs` — orquestrador que roteia para validadores por estado
- `State.cs` — enum com 27 estados + DF (28 valores)
- 27 classes de validação em `Validation/Ie/` (uma por estado)
- 27 funções de máscara nas Extensions (uma por estado)
- `InscricaoEstadual.cs` — `Generate(State)` e geradores por estado em `Mockups/Ie/`
- **Cada estado tem seu próprio:** algoritmo de validação, formato de máscara, lógica de geração
- Dependência: `System.Text.RegularExpressions` para masking

- [ ] **Task 3.1: Criar `req-0006-inscricao-estadual.md`** — Requisito de negócio Inscrição Estadual
  - **Description:** Documentar o requisito de negócio para validação, formatação e geração de Inscrição Estadual para 27 estados + DF. Por ser um requisito grande (28 variações), documentar a estrutura unificada com referências às particularidades de cada estado.
  - **Acceptance criteria:**
    - [ ] Cobertura dos 27 estados + DF explicitamente listada
    - [ ] Referência à interface polimórfica `IInscricaoEstadualValidation`
    - [ ] CRITÉRIO: como este é um requisito grande (28 algoritmos distintos), a documentação deve focar na estrutura unificada e nos padrões comuns, com referência às implementações específicas
  - **Verification:** Arquivo criado em `docs/requirement/req-0006-inscricao-estadual.md`
  - **Dependencies:** Task 0.1
  - **Files likely touched:**
    - `docs/requirement/req-0006-inscricao-estadual.md` (novo)
  - **Estimated scope:** M (pode tender a L — decompor se necessário)
  - **Assigned agent:** writer

- [ ] **Task 3.2: Criar `tec-req-0006-inscricao-estadual.md`** — Requisito técnico Inscrição Estadual
  - **Description:** Documentar o detalhamento técnico da IE: arquitetura de roteamento por estado (dicionário State → IInscricaoEstadualValidation), enum State, interface, padrão Strategy, 28 implementações de validação, 28 funções de máscara, geradores de dados de teste. Incluir tabela resumo dos 28 estados com formato de máscara, tamanho e particularidades do algoritmo.
  - **Acceptance criteria:**
    - [ ] Arquitetura de roteamento por estado documentada (dicionário + interface)
    - [ ] Tabela dos 28 estados com formato de máscara, tamanho e validação
    - [ ] Diagrama de sequência Mermaid do fluxo de validação com roteamento
    - [ ] API pública mapeada: `InscricaoEstadualValidation.IsValid()`, `PlaceMask()` (por extensão), `Generate()`
  - **Verification:** Arquivo criado em `docs/requirement/tec-req-0006-inscricao-estadual.md`
  - **Dependencies:** Task 3.1
  - **Files likely touched:**
    - `docs/requirement/tec-req-0006-inscricao-estadual.md` (novo)
  - **Estimated scope:** M (pode tender a L — decompor se necessário)
  - **Assigned agent:** writer

- [ ] **Task 3.3: Criar `apf-req-0006.md`** — Análise de Pontos de Função Inscrição Estadual
  - **Description:** Contagem APF para o requisito IE. Considerar as 28 variações como funções relacionadas usando o princípio de contagem por tipo (não 28x a mesma função).
  - **Acceptance criteria:** Funções classificadas (validação como CE, geração como EE, máscara como SE), PFNA calculado
  - **Verification:** Arquivo criado em `docs/requirement/apf/apf-req-0006.md`
  - **Dependencies:** Tasks 3.1 e 3.2
  - **Files likely touched:**
    - `docs/requirement/apf/apf-req-0006.md` (novo)
  - **Estimated scope:** S
  - **Assigned agent:** writer

- [ ] **Task 3.4: Criar `analise-req-0006.md`** — Análise Cross-Artifact Inscrição Estadual
  - **Description:** Verificar consistência entre artefatos da IE.
  - **Acceptance criteria:** Resultado APROVADO ou APROVADO COM RESSALVAS
  - **Verification:** Arquivo criado em `docs/requirement/analise/analise-req-0006.md`
  - **Dependencies:** Tasks 3.1, 3.2, 3.3
  - **Files likely touched:**
    - `docs/requirement/analise/analise-req-0006.md` (novo)
  - **Estimated scope:** S
  - **Assigned agent:** writer

- [ ] **Task 3.5: Criar `checklist-req-0006.md`** — Quality Checklist Inscrição Estadual
  - **Description:** Gate final de qualidade para IE.
  - **Acceptance criteria:** Veredito APROVADO ou APROVADO COM RESSALVAS
  - **Verification:** Arquivo criado em `docs/requirement/checklist/checklist-req-0006.md`
  - **Dependencies:** Task 3.4
  - **Files likely touched:**
    - `docs/requirement/checklist/checklist-req-0006.md` (novo)
  - **Estimated scope:** S
  - **Assigned agent:** writer

### Checkpoint: Inscrição Estadual (req-0006)

- [ ] Todos os 5 artefatos da IE criados
- [ ] Checkpoint similar ao CPF

### Fase 4: Artefatos Globais e Finalização

- [ ] **Task 4.1: Criar `system-mapping.md`** — Mapeamento do Sistema
  - **Description:** Documento contínuo e cumulativo que mapeia a arquitetura do sistema. Incluir visão geral, estrutura de pastas, componentes, classes principais dos 3 requisitos documentados, relacionamentos entre camadas (Rules → Validation → Extensions → Mockups).
  - **Acceptance criteria:**
    - [ ] Visão geral do sistema (Sirb.Validation)
    - [ ] Estrutura de diretórios completa
    - [ ] Mapa de componentes com responsabilidades
    - [ ] Tabela de classes principais dos 3 requisitos (CPF, CNPJ, IE)
    - [ ] Mapeamento de relacionamentos entre camadas
  - **Verification:**
    - [ ] Arquivo criado em `docs/system-mapping.md`
    - [ ] Conteúdo referenciado na TOC do `docs/README.md`
  - **Dependencies:** Tasks 1.1-1.2, 2.1-2.2, 3.1-3.2 (depende da documentação dos requisitos para mapear corretamente)
  - **Files likely touched:**
    - `docs/system-mapping.md` (novo)
  - **Estimated scope:** M
  - **Assigned agent:** writer

- [ ] **Task 4.2: Criar `system-risk-matrix.md`** — Matriz de Risco Global
  - **Description:** Matriz de risco global do sistema consolidando riscos dos 3 requisitos (CPF, CNPJ, IE). Incluir riscos de segurança (dados sensíveis — LGPD), performance (regressão de validação), manutenibilidade (28 estados da IE), conformidade (algoritmos incorretos), qualidade (cobertura de testes).
  - **Acceptance criteria:**
    - [ ] Riscos dos 3 requisitos consolidados
    - [ ] Cada risco com ID, descrição, probabilidade, impacto, nível, mitigação, status
    - [ ] Riscos incluem: dados sensíveis (LGPD), performance (benchmark), manutenibilidade (IE), conformidade fiscal, qualidade
  - **Verification:**
    - [ ] Arquivo criado em `docs/system-risk-matrix.md`
    - [ ] Tabela com colunas: ID do Risco, Requisito relacionado, Descrição, Probabilidade, Impacto, Nível, Mitigação, Status
    - [ ] Conteúdo referenciado na TOC do `docs/README.md`
  - **Dependencies:** Tasks 1.1, 2.1, 3.1 (matrizes locais nos req-XXXX)
  - **Files likely touched:**
    - `docs/system-risk-matrix.md` (novo)
  - **Estimated scope:** S
  - **Assigned agent:** writer

- [ ] **Task 4.3: Criar `tamanho-aplicacao.md`** — APF Consolidado
  - **Description:** Documento consolidado que soma os pontos de função dos 3 requisitos (apf-req-0001 + apf-req-0002 + apf-req-0006) e apresenta o tamanho total estimado da aplicação.
  - **Acceptance criteria:**
    - [ ] Soma dos PFNA dos 3 requisitos
    - [ ] Tabela resumo por requisito
    - [ ] Fator de Ajuste (VAF) calculado (opcional — pode ser omitido para biblioteca stateless)
    - [ ] PF Ajustado total (se VAF aplicado)
  - **Verification:**
    - [ ] Arquivo criado em `docs/tamanho-aplicacao.md`
    - [ ] Totais batem com a soma dos apf-req-XXXX individuais
    - [ ] Conteúdo referenciado na TOC do `docs/README.md`
  - **Dependencies:** Tasks 1.3, 2.3, 3.3 (todos os APFs individuais)
  - **Files likely touched:**
    - `docs/tamanho-aplicacao.md` (novo)
  - **Estimated scope:** S
  - **Assigned agent:** writer

- [ ] **Task 4.4: Atualizar `docs/README.md`** — TOC Raiz
  - **Description:** Atualizar o TOC raiz da documentação com links para todos os novos artefatos criados (requisitos, APFs, análises, checklists, system-mapping, risk-matrix, tamanho-aplicacao). Atualizar tabela de status dos artefatos e última atualização global.
  - **Acceptance criteria:**
    - [ ] Seção "Requisitos" com links para req-0001, req-0002, req-0006
    - [ ] Links para todos os 18 novos artefatos
    - [ ] Tabela de status atualizada
    - [ ] Data da última atualização alterada
  - **Verification:**
    - [ ] `docs/README.md` lido e confirmado com links funcionais
  - **Dependencies:** Tasks 4.1, 4.2, 4.3 (artefatos globais concluídos)
  - **Files likely touched:**
    - `docs/README.md` (atualização)
  - **Estimated scope:** S
  - **Assigned agent:** writer

### Checkpoint: Final

- [ ] Todos os 18 arquivos criados + 1 atualizado
- [ ] Build da solution não é aplicável (documentação pura — sem código)
- [ ] Verificação cruzada: todos os links do TOC funcionam
- [ ] Ready for review

## Parallelization Strategy

| Wave | Tasks | Tipo | Observação |
|------|-------|------|------------|
| **Wave A** | Tasks 1.1 → 1.2 → 1.3 → 1.4 → 1.5 | **Sequencial** (cada task depende da anterior dentro do mesmo req) | CPF completo em sequência |
| **Wave B** | Tasks 2.1 → 2.2 → 2.3 → 2.4 → 2.5 | **Sequencial** (cada task depende da anterior dentro do mesmo req) | CNPJ completo em sequência |
| **Wave C** | Tasks 3.1 → 3.2 → 3.3 → 3.4 → 3.5 | **Sequencial** (cada task depende da anterior dentro do mesmo req) | IE completo em sequência |
| **Inter-Wave** | Waves A, B, C entre si | **Paralelizável** (requisitos independentes) | CPF, CNPJ e IE não dependem entre si |
| **Wave D** | Tasks 4.1, 4.2, 4.3, 4.4 | **Sequencial** (dependem dos artefatos das Waves A, B, C) | Artefatos globais após conclusão dos requisitos |

**Contratos compartilhados:** Nenhum — os 3 requisitos são independentes (cada um documenta uma funcionalidade distinta da biblioteca). Podem ser executados em paralelo por agentes diferentes, cada um seguindo a sequência interna req → tec-req → apf → analise → checklist.

## Dependency Graph

```
Task 0.1 (diretórios)
  ├── Task 1.1 (req-cpf) → Task 1.2 (tec-req-cpf) → Task 1.3 (apf-cpf) → Task 1.4 (analise-cpf) → Task 1.5 (checklist-cpf)
  ├── Task 2.1 (req-cnpj) → Task 2.2 (tec-req-cnpj) → Task 2.3 (apf-cnpj) → Task 2.4 (analise-cnpj) → Task 2.5 (checklist-cnpj)
  └── Task 3.1 (req-ie) → Task 3.2 (tec-req-ie) → Task 3.3 (apf-ie) → Task 3.4 (analise-ie) → Task 3.5 (checklist-ie)
                              │
                              └── Task 4.1 (system-mapping)
                                   Task 4.2 (risk-matrix) ← reqs 1,2,3
                                   Task 4.3 (tamanho-aplicacao) ← apfs 1,2,3
                                   Task 4.4 (README TOC) ← todos anteriores
```

## Estoque de Arquivos

| # | Arquivo | Status |
|---|---------|--------|
| 1 | `docs/requirement/req-0001-cpf.md` | `[ ]` |
| 2 | `docs/requirement/tec-req-0001-cpf.md` | `[ ]` |
| 3 | `docs/requirement/apf/apf-req-0001.md` | `[ ]` |
| 4 | `docs/requirement/analise/analise-req-0001.md` | `[ ]` |
| 5 | `docs/requirement/checklist/checklist-req-0001.md` | `[ ]` |
| 6 | `docs/requirement/req-0002-cnpj.md` | `[ ]` |
| 7 | `docs/requirement/tec-req-0002-cnpj.md` | `[ ]` |
| 8 | `docs/requirement/apf/apf-req-0002.md` | `[ ]` |
| 9 | `docs/requirement/analise/analise-req-0002.md` | `[ ]` |
| 10 | `docs/requirement/checklist/checklist-req-0002.md` | `[ ]` |
| 11 | `docs/requirement/req-0006-inscricao-estadual.md` | `[ ]` |
| 12 | `docs/requirement/tec-req-0006-inscricao-estadual.md` | `[ ]` |
| 13 | `docs/requirement/apf/apf-req-0006.md` | `[ ]` |
| 14 | `docs/requirement/analise/analise-req-0006.md` | `[ ]` |
| 15 | `docs/requirement/checklist/checklist-req-0006.md` | `[ ]` |
| 16 | `docs/system-mapping.md` | `[ ]` |
| 17 | `docs/system-risk-matrix.md` | `[ ]` |
| 18 | `docs/tamanho-aplicacao.md` | `[ ]` |
| — | `docs/README.md` (atualizar) | `[ ]` |

## Risks and Mitigations

| Risco | Impacto | Probabilidade | Mitigação |
|-------|---------|---------------|-----------|
| **req-0006 muito grande** (28 estados) pode tornar os documentos muito extensos | Médio — documentos muito longos podem ter qualidade reduzida | Alta | Decompor: documentar estrutura unificada + padrões comuns no corpo; criar tabela resumo dos 28 estados; detalhamento completo de cada estado pode ficar para ondas futuras se necessário |
| **Divergência entre documentação e código** (código mudou desde a última investigação) | Alto — documentos incorretos | Média | Re-verificar código-fonte imediatamente antes de escrever cada artefato; rodar `dotnet build` e `dotnet test` para confirmar que o código compila |
| **Clarification Log com pendências bloqueantes** impede fechamento do requisito | Médio — atrasa conclusão da onda | Média | Usar perguntas progressivas via `question` tool (via orchestrator) durante a elicitação; priorizar resolução de pendências antes de avançar para próxima fase |
| **Cobertura 8/8 do Clarification não atingida** | Médio — requisito não pode ser fechado | Média | Usar a subseção "Cobertura do Clarification (8 áreas)" para rastrear; preencher N/A com justificativa explícita quando aplicável |
| **APF com contagem incorreta** (especialmente IE com 28 variações) | Baixo — não bloqueia, mas ajuste necessário | Média | Usar princípio de contagem agrupada para IE (funções similares, não 28 × mesma função); revisar após análise cross-artifact |

## Changes

### Added

- `docs/requirement/req-0001-cpf.md` — Requisito de negócio CPF
- `docs/requirement/tec-req-0001-cpf.md` — Requisito técnico CPF
- `docs/requirement/apf/apf-req-0001.md` — APF CPF
- `docs/requirement/analise/analise-req-0001.md` — Análise Cross-Artifact CPF
- `docs/requirement/checklist/checklist-req-0001.md` — Quality Checklist CPF
- `docs/requirement/req-0002-cnpj.md` — Requisito de negócio CNPJ
- `docs/requirement/tec-req-0002-cnpj.md` — Requisito técnico CNPJ
- `docs/requirement/apf/apf-req-0002.md` — APF CNPJ
- `docs/requirement/analise/analise-req-0002.md` — Análise Cross-Artifact CNPJ
- `docs/requirement/checklist/checklist-req-0002.md` — Quality Checklist CNPJ
- `docs/requirement/req-0006-inscricao-estadual.md` — Requisito de negócio Inscrição Estadual
- `docs/requirement/tec-req-0006-inscricao-estadual.md` — Requisito técnico Inscrição Estadual
- `docs/requirement/apf/apf-req-0006.md` — APF Inscrição Estadual
- `docs/requirement/analise/analise-req-0006.md` — Análise Cross-Artifact Inscrição Estadual
- `docs/requirement/checklist/checklist-req-0006.md` — Quality Checklist Inscrição Estadual
- `docs/system-mapping.md` — Mapeamento do sistema
- `docs/system-risk-matrix.md` — Matriz de risco global
- `docs/tamanho-aplicacao.md` — APF consolidado

### Modified

- `docs/README.md` — Atualização do TOC com links para todos os novos artefatos

### Removed

- Nenhum

## Open Questions

- `⏳ PENDENTE` — Nenhuma pendência no momento. Se durante a execução surgirem ambiguidades (ex.: algoritmo de validação específico de algum estado da IE que não está claro no código), registrar no Clarification Log e rotear pergunta via `question` tool (via orchestrator).
