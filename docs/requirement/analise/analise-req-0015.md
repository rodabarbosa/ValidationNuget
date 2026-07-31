---
type: analise
title: "analise-req-0015 — CNPJ — Máscara (Análise Cross-Artifact)"
description: "Análise de consistência cross-artifact para req-0015/tec-req-0015"
resource: "./requirement/analise/analise-req-0015.md"
tags: [analise, cross-artifact, mascara, cnpj]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-31"
verified:
  by: "Rodrigo Araujo Barbosa"
  timestamp: "2026-07-31T02:00:00Z"
  method: "validação com PO"
status: approved
domain:
  artifact_id: "analise-req-0015"
  title_pt: "CNPJ — Máscara — Análise Cross-Artifact"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "31/07/2026"
  updated: "31/07/2026"
  bundle: "flat"
  language: pt-BR
  status: "APROVADO"
---

# analise-req-0015 — CNPJ — Máscara (Análise Cross-Artifact)

## Metadados

| Campo | Valor |
|---|---|
| **Requisito de negócio** | `req-0015-cnpj-mascara.md` v1.0.0 |
| **Requisito técnico** | `tec-req-0015-cnpj-mascara.md` v1.0.0 |
| **Status da análise** | **APROVADO** |
| **Data da análise** | 31/07/2026 |
| **Analista** | Rodrigo Araujo Barbosa |

---

## 1. Consistência `req-0015` ↔ `tec-req-0015`

| Critério | req-0015 | tec-req-0015 | Status |
|----------|----------|--------------|--------|
| Mesmo `XXXX` | 0015 | 0015 | ✅ |
| Mesma versão | 1.0.0 | 1.0.0 | ✅ |
| "Por quê" alinhado | Sim (padronizar formatação CNPJ) | Sim | ✅ |
| RFs consistentes | RF-001 a RF-004 | RF-001 a RF-004 | ✅ |
| RNs consistentes | RN-001 a RN-004 | RN-001 a RN-004 | ✅ |
| Cenários Gherkin cobertos | 7 cenários | Exemplos correspondem | ✅ |

---

## 2. Entidades ↔ `did-*` ↔ `api-*` ↔ `der-*`

| Item | Referência | Status |
|------|------------|--------|
| Entidades de dados | N/A (stateless) | ✅ N/A |
| Dicionário de dados | N/A | ✅ N/A |
| Documentação de API | N/A | ✅ N/A |
| Diagramas DER | N/A | ✅ N/A |

---

## 3. APF ↔ `apf-req-0015.md` ↔ `tamanho-aplicacao.md`

| Item | Valor | Status |
|------|-------|--------|
| PF do requisito | 3 PF | ✅ |
| `apf-req-0015.md` existe | Sim | ✅ |
| `tamanho-aplicacao.md` atualizado | Pendente (global) | ⏳ |

---

## 4. Risco Local ↔ `system-risk-matrix.md`

| Risco Local | ID Global | Score | Nível | Status |
|-------------|-----------|-------|-------|--------|
| Regex máscara erro | RSK-016 | 3 | Baixo | ✅ Mapeado |
| Performance alocação | RSK-017 | 6 | Médio | ✅ Mapeado |

---

## 5. Clarification Log — Sem Pendentes Bloqueantes

| # | Pergunta | Status | Origem | Impacta Aceite? |
|---|----------|--------|--------|-----------------|
| 1 | PlaceMask valida CNPJ? | Resolvido | Criação | Não |
| 2 | Comportamento < 14 dígitos | Resolvido | Criação | Não |
| 3 | Namespace Exceptions vs Extensions | Resolvido | Criação | Não |
| 4 | Lançar exceção inválida? | Resolvido | Criação | Não |
| 5 | RemoveMask específico CNPJ? | Resolvido | Criação | Não |
| 6 | Preservar não-numéricos? | Resolvido | Criação | Não |
| 7 | PlaceMask vs PlaceCnpjMask | Resolvido | Criação | Não |
| 8 | Whitespace-only como vazio? | Resolvido | Criação | Não |

**Todos 8 itens: Resolvido. Nenhum Pendente bloqueante.**

---

## 6. Alinhamento com `constituicao.md`

| Princípio | Alinhamento | Evidência |
|-----------|-------------|-----------|
| SEC-06 (Dados sensíveis) | ✅ | Não logar CNPJ bruto |
| SEC-07 (ReDoS) | ✅ | Regex simples |
| PERF-01/02 | ✅ | p95 < 1ms, >100k/s |
| QUAL-01 | ✅ | Cobertura 100% |
| ARCH-03 | ✅ | Sem logging próprio |

---

## Veredito Final

**STATUS: APROVADO** ✅

Todos 6 eixos validados. Requisito pronto para fechamento.

---

## Histórico

| Data | Autor | Versão | Alteração |
|------|-------|--------|-----------|
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação |