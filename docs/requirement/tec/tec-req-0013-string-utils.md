---
type: tec-req
title: "tec-req-0013 — String Utils (Especificação Técnica)"
description: "Especificação técnica dos utilitários de string: OnlyNumbers, RemoveMask, NoNumbers, ToCapitalize, RemoveLatinCharacters, Reverse."
resource: "./requirement/tec/tec-req-0013-string-utils.md"
tags: [utilitarios, string, especificacao-tecnica]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "tec-req-0013"
  title_pt: "String Utils — Especificação Técnica"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "27/07/2026"
  language: pt-BR
---

# tec-req-0013 — String Utils (Especificação Técnica)

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** tec-req-0013 | **Versão:** 1.0.0 | **Status:** Aprovado
- **Req relacionado:** req-0013-string-utils.md

## Detalhamento

### Classe

```csharp
// Sirb.Validation.Extensions.StringExtension
public static class StringExtension
{
    public static string OnlyNumbers(this string value);         // Regex [^\d]
    public static string RemoveMask(this string value);          // OnlyNumbers
    public static string NoNumbers(this string value);           // Regex [\d]
    public static string ToCapitalizeAll(this string value);     // CultureInfo.TextInfo.ToTitleCase
    public static string ToCapitalize(this string value);        // 1ª maiúscula, resto minúsculo
    public static string RemoveLatinCharacters(this string value); // Normalization FormD
    public static string Reverse(this string value);             // Array.Reverse
}
```

### Comportamentos

| Método | Entrada | Saída | Observação |
| ------ | ------- | ----- | ---------- |
| OnlyNumbers | "abc123" | "123" | Remove não-dígitos |
| RemoveMask | "123.456-78" | "12345678" | Alias OnlyNumbers |
| NoNumbers | "abc123" | "abc" | Remove dígitos |
| ToCapitalizeAll | "olá mundo" | "Olá Mundo" | CultureInfo.CurrentCulture |
| ToCapitalize | "olá mundo" | "Olá mundo" | Só primeira palavra |
| RemoveLatinCharacters | "café" | "cafe" | FormD + NonSpacingMark |
| Reverse | "abc" | "cba" | Array.Reverse |

## Rastreabilidade: `Extensions/StringExtension.cs`

## Histórico: 27/07/2026, v1.0.0
