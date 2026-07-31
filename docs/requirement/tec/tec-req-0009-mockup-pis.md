---
type: tec-req
title: "tec-req-0009 — Mockup PIS (Especificação Técnica)"
description: "Especificação técnica do gerador de PIS para testes, reutilizando o algoritmo PisRule para garantir validade sintática."
resource: "./requirement/tec/tec-req-0009-mockup-pis.md"
tags: [documento-brasileiro, especificacao-tecnica, geracao]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "tec-req-0009"
  title_pt: "Mockup PIS — Especificação Técnica"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "27/07/2026"
  language: pt-BR
---

# tec-req-0009 — Mockup PIS (Especificação Técnica)

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** `tec-req-0009`
- **Título:** Mockup PIS — Especificação Técnica
- **Data de criação:** 27/07/2026
- **Última atualização:** 27/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão:** 1.0.0
- **Status:** Aprovado
- **Requisito de negócio relacionado:** `req-0009-mockup-pis.md` (v1.0.0)

## Classe

```csharp
public static class Pis
{
    public static string Generate();
}
```

### Algoritmo

1. Gera 10 dígitos aleatórios
2. Soma += dígito * PisRule.CalculateWeight(i)
3. DV = PisRule.CalculateLastDigit(total)
4. Concatena 10 dígitos + DV

## Rastreabilidade: `Documents/BR/Mockups/Pis.cs`

## Histórico: 27/07/2026, v1.0.0
