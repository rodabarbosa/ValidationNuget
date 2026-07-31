---
type: tec-req
title: "tec-req-0007 — Mockup CPF (Especificação Técnica)"
description: "Especificação técnica do gerador de CPF para testes, reutilizando o algoritmo CpfRule para garantir validade sintática."
resource: "./requirement/tec/tec-req-0007-mockup-cpf.md"
tags: [documento-brasileiro, especificacao-tecnica, geracao]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "tec-req-0007"
  title_pt: "Mockup CPF — Especificação Técnica"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "27/07/2026"
  language: pt-BR
---

# tec-req-0007 — Mockup CPF (Especificação Técnica)

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** `tec-req-0007`
- **Título:** Mockup CPF — Especificação Técnica
- **Data de criação:** 27/07/2026
- **Última atualização:** 27/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão:** 1.0.0
- **Status:** Aprovado
- **Requisito de negócio relacionado:** req-0007-mockup-cpf.md

## Detalhamento

### Classe

```csharp
// Sirb.Validation.Documents.BR.Mockups.Cpf
public static class Cpf
{
    public static string Generate(State? state = null);
}
```

### Algoritmo

1. Se state não informado, sorteia aleatoriamente entre 0 e 9
2. Gera 9 dígitos: 8 aleatórios + 1 do estado (9º dígito)
3. Calcula 1º DV: módulo 11 com pesos CpfRule.CalculateBeforeLastDigitWeight
4. Calcula 2º DV: módulo 11 com pesos CpfRule.CalculateLastDigitWeight + dígito 10 × 2
5. Concatena tudo com IntArrayExtension.ConvertToString

## Rastreabilidade: `Documents/BR/Mockups/Cpf.cs`

## Histórico: 27/07/2026, v1.0.0
