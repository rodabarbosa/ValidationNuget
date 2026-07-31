---
type: analise
title: "Análise Cross-Artifact — req-0019"
description: "Análise de consistência entre req-0019, tec-req-0019 e artefatos relacionados (CNPJ Alfanumérico)."
resource: "./requirement/analise/analise-req-0019.md"
tags: [analise, cross-artifact, consistencia, cnpj-alfanumerico]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-31"
status: rascunho
domain:
  artifact_id: "analise-req-0019"
  title_pt: "Análise Cross-Artifact — req-0019"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "31/07/2026"
  updated: "31/07/2026"
  language: pt-BR
---

# Análise Cross-Artifact — req-0019 (CNPJ Alfanumérico)

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** `analise-req-0019`
- **Requisito analisado:** `req-0019` / `tec-req-0019`
- **Data da análise:** 31/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão dos artefatos analisados:** req-0019 v1.0.0, tec-req-0019 v1.0.0
- **Versão deste documento:** 1.0.0
- **Status:** Rascunho

## Checklist

| # | Verificação | Resultado |
| - | ----------- | --------- |
| 1 | req ↔ tec: mesmo XXXX e versão | OK (0019, v1.0.0) |
| 2 | "Por quê" alinhado | OK |
| 3 | RFs/RNs consistentes | OK |
| 4 | did-* | N/A (sem banco) |
| 5 | api-* | N/A (extension methods) |
| 6 | DER | N/A |
| 7 | APF consistente | OK (3 PF) |
| 8 | Risco local ↔ global | OK |

## Alinhamento com Constituição

| Princípio | Atendido |
| --------- | -------- |
| Segurança | Sim |
| Performance | Sim |
| Qualidade | Sim |
| UX | N/A |
| Dados | Sim |
| Arquitetura | Sim |
| Processo | Sim |

## Detalhamento das Verificações

### 1. req ↔ tec: mesmo XXXX e versão
- req-0019 v1.0.0 ↔ tec-req-0019 v1.0.0 — **OK**

### 2. "Por quê" alinhado
- req-0019 §Intenção/Motivação: problema real de negócio (emissão CNPJ alfanumérico a partir de jul/2026), público afetado, critério de sucesso
- tec-req-0019 §1: resumo técnico correspondente — **OK**

### 3. RFs/RNs consistentes
| RF/RN | req-0019 | tec-req-0019 | Status |
| ----- | -------- | ------------ | ------ |
| RF-001 | Validar CNPJ Alfanumérico módulo 11 ASCII-48 | Validar CNPJ Alfanumérico módulo 11 ASCII-48 | OK |
| RF-002 | Rejeitar sequências repetidas | Rejeitar sequências repetidas | OK |
| RF-003 | Nulas/vazias → false | Nulas/vazias → false | OK |
| RF-004 | Retrocompatibilidade numérico | Retrocompatibilidade numérico | OK |
| RF-005 | Normalização OnlyNumbers | Normalização OnlyNumbers | OK |
| RN-001 | Estrutura 14 chars, pesos | Estrutura 14 chars, pesos | OK |
| RN-002 | Conversão ASCII-48, módulo 11 | Conversão ASCII-48, módulo 11 | OK |
| RN-003 | Sequências repetidas/nulas | Sequências repetidas/nulas | OK |
| RN-004 | Retrocompatibilidade | Retrocompatibilidade | OK |
| RN-005 | Normalização pontuação | Normalização pontuação | OK |

### 4. did-* (Data Dictionary)
- N/A — biblioteca stateless sem persistência — **OK (isentos)**

### 5. api-* (API Documentation)
- N/A — interface via extension methods sobre `string` — **OK (isentos)**

### 6. DER (Diagrama Entidade-Relacionamento)
- N/A — sem banco de dados — **OK (isentos)**

### 7. APF consistente
- apf-req-0019: 1 EE Baixa = 3 PF
- req-0019 RFs: 5 RFs mapeados para 1 função de entrada — **OK**

### 8. Risco local ↔ global
- req-0019 matriz local: RSK-019 (Algoritmo incorreto, Alto), RSK-020 (Quebra retrocompatibilidade, Alto), RSK-021 (Performance, Médio)
- system-risk-matrix.md deve conter riscos correspondentes — **OK (pendente atualização global)**

## Pendentes: 1

| ID | Item | Origem | Ação |
| -- | ---- | ------ | ---- |
| ⏳ PENDENTE [Fase 3 — Design] | Atualizar `system-risk-matrix.md` com RSK-019, RSK-020, RSK-021 | Convergência | Incluir na matriz global na próxima iteração |

## Resultado

- [ ] **APROVADO**
- [x] **APROVADO COM RESSALVAS** — 1 pendente (atualização matriz global de risco)

## Histórico

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação do documento |