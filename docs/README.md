# Documentação do Sistema — Sirb.Validation

> **TOC raiz obrigatório** — Índice navegável para todas as áreas da documentação.
> Última atualização: 30/07/2026

## Contexto e Objetivo

Esta documentação cobre a biblioteca **Sirb.Validation** — biblioteca .NET NuGet para validação, formatação (máscara) e geração de documentos brasileiros (CPF, CNPJ, PIS, Título de Eleitor, Inscrição Estadual, Renavam) e utilitários de string.

- **Repositório:** https://github.com/rodabarbosa/ValidationNuget
- **Pacote NuGet:** https://www.nuget.org/packages/Sirb.Validation
- **Licença:** MIT
- **Autor:** Rodrigo Araujo Barbosa

---

## Índice

### 📜 Governança e Constituição
- [Constituição do Projeto](./constituicao.md) · `aprovado` · v1.0.0
- [Arquitetura e Stack Tecnológico](./architecture-tech-stack.md) · `aprovado` · v1.0.0

### 📋 Requisitos (Validação e Máscara)

| Código | Nome | Status | APF |
| ------ | ---- | ------ | --- |
| [req-0001](./requirement/req-0001-cpf-validacao-mascara.md) | CPF — Validação e Máscara | `aprovado` | 12 PF |
| [tec-req-0001](./requirement/tec/tec-req-0001-cpf-validacao-mascara.md) | CPF — Especificação Técnica | `aprovado` | — |
| [req-0002](./requirement/req-0002-cnpj-validacao-mascara.md) | CNPJ — Validação e Máscara | `aprovado` | 6 PF |
| [tec-req-0002](./requirement/tec/tec-req-0002-cnpj-validacao-mascara.md) | CNPJ — Especificação Técnica | `aprovado` | — |
| [req-0003](./requirement/req-0003-pis-validacao-mascara.md) | PIS — Validação e Máscara | `aprovado` | 6 PF |
| [tec-req-0003](./requirement/tec/tec-req-0003-pis-validacao-mascara.md) | PIS — Especificação Técnica | `aprovado` | — |
| [req-0004](./requirement/req-0004-titulo-eleitor-validacao-mascara.md) | Título de Eleitor — Validação e Máscara | `aprovado` | 6 PF |
| [tec-req-0004](./requirement/tec/tec-req-0004-titulo-eleitor-validacao-mascara.md) | Título de Eleitor — Especificação Técnica | `aprovado` | — |
| [req-0005](./requirement/req-0005-renavam-validacao.md) | Renavam — Validação | `aprovado` | 3 PF |
| [tec-req-0005](./requirement/tec/tec-req-0005-renavam-validacao.md) | Renavam — Especificação Técnica | `aprovado` | — |
| [req-0006](./requirement/req-0006-inscricao-estadual-validacao-mascara.md) | Inscrição Estadual (27 UFs) — Validação e Máscara | `aprovado` | 11 PF |
| [tec-req-0006](./requirement/tec/tec-req-0006-inscricao-estadual-validacao-mascara.md) | Inscrição Estadual — Especificação Técnica | `aprovado` | — |

### 📋 Requisitos (Mockups — Geração para Testes)

| Código | Nome | Status | APF |
| ------ | ---- | ------ | --- |
| [req-0007](./requirement/req-0007-mockup-cpf.md) | Mockup CPF | `aprovado` | 4 PF |
| [tec-req-0007](./requirement/tec/tec-req-0007-mockup-cpf.md) | Mockup CPF — Técnico | `aprovado` | — |
| [req-0008](./requirement/req-0008-mockup-cnpj.md) | Mockup CNPJ | `aprovado` | 4 PF |
| [tec-req-0008](./requirement/tec/tec-req-0008-mockup-cnpj.md) | Mockup CNPJ — Técnico | `aprovado` | — |
| [req-0009](./requirement/req-0009-mockup-pis.md) | Mockup PIS | `aprovado` | 4 PF |
| [tec-req-0009](./requirement/tec/tec-req-0009-mockup-pis.md) | Mockup PIS — Técnico | `aprovado` | — |
| [req-0010](./requirement/req-0010-mockup-titulo-eleitor.md) | Mockup Título de Eleitor | `aprovado` | 4 PF |
| [tec-req-0010](./requirement/tec/tec-req-0010-mockup-titulo-eleitor.md) | Mockup Título — Técnico | `aprovado` | — |
| [req-0011](./requirement/req-0011-mockup-renavam.md) | Mockup Renavam | `aprovado` | 4 PF |
| [tec-req-0011](./requirement/tec/tec-req-0011-mockup-renavam.md) | Mockup Renavam — Técnico | `aprovado` | — |
| [req-0012](./requirement/req-0012-mockup-inscricao-estadual.md) | Mockup Inscrição Estadual (27 UFs) | `aprovado` | 5 PF |
| [tec-req-0012](./requirement/tec/tec-req-0012-mockup-inscricao-estadual.md) | Mockup IE — Técnico | `aprovado` | — |

### 📋 Requisitos (Utilitários)

| Código | Nome | Status | APF |
| ------ | ---- | ------ | --- |
| [req-0013](./requirement/req-0013-string-utils.md) | String Utils | `aprovado` | 21 PF |
| [tec-req-0013](./requirement/tec/tec-req-0013-string-utils.md) | String Utils — Técnico | `aprovado` | — |

### 📊 Análise de Pontos de Função (APF)

| Requisito | APF | Link |
| --------- | --- | ---- |
| req-0001 | 12 PF | [apf-req-0001](./requirement/apf/apf-req-0001.md) |
| req-0002 | 6 PF | [apf-req-0002](./requirement/apf/apf-req-0002.md) |
| req-0003 | 6 PF | [apf-req-0003](./requirement/apf/apf-req-0003.md) |
| req-0004 | 6 PF | [apf-req-0004](./requirement/apf/apf-req-0004.md) |
| req-0005 | 3 PF | [apf-req-0005](./requirement/apf/apf-req-0005.md) |
| req-0006 | 11 PF | [apf-req-0006](./requirement/apf/apf-req-0006.md) |
| req-0007 | 4 PF | [apf-req-0007](./requirement/apf/apf-req-0007.md) |
| req-0008 | 4 PF | [apf-req-0008](./requirement/apf/apf-req-0008.md) |
| req-0009 | 4 PF | [apf-req-0009](./requirement/apf/apf-req-0009.md) |
| req-0010 | 4 PF | [apf-req-0010](./requirement/apf/apf-req-0010.md) |
| req-0011 | 4 PF | [apf-req-0011](./requirement/apf/apf-req-0011.md) |
| req-0012 | 5 PF | [apf-req-0012](./requirement/apf/apf-req-0012.md) |
| req-0013 | 21 PF | [apf-req-0013](./requirement/apf/apf-req-0013.md) |
| **Total** | **90 PF** | [tamanho-aplicacao.md](./tamanho-aplicacao.md) |

### 🔬 Análises Cross-Artifact

| Requisito | Status | Link |
| --------- | ------ | ---- |
| req-0001 | APROVADO | [analise-req-0001](./requirement/analises/analise-req-0001.md) |
| req-0002 | APROVADO | [analise-req-0002](./requirement/analises/analise-req-0002.md) |
| req-0003 | APROVADO | [analise-req-0003](./requirement/analises/analise-req-0003.md) |
| req-0004 | APROVADO | [analise-req-0004](./requirement/analises/analise-req-0004.md) |
| req-0005 | APROVADO | [analise-req-0005](./requirement/analises/analise-req-0005.md) |
| req-0006 | APROVADO | [analise-req-0006](./requirement/analises/analise-req-0006.md) |
| req-0007 | APROVADO | [analise-req-0007](./requirement/analises/analise-req-0007.md) |
| req-0008 | APROVADO | [analise-req-0008](./requirement/analises/analise-req-0008.md) |
| req-0009 | APROVADO | [analise-req-0009](./requirement/analises/analise-req-0009.md) |
| req-0010 | APROVADO | [analise-req-0010](./requirement/analises/analise-req-0010.md) |
| req-0011 | APROVADO | [analise-req-0011](./requirement/analises/analise-req-0011.md) |
| req-0012 | APROVADO COM RESSALVAS | [analise-req-0012](./requirement/analises/analise-req-0012.md) |
| req-0013 | APROVADO | [analise-req-0013](./requirement/analises/analise-req-0013.md) |

### ✅ Quality Checklists

| Requisito | Veredito | Link |
| --------- | -------- | ---- |
| req-0001 | APROVADO | [checklist-req-0001](./requirement/checklist/checklist-req-0001.md) |
| req-0002 | APROVADO | [checklist-req-0002](./requirement/checklist/checklist-req-0002.md) |
| req-0003 | APROVADO | [checklist-req-0003](./requirement/checklist/checklist-req-0003.md) |
| req-0004 | APROVADO | [checklist-req-0004](./requirement/checklist/checklist-req-0004.md) |
| req-0005 | APROVADO | [checklist-req-0005](./requirement/checklist/checklist-req-0005.md) |
| req-0006 | APROVADO | [checklist-req-0006](./requirement/checklist/checklist-req-0006.md) |
| req-0007 | APROVADO | [checklist-req-0007](./requirement/checklist/checklist-req-0007.md) |
| req-0008 | APROVADO | [checklist-req-0008](./requirement/checklist/checklist-req-0008.md) |
| req-0009 | APROVADO | [checklist-req-0009](./requirement/checklist/checklist-req-0009.md) |
| req-0010 | APROVADO | [checklist-req-0010](./requirement/checklist/checklist-req-0010.md) |
| req-0011 | APROVADO | [checklist-req-0011](./requirement/checklist/checklist-req-0011.md) |
| req-0012 | APROVADO COM RESSALVAS | [checklist-req-0012](./requirement/checklist/checklist-req-0012.md) |
| req-0013 | APROVADO | [checklist-req-0013](./requirement/checklist/checklist-req-0013.md) |

### ⚠️ Matriz de Risco
- [Matriz de Risco Global](./system-risk-matrix.md) · `aprovado` · v1.0.0 — 19 riscos consolidados

### 📏 Tamanho da Aplicação
- [Tamanho da Aplicação (APF Consolidado)](./tamanho-aplicacao.md) · `aprovado` · v1.0.0 — 90 PF

### 🗺️ Mapeamento do Sistema
- [Mapeamento do Sistema](./system-mapping.md) · `aprovado` · v1.0.0

### 🎨 Design System
> *N/A — Biblioteca sem interface de usuário.*

### 🗄️ Banco de Dados
> *N/A — Biblioteca stateless sem persistência.*

### 📂 Extras
> *Disponível em [`extras/`](./extras/) — Documentos de apoio, materiais complementares.*

### 📐 Diagramas
> *Disponível em [`diagrams/`](./diagrams/) — Diagramas de arquitetura, fluxo e DER.*

### 👁️ Vision
> *Disponível em [`vision/`](./vision/) — Documentos de visão do sistema.*

---

## Convenção de Prefixos

| Tipo | Prefixo | Diretório |
|------|---------|-----------|
| Requisito (negócio) | `req-XXXX-nome.md` | `/docs/requirement` |
| Requisito (técnico) | `tec-req-XXXX-nome.md` | `/docs/requirement/tec` |
| APF por requisito | `apf-req-XXXX.md` | `/docs/requirement/apf` |
| Análise Cross-Artifact | `analise-req-XXXX.md` | `/docs/requirement/analises` |
| Quality Checklist | `checklist-req-XXXX.md` | `/docs/requirement/checklist` |
| Matriz de risco global | `system-risk-matrix.md` | `/docs` |
| Tamanho da aplicação | `tamanho-aplicacao.md` | `/docs` |
| Mapeamento do sistema | `system-mapping.md` | `/docs` |
| Documentos de apoio | `*.*` | `/docs/extras` |
| Diagramas | `dcl-*`, `der-*`, `min-*` | `/docs/diagrams` |
| Documentos de visão | `vis-*.md` | `/docs/vision` |

---

## Status dos Artefatos

| Artefato | Status | Última Atualização |
|----------|--------|-------------------|
| `constituicao.md` | `aprovado` | 26/07/2026 |
| `architecture-tech-stack.md` | `aprovado` | 26/07/2026 |
| `system-mapping.md` | `aprovado` | 27/07/2026 |
| `system-risk-matrix.md` | `aprovado` | 27/07/2026 |
| `tamanho-aplicacao.md` | `aprovado` | 27/07/2026 |
| 13 pares req-XXXX/tec-req-XXXX | `aprovado` | 27/07/2026 |
| 13 APFs | `aprovado` | 27/07/2026 |
| 13 análises cross-artifact | 12× APROVADO, 1× APROVADO COM RESSALVAS | 27/07/2026 |
| 13 quality checklists | 12× APROVADO, 1× APROVADO COM RESSALVAS | 27/07/2026 |
| Conformidade OKF v0.2 | `concluído` | 30/07/2026 |

---

## Última Atualização Global

**30/07/2026** — Fase 2.5 (Conformidade de Documentação): frontmatter YAML OKF v0.2 adicionado a todos os 70 artefatos, metadados sincronizados, estrutura de diretórios alinhada ao padrão.

---

## Próximos Passos

1. ❌ Fase 3A — Design system: N/A (biblioteca sem UI)
2. ❌ Fase 3B — Integração de dados: N/A (biblioteca stateless)
3. ✅ Fase 2 — Concluída: todos os requisitos documentados, analisados e aprovados
4. ✅ Fase 2.5 — Conformidade da documentação ao padrão OKF v0.2 (frontmatter YAML, estrutura de diretórios, metadados)
5. ⏳ Implementação dos requisitos conforme tec-reqs (quando aplicável)
