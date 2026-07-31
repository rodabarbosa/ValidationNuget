# Documentação do Sistema — Sirb.Validation

> **TOC raiz obrigatório** — Índice navegável para todas as áreas da documentação.
> Última atualização: 31/07/2026

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

### 📋 Requisitos (Validação)

| Código | Nome | Status | APF |
| ------ | ---- | ------ | --- |
| [req-0001](./requirement/req-0001-cpf-validacao.md) | CPF — Validação | `aprovado` | 6 PF |
| [tec-req-0001](./requirement/tec/tec-req-0001-cpf-validacao.md) | CPF — Especificação Técnica | `aprovado` | — |
| [req-0002](./requirement/req-0002-cnpj-validacao.md) | CNPJ — Validação | `aprovado` | 3 PF |
| [tec-req-0002](./requirement/tec/tec-req-0002-cnpj-validacao.md) | CNPJ — Especificação Técnica | `aprovado` | — |
| [req-0003](./requirement/req-0003-pis-validacao.md) | PIS — Validação | `aprovado` | 3 PF |
| [tec-req-0003](./requirement/tec/tec-req-0003-pis-validacao.md) | PIS — Especificação Técnica | `aprovado` | — |
| [req-0004](./requirement/req-0004-titulo-eleitor-validacao.md) | Título de Eleitor — Validação | `aprovado` | 3 PF |
| [tec-req-0004](./requirement/tec/tec-req-0004-titulo-eleitor-validacao.md) | Título de Eleitor — Especificação Técnica | `aprovado` | — |
| [req-0005](./requirement/req-0005-renavam-validacao.md) | Renavam — Validação | `aprovado` | 3 PF |
| [tec-req-0005](./requirement/tec/tec-req-0005-renavam-validacao.md) | Renavam — Especificação Técnica | `aprovado` | — |
| [req-0006](./requirement/req-0006-inscricao-estadual-validacao.md) | Inscrição Estadual (27 UFs) — Validação | `aprovado` | 4 PF |
| [tec-req-0006](./requirement/tec/tec-req-0006-inscricao-estadual-validacao.md) | Inscrição Estadual — Especificação Técnica | `aprovado` | — |
| [req-0019](./requirement/req-0019-cnpj-alfanumerico-validacao.md) | CNPJ Alfanumérico — Validação | `rascunho` | 3 PF |
| [tec-req-0019](./requirement/tec/tec-req-0019-cnpj-alfanumerico-validacao.md) | CNPJ Alfanumérico — Especificação Técnica | `rascunho` | — |

### 📋 Requisitos (Máscaras Independentes)

| Código | Nome | Status | APF |
| ------ | ---- | ------ | --- |
| [req-0014](./requirement/req-0014-cpf-mascara.md) | CPF — Máscara | `aprovado` | 3 PF |
| [tec-req-0014](./requirement/tec/tec-req-0014-cpf-mascara.md) | CPF — Máscara Especificação Técnica | `aprovado` | — |
| [req-0015](./requirement/req-0015-cnpj-mascara.md) | CNPJ — Máscara | `aprovado` | 3 PF |
| [tec-req-0015](./requirement/tec/tec-req-0015-cnpj-mascara.md) | CNPJ — Máscara Especificação Técnica | `aprovado` | — |
| [req-0016](./requirement/req-0016-pis-mascara.md) | PIS — Máscara | `aprovado` | 3 PF |
| [tec-req-0016](./requirement/tec/tec-req-0016-pis-mascara.md) | PIS — Máscara Especificação Técnica | `aprovado` | — |
| [req-0017](./requirement/req-0017-titulo-eleitor-mascara.md) | Título de Eleitor — Máscara | `aprovado` | 3 PF |
| [tec-req-0017](./requirement/tec/tec-req-0017-titulo-eleitor-mascara.md) | Título de Eleitor — Máscara Especificação Técnica | `aprovado` | — |
| [req-0018](./requirement/req-0018-inscricao-estadual-mascara.md) | Inscrição Estadual (27 UFs + DF) — Máscaras | `aprovado` | 12 PF |
| [tec-req-0018](./requirement/tec/tec-req-0018-inscricao-estadual-mascara.md) | Inscrição Estadual — Máscaras Especificação Técnica | `aprovado` | — |
| [req-0021](./requirement/req-0021-cnpj-alfanumerico-mascara.md) | CNPJ Alfanumérico — Máscara | `rascunho` | 3 PF |
| [tec-req-0021](./requirement/tec/tec-req-0021-cnpj-alfanumerico-mascara.md) | CNPJ Alfanumérico — Máscara Especificação Técnica | `rascunho` | — |

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
| [req-0020](./requirement/req-0020-mockup-cnpj-alfanumerico.md) | Mockup CNPJ Alfanumérico | `rascunho` | 4 PF |
| [tec-req-0020](./requirement/tec/tec-req-0020-mockup-cnpj-alfanumerico.md) | Mockup CNPJ Alfanumérico — Técnico | `rascunho` | — |

### 📋 Requisitos (Utilitários)

| Código | Nome | Status | APF |
| ------ | ---- | ------ | --- |
| [req-0013](./requirement/req-0013-string-utils.md) | String Utils | `aprovado` | 21 PF |
| [tec-req-0013](./requirement/tec/tec-req-0013-string-utils.md) | String Utils — Técnico | `aprovado` | — |

### 📊 Análise de Pontos de Função (APF)

| Requisito | APF | Link |
| --------- | --- | ---- |
| req-0001 | 6 PF | [apf-req-0001](./requirement/apf/apf-req-0001.md) |
| req-0002 | 3 PF | [apf-req-0002](./requirement/apf/apf-req-0002.md) |
| req-0003 | 3 PF | [apf-req-0003](./requirement/apf/apf-req-0003.md) |
| req-0004 | 3 PF | [apf-req-0004](./requirement/apf/apf-req-0004.md) |
| req-0005 | 3 PF | [apf-req-0005](./requirement/apf/apf-req-0005.md) |
| req-0006 | 4 PF | [apf-req-0006](./requirement/apf/apf-req-0006.md) |
| req-0007 | 4 PF | [apf-req-0007](./requirement/apf/apf-req-0007.md) |
| req-0008 | 4 PF | [apf-req-0008](./requirement/apf/apf-req-0008.md) |
| req-0009 | 4 PF | [apf-req-0009](./requirement/apf/apf-req-0009.md) |
| req-0010 | 4 PF | [apf-req-0010](./requirement/apf/apf-req-0010.md) |
| req-0011 | 4 PF | [apf-req-0011](./requirement/apf/apf-req-0011.md) |
| req-0012 | 5 PF | [apf-req-0012](./requirement/apf/apf-req-0012.md) |
| req-0013 | 21 PF | [apf-req-0013](./requirement/apf/apf-req-0013.md) |
| req-0014 | 3 PF | [apf-req-0014](./requirement/apf/apf-req-0014.md) |
| req-0015 | 3 PF | [apf-req-0015](./requirement/apf/apf-req-0015.md) |
| req-0016 | 3 PF | [apf-req-0016](./requirement/apf/apf-req-0016.md) |
| req-0017 | 3 PF | [apf-req-0017](./requirement/apf/apf-req-0017.md) |
| req-0018 | 12 PF | [apf-req-0018](./requirement/apf/apf-req-0018.md) |
| req-0019 | 3 PF | [apf-req-0019](./requirement/apf/apf-req-0019.md) |
| req-0020 | 4 PF | [apf-req-0020](./requirement/apf/apf-req-0020.md) |
| req-0021 | 3 PF | [apf-req-0021](./requirement/apf/apf-req-0021.md) |
| **Total** | **102 PF** | [tamanho-aplicacao.md](./tamanho-aplicacao.md) |

### 🔬 Análises Cross-Artifact

| Requisito | Status | Link |
| --------- | ------ | ---- |
| req-0001 | APROVADO | [analise-req-0001](./requirement/analise/analise-req-0001.md) |
| req-0002 | APROVADO | [analise-req-0002](./requirement/analise/analise-req-0002.md) |
| req-0003 | APROVADO | [analise-req-0003](./requirement/analise/analise-req-0003.md) |
| req-0004 | APROVADO | [analise-req-0004](./requirement/analise/analise-req-0004.md) |
| req-0005 | APROVADO | [analise-req-0005](./requirement/analise/analise-req-0005.md) |
| req-0006 | APROVADO | [analise-req-0006](./requirement/analise/analise-req-0006.md) |
| req-0007 | APROVADO | [analise-req-0007](./requirement/analise/analise-req-0007.md) |
| req-0008 | APROVADO | [analise-req-0008](./requirement/analise/analise-req-0008.md) |
| req-0009 | APROVADO | [analise-req-0009](./requirement/analise/analise-req-0009.md) |
| req-0010 | APROVADO | [analise-req-0010](./requirement/analise/analise-req-0010.md) |
| req-0011 | APROVADO | [analise-req-0011](./requirement/analise/analise-req-0011.md) |
| req-0012 | APROVADO COM RESSALVAS | [analise-req-0012](./requirement/analise/analise-req-0012.md) |
| req-0013 | APROVADO | [analise-req-0013](./requirement/analise/analise-req-0013.md) |
| req-0014 | APROVADO | [analise-req-0014](./requirement/analise/analise-req-0014.md) |
| req-0015 | APROVADO | [analise-req-0015](./requirement/analise/analise-req-0015.md) |
| req-0016 | APROVADO | [analise-req-0016](./requirement/analise/analise-req-0016.md) |
| req-0017 | APROVADO | [analise-req-0017](./requirement/analise/analise-req-0017.md) |
| req-0018 | APROVADO | [analise-req-0018](./requirement/analise/analise-req-0018.md) |
| req-0019 | RASCUNHO | [analise-req-0019](./requirement/analise/analise-req-0019.md) |
| req-0020 | RASCUNHO | [analise-req-0020](./requirement/analise/analise-req-0020.md) |
| req-0021 | RASCUNHO | [analise-req-0021](./requirement/analise/analise-req-0021.md) |

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
| req-0014 | APROVADO | [checklist-req-0014](./requirement/checklist/checklist-req-0014.md) |
| req-0015 | APROVADO | [checklist-req-0015](./requirement/checklist/checklist-req-0015.md) |
| req-0016 | APROVADO | [checklist-req-0016](./requirement/checklist/checklist-req-0016.md) |
| req-0017 | APROVADO | [checklist-req-0017](./requirement/checklist/checklist-req-0017.md) |
| req-0018 | APROVADO | [checklist-req-0018](./requirement/checklist/checklist-req-0018.md) |
| req-0019 | EM ANDAMENTO | [checklist-req-0019](./requirement/checklist/checklist-req-0019.md) |
| req-0020 | EM ANDAMENTO | [checklist-req-0020](./requirement/checklist/checklist-req-0020.md) |
| req-0021 | EM ANDAMENTO | [checklist-req-0021](./requirement/checklist/checklist-req-0021.md) |

### ⚠️ Matriz de Risco
- [Matriz de Risco Global](./system-risk-matrix.md) · `aprovado` · v1.4.0 — 32 riscos consolidados

### 📏 Tamanho da Aplicação
- [Tamanho da Aplicação (APF Consolidado)](./tamanho-aplicacao.md) · `aprovado` · v1.4.0 — 102 PF

### 🗺️ Mapeamento do Sistema
- [Mapeamento do Sistema](./system-mapping.md) · `aprovado` · v1.5.0

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
| Análise Cross-Artifact | `analise-req-XXXX.md` | `/docs/requirement/analise` |
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
| `system-mapping.md` | `aprovado` | 31/07/2026 |
| `system-risk-matrix.md` | `aprovado` | 31/07/2026 |
| `tamanho-aplicacao.md` | `aprovado` | 31/07/2026 |
| 21 pares req-XXXX/tec-req-XXXX | 18× `aprovado`, 3× `rascunho` | 31/07/2026 |
| 21 APFs | 18× `aprovado`, 3× `rascunho` | 31/07/2026 |
| 21 análises cross-artifact | 17× APROVADO, 1× APROVADO COM RESSALVAS, 3× RASCLUNHO | 31/07/2026 |
| 21 quality checklists | 17× APROVADO, 1× APROVADO COM RESSALVAS, 3× EM ANDAMENTO | 31/07/2026 |
| Conformidade OKF v0.2 | `concluído` | 31/07/2026 |

---

## Última Atualização Global

**31/07/2026** — Adicionados req-0020 (Mockup CNPJ Alfanumérico: 4 PF, EO) e req-0021 (CNPJ Alfanumérico — Máscara: 3 PF, EE) completando o ciclo do CNPJ Alfanumérico (validação req-0019 + mockup req-0020 + máscara req-0021). APF: +7 PF (total 102). Matriz de risco global: +3 riscos (RSK-034 a RSK-036, total 32). Artefatos globais atualizados: system-risk-matrix.md (v1.4.0), tamanho-aplicacao.md (v1.4.0), system-mapping.md (v1.5.0), docs/README.md. Documentação em conformidade com OKF v0.2.

---

**31/07/2026** — Adicionado req-0019 (CNPJ Alfanumérico — Validação) como 19º requisito: novo formato RFB (IN 2.229/2024) com algoritmo módulo 11 e conversão ASCII-48, retrocompatível com CNPJ numérico. APF: +3 PF (total 95). Matriz de risco global: +3 riscos (RSK-031 a RSK-033, total 29). Artefatos globais atualizados: system-risk-matrix.md (v1.3.0), tamanho-aplicacao.md (v1.3.0), docs/README.md. Documentação em conformidade com OKF v0.2.

---

**31/07/2026** — Removido o conteúdo de máscara dos requisitos de validação req-0001 a req-0006 (escopo reduzido a validação pura; formatação passa a ser coberta exclusivamente pelos requisitos de máscara independentes req-0014 a req-0018). Arquivos renomeados (`*-validacao-mascara.md` → `*-validacao.md`). APFs recalculados: total 126→92 PF. Matriz de risco global atualizada: 30→26 riscos (RSK-002/005/007/013 removidos por cobertura nos requisitos de máscara). Artefatos globais atualizados: system-risk-matrix.md (v1.2.0), tamanho-aplicacao.md (v1.2.0), system-mapping.md (v1.2.0). Documentação em conformidade com OKF v0.2.

---

## Próximos Passos

1. ❌ Fase 3A — Design system: N/A (biblioteca sem UI)
2. ❌ Fase 3B — Integração de dados: N/A (biblioteca stateless)
3. ✅ Fase 2 — Concluída: todos os 18 requisitos documentados, analisados e aprovados
4. ✅ Fase 2.5 — Conformidade da documentação ao padrão OKF v0.2 (frontmatter YAML, estrutura de diretórios, metadados)
5. ⏳ Implementação dos requisitos conforme tec-reqs (quando aplicável)