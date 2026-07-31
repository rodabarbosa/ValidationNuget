---
type: risk
title: "Matriz de Risco Global — Sirb.Validation"
description: "Matriz de risco global com 19 riscos mapeados para o projeto Sirb.Validation."
resource: "./system-risk-matrix.md"
tags: [risco, matriz, seguranca]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "system-risk-matrix"
  title_pt: "Matriz de Risco Global"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "27/07/2026"
  language: pt-BR
---

# Matriz de Risco Global — Sirb.Validation

> **Arquivo de destino:** `docs/system-risk-matrix.md` (raiz de `/docs`).
> Matriz de risco global do sistema, atualizada a cada inclusão/alteração de requisito.

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** `system-risk-matrix`
- **Título:** Matriz de Risco Global — Sirb.Validation
- **Data de criação:** 27/07/2026
- **Última atualização:** 27/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão:** 1.0.0
- **Status:** Aprovado

## Legenda

- **Probabilidade (P):** 1 (Muito Baixa) a 5 (Muito Alta)
- **Impacto (I):** 1 (Muito Baixo) a 5 (Muito Alto)
- **Score:** P × I (produto)
- **Nível:** Baixo (1-4) | Médio (5-9) | Alto (10-16) | Crítico (17-25)

## Matriz Consolidada

| ID | Requisito | Descrição | P | I | Score | Nível | Mitigação | Status |
| -- | --------- | --------- | - | - | ----- | ----- | --------- | ------ |
| RSK-001 | req-0001 | Algoritmo de validação de CPF incorreto (falso positivo) | 2 | 5 | 10 | Alto | Testes exaustivos; benchmark em CI | Aberto |
| RSK-002 | req-0001 | Regex de máscara de CPF com erro de formatação | 1 | 3 | 3 | Baixo | Testes unitários | Aberto |
| RSK-003 | req-0001 | Performance degradada por alocação excessiva em CPF | 2 | 3 | 6 | Médio | BenchmarkDotNet com MemoryDiagnoser; gate > 10% | Aberto |
| RSK-004 | req-0002 | Algoritmo de validação de CNPJ incorreto | 2 | 5 | 10 | Alto | Testes exaustivos; benchmark em CI | Aberto |
| RSK-005 | req-0002 | Regex de máscara de CNPJ incorreta | 1 | 3 | 3 | Baixo | Testes unitários | Aberto |
| RSK-006 | req-0003 | Algoritmo de validação de PIS incorreto | 2 | 4 | 8 | Alto | Testes exaustivos | Aberto |
| RSK-007 | req-0003 | Regex de máscara de PIS incorreta | 1 | 3 | 3 | Baixo | Testes unitários | Aberto |
| RSK-008 | req-0004 | Algoritmo de validação de Título de Eleitor incorreto | 2 | 4 | 8 | Alto | Testes exaustivos | Aberto |
| RSK-009 | req-0004 | Validação de UF do Título com range errado | 1 | 3 | 3 | Baixo | Testes de limite | Aberto |
| RSK-010 | req-0005 | Algoritmo de validação de Renavam incorreto | 2 | 4 | 8 | Alto | Testes exaustivos | Aberto |
| RSK-011 | req-0005 | Normalização 9→11 dígitos do Renavam incorreta | 1 | 3 | 3 | Baixo | Testes com 9 e 11 dígitos | Aberto |
| RSK-012 | req-0006 | Algoritmo de IE de um estado específico incorreto | 3 | 5 | 15 | Crítico | Testes exaustivos por estado; doc oficial Sefaz | Aberto |
| RSK-013 | req-0006 | Máscara de IE de estado específico com formato errado | 2 | 3 | 6 | Médio | Testes de PlaceMask por estado | Aberto |
| RSK-014 | req-0006 | Exceção para estado não mapeado não tratada | 1 | 4 | 4 | Médio | StateNotFoundException lançada antes da validação | Aberto |
| RSK-015 | req-0007 | CPF gerado inválido (algoritmo divergente do de validação) | 2 | 4 | 8 | Alto | Reutiliza mesma CpfRule; teste pós-geração | Aberto |
| RSK-016 | req-0008 | CNPJ gerado inválido | 2 | 3 | 6 | Médio | Reutiliza mesma CnpjRule | Aberto |
| RSK-017 | req-0012 | Gerador de IE do AC com erro conhecido | 2 | 4 | 8 | Alto | Erro documentado; em avaliação | Aberto |
| RSK-018 | req-0013 | Regex catastrófica em OnlyNumbers | 1 | 3 | 3 | Baixo | Regex simples, sem backtracking | Aberto |
| RSK-019 | req-0013 | ToCapitalizeAll com cultura incorreta | 1 | 2 | 2 | Baixo | Usa CultureInfo.CurrentCulture | Aberto |

## Resumo

| Nível | Quantidade |
| ----- | ---------- |
| Crítico | 1 |
| Alto | 7 |
| Médio | 5 |
| Baixo | 6 |
| **Total** | **19** |

## Histórico de alterações

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 27/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação da matriz consolidada com 19 riscos de 13 requisitos |
