---
type: tec-req
title: "tec-req-0011 — Mockup Renavam (Especificação Técnica)"
description: "Especificação técnica do gerador de Renavam para testes, garantindo validade sintática."
resource: "./requirement/tec/tec-req-0011-mockup-renavam.md"
tags: [documento-brasileiro, especificacao-tecnica, geracao]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "tec-req-0011"
  title_pt: "Mockup Renavam — Especificação Técnica"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "27/07/2026"
  language: pt-BR
---

# tec-req-0011 — Mockup Renavam (Especificação Técnica)

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** `tec-req-0011`
- **Título:** Mockup Renavam — Especificação Técnica
- **Data de criação:** 27/07/2026
- **Última atualização:** 27/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão:** 1.0.0
- **Status:** Aprovado
- **Requisito de negócio relacionado:** `req-0011-mockup-renavam.md` (v1.0.0)

## Classe

```csharp
public static class Renavam
{
    public static string Generate();
}
```

### Algoritmo

1. Gera 10 dígitos aleatórios (0-8)
2. Reverte lista
3. Soma via RenavanRules.GetSummationValue
4. DV = RenavanRules.CalculateastDigit(total)
5. Concatena 10 dígitos + DV = 11 dígitos

## Rastreabilidade: `Documents/BR/Mockups/Renavam.cs`

## Histórico: 27/07/2026, v1.0.0
