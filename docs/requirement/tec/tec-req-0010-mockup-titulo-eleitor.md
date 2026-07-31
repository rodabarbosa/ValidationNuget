---
type: tec-req
title: "tec-req-0010 — Mockup Título de Eleitor (Especificação Técnica)"
description: "Especificação técnica do gerador de Título de Eleitor para testes, garantindo validade sintática."
resource: "./requirement/tec/tec-req-0010-mockup-titulo-eleitor.md"
tags: [documento-brasileiro, especificacao-tecnica, geracao]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "tec-req-0010"
  title_pt: "Mockup Título de Eleitor — Especificação Técnica"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "27/07/2026"
  language: pt-BR
---

# tec-req-0010 — Mockup Título de Eleitor (Especificação Técnica)

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** `tec-req-0010`
- **Título:** Mockup Título de Eleitor — Especificação Técnica
- **Data de criação:** 27/07/2026
- **Última atualização:** 27/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão:** 1.0.0
- **Status:** Aprovado
- **Requisito de negócio relacionado:** `req-0010-mockup-titulo-eleitor.md` (v1.0.0)

## Classe

```csharp
public static class TituloEleitor
{
    public static string Generate();
}
```

### Algoritmo

1. Gera 8 dígitos aleatórios
2. Soma pesos 2..9 → 1º DV
3. Gera UF (09-10): aleatório entre 01 e 28
4. Soma dígitos 9×7 + 10×8 + 11×9 → 2º DV
5. Concatena 12 dígitos

## Rastreabilidade: `Documents/BR/Mockups/TituloEleitor.cs`

## Histórico: 27/07/2026, v1.0.0
