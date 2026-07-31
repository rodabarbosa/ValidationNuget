---
type: risk
title: "Matriz de Risco Global — Sirb.Validation"
description: "Matriz de risco global com 32 riscos mapeados para o projeto Sirb.Validation."
resource: "./system-risk-matrix.md"
tags: [risco, matriz, seguranca]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-31"
status: approved
domain:
  artifact_id: "system-risk-matrix"
  title_pt: "Matriz de Risco Global"
  version: "1.4.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "31/07/2026"
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
- **Última atualização:** 31/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão:** 1.2.0
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
| RSK-003 | req-0001 | Performance degradada por alocação excessiva em CPF | 2 | 3 | 6 | Médio | BenchmarkDotNet com MemoryDiagnoser; gate > 10% | Aberto |
| RSK-004 | req-0002 | Algoritmo de validação de CNPJ incorreto | 2 | 5 | 10 | Alto | Testes exaustivos; benchmark em CI | Aberto |
| RSK-006 | req-0003 | Algoritmo de validação de PIS incorreto | 2 | 4 | 8 | Médio | Testes exaustivos | Aberto |
| RSK-008 | req-0004 | Algoritmo de validação de Título de Eleitor incorreto | 2 | 4 | 8 | Médio | Testes exaustivos | Aberto |
| RSK-009 | req-0004 | Validação de UF do Título com range errado | 1 | 3 | 3 | Baixo | Testes de limite | Aberto |
| RSK-010 | req-0005 | Algoritmo de validação de Renavam incorreto | 2 | 4 | 8 | Médio | Testes exaustivos | Aberto |
| RSK-011 | req-0005 | Normalização 9→11 dígitos do Renavam incorreta | 1 | 3 | 3 | Baixo | Testes com 9 e 11 dígitos | Aberto |
| RSK-012 | req-0006 | Algoritmo de IE de um estado específico incorreto | 3 | 5 | 15 | Alto | Testes exaustivos por estado; doc oficial Sefaz | Aberto |
| RSK-014 | req-0006 | Exceção para estado não mapeado não tratada | 1 | 4 | 4 | Baixo | StateNotFoundException lançada antes da validação | Aberto |
| RSK-015 | req-0007 | CPF gerado inválido (algoritmo divergente do de validação) | 2 | 4 | 8 | Médio | Reutiliza mesma CpfRule; teste pós-geração | Aberto |
| RSK-016 | req-0008 | CNPJ gerado inválido | 2 | 3 | 6 | Médio | Reutiliza mesma CnpjRule | Aberto |
| RSK-017 | req-0012 | Gerador de IE do AC com erro conhecido | 2 | 4 | 8 | Médio | Erro documentado; em avaliação | Aberto |
| RSK-018 | req-0013 | Regex catastrófica em OnlyNumbers | 1 | 3 | 3 | Baixo | Regex simples, sem backtracking | Aberto |
| RSK-019 | req-0013 | ToCapitalizeAll com cultura incorreta | 1 | 2 | 2 | Baixo | Usa CultureInfo.CurrentCulture | Aberto |
| RSK-020 | req-0014 | Regex de máscara de CPF com erro de formatação | 1 | 3 | 3 | Baixo | Testes unitários para PlaceMask com vários formatos | Aberto |
| RSK-021 | req-0014 | Performance degradada por alocação excessiva em PlaceMask CPF | 2 | 3 | 6 | Médio | BenchmarkDotNet com MemoryDiagnoser; gate regressão > 10% | Aberto |
| RSK-022 | req-0015 | Regex de máscara de CNPJ com erro de formatação | 1 | 3 | 3 | Baixo | Testes unitários para PlaceMask com vários formatos | Aberto |
| RSK-023 | req-0015 | Performance degradada por alocação excessiva em PlaceMask CNPJ | 2 | 3 | 6 | Médio | BenchmarkDotNet com MemoryDiagnoser; gate regressão > 10% | Aberto |
| RSK-024 | req-0016 | Regex de máscara de PIS com erro de formatação | 1 | 3 | 3 | Baixo | Testes unitários para PlaceMask com vários formatos | Aberto |
| RSK-025 | req-0016 | Performance degradada por alocação excessiva em PlaceMask PIS | 2 | 3 | 6 | Médio | BenchmarkDotNet com MemoryDiagnoser; gate regressão > 10% | Aberto |
| RSK-026 | req-0017 | Regex de máscara de Título de Eleitor com erro de formatação | 1 | 3 | 3 | Baixo | Testes unitários para PlaceMask com vários formatos | Aberto |
| RSK-027 | req-0017 | Performance degradada por alocação excessiva em PlaceMask Título | 2 | 3 | 6 | Médio | BenchmarkDotNet com MemoryDiagnoser; gate regressão > 10% | Aberto |
| RSK-028 | req-0018 | Máscara de IE de estado específico com formato errado | 2 | 5 | 10 | Alto | Testes de PlaceMask por estado; consulta doc oficial Sefaz | Aberto |
| RSK-029 | req-0018 | Exceção StateNotFoundException para UF não mapeada | 1 | 4 | 4 | Baixo | StateNotFoundException lançada antes da formatação; teste UF inválida | Aberto |
| RSK-030 | req-0018 | Performance degradada por dicionário de 28 funções de máscara | 1 | 3 | 3 | Baixo | BenchmarkDotNet; dicionário estático O(1) lookup | Aberto |
| RSK-031 | req-0019 | Algoritmo de validação de CNPJ Alfanumérico incorreto (ASCII-48) | 2 | 5 | 10 | Alto | Testes exaustivos com massa alfanumérica; benchmark em CI; casos de borda ASCII | Aberto |
| RSK-032 | req-0019 | Quebra de retrocompatibilidade com CNPJ numérico legado | 2 | 5 | 10 | Alto | Testes de regressão abrangentes cobrindo formato numérico | Aberto |
| RSK-033 | req-0019 | Performance degradada por conversão ASCII por caractere | 2 | 3 | 6 | Médio | BenchmarkDotNet com MemoryDiagnoser; gate de regressão > 10% | Aberto |
| RSK-034 | req-0020 | CNPJ Alfanumérico gerado inválido (algoritmo de geração divergente do de validação) | 2 | 4 | 8 | Médio | Reutiliza mesma CnpjAlfanumericoRule; teste pós-geração com IsValid | Aberto |
| RSK-035 | req-0021 | Regex de máscara de CNPJ Alfanumérico com erro de formatação | 1 | 3 | 3 | Baixo | Testes unitários para PlaceMask com vários formatos de entrada alfanumérica | Aberto |
| RSK-036 | req-0021 | Performance degradada por alocação excessiva em PlaceMask CNPJ Alfanumérico | 2 | 3 | 6 | Médio | BenchmarkDotNet com MemoryDiagnoser; gate de regressão > 10% | Aberto |

## Resumo

| Nível | Quantidade |
| ----- | ---------- |
| Crítico | 0 |
| Alto | 6 |
| Médio | 14 |
| Baixo | 12 |
| **Total** | **32** |

## Histórico de alterações

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 27/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação da matriz consolidada com 19 riscos de 13 requisitos |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.1.0 | Adicionados 11 novos riscos (RSK-020 a RSK-030) dos requisitos req-0014 a req-0018 (máscaras) |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.2.0 | Remoção de máscara de req-0001..0006: RSK-002/005/007/013 removidos (cobertos por RSK-020/022/024/028 nos req-0014..0018); total 30→26 riscos; descrição do frontmatter corrigida (24→26); classificação de nível realinhada à legenda (Crítico 1→0, Alto 8→4, Médio 10→11, Baixo 7→11) |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.3.0 | Adicionados 3 novos riscos (RSK-031 a RSK-033) do requisito req-0019 (CNPJ Alfanumérico); total 26→29 riscos; Alto 4→6, Médio 11→12 |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.4.0 | Adicionados 3 novos riscos: RSK-034 (req-0020 Mockup CNPJ Alfanumérico), RSK-035/036 (req-0021 CNPJ Alfanumérico Máscara); total 29→32 riscos; Médio 12→14, Baixo 11→12 |