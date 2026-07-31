---
type: checklist
title: "Quality Checklist — req-0001"
description: "Checklist de qualidade do requisito req-0001 (CPF — Validação)."
resource: "./requirement/checklist/checklist-req-0001.md"
tags: [checklist, qualidade, revisao]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "checklist-req-0001"
  title_pt: "Quality Checklist — req-0001"
  version: "1.1.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "31/07/2026"
  language: pt-BR
---

# Quality Checklist — req-0001 (CPF — Validação)

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** `checklist-req-0001`
- **Requisito analisado:** `req-0001` / `tec-req-0001` — CPF — Validação
- **Data do checklist:** 27/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão deste documento:** 1.1.0
- **Status do checklist:** Concluído
- **Veredito final:** APROVADO

## Dimensões de Qualidade

### 1. Clareza

| # | Verificação | Resultado | Evidência/Seção | Ação corretiva |
| - | ----------- | --------- | --------------- | -------------- |
| 1.1 | Frases curtas, voz ativa | Pass | Todo o documento usa voz ativa | — |
| 1.2 | Ausência de jargão técnico no req | Pass | req-0001 em linguagem de negócio | — |
| 1.3 | Termos definidos no glossário | Pass | Escopo define o que é CPF, validação, normalização | — |
| 1.4 | Nenhum termo vago | Pass | Todos os cenários têm métricas e critérios | — |
| 1.5 | Título e H1 alinhados | Pass | Título "CPF — Validação" reflete conteúdo | — |

**Total da dimensão 1:** Pass 5 · Fail 0 · N/A 0

### 2. Completude

| # | Verificação | Resultado | Evidência/Seção | Ação corretiva |
| - | ----------- | --------- | --------------- | -------------- |
| 2.1 | Seção "Por quê" presente, específica, mensurável | Pass | Problema (retrabalho em integrações), impacto, público, critério p95 < 1ms | — |
| 2.2 | Escopo delimitado (in/out) | Pass | In: validação, estado emissor, normalização. Out: máscara (req-0014), consulta externa, situação cadastral | — |
| 2.3 | RFs e RNs numeradas, sem gaps | Pass | RF-001 a RF-004, RN-001 a RN-004, sem saltos | — |
| 2.4 | Gherkin com cenários negativos | Pass | 8 cenários incluindo CPF repetido, curto, nulo, vazio | — |
| 2.5 | NFRs mensuráveis | Pass | p95 < 1ms, > 100k/s, cobertura 100% | — |

**Total da dimensão 2:** Pass 5 · Fail 0 · N/A 0

### 3. Testabilidade

| # | Verificação | Resultado | Evidência/Seção | Ação corretiva |
| - | ----------- | --------- | --------------- | -------------- |
| 3.1 | Gherkin Given/When/Then completos | Pass | Todos os cenários têm Given/When/Then explícitos | — |
| 3.2 | Cenários negativos presentes | Pass | CPF inválido, repetido, curto, nulo, vazio | — |
| 3.3 | Dados de teste mencionados | Pass | Fixtures inline nos cenários Gherkin | — |
| 3.4 | Cobertura ≥ 80% prevista | Pass | Meta: 100% cobertura linha/branch | — |
| 3.5 | NFRs com métrica objetiva | Pass | p95 < 1ms, > 100k/s, verificado via BenchmarkDotNet | — |

**Total da dimensão 3:** Pass 5 · Fail 0 · N/A 0

### 4. Rastreabilidade

| # | Verificação | Resultado | Evidência/Seção | Ação corretiva |
| - | ----------- | --------- | --------------- | -------------- |
| 4.1 | Links funcionam | Pass | Todos os artefatos referenciados existem | — |
| 4.2 | Sem placeholders "TBD" | Pass | Nenhum placeholder órfão | — |
| 4.3 | XXXX consistente | Pass | Todos os artefatos usam 0001 | — |
| 4.4 | Versão referenciada | Pass | req-0001 v1.1.0, tec-req-0001 v1.1.0 | — |
| 4.5 | Artefatos relacionados bidirecional | Pass | Lista impactantes e impactados | — |

**Total da dimensão 4:** Pass 5 · Fail 0 · N/A 0

### 5. Conformidade com a Constituição

| # | Verificação | Resultado | Evidência/Seção | Ação corretiva |
| - | ----------- | --------- | --------------- | -------------- |
| 5.1 | Segurança | Pass | SEC-06 (dados sensíveis), SEC-07 (ReDoS) | — |
| 5.2 | Performance | Pass | PERF-01, PERF-02 atendidos | — |
| 5.3 | Qualidade de Código | Pass | QUAL-01 (100% cobertura) | — |
| 5.4 | UX e Acessibilidade | N/A | Sem interface de usuário | — |
| 5.5 | Dados e Privacidade | Pass | DATA-01, DATA-04 | — |
| 5.6 | Arquitetura | Pass | ARCH-01 (camadas) | — |
| 5.7 | Processo | Pass | PROC-01, PROC-02 | — |

**Total da dimensão 5:** Pass 6 · Fail 0 · N/A 1

### 6. Consistência Cross-Artifact

| # | Verificação | Resultado | Evidência/Seção | Ação corretiva |
| - | ----------- | --------- | --------------- | -------------- |
| 6.1 | Mesmo XXXX e versão | Pass | req e tec usam 0001 e v1.1.0 | — |
| 6.2 | RFs/RNs idênticas | Pass | RF-001 a RF-004, RN-001 a RN-004 idênticas | — |
| 6.3 | Entidades/endpoints no did/api | N/A | Sem dados persistentes | — |
| 6.4 | APF reflete requisito | Pass | 6 PF calculados sobre 2 funções públicas | — |
| 6.5 | Risco local bate com global | Pass | RSK-001/003 consistentes | — |

**Total da dimensão 6:** Pass 4 · Fail 0 · N/A 1

### 7. Acessibilidade

| # | Verificação | Resultado | Evidência/Seção | Ação corretiva |
| - | ----------- | --------- | --------------- | -------------- |
| 7.1 | WCAG | N/A | Biblioteca sem UI — isento | — |
| 7.2 | Alt text | N/A | Sem imagens | — |
| 7.3 | Navegação teclado | N/A | Sem interface | — |
| 7.4 | Foco visível | N/A | Sem interface | — |
| 7.5 | Wireframe coerente | N/A | Sem wireframe | — |

**Total da dimensão 7:** Pass 0 · Fail 0 · N/A 5

### 8. Manutenibilidade

| # | Verificação | Resultado | Evidência/Seção | Ação corretiva |
| - | ----------- | --------- | --------------- | -------------- |
| 8.1 | Versão SemVer | Pass | v1.1.0 consistente | — |
| 8.2 | Histórico atualizado | Pass | 2 entradas (criação + revisão de escopo) | — |
| 8.3 | Clarification sem pendentes bloqueantes | Pass | 0 pendentes que impactem aceite/escopo | — |
| 8.4 | Links funcionando | Pass | Referências válidas | — |
| 8.5 | Idioma pt-BR consistente | Pass | Todo o documento em pt-BR | — |

**Total da dimensão 8:** Pass 5 · Fail 0 · N/A 0

## Resultado do Checklist

| Dimensão | Pass | Fail | N/A | Observação |
| -------- | ---- | ---- | --- | ---------- |
| 1. Clareza | 5 | 0 | 0 | |
| 2. Completude | 5 | 0 | 0 | |
| 3. Testabilidade | 5 | 0 | 0 | |
| 4. Rastreabilidade | 5 | 0 | 0 | |
| 5. Conformidade | 6 | 0 | 1 | UX/Acessibilidade N/A (sem UI) |
| 6. Consistência | 4 | 0 | 1 | did/api N/A (stateless) |
| 7. Acessibilidade | 0 | 0 | 5 | Sem interface |
| 8. Manutenibilidade | 5 | 0 | 0 | |
| **TOTAL** | **35** | **0** | **7** | |

### Veredito final

- [x] **APROVADO** — todos Pass ou Pass/N/A. Requisito pode ser considerado fechado.
- [ ] **APROVADO COM RESSALVAS**
- [ ] **REPROVADO**

**Veredito aplicado:** APROVADO

## Sign-off

- **Agente que executou o checklist:** writer
- **Data:** 27/07/2026
- **Próximo passo:** Requisito fechado. Prosseguir para req-0002 (CNPJ).

## Histórico de alterações

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 27/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação do documento |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.1.0 | Checklist atualizado para o escopo de validação pura (remoção de máscara — req-0001 v1.1.0) |

## Clarification Log

| Data | Pergunta | Resposta | Status | Origem | Impacto |
| ---- | -------- | -------- | ------ | ------ | ------- |
| 27/07/2026 | Dimensão 7 inteira como N/A? | Sim. Biblioteca sem UI. Justificativa clara. | Resolvido | Criação | N/A para acessibilidade. |
