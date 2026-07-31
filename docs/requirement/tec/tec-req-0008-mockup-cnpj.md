---
type: tec-req
title: "tec-req-0008 — Mockup CNPJ (Especificação Técnica)"
description: "Especificação técnica do gerador de CNPJ para testes, reutilizando o algoritmo CnpjRule para garantir validade sintática."
resource: "./requirement/tec/tec-req-0008-mockup-cnpj.md"
tags: [documento-brasileiro, especificacao-tecnica, geracao]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "tec-req-0008"
  title_pt: "Mockup CNPJ — Especificação Técnica"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "27/07/2026"
  language: pt-BR
---

# tec-req-0008 — Mockup CNPJ (Especificação Técnica)

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** `tec-req-0008`
- **Título:** Mockup CNPJ — Especificação Técnica
- **Data de criação:** 27/07/2026
- **Última atualização:** 27/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão:** 1.0.0
- **Status:** Aprovado
- **Requisito de negócio relacionado:** `req-0008-mockup-cnpj.md` (v1.0.0)

## Classe

```csharp
public static class Cnpj
{
    public static string Generate();
}
```

### Algoritmo

1. Gera 12 dígitos aleatórios
2. Calcula 1º DV: CnpjRule.CalculateDigitValue(totalBeforeLastDigit)
3. Calcula 2º DV: CnpjRule.CalculateDigitValue(totalLastDigit + último × 2)
4. Concatena

## Rastreabilidade: `Documents/BR/Mockups/Cnpj.cs`

## Histórico: 27/07/2026, v1.0.0
