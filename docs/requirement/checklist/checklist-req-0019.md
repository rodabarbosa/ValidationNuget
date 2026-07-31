---
type: checklist
title: "Quality Checklist — req-0019"
description: "Checklist de qualidade do requisito req-0019 (CNPJ Alfanumérico — Validação)."
resource: "./requirement/checklist/checklist-req-0019.md"
tags: [checklist, qualidade, revisao, cnpj-alfanumerico]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-31"
status: rascunho
domain:
  artifact_id: "checklist-req-0019"
  title_pt: "Quality Checklist — req-0019"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "31/07/2026"
  updated: "31/07/2026"
  language: pt-BR
---

# Quality Checklist — req-0019 (CNPJ Alfanumérico)

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** `checklist-req-0019`
- **Requisito analisado:** `req-0019` / `tec-req-0019` — CNPJ Alfanumérico — Validação
- **Data do checklist:** 31/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão deste documento:** 1.0.0
- **Status do checklist:** Em andamento
- **Veredito final:** Pendente

## Dimensões

| Dimensão | Pass | Fail | N/A |
| -------- | ---- | ---- | --- |
| 1. Clareza | 5 | 0 | 0 |
| 2. Completude | 5 | 0 | 0 |
| 3. Testabilidade | 5 | 0 | 0 |
| 4. Rastreabilidade | 5 | 0 | 0 |
| 5. Conformidade | 6 | 0 | 1 |
| 6. Consistência | 4 | 0 | 1 |
| 7. Acessibilidade | 0 | 0 | 5 |
| 8. Manutenibilidade | 5 | 0 | 0 |
| **TOTAL** | **35** | **0** | **7** |

## Detalhamento por Dimensão

### 1. Clareza (5/5)

| Item | Critério | Resultado |
| ---- | -------- | --------- |
| 1.1 | Objetivo claro e inequívoco | ✅ |
| 1.2 | Escopo (in/out) bem delimitado | ✅ |
| 1.3 | Linguagem acessível ao público-alvo (devs .NET) | ✅ |
| 1.4 | Glossário/implícitos definidos (ASCII-48, DV, RFB) | ✅ |
| 1.5 | Diagramas/fluxos compreensíveis | ✅ |

### 2. Completude (5/5)

| Item | Critério | Resultado |
| ---- | -------- | --------- |
| 2.1 | Todos os RFs identificados (RF-001 a RF-005) | ✅ |
| 2.2 | Todas as RNs documentadas (RN-001 a RN-005) | ✅ |
| 2.3 | Critérios de aceitação cobrem happy path + edge cases + retrocompatibilidade | ✅ |
| 2.4 | NFRs mensuráveis (latência, throughput, cobertura) | ✅ |
| 2.5 | Matriz de risco local presente | ✅ |

### 3. Testabilidade (5/5)

| Item | Critério | Resultado |
| ---- | -------- | --------- |
| 3.1 | Cenários Gherkin executáveis (8 cenários) | ✅ |
| 3.2 | Dados de teste explícitos (valores de entrada/esperado) | ✅ |
| 3.3 | Casos negativos cobertos (inválido, repetido, nulo, tamanho) | ✅ |
| 3.4 | Retrocompatibilidade testável (CNPJ numérico) | ✅ |
| 3.5 | NFRs verificáveis via benchmark (p95, throughput) | ✅ |

### 4. Rastreabilidade (5/5)

| Item | Critério | Resultado |
| ---- | -------- | --------- |
| 4.1 | req ↔ tec mesmo código/versão | ✅ |
| 4.2 | RFs ↔ RNs mapeados 1:1 | ✅ |
| 4.3 | Código-fonte referenciado (classes, methods) | ✅ |
| 4.4 | Artefatos relacionados listados (impactantes/impactados) | ✅ |
| 4.5 | APF vinculado e consistente | ✅ |

### 5. Conformidade (6/6, 1 N/A)

| Item | Critério | Resultado |
| ---- | -------- | --------- |
| 5.1 | Constituição: Segurança (SEC-06, SEC-07) | ✅ |
| 5.2 | Constituição: Performance (PERF-01) | ✅ |
| 5.3 | Constituição: Qualidade (cobertura 100%) | ✅ |
| 5.4 | Constituição: Dados (LGPD, sensibilidade) | ✅ |
| 5.5 | Constituição: Arquitetura (stateless, multi-target) | ✅ |
| 5.6 | Constituição: Processo (OKF v0.2, frontmatter) | ✅ |
| 5.7 | UX (interface) | N/A |

### 6. Consistência (4/4, 1 N/A)

| Item | Critério | Resultado |
| ---- | -------- | --------- |
| 6.1 | Terminologia unificada (ASCII-48, DV, RFB, IN 2.229/2024) | ✅ |
| 6.2 | Padrão de nomes (IsCnpjAlfanumericoValid, PlaceCnpjAlfanumericoMask) | ✅ |
| 6.3 | Estrutura de docs igual a req-0001/0002/0015 | ✅ |
| 6.4 | Matriz risco níveis (Baixo/Médio/Alto/Crítico) coerentes | ✅ |
| 6.5 | DER/Diagrama dados | N/A |

### 7. Acessibilidade (0/0, 5 N/A)

| Item | Critério | Resultado |
| ---- | -------- | --------- |
| 7.1 | Contraste/legibilidade | N/A |
| 7.2 | Navegação teclado | N/A |
| 7.3 | Leitores de tela | N/A |
| 7.4 | Idioma/locale | N/A |
| 7.5 | Documentação alternativa | N/A |

*Isentos: biblioteca sem interface de usuário*

### 8. Manutenibilidade (5/5)

| Item | Critério | Resultado |
| ---- | -------- | --------- |
| 8.1 | Versionamento semântico (v1.0.0) | ✅ |
| 8.2 | Histórico de alterações preenchido | ✅ |
| 8.3 | Clarification Log com 8 áreas cobertas | ✅ |
| 8.4 | Separação clara validação vs máscara | ✅ |
| 8.5 | Extensibilidade (novos formatos) considerada | ✅ |

## Observações

- **Pontos fortes:** Estrutura completa seguindo padrão OKF v0.2; retrocompatibilidade explicitada; algoritmo ASCII-48 documentado com tabela de referência; 8 cenários Gherkin cobrindo happy path, edge cases e regressão.
- **Risco identificado:** Conversão ASCII por caractere pode impactar performance vs `int.Parse` do CNPJ numérico — mitigado por benchmark gate.
- **Pendente:** Atualização da `system-risk-matrix.md` global com RSK-019, RSK-020, RSK-021 (marcado em analise-req-0019).

## Veredito

- [ ] **APROVADO**
- [x] **APROVADO COM RESSALVAS** — 1 item pendente (matriz global de risco)
- [ ] **REPROVADO**

## Histórico

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação do checklist |