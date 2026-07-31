---
type: analise
title: "analise-req-0018 — Inscrição Estadual (27 UFs + DF) — Máscaras (Análise Cross-Artifact)"
description: "Análise de consistência cross-artifact para req-0018/tec-req-0018"
resource: "./requirement/analise/analise-req-0018.md"
tags: [analise, cross-artifact, mascara, inscricao-estadual]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-31"
verified:
  by: "Rodrigo Araujo Barbosa"
  timestamp: "2026-07-31T02:00:00Z"
  method: "validação com PO"
status: approved
domain:
  artifact_id: "analise-req-0018"
  title_pt: "Inscrição Estadual (27 UFs + DF) — Máscaras — Análise Cross-Artifact"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "31/07/2026"
  updated: "31/07/2026"
  bundle: "flat"
  language: pt-BR
  status: "APROVADO"
---

# analise-req-0018 — Inscrição Estadual (27 UFs + DF) — Máscaras (Análise Cross-Artifact)

## Metadados

| Campo | Valor |
|---|---|
| **Requisito de negócio** | `req-0018-inscricao-estadual-mascara.md` v1.0.0 |
| **Requisito técnico** | `tec-req-0018-inscricao-estadual-mascara.md` v1.0.0 |
| **Status da análise** | **APROVADO** |
| **Data da análise** | 31/07/2026 |
| **Analista** | Rodrigo Araujo Barbosa |

---

## 1. Consistência `req-0018` ↔ `tec-req-0018`

| Critério | req-0018 | tec-req-0018 | Status |
|----------|----------|--------------|--------|
| Mesmo `XXXX` | 0018 | 0018 | ✅ |
| Mesma versão | 1.0.0 | 1.0.0 | ✅ |
| "Por quê" alinhado | Sim (centralizar 28 máscaras) | Sim | ✅ |
| RFs consistentes | RF-001 a RF-006 | RF-001 a RF-006 | ✅ |
| RNs consistentes | RN-001 a RN-006 | RN-001 a RN-006 | ✅ |
| Cenários Gherkin cobertos | 6 cenários | Exemplos técnicos cobrem | ✅ |

---

## 2. Entidades ↔ `did-*` ↔ `api-*` ↔ `der-*`

| Item | Referência | Status |
|------|------------|--------|
| Enum `State` (28 valores) | `Documents/BR/Enumeration/State.cs` | ✅ Mapeado |
| Dicionário `_mask` (28 entries) | `InscricaoEstadualValidation.cs` | ✅ Mapeado |
| 27 Extensions estaduais | `Extensions/*Extension.cs` | ✅ Mapeado |
| Extension genérico `StateExtension` | `Extensions/StateExtension.cs` | ✅ Mapeado |
| Interface `IInscricaoEstadualValidation` | `Interfaces/IInscricaoEstadualValidation.cs` | ✅ Mapeado |
| Exceção `StateNotFoundException` | `Exceptions/StateNotFoundException.cs` | ✅ Mapeado |

---

## 3. APF ↔ `apf-req-0018.md` ↔ `tamanho-aplicacao.md`

| Item | Valor | Status |
|------|-------|--------|
| PF do requisito | 12 PF | ✅ |
| `apf-req-0018.md` existe | Sim | ✅ |
| `tamanho-aplicacao.md` atualizado | Pendente (global) | ⏳ |

---

## 4. Risco Local ↔ `system-risk-matrix.md`

| Risco Local | ID Global | Score | Nível | Status |
|-------------|-----------|-------|-------|--------|
| Máscara estado errado | RSK-022 | 10 | Alto | ✅ Mapeado |
| StateNotFoundException | RSK-023 | 4 | Médio | ✅ Mapeado |
| Performance dicionário | RSK-024 | 3 | Baixo | ✅ Mapeado |

---

## 5. Clarification Log — Sem Pendentes Bloqueantes

| # | Pergunta | Status | Origem | Impacta Aceite? |
|---|----------|--------|--------|-----------------|
| 1 | PlaceMask valida IE? | Resolvido | Criação | Não |
| 2 | Dígitos insuficientes por UF | Resolvido | Criação | Não |
| 3 | Namespace Extensions correto? | Resolvido | Criação | Não (já correto) |
| 4 | Dois tipos de erro (null vs exceção) | Resolvido | Criação | Não |
| 5 | RemoveMask específico IE? | Resolvido | Criação | Não |
| 6 | Roteamento por dicionário | Resolvido | Criação | Não |
| 7 | 28 UFs cobertas? | Resolvido | Criação | Não |
| 8 | Whitespace-only como vazio? | Resolvido | Criação | Não |

**Todos 8 itens: Resolvido. Nenhum Pendente bloqueante.**

---

## 6. Alinhamento com `constituicao.md`

| Princípio | Alinhamento | Evidência |
|-----------|-------------|-----------|
| SEC-06 (Dados sensíveis) | ✅ | IE sensível; não logar bruta |
| SEC-07 (ReDoS) | ✅ | 28 regex simples por UF |
| PERF-01/02 | ✅ | p95 < 1ms, O(1) lookup |
| QUAL-01 (Cobertura 100%) | ✅ | 27 testes estaduais + central |
| EXT-01 (Extensibilidade) | ✅ | Nova UF = entry no _mask + extension |
| ARCH-03 | ✅ | Sem logging próprio |

---

## Veredito Final

**STATUS: APROVADO** ✅

Todos 6 eixos validados. Cobertura completa de 28 UFs mapeada. Requisito pronto para fechamento.

---

## Histórico

| Data | Autor | Versão | Alteração |
|------|-------|--------|-----------|
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação |