---
type: tec-req
title: "tec-req-0012 — Mockup Inscrição Estadual (Especificação Técnica)"
description: "Especificação técnica do gerador de Inscrição Estadual para todas as UFs, com arquitetura por estado e reutilização dos validadores."
resource: "./requirement/tec/tec-req-0012-mockup-inscricao-estadual.md"
tags: [documento-brasileiro, especificacao-tecnica, geracao, inscricao-estadual]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "tec-req-0012"
  title_pt: "Mockup Inscrição Estadual — Especificação Técnica"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "27/07/2026"
  language: pt-BR
---

# tec-req-0012 — Mockup Inscrição Estadual (Especificação Técnica)

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** `tec-req-0012`
- **Título:** Mockup Inscrição Estadual — Especificação Técnica
- **Data de criação:** 27/07/2026
- **Última atualização:** 27/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão:** 1.0.0
- **Status:** Aprovado
- **Requisito de negócio relacionado:** `req-0012-mockup-inscricao-estadual.md` (v1.0.0)

## Classe

```csharp
public static class InscricaoEstadual
{
    public static string Generate(State state);
}
```

### Arquitetura

- Dicionário `_generator: Dictionary<State, IInscricaoEstadualInternal>`
- 27 implementações do gerador em `Documents/BR/Mockups/Ie/`
- Interface: `Generate() → string`

## Rastreabilidade

- `Documents/BR/Mockups/InscricaoEstadual.cs`
- `Documents/BR/Mockups/Ie/` (27 classes)

## Erro conhecido: Gerador do AC com problema em avaliação (comentário no código-fonte).

## Histórico: 27/07/2026, v1.0.0
