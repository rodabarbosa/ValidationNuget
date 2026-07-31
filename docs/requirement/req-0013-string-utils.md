---
type: req
title: "req-0013 — String Utils — Utilitários de String"
description: "Utilitários de string para aplicações .NET: OnlyNumbers, RemoveMask, NoNumbers, ToCapitalize, RemoveLatinCharacters, Reverse e outros."
resource: "./requirement/req-0013-string-utils.md"
tags: [utilitarios, string, mascara]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "req-0013"
  title_pt: "String Utils — Utilitários de String"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "27/07/2026"
  language: pt-BR
---

# req-0013 — String Utils — Utilitários de String

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** `req-0013`
- **Título:** String Utils — Utilitários de String
- **Data de criação:** 27/07/2026
- **Última atualização:** 27/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão:** 1.0.0
- **Status:** Aprovado

## Intenção

- **Problema:** Aplicações frequentemente precisam manipular strings: extrair apenas números, capitalizar nomes, remover acentos, reverter strings. Ter esses utilitários na mesma biblioteca de validação evita dependências adicionais.
- **Impacto:** Produtividade do desenvolvedor, consistência nas transformações de string em todo o ecossistema da aplicação.
- **Público:** Desenvolvedores .NET.
- **Critério de sucesso:** Métodos executam em < 0,1 ms, 100% de cobertura.

## Requisitos funcionais

| ID | Descrição | Prioridade |
| -- | --------- | ---------- |
| RF-001 | Extrair apenas números de uma string (OnlyNumbers) | Média |
| RF-002 | Remover máscara genérica (alias para OnlyNumbers) | Média |
| RF-003 | Remover números de uma string (NoNumbers) | Média |
| RF-004 | Capitalizar todas as palavras (ToCapitalizeAll) | Média |
| RF-005 | Capitalizar apenas a primeira letra (ToCapitalize) | Média |
| RF-006 | Remover caracteres latinos acentuados (RemoveLatinCharacters) | Média |
| RF-007 | Reverter string (Reverse) | Média |

## Regras de negócio

| ID | Regra |
| -- | ----- |
| RN-001 | OnlyNumbers usa regex `[^\d]` para remover tudo que não é dígito. |
| RN-002 | RemoveMask delega para OnlyNumbers. |
| RN-003 | NoNumbers usa regex `[\d]` para remover dígitos. |
| RN-004 | ToCapitalizeAll usa `CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower())`. |
| RN-005 | ToCapitalize: primeira letra maiúscula, resto minúsculo. |
| RN-006 | RemoveLatinCharacters usa NormalizationForm.FormD para decomposição, remove NonSpacingMark. |
| RN-007 | Reverse usa Array.Reverse em ToCharArray. |

## Critérios de aceitação

```gherkin
Funcionalidade: String Utils
  Cenário: OnlyNumbers
    Dado "abc123" → OnlyNumbers() → "123"
  Cenário: RemoveMask
    Dado "123.456-78" → RemoveMask() → "12345678"
  Cenário: NoNumbers
    Dado "abc123" → NoNumbers() → "abc"
  Cenário: ToCapitalizeAll
    Dado "olá mundo" → ToCapitalizeAll() → "Olá Mundo"
  Cenário: ToCapitalize
    Dado "olá mundo" → ToCapitalize() → "Olá mundo"
  Cenário: RemoveLatinCharacters
    Dado "café" → RemoveLatinCharacters() → "cafe"
  Cenário: Reverse
    Dado "abc" → Reverse() → "cba"
```

## NFRs

| Categoria | Métrica |
| --------- | ------- |
| Desempenho | < 0,1 ms por operação |
| Cobertura | 100% |

## Risco local

| ID | Risco | P | I | Score | Nível |
| -- | ----- | - | - | ----- | ----- |
| RSK-018 | Regex catastrófica em OnlyNumbers | 1 | 3 | 3 | Baixo |
| RSK-019 | ToCapitalizeAll com cultura incorreta | 1 | 2 | 2 | Baixo |

## Rastreabilidade

- `Extensions/StringExtension.cs` — todos os métodos

## Histórico

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 27/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação |

## Clarification Log (8/8) — OK
