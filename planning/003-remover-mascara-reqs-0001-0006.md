# Implementation Plan: Remoção de conteúdo de máscara dos requisitos req-0001..req-0006 (validação pura)

**Status:** COMPLETED — 31/07/2026 (T1–T15 concluídas; verificação final T15 executada; divergência P7 resolvida; plano encerrado)

**Audit Ref:** TRACE-2026-0731-01 · **Data:** 31/07/2026 · **Autor do plano:** planner (subagent do orchestrator)

## 1. Overview

Refatoração **somente de documentação** (`docs/`) para que os requisitos `req-0001..req-0006` (CPF, CNPJ, PIS, Título de Eleitor, Renavam, Inscrição Estadual) passem a descrever **apenas validação**. O conteúdo de máscara/formatação (PlaceMask, `_mask`, RemoveMask, Gherkin/RF/RN de máscara, riscos de máscara, evidências de métodos de máscara) será removido de `req-0001..0006` e de `tec-req-0001..0006`, porque já vive nos requisitos independentes `req-0014..0018` (máscaras). Os 10 arquivos `*-validacao-mascara.md` são renomeados via `git mv` para `*-validacao.md` (preservando histórico). APFs dos reqs 0001..0006 são recalculados (total consolidado 126→**92 PF**, com correção da inconsistência pré-existente 126 vs 114). Todas as referências cruzadas (README, system-mapping, system-risk-matrix, tamanho-aplicacao, análises cross-artifact, checklists, req-0014..0018 e tec-req-0014..0018) são atualizadas. Nenhum arquivo `.cs` é alterado.

**Dono da execução:** agente `writer` (todas as tarefas de edição de documentação). Este plano é o contrato de execução; o `writer` executa as ondas na ordem de dependência e atualiza este arquivo em tempo real (checklist `[ ]→[x]`, seção Changes).

## 2. Contexto da demanda (restated)

O usuário determinou: `req-0001-cpf-validacao-mascara.md` deve virar `req-0001-cpf-validacao.md` e o documento deve descrever **apenas a validação**; o mesmo vale para req-0002..req-0006. O conteúdo de máscara (formatação PlaceMask) já vive nos novos requisitos `req-0014..0018` e deve ser **removido** de `req-0001..0006` (e dos `tec-req-0001..0006` correspondentes). Base: `/home/rodbarbosa/Projetos/ValidationNuget` (docs em `docs/`, padrão da skill `documentation`).

## 3. Escopo / Fora de escopo

### In scope
- Renomear 10 arquivos via `git mv` (5 `req-*` + 5 `tec-req-*`).
- Remover conteúdo de máscara de `req-0001..0006` e `tec-req-0001..0006`, mantendo validação (`IsValid`/`IsCpfValid` etc.), estado emissor (CPF) e **normalização de entrada via `OnlyNumbers`** quando fizer parte do fluxo de validação.
- Atualizar frontmatter/metadados (title, description, tags, title_pt, resource, version, updated) dos arquivos tocados.
- Recalcular APFs `apf-req-0001..0006` e o consolidado `tamanho-aplicacao.md`.
- Atualizar referências cruzadas (inventário na seção 7).
- Version bump + linha de histórico datada 31/07/2026, autor "Rodrigo Araujo Barbosa", em **todos** os artefatos modificados (regra da skill `documentation`).

### Out of scope (restrições)
- **Nenhum** arquivo `.cs` (código-fonte).
- Nenhuma criação de documentação fora de `docs/` (exceto este plano em `planning/`, que é artefato de planejamento).
- `req-0014..0018` / `tec-req-0014..0018`: **intactos em escopo** — apenas atualização de referências aos reqs base renomeados + version bump.
- Não renomear `apf-*`, `analise-*`, `checklist-*` (não têm "mascara" no nome).
- Corrigir inconsistências pré-existentes **apenas** onde o escopo toca; o restante é sinalizado em Open Questions (seção 10).

## 4. Decisões de planejamento

| # | Decisão | Racional |
| - | ------- | -------- |
| D1 | **Baseline APF pré-existente = 114 PF** (soma da tabela e das APFs por requisito). O valor "126 PF" de frontmatter/nota está errado (os 5 reqs novos somam 24 PF, não 36; e 90+24=114). Após remoção: **92 PF**. | A fonte de verdade é `docs/requirement/apf/apf-req-XXXX.md` (soma = 114). Verificado por aritmética. |
| D2 | **Dupla contagem RemoveMask/OnlyNumbers em `apf-req-0013` (21 PF, 2 CEs para o mesmo método): SINALIZAR, não ajustar.** | Ajustar mudaria o total para 89 PF (fora do esperado de 92) e expande o escopo para problema pré-existente não causado pela remoção de máscara. Recomendação: plano futuro. Registrado em Open Questions (P1). |
| D3 | **Riscos de máscara RSK-002/005/007/013 removidos da matriz global** (30→26 riscos), pois a funcionalidade migrou para req-0014..0018, onde RSK-020/022/024/028 já cobrem os mesmos riscos. | Manter os dois conjuntos seria duplicação. |
| D4 | **Renumeração limpa (sem gaps) de RFs/RNs** nos 5 reqs com máscara removida, sincronizando tec-req/analise/checklist do mesmo slice. | Rastreabilidade sem buracos; todas as referências familiares estão sendo editadas no mesmo slice. Verificação via grep de ranges. |
| D5 | **Convenção unificada de diretório de análises: `analise/` (singular) para TODOS os reqs (0001..0018)** — REVISADA em 31/07/2026 por decisão soberana do usuário. O diretório canônico de análises cross-artifact é `docs/requirement/analise/`; o diretório `analises/` **será removido**. Os arquivos `analise-req-0001..0006` (atualmente em `analises/`) são movidos via `git mv` para `analise/` (que já contém 0014..0018); todos os links nos arquivos em edição (req-0001..0006, README e demais referências) passam a apontar para `analise/`. | Antes (decisão anterior): corrigir links pontuais em arquivos já em edição, sem mover diretórios. **Após 31/07/2026:** migração completa para o singular — `analise/` é a convenção para todos os 18 reqs; `analises/` deixa de existir. Movimentação dos 13 arquivos em execução paralela pelo `writer`. |
| D6 | **`req-0005`/`tec-req-0005`/`apf-req-0005`**: sem rename e sem conteúdo de máscara; manter a nota factual "Renavam não tem máscara"; aplicar version bump 1.1.0 por consistência da família. `checklist-req-0005` não é alterado (não possui conteúdo de máscara nem nome antigo). | Demanda: "revisar apenas menção 'não tem máscara'". Nota factual preservada; bump registra a revisão. |

## 5. Recálculo APF — números exatos

| Requisito | Antes | Funções removidas | Depois | Δ |
| --------- | ----- | ----------------- | ------ | - |
| req-0001 | 12 PF | PlaceCpfMask (EE 3) + RemoveMask (CE 3) — fica IsCpfValid (EE 3) + GetIssuingState (EE 3) | **6 PF** | −6 |
| req-0002 | 6 PF | PlaceCnpjMask (EE 3) — fica IsCnpjValid (EE 3) | **3 PF** | −3 |
| req-0003 | 6 PF | PlacePisMask (EE 3) — fica IsPisValid (EE 3) | **3 PF** | −3 |
| req-0004 | 6 PF | PlaceTituloEleitorMask (EE 3) — fica IsTituloEleitorValid (EE 3) | **3 PF** | −3 |
| req-0005 | 3 PF | — (inalterado) | **3 PF** | 0 |
| req-0006 | 11 PF | PlaceMask (EE Média 4) + RemoveMask (CE 3) — fica IsValid(State,string) (EE Média 4) | **4 PF** | −7 |
| req-0007..0012 | 25 PF | — | 25 PF | 0 |
| req-0013 | 21 PF | — (RemoveMask/OnlyNumbers permanecem; ver D2/P1) | 21 PF | 0 |
| req-0014..0017 | 12 PF | — | 12 PF | 0 |
| req-0018 | 12 PF | — | 12 PF | 0 |
| **Total** | **114 PF\*** | | **92 PF** | **−22** |

\* Baseline consistente (soma das APFs por requisito). O frontmatter/nota do consolidado dizia "126 PF" e "adicionaram 36 PF" — ambos incorretos (ver D1). Após a remoção: **92 PF** e "adicionaram 24 PF" nos reqs 0014..0018.

**Novos componentes para a tabela consolidada (`tamanho-aplicacao.md`):** EE total = 13 (0001:2, 0002:1, 0003:1, 0004:1, 0005:1, 0006:1, 0014..0017:1 cada, 0018:2); CE = 7 (0013); EO = 6 (0007..0012); ALI = 1 (0018). Total PF por componentes = 92. **Nota para o writer:** os componentes da linha req-0018 no consolidado (EE 2 + ALI 1 = 12 PF declarados) vêm do `apf-req-0018` que usa ajuste por sobreposição (PFNA 21 → 12); copiar a linha como está e, se a soma dos componentes da tabela consolidada divergir do total, adicionar nota de rodapé "ajuste por sobreposição documentado em apf-req-0018" (pré-existente).

## 6. Ondas e Tarefas

Legenda: **Onda paralela (P)** = independente; **Sequencial (S)** = depende da anterior; **Coordenada (C)** = precisa de contrato definido antes (aqui: nomes finais de arquivos — definidos na seção 7 antes da Onda 2).

### Fase 1 — Renomeações (fundação) · Sequencial

- [x] **T1: Renomear 5 arquivos `req-*` via `git mv`** (S)
  - **Descrição:** Executar `git mv` dos 5 reqs de validação-máscara para os novos nomes `*-validacao.md` (lista exata na seção 7, itens R1–R5).
  - **Critérios de aceitação:**
    - [x] `git status --short` mostra os 5 arquivos como renamed (R) com 100% de similaridade
    - [x] Não resta `docs/requirement/req-000{1,2,3,4,6}-*-validacao-mascara.md`
  - **Verificação:** `git status --short docs/requirement/` ; `ls docs/requirement/req-000*`
  - **Dependências:** None
  - **Arquivos:** `docs/requirement/req-0001..0006` (5 renames)
  - **Tamanho:** S · **Agente:** writer

- [x] **T2: Renomear 5 arquivos `tec-req-*` via `git mv`** (S)
  - **Descrição:** Mesmo procedimento para `tec-req-000{1,2,3,4,6}-*-validacao-mascara.md` → `*-validacao.md`.
  - **Nota 31/07/2026 (D5 revisada):** nesta tarefa também mover os 6 arquivos `docs/requirement/analises/analise-req-0001..0006.md` → `docs/requirement/analise/analise-req-0001..0006.md` via `git mv` (convenção unificada `analise/` — singular), removendo em seguida o diretório vazio `analises/`. Se a movimentação dos 13 arquivos já tiver sido executada pelo `writer` em paralelo, apenas confirmar com `git status`.
  - **Critérios de aceitação:**
    - [x] `git status --short` mostra os 5 arquivos como renamed (R)
    - [x] Não resta `docs/requirement/tec/tec-req-000{1,2,3,4,6}-*-validacao-mascara.md`
  - **Verificação:** `git status --short docs/requirement/tec/` (OK — 10 renames confirmados em T1/T2; movimentação analises/→analise/ já executada: 13 RM em git status)
  - **Dependências:** T1
  - **Arquivos:** `docs/requirement/tec/tec-req-0001..0006` (5 renames) + `docs/requirement/analise/analise-req-0001..0006` (6 moves)
  - **Tamanho:** S · **Agente:** writer

- **Checkpoint 1 (Fase 1):** [x] 10 renames confirmados; nenhum `*-validacao-mascara.md` restante em `docs/requirement/`.
- **Checkpoint 1b (D5 revisada — 31/07/2026):** [x] 6 arquivos `analise-req-0001..0006` em `docs/requirement/analise/` (singular); diretório `analises/` vazio/removido. (Confirmado via `git status`: 13 RM `analises/` → `analise/`.)

### Fase 2 — Slices verticais por família de documento · Sequencial (slices independentes entre si → paralelizáveis; executados em sequência por um único writer)

Contrato compartilhado definido **antes** da Fase 2 (Onda Coordenada): nomes finais na seção 7; renumeração RF/RN conforme D4; versão alvo 1.1.0; histórico "31/07/2026 | Rodrigo Araujo Barbosa | 1.1.0 | ...".

- [x] **T3: Slice CPF — req-0001, tec-req-0001, apf-req-0001, checklist-req-0001, analise-req-0001** (M, 5 arquivos)
  - **Descrição:** No req-0001 (renomeado): remover do frontmatter/H1/Metadados toda menção a máscara (title, description, resource, tags `mascara`, title_pt); Objetivo; Escopo In ("aplicação de máscara", "remoção de máscara"); Descrição geral (gatilho `PlaceCpfMask`, resultado de máscara); RF-003 (PlaceMask) e RF-004 (RemoveMask) com **renumeração** (GetIssuingState→RF-003, nulo/vazio→RF-004); RN-004 (máscara) com **renumeração** (UF emissora→RN-004); Gherkin "Aplicar máscara em CPF válido" e "Aplicar máscara em CPF vazio" (linhas ~141–149); NFR "Alocação zero" (menciona PlaceMask) e NFR "Dados sensíveis" (substituir "usar PlaceMask() antes de logar" por referência ao req-0014); risco local RSK-002; Impactos técnicos (remover PlaceMask/PlaceCpfMask); Clarification Log (entradas de PlaceMask: reescrever mantendo validação, delegar comportamento de máscara ao req-0014; manter entradas de OnlyNumbers/estado emissor/ausência de máscara no Renavam); "Cobertura do Clarification" (ranges RF/RN). **Manter:** validação, GetIssuingState, normalização via OnlyNumbers, cenário "CPF válido com máscara" (entrada normalizada — renomear para "CPF válido com pontuação"). Frontmatter/Metadados: version 1.1.0, updated 31/07/2026; link `analise/` (convenção unificada — D5 revisada); Histórico + linha 31/07/2026. No tec-req-0001: remover seção "2.4 Máscara"; RF/RN de máscara com renumeração; diagrama de camadas (PlaceCpfMask/PlaceMask/RemoveMask); mermaid/sequência (`RemoveMask()`→`OnlyNumbers()`); exemplos de código (bloco "--- Máscara ---"); Clarification Log (linha RemoveMask→OnlyNumbers); rastreabilidade (nome antigo). No apf-req-0001: remover linhas PlaceCpfMask e RemoveMask → **6 PF** (EE 2); justificativa; título/descrição. No checklist-req-0001: título/descrição/metadados; evidências das linhas 1.3, 1.5, 2.2, 2.3 (ranges), 2.4 (10→8 cenários), 3.2. Na analise-req-0001: título (linha 21); referências (37–38, novos nomes); versão artefatos analisados v1.1.0; linha APF (54: 12→6 PF); linha risco local (55: RSK-001/002/003→RSK-001/003); linha Dados/Privacidade (65: DATA-04 → referenciar req-0014 ou remover, mantendo DATA-01).
  - **Critérios de aceitação:**
    - [x] Nenhuma linha de máscara restante no req-0001/tec-req-0001 exceto menções válidas (req-0014, OnlyNumbers, "não possui máscara")
    - [x] apf-req-0001 = 6 PF (EE: IsCpfValid + GetIssuingState)
    - [x] RF/RN renumerados sem gaps e referências familiares atualizadas (tec-req, checklist, analise)
  - **Verificação:** `grep -inE "m[aá]scara|Place[A-Za-z]*Mask|RemoveMask" docs/requirement/req-0001-cpf-validacao.md docs/requirement/tec/tec-req-0001-cpf-validacao.md` (apenas hits válidos); `grep -n "12 PF" docs/requirement/apf/apf-req-0001.md` → 0 hits; leitura do diff
  - **Dependências:** T1, T2
  - **Arquivos:** `docs/requirement/req-0001-cpf-validacao.md`, `docs/requirement/tec/tec-req-0001-cpf-validacao.md`, `docs/requirement/apf/apf-req-0001.md`, `docs/requirement/checklist/checklist-req-0001.md`, `docs/requirement/analise/analise-req-0001.md`
  - **Tamanho:** M · **Agente:** writer

- [x] **T4: Slice CNPJ — req-0002, tec-req-0002, apf-req-0002, checklist-req-0002, analise-req-0002** (M, 5 arquivos)
  - **Descrição:** Mesmo padrão do T3. No req-0002: frontmatter/H1/Metadados; Objetivo; Escopo In ("aplicação de máscara"); RF-003 (PlaceMask) removido (renumeração: RF-003→nulo/vazio); RN-004 (máscara) removido; Gherkin "Aplicar máscara em CNPJ válido" (linhas ~121–124); risco local RSK-005; Clarification Log (linha "RemoveMask é herdado de StringExtension.OnlyNumbers" → reescrever para OnlyNumbers; manter linha "Entrada com caracteres especiais"); Cobertura (ranges). No tec-req-0002: seção "### Máscara" (linha 64); RF-003/RN-004; diagrama de camadas (PlaceCnpjMask/PlaceMask); mermaid (RemoveMask→OnlyNumbers); exemplo de código (linhas ~105–106); rastreabilidade; Clarification Log. No apf-req-0002: remover PlaceCnpjMask → **3 PF** (EE 1); justificativa ("2 funções: validação e máscara" → "1 função: validação"). No checklist-req-0002: título/descrição/metadados. Na analise-req-0002: "Versão dos artefatos analisados" v1.1.0; linha APF (45: 6→3 PF); histórico.
  - **Critérios de aceitação:**
    - [x] Nenhuma linha de máscara restante exceto menções válidas
    - [x] apf-req-0002 = 3 PF
    - [x] RF/RN renumerados sem gaps e referências familiares atualizadas
  - **Verificação:** greps análogos ao T3 para `req-0002`/`tec-req-0002`/`apf-req-0002`
  - **Dependências:** T1, T2
  - **Arquivos:** `docs/requirement/req-0002-cnpj-validacao.md`, `docs/requirement/tec/tec-req-0002-cnpj-validacao.md`, `docs/requirement/apf/apf-req-0002.md`, `docs/requirement/checklist/checklist-req-0002.md`, `docs/requirement/analise/analise-req-0002.md`
  - **Tamanho:** M · **Agente:** writer

- [x] **T5: Slice PIS — req-0003, tec-req-0003, apf-req-0003, checklist-req-0003, analise-req-0003** (M, 5 arquivos)
  - **Descrição:** Mesmo padrão. No req-0003: frontmatter/H1/Metadados; RF-002 (PlacePisMask) removido; RN-003 (máscara) removido; Gherkin "Aplicar máscara" (linhas 70–71); risco local RSK-007; Clarification Log (linha "PIS tem método RemoveMask próprio?" → reescrever para OnlyNumbers); Cobertura. No tec-req-0003: seção "### Máscara"; PlacePisMask/PlaceMask/RemoveMask do diagrama de camadas; mermaid; exemplo (linha 87); rastreabilidade. No apf-req-0003: remover PlacePisMask → **3 PF** (EE 1). No checklist-req-0003: título/descrição/metadados. Na analise-req-0003: versão artefatos v1.1.0; linha APF (6→3 PF); histórico.
  - **Critérios de aceitação:**
    - [x] Nenhuma linha de máscara restante exceto menções válidas
    - [x] apf-req-0003 = 3 PF
    - [x] RF/RN renumerados sem gaps e referências familiares atualizadas
  - **Verificação:** greps análogos para `req-0003`
  - **Dependências:** T1, T2
  - **Arquivos:** `docs/requirement/req-0003-pis-validacao.md`, `docs/requirement/tec/tec-req-0003-pis-validacao.md`, `docs/requirement/apf/apf-req-0003.md`, `docs/requirement/checklist/checklist-req-0003.md`, `docs/requirement/analise/analise-req-0003.md`
  - **Tamanho:** M · **Agente:** writer

- **Checkpoint 2 (após T3–T5):** [x] famílias CPF/CNPJ/PIS sem hits de máscara inválidos; APFs 6/3/3 PF

- [x] **T6: Slice Título de Eleitor — req-0004, tec-req-0004, apf-req-0004, checklist-req-0004, analise-req-0004** (M, 5 arquivos)
  - **Descrição:** Mesmo padrão. No req-0004: frontmatter/H1/Metadados; RF-003 (PlaceTituloEleitorMask) removido; Gherkin "Aplicar máscara" (linhas 70–71); "Nota sobre máscara" (linha 75) removida (a inconsistência README/código mencionada pertence ao req-0017 — transferir nota para lá se necessário ou remover); risco local RSK-009 **permanece** (validação de UF). No tec-req-0004: seção "### Máscara"; PlaceTituloEleitorMask/PlaceMask; RemoveMask→OnlyNumbers; exemplo (linha 88); rastreabilidade. No apf-req-0004: remover PlaceTituloEleitorMask → **3 PF** (EE 1). No checklist-req-0004: título/descrição/metadados. Na analise-req-0004: versão artefatos v1.1.0; linha APF (6→3 PF); histórico.
  - **Critérios de aceitação:**
    - [x] Nenhuma linha de máscara restante exceto menções válidas
    - [x] apf-req-0004 = 3 PF
    - [x] RF/RN renumerados sem gaps e referências familiares atualizadas
  - **Verificação:** greps análogos para `req-0004`
  - **Dependências:** T1, T2
  - **Arquivos:** `docs/requirement/req-0004-titulo-eleitor-validacao.md`, `docs/requirement/tec/tec-req-0004-titulo-eleitor-validacao.md`, `docs/requirement/apf/apf-req-0004.md`, `docs/requirement/checklist/checklist-req-0004.md`, `docs/requirement/analise/analise-req-0004.md`
  - **Tamanho:** M · **Agente:** writer

- [x] **T7: Slice Renavam — req-0005, tec-req-0005, apf-req-0005, analise-req-0005** (S, 4 arquivos)
  - **Descrição:** Sem rename e sem conteúdo de máscara. Manter a nota factual "Renavam **não tem máscara**" (req-0005 linha 40; tec-req-0005 linha 37). Em tec-req-0005, reescrever menções `RemoveMask (OnlyNumbers)` (linhas 44, 52, 64) para `OnlyNumbers` (alias documentado em req-0013). Version bump 1.1.0 + histórico em req-0005, tec-req-0005, apf-req-0005. Na analise-req-0005: "Versão dos artefatos analisados" v1.1.0 + histórico (APF permanece 3 PF). **`checklist-req-0005` não é alterado** (sem máscara, sem nome antigo).
  - **Critérios de aceitação:**
    - [x] Menções "não tem máscara" preservadas (nota factual)
    - [x] `RemoveMask` no fluxo de validação reescrito como `OnlyNumbers`
    - [x] Version bump 1.1.0 nos 4 arquivos com linha de histórico
  - **Verificação:** `grep -n "mascara" docs/requirement/req-0005-renavam-validacao.md` → apenas linha 40; `grep -n "RemoveMask" docs/requirement/tec/tec-req-0005-renavam-validacao.md` → 0 hits (única ocorrência restante é a linha de histórico 96, que documenta a própria mudança — menção válida)
  - **Verificação:** `grep -n "mascara" docs/requirement/req-0005-renavam-validacao.md` → apenas linha 40; `grep -n "RemoveMask" docs/requirement/tec/tec-req-0005-renavam-validacao.md` → 0 hits
  - **Dependências:** None (não depende de renames)
  - **Arquivos:** `docs/requirement/req-0005-renavam-validacao.md`, `docs/requirement/tec/tec-req-0005-renavam-validacao.md`, `docs/requirement/apf/apf-req-0005.md`, `docs/requirement/analise/analise-req-0005.md`
  - **Tamanho:** S · **Agente:** writer

- [x] **T8: Slice Inscrição Estadual — req-0006, tec-req-0006, apf-req-0006, checklist-req-0006, analise-req-0006** (M, 5 arquivos)
  - **Descrição:** No req-0006 (renomeado): frontmatter/H1/Metadados; RF-002 (PlaceMask) e RF-003 (RemoveMask) removidos (renumeração: RF-002→exceção StateNotFound, RF-003→nulo/vazio); RN-003 (`_mask`) removida e RN-005 ("validação remove máscara internamente") reescrita para `OnlyNumbers`; Gherkin "Aplicar máscara em IE de SP" (linhas 81–84) removido; risco local RSK-013 removido (RSK-012 e RSK-014 permanecem); Rastreabilidade "27 extension methods de máscara" → mover/remover (máscaras agora em req-0018). No tec-req-0006: PlaceMask/_mask/RemoveMask do diagrama de camadas (linhas 48–50); dicionário `_mask` (linha 57–58); exemplo de código "Máscara/Remover máscara" (linhas 114–119); "Extensions de máscara" (linha 130); RF/RN de máscara; rastreabilidade. No apf-req-0006: remover PlaceMask (EE Média 4) e RemoveMask (CE 3) → **4 PF** (EE 1 Média); justificativa. No checklist-req-0006: título/descrição/metadados. Na analise-req-0006: versão artefatos v1.1.0; linha APF (11→4 PF); histórico.
  - **Critérios de aceitação:**
    - [x] Nenhuma linha de máscara restante exceto menções válidas (req-0018)
    - [x] apf-req-0006 = 4 PF
    - [x] RF/RN renumerados sem gaps e referências familiares atualizadas
  - **Verificação:** greps análogos para `req-0006`
  - **Dependências:** T1, T2
  - **Arquivos:** `docs/requirement/req-0006-inscricao-estadual-validacao.md`, `docs/requirement/tec/tec-req-0006-inscricao-estadual-validacao.md`, `docs/requirement/apf/apf-req-0006.md`, `docs/requirement/checklist/checklist-req-0006.md`, `docs/requirement/analise/analise-req-0006.md`
  - **Tamanho:** M · **Agente:** writer

- **Checkpoint 3 (após T6–T8):** [x] famílias Título/Renavam/IE limpas; APFs 3/3/4 PF

### Fase 3 — Referências nos requisitos de máscara (req-0014..0018) · Sequencial, independente da Fase 2 (pode rodar em paralelo após a Fase 1)

- [x] **T9: Atualizar referências em req-0014..0018** (S, 5 arquivos)
  - **Descrição:** Em cada `req-00XX-mascara.md`: seção "Artefatos relacionados" (linha ~84–85) e tabela "Rastreabilidade" → "Requisito de validação base" (linha ~218/227) — trocar `req-0001..0006-*-validacao-mascara.md` pelo novo nome `*-validacao.md`. Version bump 1.0.0→1.1.0 (frontmatter + Metadados + Histórico com linha 31/07/2026 "Atualização de referência ao requisito base renomeado"). **Não** alterar conteúdo de máscara desses requisitos.
  - **Critérios de aceitação:**
    - [x] Nenhuma ocorrência de `validacao-mascara` nos 5 arquivos
    - [x] Version bump 1.1.0 + histórico nos 5
  - **Verificação:** `grep -n "validacao-mascara" docs/requirement/req-0014*.md docs/requirement/req-0015*.md docs/requirement/req-0016*.md docs/requirement/req-0017*.md docs/requirement/req-0018*.md` → 0 hits
  - **Dependências:** T1
  - **Arquivos:** `docs/requirement/req-0014-cpf-mascara.md`, `req-0015-cnpj-mascara.md`, `req-0016-pis-mascara.md`, `req-0017-titulo-eleitor-mascara.md`, `req-0018-inscricao-estadual-mascara.md`
  - **Tamanho:** S · **Agente:** writer

- [x] **T10: Atualizar referências em tec-req-0014..0018** (S, 5 arquivos)
  - **Descrição:** Em cada `tec-req-00XX-mascara.md`: tabela "Requisito de validação base" (linhas ~199–202/307) — novo nome do req base. Version bump 1.0.0→1.1.0 + histórico. Não alterar conteúdo de máscara.
  - **Critérios de aceitação:**
    - [x] Nenhuma ocorrência de `validacao-mascara` nos 5 arquivos
    - [x] Version bump 1.1.0 + histórico nos 5
  - **Verificação:** `grep -n "validacao-mascara" docs/requirement/tec/tec-req-0014*.md docs/requirement/tec/tec-req-0015*.md docs/requirement/tec/tec-req-0016*.md docs/requirement/tec/tec-req-0017*.md docs/requirement/tec/tec-req-0018*.md` → 0 hits
  - **Dependências:** T1
  - **Arquivos:** `docs/requirement/tec/tec-req-0014-cpf-mascara.md`, `tec-req-0015-cnpj-mascara.md`, `tec-req-0016-pis-mascara.md`, `tec-req-0017-titulo-eleitor-mascara.md`, `tec-req-0018-inscricao-estadual-mascara.md`
  - **Tamanho:** S · **Agente:** writer

### Fase 4 — Artefatos globais · Sequencial (depende dos números PF finais e nomes finais)

- [x] **T11: Atualizar `docs/README.md`** (M, 1 arquivo)
  - **Descrição:** TOC: seção "### 📋 Requisitos (Validação e Máscara)" → "Requisitos (Validação)"; links e títulos das linhas 27–38 para os novos nomes (`*-validacao.md`, títulos sem "e Máscara"); tabela APF (linhas 83–101): valores 0001=6, 0002=3, 0003=3, 0004=3, 0006=4 e **Total 126→92 PF**; linha 150 "30 riscos" → "26 riscos"; linha 153 "126 PF" → "92 PF"; seção "Máscaras Independentes" (0014..0018) permanece; corrigir links de análise **0001..0018** para `analise/` (convenção unificada — D5 revisada); seção "Última Atualização Global" — acrescentar/atualizar parágrafo de 31/07/2026 descrevendo a remoção de máscara de 0001..0006 e recálculo para 92 PF; seção "Status dos Artefatos" (manter 18 pares, atualizar datas se necessário).
  - **Critérios de aceitação:**
    - [x] Nenhuma ocorrência de `validacao-mascara` ou "Validação e Máscara" (exceto histórico)
    - [x] Total APF = 92 PF; riscos = 26
  - **Verificação:** `grep -n "validacao-mascara" docs/README.md` → 0; `grep -n "126 PF" docs/README.md` → 0; `grep -n "92 PF" docs/README.md` → ≥1
  - **Dependências:** Fase 2 (T3–T8), Fase 3 (T9–T10)
  - **Arquivos:** `docs/README.md`
  - **Tamanho:** M · **Agente:** writer

- [x] **T12: Atualizar `docs/tamanho-aplicacao.md`** (M, 1 arquivo)
  - **Descrição:** Frontmatter: description "126 PF" → "92 PF"; version 1.1.0→1.2.0; updated 31/07/2026. Metadados idem. Tabela "Resumo por Requisito": nomes das linhas 42–47 sem "e Máscara"; valores 0001=6 (EE 2), 0002=3 (EE 1), 0003=3 (EE 1), 0004=3 (EE 1), 0006=4 (EE 1); Total **92 PF**; reconstruir colunas EE/CE/EO/ALI conforme seção 5 (com nota de rodapé sobre o ajuste de sobreposição do req-0018, pré-existente). Tabela "Distribuição por Tipo de Função": recomputar (EE 13, CE 7, EO 6, ALI 1; total 92). "Estimativa de Esforço": PF 126→92, PF ajustados ~78, horas ~780h, dias ~98; reescrever a nota "36 PF"→"24 PF" e remover/corrigir a afirmação "126 PF". Histórico: + linha 31/07/2026 v1.2.0 (remoção de máscara de 0001..0006; recálculo 114→92; correção da inconsistência pré-existente 126 vs 114).
  - **Critérios de aceitação:**
    - [x] Total = 92 PF consistente em frontmatter, tabelas e esforço
    - [x] Nenhuma ocorrência de "126 PF", "36 PF", "Validação e Máscara" (exceto histórico)
  - **Verificação:** `grep -n "126 PF\|36 PF" docs/tamanho-aplicacao.md` → 0 (exceto linha de histórico se citada); `grep -n "92 PF" docs/tamanho-aplicacao.md` → ≥1
  - **Dependências:** Fase 2 (APFs finais)
  - **Arquivos:** `docs/tamanho-aplicacao.md`
  - **Tamanho:** M · **Agente:** writer

- [x] **T13: Atualizar `docs/system-mapping.md`** (M, 1 arquivo)
  - **Descrição:** Subgraph `Validacao[Validação e Máscara]` → `Validacao[Validação]` (linha 72); subgraph `Mascaras[Máscaras Independentes]` **permanece**; Mapa de Evidências (linhas 121–139): remover funções de máscara das linhas req-0001 (PlaceMask, PlaceCpfMask), req-0002 (PlaceMask), req-0003 (PlaceMask, RemoveMask), req-0004 (PlaceMask), req-0006 (PlaceMask, RemoveMask); **remover** a linha 138 (`Extensions/*Extension.cs` → req-0006 "Máscara por estado") pois máscaras agora mapeiam para req-0018 (linhas 160–161 já cobrem); seção "Cobertura dos Requisitos no Código" — ajustar descrições que atribuam máscara a 0001..0006; versão 1.1.0→1.2.0; Histórico + linha 31/07/2026.
  - **Critérios de aceitação:**
    - [x] Nenhuma linha de evidência atribui função de máscara a req-0001..0006
    - [x] "Validação e Máscara" ausente; "Máscaras Independentes" preservado
  - **Verificação:** `grep -n "Validação e Máscara" docs/system-mapping.md` → 0; `grep -n "PlaceMask" docs/system-mapping.md` → apenas linhas 152–162 (req-0014..0018)
  - **Dependências:** Fase 2
  - **Arquivos:** `docs/system-mapping.md`
  - **Tamanho:** M · **Agente:** writer

- [x] **T14: Atualizar `docs/system-risk-matrix.md`** (S, 1 arquivo)
  - **Descrição:** Remover linhas RSK-002 (req-0001), RSK-005 (req-0002), RSK-007 (req-0003), RSK-013 (req-0006) — cobertas por RSK-020/022/024/028 (req-0014..0018); Resumo: **30→26 riscos** (Crítico 1, Alto 8, Médio 10, Baixo 7); frontmatter description "24 riscos" → "26 riscos" (corrige inconsistência pré-existente); versão 1.1.0→1.2.0; Histórico + linha 31/07/2026.
  - **Critérios de aceitação:**
    - [x] RSK-002/005/007/013 ausentes; 26 riscos no resumo e no frontmatter
  - **Verificação:** `grep -n "RSK-002\|RSK-005\|RSK-007\|RSK-013" docs/system-risk-matrix.md` → 0; `grep -n "26" docs/system-risk-matrix.md` → resumo correto
  - **Dependências:** Fase 2
  - **Arquivos:** `docs/system-risk-matrix.md`
  - **Tamanho:** S · **Agente:** writer

- **Checkpoint 4 (Fase 4):** [x] consolidado 92 PF; matriz 26 riscos; README/mapping coerentes

### Fase 5 — Verificação final · Sequencial

- [x] **T15: Verificação final e fechamento** (S)
  - **Descrição:** Executar o checklist da seção 8 completo; registrar divergências na seção 11; atualizar este plano para COMPLETED após a validação.
  - **Critérios de aceitação:**
    - [x] Todos os greps de verificação passam (seção 8)
    - [x] `dotnet build` OK (smoke — nenhum `.cs` alterado)
    - [x] Plano atualizado com `[x]` e Changes completo
  - **Verificação:** comandos da seção 8
  - **Dependências:** T3–T14
  - **Arquivos:** `planning/003-remover-mascara-reqs-0001-0006.md`
  - **Tamanho:** S · **Agente:** writer (validação com apoio de tester-quality se disponível)

## 7. Inventário exaustivo de arquivos afetados (ação exata por arquivo)

### Renomear via `git mv` (10)

| # | De | Para | Ação |
| - | -- | --- | ---- |
| R1 | `docs/requirement/req-0001-cpf-validacao-mascara.md` | `req-0001-cpf-validacao.md` | git mv + edição (T3) |
| R2 | `docs/requirement/req-0002-cnpj-validacao-mascara.md` | `req-0002-cnpj-validacao.md` | git mv + edição (T4) |
| R3 | `docs/requirement/req-0003-pis-validacao-mascara.md` | `req-0003-pis-validacao.md` | git mv + edição (T5) |
| R4 | `docs/requirement/req-0004-titulo-eleitor-validacao-mascara.md` | `req-0004-titulo-eleitor-validacao.md` | git mv + edição (T6) |
| R5 | `docs/requirement/req-0006-inscricao-estadual-validacao-mascara.md` | `req-0006-inscricao-estadual-validacao.md` | git mv + edição (T8) |
| R6 | `docs/requirement/tec/tec-req-0001-cpf-validacao-mascara.md` | `tec-req-0001-cpf-validacao.md` | git mv + edição (T3) |
| R7 | `docs/requirement/tec/tec-req-0002-cnpj-validacao-mascara.md` | `tec-req-0002-cnpj-validacao.md` | git mv + edição (T4) |
| R8 | `docs/requirement/tec/tec-req-0003-pis-validacao-mascara.md` | `tec-req-0003-pis-validacao.md` | git mv + edição (T5) |
| R9 | `docs/requirement/tec/tec-req-0004-titulo-eleitor-validacao-mascara.md` | `tec-req-0004-titulo-eleitor-validacao.md` | git mv + edição (T6) |
| R10 | `docs/requirement/tec/tec-req-0006-inscricao-estadual-validacao-mascara.md` | `tec-req-0006-inscricao-estadual-validacao.md` | git mv + edição (T8) |

### Editar conteúdo + version bump 1.0.0 → 1.1.0 (35)

> **Nota (D5 revisada — 31/07/2026):** os arquivos `analise-req-0001..0006` (E5, E10, E15, E20, E24, E29) são movidos do diretório `analises/` (antiga convenção, removida) para `docs/requirement/analise/` (canônico singular) via `git mv` antes da edição (ver T2/Checkpoint 1b). O diretório `analises/` é removido ao final. Se a movimentação já tiver sido executada pelo `writer` em paralelo, apenas confirmar.

| # | Arquivo | Ação principal | Tarefa |
| - | ------- | -------------- | ------ |
| E1 | `docs/requirement/req-0001-cpf-validacao.md` | Remover máscara; renumeração RF/RN; frontmatter; bump | T3 |
| E2 | `docs/requirement/tec/tec-req-0001-cpf-validacao.md` | Remover seção 2.4 e máscara; OnlyNumbers; bump | T3 |
| E3 | `docs/requirement/apf/apf-req-0001.md` | 12→6 PF; remover PlaceCpfMask/RemoveMask | T3 |
| E4 | `docs/requirement/checklist/checklist-req-0001.md` | Título/evidências (1.3, 1.5, 2.2, 2.3, 2.4, 3.2); bump | T3 |
| E5 | `docs/requirement/analise/analise-req-0001.md` | Título; refs (37–38); APF 12→6; risco RSK-001/003; DATA-04; bump | T3 |
| E6 | `docs/requirement/req-0002-cnpj-validacao.md` | Remover máscara; renumeração; bump | T4 |
| E7 | `docs/requirement/tec/tec-req-0002-cnpj-validacao.md` | Remover máscara; OnlyNumbers; bump | T4 |
| E8 | `docs/requirement/apf/apf-req-0002.md` | 6→3 PF; remover PlaceCnpjMask | T4 |
| E9 | `docs/requirement/checklist/checklist-req-0002.md` | Título/descrição/metadados; bump | T4 |
| E10 | `docs/requirement/analise/analise-req-0002.md` | Versão artefatos v1.1.0; APF 6→3; bump | T4 |
| E11 | `docs/requirement/req-0003-pis-validacao.md` | Remover máscara; renumeração; bump | T5 |
| E12 | `docs/requirement/tec/tec-req-0003-pis-validacao.md` | Remover máscara; OnlyNumbers; bump | T5 |
| E13 | `docs/requirement/apf/apf-req-0003.md` | 6→3 PF; remover PlacePisMask | T5 |
| E14 | `docs/requirement/checklist/checklist-req-0003.md` | Título/descrição/metadados; bump | T5 |
| E15 | `docs/requirement/analise/analise-req-0003.md` | Versão artefatos v1.1.0; APF 6→3; bump | T5 |
| E16 | `docs/requirement/req-0004-titulo-eleitor-validacao.md` | Remover máscara e nota; renumeração; bump | T6 |
| E17 | `docs/requirement/tec/tec-req-0004-titulo-eleitor-validacao.md` | Remover máscara; OnlyNumbers; bump | T6 |
| E18 | `docs/requirement/apf/apf-req-0004.md` | 6→3 PF; remover PlaceTituloEleitorMask | T6 |
| E19 | `docs/requirement/checklist/checklist-req-0004.md` | Título/descrição/metadados; bump | T6 |
| E20 | `docs/requirement/analise/analise-req-0004.md` | Versão artefatos v1.1.0; APF 6→3; bump | T6 |
| E21 | `docs/requirement/req-0005-renavam-validacao.md` | Manter nota "não tem máscara"; bump | T7 |
| E22 | `docs/requirement/tec/tec-req-0005-renavam-validacao.md` | RemoveMask→OnlyNumbers; nota; bump | T7 |
| E23 | `docs/requirement/apf/apf-req-0005.md` | 3 PF (inalterado); bump | T7 |
| E24 | `docs/requirement/analise/analise-req-0005.md` | Versão artefatos v1.1.0; bump | T7 |
| E25 | `docs/requirement/req-0006-inscricao-estadual-validacao.md` | Remover máscara/_mask; renumeração; bump | T8 |
| E26 | `docs/requirement/tec/tec-req-0006-inscricao-estadual-validacao.md` | Remover máscara/_mask; OnlyNumbers; bump | T8 |
| E27 | `docs/requirement/apf/apf-req-0006.md` | 11→4 PF; remover PlaceMask/RemoveMask | T8 |
| E28 | `docs/requirement/checklist/checklist-req-0006.md` | Título/descrição/metadados; bump | T8 |
| E29 | `docs/requirement/analise/analise-req-0006.md` | Versão artefatos v1.1.0; APF 11→4; bump | T8 |
| E30 | `docs/requirement/req-0014-cpf-mascara.md` | Ref. req-0001 (linhas 84, 218); bump | T9 |
| E31 | `docs/requirement/req-0015-cnpj-mascara.md` | Ref. req-0002 (linhas 84, 218); bump | T9 |
| E32 | `docs/requirement/req-0016-pis-mascara.md` | Ref. req-0003 (linhas 84, 218); bump | T9 |
| E33 | `docs/requirement/req-0017-titulo-eleitor-mascara.md` | Ref. req-0004 (linhas 84, 218); bump | T9 |
| E34 | `docs/requirement/req-0018-inscricao-estadual-mascara.md` | Ref. req-0006 (linhas 85, 227); bump | T9 |
| E35 | `docs/requirement/tec/tec-req-0014-cpf-mascara.md` | Ref. req-0001 (linha 202); bump | T10 |
| E36 | `docs/requirement/tec/tec-req-0015-cnpj-mascara.md` | Ref. req-0002 (linha 200); bump | T10 |
| E37 | `docs/requirement/tec/tec-req-0016-pis-mascara.md` | Ref. req-0003 (linha 199); bump | T10 |
| E38 | `docs/requirement/tec/tec-req-0017-titulo-eleitor-mascara.md` | Ref. req-0004 (linha 199); bump | T10 |
| E39 | `docs/requirement/tec/tec-req-0018-inscricao-estadual-mascara.md` | Ref. req-0006 (linha 307); bump | T10 |
| E40 | `docs/requirement/req-0013-string-utils.md` | **Opcional/flag**: sem edição de conteúdo neste escopo (ver P1) | — |

### Artefatos globais — version bump 1.1.0 → 1.2.0 (4) + README (sem frontmatter de versão)

| # | Arquivo | Ação principal | Tarefa |
| - | ------- | -------------- | ------ |
| G1 | `docs/README.md` | TOC, links, PF 92, riscos 26, seção "Última Atualização Global" | T11 |
| G2 | `docs/tamanho-aplicacao.md` | 92 PF; corrigir 126/36; rebuild tabelas; v1.2.0 | T12 |
| G3 | `docs/system-mapping.md` | Subgraph; evidências; v1.2.0 | T13 |
| G4 | `docs/system-risk-matrix.md` | RSK-002/005/007/013 removidos; 26; v1.2.0 | T14 |

### Sem alteração (verificar apenas)

| Arquivo | Motivo |
| ------- | ------ |
| `docs/requirement/checklist/checklist-req-0005.md` | Sem máscara, sem nome antigo (verificar no T15) |
| `docs/requirement/apf/apf-req-0014..0018.md` | Não referenciam nomes antigos (verificar no T15) |
| `docs/requirement/analise/analise-req-0014..0018.md` | Não referenciam nomes antigos; já residem no canônico `analise/` (singular). Links no README serão corrigidos para `analise/` em todos os reqs (0001..0018, D5 revisada) |
| `docs/architecture-tech-stack.md`, `docs/constituicao.md` | Sem referências aos nomes antigos (verificado por grep) |

## 8. Checklist de verificação final (T15)

- [x] `grep -rl "validacao-mascara" docs/` → **zero resultados** (repo todo) — único hit é menção histórica em `docs/README.md` linha 212 (registro da renomeação, aceito como histórico)
- [x] `grep -inE "m[aá]scara|Place[A-Za-z]*Mask|RemoveMask" docs/requirement/req-0001-cpf-validacao.md docs/requirement/req-0002-cnpj-validacao.md docs/requirement/req-0003-pis-validacao.md docs/requirement/req-0004-titulo-eleitor-validacao.md docs/requirement/req-0005-renavam-validacao.md docs/requirement/req-0006-inscricao-estadual-validacao.md` → apenas hits **válidos** (menção a req-0014..0018, "não possui máscara" em req-0005, normalização `OnlyNumbers`); zero menções a `PlaceMask`/`PlaceCpfMask` etc.
- [x] `grep -n "126 PF\|36 PF" docs/ docs/README.md docs/tamanho-aplicacao.md` → 0 (exceto histórico se citado) — hits apenas em histórico/nota (`tamanho-aplicacao.md` linhas 87/94; `README.md` linha 212)
- [x] `grep -n "92 PF" docs/README.md docs/tamanho-aplicacao.md` → presente e consistente (frontmatter + tabela + esforço)
- [x] `grep -n "26" docs/system-risk-matrix.md` → resumo 26 riscos; `grep -n "RSK-002\|RSK-005\|RSK-007\|RSK-013" docs/system-risk-matrix.md` → 0 fora do histórico (única menção: linha 92, registro da remoção — aceito)
- [x] `grep -n "Validação e Máscara" docs/` → 0 (exceto histórico); `grep -n "Máscaras Independentes" docs/README.md docs/system-mapping.md` → presente (preservado)
- [x] Version bump auditado: todos os arquivos E1–E39 em 1.1.0 e G2–G4 em 1.2.0, com linha de histórico 31/07/2026 autor "Rodrigo Araujo Barbosa"
- [x] `git status --short` → 10 renames (R) + modificações esperadas; nenhum arquivo órfão/stray; `*-validacao-mascara.md` não existe mais
- [x] Link check manual: `docs/README.md` e reqs apontam para caminhos existentes — **todos** os links de análise apontam para `analise/` (0001..0018); nenhum link restante aponta para `analises/`
- [x] `dotnet build` → sem erros (smoke; nenhum `.cs` alterado)
- [x] Leitura reversa: abrir 3–5 arquivos editados (ex.: req-0001, apf-0001, tamanho-aplicacao) e confirmar coerência de títulos/metadados/PF — **divergência encontrada e corrigida**: rótulos de nível na matriz global e em fatias locais não seguiam a legenda; realinhados (ver Changes e Open Questions P7)

## 9. Riscos e Mitigações

| Risco | Impacto | Mitigação |
| ----- | ------- | --------- |
| Referência cruzada esquecida (grep parcial/acentos) | Médio | Greps com padrão acentuado `m[aá]scara` + `Place\w*Mask`; verificação final com leitura reversa; busca por nomes antigos em todo o repo |
| Arquivos untracked da fase 2.5 (reqs 0014–0018, `analise/`, apfs/checklists 0014–18) — `git mv` não se aplica | Médio | `git mv` apenas para os 10 trackeados; edição in-place nos untracked; recomendar commit separado da fase 2.5 (P4) |
| Renumeração RF/RN quebrar referências familiares | Médio | Slices editam req+tec-req+analise+checklist juntos; grep de ranges (ex.: "RF-001 a RF-006") no slice |
| Inconsistências pré-existentes (126 vs 114; dupla contagem apf-0013; dirs analise/analises — **migração para `analise/` agora no escopo, D5 revisada**; "24 riscos") | Baixo | Corrigir só onde o escopo toca; sinalizar em Open Questions (P1–P3) |
| Links quebrados após rename | Baixo | Link check no checkpoint final |
| Escopo crescer (corrigir tudo que está inconsistente) | Médio | Regra: corrigir apenas o que o escopo toca; o resto → Open Questions |

## 10. Open Questions / Pendentes (⏳)

- **P1 ⏳ Dupla contagem RemoveMask/OnlyNumbers em `apf-req-0013`** (21 PF = 7 CEs, sendo OnlyNumbers e RemoveMask o mesmo método, 6 PF). Decisão do plano (D2): **sinalizar, não ajustar** — total permanece 92 PF. Recomendação: plano de correção futuro (reduziria para 89 PF).
- **P2 ⏳ Baseline APF pré-existente:** tabela soma 114 PF vs frontmatter/nota "126 PF" e "adicionaram 36 PF" (real: 24 PF). Decisão (D1): baseline = 114 PF; após remoção = **92 PF**; frontmatter/nota corrigidos. Registrado como correção de inconsistência no histórico de `tamanho-aplicacao.md`.
- **P3 ✅ RESOLVIDA em 31/07/2026 (decisão soberana do usuário):** convenção unificada — o diretório canônico de análises cross-artifact é **`analise/` (singular)** para TODOS os reqs (0001..0018). O diretório `analises/` será removido: os 6 arquivos `analise-req-0001..0006` (em `analises/`) são movidos via `git mv` para `analise/` (que já contém 0014..0018); todos os links em edição e no README passam a apontar para `analise/`. D5 atualizada; movimentação dos 13 arquivos em execução paralela pelo `writer`.
- **P4 ⏳ Fase 2.5 não commitada:** reqs 0014–0018, `analise/`, apfs/checklists 0014–18 estão untracked. Recomendação: commitar separadamente (antes ou depois desta refatoração). Sem ação automática.
- **P5 ℹ️ Status `approved` mantido** nos reqs 0001..0006 após a redução de escopo: a própria demanda do usuário re-define o escopo; o bump 1.1.0 registra a mudança. Não é bloqueante.
- **P6 ℹ️ Renumeração RF/RN (D4):** aplicada nos 5 reqs editados (0001–0004, 0006); verificação via ranges nos artefatos familiares.
- **P7 ✅ RESOLVIDA em 31/07/2026 (verificação final T15):** rótulos de nível (Nível) na `system-risk-matrix.md` e em fatias locais não seguiam a legenda (Baixo 1-4, Médio 5-9, Alto 10-16, Crítico 17-25). Corrigidos: RSK-006/008/010/015/017 (score 8) Alto→Médio; RSK-012 (score 15) Crítico→Alto; RSK-014/029/023 (score 4) Médio→Baixo; RSK-023 em req-0018. Resumo da matriz atualizado: Crítico 0, Alto 4, Médio 11, Baixo 11 (total 26). Históricos dos reqs 0003/0004/0005/0006/0007/0018 e da matriz registram o realinhamento. Nenhuma função de máscara afetada — correção classificatória apenas.

## 11. Changes (live tracking — atualizado a cada tarefa)

### Added
- `planning/003-remover-mascara-reqs-0001-0006.md` — este plano de execução.
- Correções de nível na matriz global e fatias locais (T15/P7): linhas `RSK-006/008/010/012/014/015/017/023/029` em `docs/system-risk-matrix.md` e `docs/requirement/req-0003-pis-validacao.md`, `req-0004-titulo-eleitor-validacao.md`, `req-0005-renavam-validacao.md`, `req-0006-inscricao-estadual-validacao.md`, `req-0007-mockup-cpf.md`, `req-0018-inscricao-estadual-mascara.md`; resumo da matriz e entradas de histórico correspondentes.

### Modified
- **Fase 1 (renames):** `req-0001..0006` e `tec-req-0001..0006` renomeados (`*-validacao-mascara.md` → `*-validacao.md`) via `git mv` — 10 arquivos.
- **Fase 2 (slices):** conteúdo de máscara removido dos reqs 0001–0004/0006 + tec-reqs; RF/RN renumerados; APFs recalculados (0002/0003/0004: 6→3 PF; 0006: 11→4 PF); checklists e análises atualizados.
- **Fase 3 (referências):** `req-0014..0018` e `tec-req-0014..0018` referências e versão 1.1.0.
- **Fase 4 (globais):** `docs/README.md` (92 PF, 26 riscos, links), `docs/tamanho-aplicacao.md` (v1.2.0, 92 PF), `docs/system-mapping.md` (v1.2.0, "Validação"), `docs/system-risk-matrix.md` (v1.2.0, 26 riscos; níveis corrigidos).
- `planning/003-remover-mascara-reqs-0001-0006.md` — status das tarefas e verificação final.

### Removed
- Conteúdo de máscara (`PlaceMask`/`RemoveMask`/máscaras) dos reqs 0001–0004/0006 e tec-reqs (transferido para req-0014..0018).
- `RSK-002/005/007/013` da matriz global (cobertos por RSK-020/022/024/028).
- Diretório `docs/requirement/analises/` (13 arquivos movidos para `docs/requirement/analise/`).

## 12. Handoff / Dono

- **Executor:** agente `writer` (todas as tarefas de documentação).
- **Contrato de retomada:** ler este plano → identificar a próxima tarefa `[ ]` → executar → marcar `[x]` → salvar → seção Changes → próxima.
- **Aprovação:** este plano aguarda aprovação do usuário (via orchestrator) antes do início da execução (approval gate).
- **Escopo total estimado:** M–L (somente docs; 15 tarefas S/M; ~44 arquivos tocados). Estimativa de esforço writer: ~4–6 h.
