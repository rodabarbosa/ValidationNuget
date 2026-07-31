# Implementation Plan: Conformidade da Documentação ao Padrão da Skill `documentation`

**Status:** COMPLETE ✅ · **REVISADO** em 31/07/2026 (decisão revertida — ver nota abaixo)

> **Nota de revisão (31/07/2026):** Por **decisão soberana do usuário**, a convenção de diretório de análises cross-artifact passa a ser **`analise/` (singular)**. Isto **REVERTE** a decisão registrada neste plano (que padronizou `analises/` na Wave 5). O diretório canônico é `docs/requirement/analise/`; `analises/` não deve mais ser usado e foi removido (13 arquivos movidos de volta para `analise/` pelo `writer`). O histórico da decisão original é preservado abaixo, com o estado atual e a revisão sinalizados em cada seção.

## Overview

Adequar toda a documentação do projeto **Sirb.Validation** (~69 arquivos em `/docs/`) ao padrão definido pela skill `documentation` (OKF v0.2). A documentação atual cobre 13 requisitos (req-0001 a req-0013) com pares req/tec-req, APF, análise cross-artifact e quality checklist, além de 5 artefatos globais. Nenhum arquivo possui YAML frontmatter, e há inconsistências estruturais de diretórios, metadados e campos de autor.

## Arquitetura de Decisões

| Decisão | Contexto | Opções | Rationale |
| ------- | -------- | ------ | --------- |
| **Onda única sequencial** (não paralelizável) | Cada onda altera os mesmos ~69 arquivos; paralelismo causaria conflitos de edição concorrente. | (a) Execução sequencial mono-agente, (b) paralelizar por subconjunto de arquivos | Onda única com `writer` é mais segura — evita merge conflicts. As alterações são puramente aditivas (inserção de frontmatter + ajustes de metadados), sem risco de sobrescrita entre ondas se sequenciadas corretamente. |
| **Manter `analise/` → renomear para `analises/`** · **REVISADA em 31/07/2026** | Originalmente a skill `documentation` padronizava plural nos nomes de diretório. **REVISÃO (decisão soberana do usuário em 31/07/2026):** a convenção passa a ser **`analise/` (singular)** para análises cross-artifact; `analises/` não deve mais ser usado. | (a) Renomear e corrigir 13 links no TOC, (b) manter singular | Executado em 27/07/2026: `analise/` → `analises/` (alinhado à skill). **Revertido em 31/07/2026** por determinação do usuário: canônico = `analise/` (singular); 13 arquivos movidos de volta; `analises/` removido; links corrigidos para `analise/`. |
| **Criar `tec/` subdiretório para tec-req-* | A skill `documentation` exige separação req/tec em subdiretórios. | (a) Mover para `requirement/tec/` e corrigir 13 links, (b) manter flat em `requirement/` | Mover alinha ao padrão. Impacto restrito a `docs/README.md` (13 links). |
| **Criar `extras/`, `diagrams/`, `vision/` vazios** | Diretórios obrigatórios pela skill mesmo se N/A agora. | (a) Criar com `.gitkeep`, (b) criar só se houver conteúdo | Criar agora evita nova onda de conformidade futura. Marcadores N/A na TOC. |

## Pré-Planejamento (checklist cumprido)

- [x] `README.md`, `docs/README.md`, `AGENTS.md` lidos e compreendidos
- [x] Demanda compreendida: adequar 69 arquivos de documentação ao padrão OKF v0.2 da skill `documentation`
- [x] Gap analysis fornecida e validada contra o codebase (leitura de amostras representativas)
- [x] Dependência entre ondas mapeada (execução sequencial)
- [x] Tarefas fatias verticalmente por tipo de alteração (não por arquivo)
- [x] Critérios de aceite e verificação definidos por tarefa
- [ ] ⏳ **PENDENTE:** Confirmar data de criação/atualização exata de cada arquivo (será extraída dos metadados existentes durante a execução)
- [ ] ⏳ **PENDENTE:** Confirmar se `docs/system-risk-matrix.md` e `docs/tamanho-aplicacao.md` devem receber `Código do documento` nos metadados (gap identificado — atualmente não possuem)

## Task List

### Wave 0: Criação de Diretórios Estruturais Faltantes

**Descrição:** Criar os diretórios obrigatórios pelo padrão `documentation` que ainda não existem, mesmo que vazios.

**Critérios de aceite:**

- [x] `docs/extras/` existe com `.gitkeep`
- [x] `docs/diagrams/` existe com `.gitkeep`
- [x] `docs/vision/` existe com `.gitkeep`

**Verificação:** `ls docs/extras/ docs/diagrams/ docs/vision/`

**Dependências:** Nenhuma

**Arquivos tocados:** 3 novos diretórios + 3 `.gitkeep`

**Estimativa:** XS (1)

**Responsável:** `writer`

---

### Wave 1: Adicionar YAML Frontmatter (OKF v0.2) a Todos os Artefatos (69 arquivos)

**Descrição:** Inserir bloco `---` YAML frontmatter no topo de cada arquivo `.md` em `/docs/`. Os valores devem ser extraídos da seção `## Metadados` existente em cada documento. O template segue o padrão OKF v0.2.

**Template de frontmatter:**

```yaml
---
type: <okf-type>
title: "<título do H1>"
description: "<breve descrição (2-3 frases)>"
resource: "./<caminho-relativo-do-arquivo>"
tags: [<tags relevantes>]
generated:
  by: "Opencode — writer"
  timestamp: "<data-da-ultima-atualizacao>"
status: approved
domain:
  artifact_id: "<código-do-documento>"
  title_pt: "<título-em-português>"
  version: "<versão-dos-metadados>"
  author: "Rodrigo Araujo Barbosa"
  created: "<data-de-criação>"
  updated: "<data-da-última-atualização>"
  language: pt-BR
---
```

**Mapeamento OKF types:**

| Tipo de arquivo | OKF type | Observação |
| --------------- | -------- | ---------- |
| req-XXXX.md | `type: req` | 13 arquivos |
| tec-req-XXXX.md | `type: tec-req` | 13 arquivos |
| apf-req-XXXX.md | `type: apf` | 13 arquivos |
| analise-req-XXXX.md | `type: analise` | 13 arquivos |
| checklist-req-XXXX.md | `type: checklist` | 13 arquivos |
| `constituicao.md` | `type: constituicao` | Sem tipo específico OKF; usar `type: project` ou manter genérico |
| `architecture-tech-stack.md` | `type: project` | Genérico |
| `system-mapping.md` | `type: project` | Genérico |
| `system-risk-matrix.md` | `type: project` (ou `type: risk`) | Usar `type: risk` se disponível; senão `type: project` |
| `tamanho-aplicacao.md` | `type: apf` | APF consolidado |
| `docs/README.md` | Sem frontmatter (TOC) | Não requer type |

**Critérios de aceite:**

- [x] Todos os 68 arquivos `.md` (excluindo `docs/README.md`) têm frontmatter YAML válido no topo
- [x] O frontmatter contém `---` delimitadores no início e fim
- [x] Os valores de `domain.version`, `domain.created`, `domain.updated` refletem exatamente os valores da seção `## Metadados`
- [x] O campo `resource` contém o caminho relativo correto a partir de `docs/`
- [x] Arquivos sem `Código do documento` nos Metadados (ex: `tamanho-aplicacao.md`) recebem `artifact_id` apropriado (ex: `tamanho-aplicacao`)

**Verificação:**

- [ ] YAML válido: ler cada arquivo e confirmar que o frontmatter faz parse (`yaml` library ou validação manual)
- [ ] Nenhum arquivo perdeu conteúdo existente (diff mostra apenas linhas adicionadas no topo)

**Dependências:** Wave 0

**Arquivos tocados:** ~68 arquivos `.md`

**Estimativa:** L (5-8+ arquivos — mas é uma única operação repetitiva em 68 arquivos; pode ser decomposta em sub-lotes de 10-15 arquivos)

**Sub-lotes sugeridos:**

1. 13 req-XXXX.md
2. 13 tec-req-XXXX.md
3. 13 apf-req-XXXX.md
4. 13 analise-req-XXXX.md
5. 13 checklist-req-XXXX.md
6. 5 artefatos globais

**Responsável:** `writer`

---

### Wave 2: Sincronizar `## Metadados` com Frontmatter

**Descrição:** Garantir que toda seção `## Metadados` existente reflita exatamente os valores do frontmatter (YAML). A seção `## Metadados` passa a ser uma **reflexão para leitura humana** do frontmatter, com a seguinte nota padronizada inserida **imediatamente antes** da tabela de metadados:

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

Além disso:

- Adicionar campos faltantes em Metadados quando necessário:
  - `tamanho-aplicacao.md`: adicionar `Código do documento: tamanho-aplicacao` e `Título: Tamanho da Aplicação — APF Consolidado`
  - `system-risk-matrix.md`: validar se `Código do documento` existe; se não, adicionar
  - Padronizar nomenclatura dos campos (ex: se um doc usa `**Autor:**` e outro `**Autor (agente):**`, padronizar para `**Autor:**` com nome correto)

**Critérios de aceite:**

- [x] Todo arquivo com `## Metadados` tem a nota de reflexão do frontmatter
- [x] Todos os valores em `## Metadados` são idênticos aos do frontmatter YAML
- [x] Campos ausentes foram adicionados (ex: `Código do documento` em `tamanho-aplicacao.md`)
- [x] Nomenclatura dos campos é consistente entre todos os arquivos

**Verificação:**

- [ ] Amostragem de 10 arquivos: valores de Metadados === frontmatter
- [ ] `tamanho-aplicacao.md` e `system-risk-matrix.md` têm `Código do documento`

**Dependências:** Wave 1

**Arquivos tocados:** ~68 arquivos (mesmo conjunto da Wave 1)

**Estimativa:** M (3-5 grupos de alteração)

**Responsável:** `writer`

---

### Wave 3: Corrigir Campo de Autor

**Descrição:** Substituir todas as ocorrências de `Autor (agente): writer` por `Autor: Rodrigo Araujo Barbosa` nos arquivos de análise e checklist.

**Arquivos afetados:**

- 13 arquivos em `docs/requirement/analise/analise-req-XXXX.md` — campo `**Autor (agente):** writer`
- 13 arquivos em `docs/requirement/checklist/checklist-req-XXXX.md` — campo `**Autor (agente):** writer`

**Critérios de aceite:**

- [x] Nenhum arquivo em `analise/` ou `checklist/` contém o texto `writer` no campo de autor
- [x] Todos os 26 arquivos têm `**Autor:** Rodrigo Araujo Barbosa` (ou o campo padronizado na Wave 2)

**Verificação:**

- [ ] `grep -r "Autor.*writer" docs/requirement/analise/ docs/requirement/checklist/` retorna vazio

**Dependências:** Wave 2 (padronização do nome do campo)

**Arquivos tocados:** 26 (13 analise + 13 checklist)

**Estimativa:** S (1-2) — operação de busca e substituição em massa

**Responsável:** `writer`

---

### Wave 4: Sincronizar `domain.version` com `## Histórico de Alterações`

**Descrição:** Garantir que o campo `domain.version` no frontmatter YAML corresponda à versão mais recente listada na seção `## Histórico de alterações` de cada documento. Onde não existir `## Histórico de alterações`, adicionar a seção.

**Observação:** Atualmente a maioria dos documentos tem apenas uma versão (`1.0.0`) tanto no frontmatter quanto no histórico. Esta onda é uma verificação de consistência.

**Critérios de aceite:**

- [x] Para cada documento com `## Histórico de alterações`: `domain.version` === última versão na tabela
- [x] Documentos sem `## Histórico de alterações` recebem a seção (se obrigatória pelo padrão) ou mantém sem (se não aplicável)

**Verificação:**

- [ ] Amostragem de 10 arquivos: último entry do histórico === `domain.version`

**Dependências:** Wave 1 (frontmatter)

**Arquivos tocados:** ~68 (verificação em massa, alterações pontuais)

**Estimativa:** S (1-2) — verificação seguida de correções pontuais

**Responsável:** `writer`

---

### Wave 5: Alinhamento Estrutural de Diretórios

**Descrição:** Realizar as alterações estruturais para alinhar a estrutura de diretórios ao padrão da skill `documentation`.

**Sub-tarefas:**

1. **Renomear `analise/` para `analises/`:** *(REVISADO em 31/07/2026 — decisão revertida pelo usuário)*
   - `mv docs/requirement/analise docs/requirement/analises` *(executado em 27/07/2026)*
   - Atualizar 13 caminhos em `docs/README.md` (`.requirement/analise/` → `.requirement/analises/`) *(executado em 27/07/2026)*
   - **31/07/2026 (REVISÃO):** decisão revertida por determinação do usuário — o diretório canônico é **`docs/requirement/analise/` (singular)**; os 13 arquivos de análise foram movidos de volta (`analises/` → `analise/`) e o diretório `analises/` foi removido; links em `docs/` corrigidos de `analises/` → `analise/`.

2. **Criar subdiretório `tec/` e mover tec-req-*:**
   - `mkdir docs/requirement/tec`
   - `mv docs/requirement/tec-req-*.md docs/requirement/tec/`
   - Atualizar 13 caminhos em `docs/README.md` (`.requirement/tec-req-` → `.requirement/tec/tec-req-`)

3. **Atualizar a tabela de convenção de prefixos no TOC** (seção "Convenção de Prefixos" em `docs/README.md`)

**Critérios de aceite:**

- [x] Diretório `docs/requirement/analises/` existe com 13 arquivos de análise *(executado 27/07/2026)*
- [x] Diretório `docs/requirement/analise/` não existe mais *(executado 27/07/2026)*
- **[REVISÃO 31/07/2026]** — critérios invertidos por decisão do usuário: `docs/requirement/analise/` (singular) é o canônico com os 13 arquivos; `analises/` não deve mais existir.
- [x] Diretório `docs/requirement/tec/` existe com 13 arquivos tec-req-*
- [x] Nenhum arquivo `tec-req-*.md` permanece em `docs/requirement/` (raiz)
- [x] 26 links em `docs/README.md` atualizados (13 analise, 13 tec-req)
- [x] Seção "Convenção de Prefixos" reflete a nova estrutura

**Verificação:**

- [ ] `ls docs/requirement/analise/` retorna "No such file or directory" *(executado 27/07/2026)*
- [ ] `ls docs/requirement/analises/` retorna 13 arquivos *(executado 27/07/2026)*
- **[REVISÃO 31/07/2026]** — verificação invertida: `ls docs/requirement/analise/` deve retornar os 13 arquivos; `ls docs/requirement/analises/` deve falhar ("No such file or directory").
- [ ] `ls docs/requirement/tec/` retorna 13 arquivos
- [ ] `ls docs/requirement/tec-req-*.md` retorna vazio (ou erro)
- [ ] Todos os links em `docs/README.md` apontam para caminhos válidos

**Dependências:** Wave 3 (todas as alterações de conteúdo nos arquivos concluídas antes do movimentação)

**Arquivos tocados:** ~26 links em `docs/README.md`, movimentação de 26 arquivos

**Estimativa:** M (3-5)

**Responsável:** `writer`

---

### Wave 6: Atualizar `docs/README.md` (TOC Final)

**Descrição:** Atualizar a TOC raiz (`docs/README.md`) para refletir todas as alterações das ondas anteriores:

- Já atualizado na Wave 5 (caminhos de analise/ e tec/)
- Garantir que a seção "Convenção de Prefixos" reflita a nova estrutura
- Garantir que os diretórios `extras/`, `diagrams/`, `vision/` sejam listados (como `N/A` ou disponíveis)
- Adicionar frontmatter YAML no TOC se o padrão exigir; caso contrário, manter sem
- Atualizar "Última Atualização Global" e "Próximos Passos"

**Critérios de aceite:**

- [x] `docs/README.md` reflete a estrutura final de diretórios
- [x] Convenção de Prefixos atualizada com `analises/` e `tec/` *(executado 27/07/2026)*
- **[REVISÃO 31/07/2026]** — Convenção de Prefixos deve refletir **`analise/` (singular)** e `tec/`.
- [x] Novos diretórios (`extras/`, `diagrams/`, `vision/`) mencionados
- [x] Data de última atualização reflete a data de conclusão

**Verificação:**

- [ ] Leitura completa de `docs/README.md` confirma todos os caminhos válidos
- [ ] Navegação manual de 3 links aleatórios funciona

**Dependências:** Wave 5 (estrutura final definida)

**Arquivos tocados:** 1 (`docs/README.md`)

**Estimativa:** S (1-2)

**Responsável:** `writer`

---

### Checkpoint Final — Verificação Geral

- [x] Wave 0 executada: 3 diretórios criados com `.gitkeep`
- [x] Wave 1 executada: 70 arquivos com frontmatter YAML válido
- [x] Wave 2 executada: `## Metadados` refletem frontmatter; nota padrão adicionada
- [x] Wave 3 executada: 26 arquivos sem `writer` no campo Autor
- [x] Wave 4 executada: `domain.version` sincronizado com histórico
- [x] Wave 5 executada: `analise/` → `analises/`, `tec/` criado, 26 links atualizados *(executado 27/07/2026)*
- **[REVISÃO 31/07/2026]** — revertido por decisão do usuário: canônico = `analise/` (singular); `analises/` removido; links atualizados para `analise/`.
- [x] Wave 6 executada: `docs/README.md` finalizado
- [x] Build dos links: todos os caminhos relativos em `docs/README.md` válidos
- [x] Nenhum arquivo perdeu conteúdo (diff contra git)
- [x] `git status` limpo (diretórios novos trackeados)

## Matriz de Dependências

```
Wave 0 (dirs vazios) → Wave 1 (frontmatter) → Wave 2 (metadados) → Wave 3 (autor fix) → Wave 5 (estrutura) → Wave 6 (TOC final)
                                                     ↓
                                                Wave 4 (version sync)
```

- **Wave 0, 1, 2, 3, 4:** Sequencial obrigatório (alteram conteúdo dos mesmos arquivos)
- **Wave 5:** Executada após Wave 3 (não depende de Wave 4)
- **Wave 6:** Final, depende de todas as anteriores
- **Paralelização:** NÃO recomendada — todas as ondas tocam o mesmo conjunto de arquivos

## Riscos e Mitigações

| Risco | Impacto | Probabilidade | Mitigação |
| ----- | ------- | ------------- | --------- |
| Quebra de links internos após Wave 5 | Alto | Média | Executar verificação de links imediatamente após Wave 5; `grep` para confirmar que nenhum caminho antigo sobreviveu |
| Frontmatter YAML inválido (sintaxe) | Alto | Baixa | Validar cada arquivo após inserção; usar linter YAML ou validação manual do parse |
| Perda de conteúdo ao editar 68 arquivos sequencialmente | Alto | Baixa | Sempre trabalhar com `Read → Edit`; verificar diff contra git entre cada sub-lote |
| Divergência metadados vs frontmatter não detectada | Médio | Média | Wave 2 inclui verificação de amostragem de 10 arquivos |
| `system-risk-matrix.md` e `tamanho-aplicacao.md` sem `Código do documento` | Baixo | Alta | Wave 2 adiciona campo ausente |

## Mudanças Planejadas

### Added

- `docs/extras/.gitkeep` — Diretório obrigatório pelo padrão
- `docs/diagrams/.gitkeep` — Diretório obrigatório pelo padrão
- `docs/vision/.gitkeep` — Diretório obrigatório pelo padrão
- `docs/requirement/tec/` — Subdiretório para tec-req-* (13 arquivos movidos)
- Frontmatter YAML OKF v0.2 em todos os 68 arquivos `.md` (exceto TOC)
- Nota de reflexão do frontmatter em todas as seções `## Metadados`

### Modified

- `docs/README.md` — 26 caminhos atualizados; seção Convenção de Prefixos; data de atualização
- `docs/requirement/analise/analise-req-0001.md` a `analise-req-0013.md` — Autor corrigido; frontmatter adicionado; metadados sincronizados
- `docs/requirement/checklist/checklist-req-0001.md` a `checklist-req-0013.md` — Autor corrigido; frontmatter adicionado; metadados sincronizados
- `docs/requirement/req-0001.md` a `req-0013.md` — Frontmatter adicionado; metadados sincronizados
- `docs/requirement/apf/apf-req-0001.md` a `apf-req-0013.md` — Frontmatter adicionado; metadados sincronizados
- `docs/requirement/tec/tec-req-0001.md` a `tec-req-0013.md` — Movidos + frontmatter adicionado
- `docs/constituicao.md` — Frontmatter adicionado
- `docs/architecture-tech-stack.md` — Frontmatter adicionado
- `docs/system-mapping.md` — Frontmatter adicionado
- `docs/system-risk-matrix.md` — Frontmatter adicionado
- `docs/tamanho-aplicacao.md` — Frontmatter adicionado; `Código do documento` adicionado

### Removed

- `docs/requirement/analise/` (diretório renomeado para `analises/` em 27/07/2026)
- **[REVISÃO 31/07/2026]** — `docs/requirement/analises/` foi removido; os 13 arquivos voltaram para `docs/requirement/analise/` (canônico singular, por decisão do usuário)

## Open Questions (⏳ PENDENTE)

1. **⏳ Data de criação/atualização exata:** A data do campo `generated.timestamp` no frontmatter deve ser a data da última atualização do arquivo. Deve ser extraída dos metadados existentes ou da última modificação no git? Recomendação: usar valor de `Última atualização` nos Metadados existentes.

2. **⏳ `docs/README.md` deve receber frontmatter?** A skill `documentation` diz que TOC raiz não requer type. Mas pode receber frontmatter genérico sem `type`. Decidir durante execução.

3. **⏳ `system-risk-matrix.md` — Código do documento:** O metadado atual não tem `Código do documento`. Sugestão: usar `system-risk-matrix` como artifact_id.

4. **⏳ Impacto da movimentação de arquivos no versionamento git:** A renomeação de `analise/` para `analises/` (27/07/2026) e a movimentação de tec-req-* para `tec/` devem ser feitas com `git mv` para preservar o histórico. **[REVISÃO 31/07/2026]** — a movimentação reversa `analises/` → `analise/` também usa `git mv` (executada pelo `writer` em paralelo).

## Instruções de Execução para o `writer`

1. **Sempre** trabalhar em lotes de 10-15 arquivos, verificando o resultado antes de prosseguir
2. **Executar `git status` e `git diff`** entre cada sub-lote para garantir que nenhum conteúdo foi perdido
3. **Usar `git mv`** para movimentação de arquivos (Wave 5) — preserva histórico
4. **Extrair dados do `## Metadados` existente** para preencher o frontmatter — não inventar valores
5. **Manter encoding UTF-8** em todos os arquivos
6. **Ao final de cada onda**, marcar `[x]` neste plano e salvar o arquivo em disco
7. **Qualquer divergência do plano**, registrar na seção Changes com o motivo

## Template de Frontmatter Detalhado por Tipo

### req-XXXX
```yaml
---
type: req
title: "req-XXXX — <título>"
description: "<descrição do objetivo>"
resource: "./requirement/req-XXXX-slug.md"
tags: [documento-brasileiro, validacao, mascara]
generated:
  by: "Opencode — writer"
  timestamp: "<YYYY-MM-DD>"
status: approved
domain:
  artifact_id: "req-XXXX"
  title_pt: "<título>"
  version: "<versão>"
  author: "Rodrigo Araujo Barbosa"
  created: "<data-criação>"
  updated: "<data-atualização>"
  language: pt-BR
---
```

### tec-req-XXXX
```yaml
---
type: tec-req
title: "tec-req-XXXX — <título>"
description: "<descrição técnica>"
resource: "./requirement/tec/tec-req-XXXX-slug.md"
tags: [documento-brasileiro, especificacao-tecnica]
generated:
  by: "Opencode — writer"
  timestamp: "<YYYY-MM-DD>"
status: approved
domain:
  artifact_id: "tec-req-XXXX"
  title_pt: "<título>"
  version: "<versão>"
  author: "Rodrigo Araujo Barbosa"
  created: "<data-criação>"
  updated: "<data-atualização>"
  language: pt-BR
---
```

### apf-req-XXXX
```yaml
---
type: apf
title: "APF — req-XXXX — <título>"
description: "Análise de Pontos de Função do requisito req-XXXX"
resource: "./requirement/apf/apf-req-XXXX.md"
tags: [apf, pontos-de-funcao]
generated:
  by: "Opencode — writer"
  timestamp: "<YYYY-MM-DD>"
status: approved
domain:
  artifact_id: "apf-req-XXXX"
  title_pt: "APF — req-XXXX"
  version: "<versão>"
  author: "Rodrigo Araujo Barbosa"
  created: "<data-criação>"
  updated: "<data-atualização>"
  language: pt-BR
---
```

### analise-req-XXXX
```yaml
---
type: analise
title: "Análise Cross-Artifact — req-XXXX"
description: "Análise de consistência entre req-XXXX, tec-req-XXXX e artefatos relacionados"
resource: "./requirement/analise/analise-req-XXXX.md"
tags: [analise, cross-artifact, consistencia]
generated:
  by: "Opencode — writer"
  timestamp: "<YYYY-MM-DD>"
status: approved
domain:
  artifact_id: "analise-req-XXXX"
  title_pt: "Análise Cross-Artifact — req-XXXX"
  version: "<versão>"
  author: "Rodrigo Araujo Barbosa"
  created: "<data-criação>"
  updated: "<data-atualização>"
  language: pt-BR
---
```

### checklist-req-XXXX
```yaml
---
type: checklist
title: "Quality Checklist — req-XXXX"
description: "Checklist de qualidade do requisito req-XXXX"
resource: "./requirement/checklist/checklist-req-XXXX.md"
tags: [checklist, qualidade, revisao]
generated:
  by: "Opencode — writer"
  timestamp: "<YYYY-MM-DD>"
status: approved
domain:
  artifact_id: "checklist-req-XXXX"
  title_pt: "Quality Checklist — req-XXXX"
  version: "<versão>"
  author: "Rodrigo Araujo Barbosa"
  created: "<data-criação>"
  updated: "<data-atualização>"
  language: pt-BR
---
```

### Artefatos Globais

#### `constituicao.md`
```yaml
---
type: constituicao
title: "Constituição do Projeto — Sirb.Validation"
description: "Princípios de governança, valores e regras do projeto"
resource: "./constituicao.md"
tags: [governanca, principios, constituicao]
generated:
  by: "Opencode — writer"
  timestamp: "<YYYY-MM-DD>"
status: approved
domain:
  artifact_id: "constituicao"
  title_pt: "Constituição do Projeto — Sirb.Validation"
  version: "<versão>"
  author: "Rodrigo Araujo Barbosa"
  created: "<data-criação>"
  updated: "<data-atualização>"
  language: pt-BR
---
```

#### `architecture-tech-stack.md`
```yaml
---
type: project
title: "Arquitetura e Stack Tecnológico — Sirb.Validation"
description: "Stack tecnológica, arquitetura e decisões estruturais"
resource: "./architecture-tech-stack.md"
tags: [arquitetura, tecnologia, dotnet]
generated:
  by: "Opencode — writer"
  timestamp: "<YYYY-MM-DD>"
status: approved
domain:
  artifact_id: "architecture-tech-stack"
  title_pt: "Arquitetura e Stack Tecnológico"
  version: "<versão>"
  author: "Rodrigo Araujo Barbosa"
  created: "<data-criação>"
  updated: "<data-atualização>"
  language: pt-BR
---
```

#### `system-mapping.md`
```yaml
---
type: project
title: "Mapeamento do Sistema — Sirb.Validation"
description: "Estrutura de pastas, dependências entre requisitos e evidências"
resource: "./system-mapping.md"
tags: [mapeamento, estrutura, dependencias]
generated:
  by: "Opencode — writer"
  timestamp: "<YYYY-MM-DD>"
status: approved
domain:
  artifact_id: "system-mapping"
  title_pt: "Mapeamento do Sistema"
  version: "<versão>"
  author: "Rodrigo Araujo Barbosa"
  created: "<data-criação>"
  updated: "<data-atualização>"
  language: pt-BR
---
```

#### `system-risk-matrix.md`
```yaml
---
type: risk
title: "Matriz de Risco Global — Sirb.Validation"
description: "Matriz de risco global com 19 riscos mapeados"
resource: "./system-risk-matrix.md"
tags: [risco, matriz, seguranca]
generated:
  by: "Opencode — writer"
  timestamp: "<YYYY-MM-DD>"
status: approved
domain:
  artifact_id: "system-risk-matrix"
  title_pt: "Matriz de Risco Global"
  version: "<versão>"
  author: "Rodrigo Araujo Barbosa"
  created: "<data-criação>"
  updated: "<data-atualização>"
  language: pt-BR
---
```

#### `tamanho-aplicacao.md`
```yaml
---
type: apf
title: "Tamanho da Aplicação — APF Consolidado"
description: "Consolidado de APF: 90 PF, 13 requisitos"
resource: "./tamanho-aplicacao.md"
tags: [apf, consolidado, tamanho]
generated:
  by: "Opencode — writer"
  timestamp: "<YYYY-MM-DD>"
status: approved
domain:
  artifact_id: "tamanho-aplicacao"
  title_pt: "Tamanho da Aplicação — APF Consolidado"
  version: "<versão>"
  author: "Rodrigo Araujo Barbosa"
  created: "<data-criação>"
  updated: "<data-atualização>"
  language: pt-BR
---
```

## Status Tracking

- [x] **Wave 0** — Criar diretórios estruturais (`extras/`, `diagrams/`, `vision/`)
- [x] **Wave 1** — Adicionar YAML Frontmatter (68 arquivos)
  - [x] Sub-lote 1: 13 req-XXXX
  - [x] Sub-lote 2: 13 tec-req-XXXX
  - [x] Sub-lote 3: 13 apf-req-XXXX
  - [x] Sub-lote 4: 13 analise-req-XXXX
  - [x] Sub-lote 5: 13 checklist-req-XXXX
  - [x] Sub-lote 6: 5 artefatos globais
- [x] **Wave 2** — Sincronizar `## Metadados` com frontmatter
- [x] **Wave 3** — Corrigir campo Autor (26 arquivos)
- [x] **Wave 4** — Sincronizar `domain.version` com histórico
- [x] **Wave 5** — Alinhamento estrutural de diretórios
  - [x] Renomear `analise/` → `analises/` *(executado 27/07/2026)*
  - **[REVISÃO 31/07/2026]** — revertido por decisão do usuário: `analises/` → `analise/` (canônico singular)
  - [x] Criar `tec/` e mover 13 tec-req-*
  - [x] Atualizar 26 links no TOC
- [x] **Wave 6** — Atualizar `docs/README.md` (TOC final)
- [x] **✅ Checkpoint Final** — Verificação geral
