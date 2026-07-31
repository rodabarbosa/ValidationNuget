---
type: tec-req
title: "tec-req-0020 — Mockup CNPJ Alfanumérico (Especificação Técnica)"
description: "Especificação técnica do gerador de CNPJ Alfanumérico para testes, reutilizando o algoritmo CnpjAlfanumericoRule para garantir validade sintática (ASCII-48 + Módulo 11)."
resource: "./requirement/tec/tec-req-0020-mockup-cnpj-alfanumerico.md"
tags: [documento-brasileiro, especificacao-tecnica, geracao, cnpj-alfanumerico]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-31"
status: rascunho
domain:
  artifact_id: "tec-req-0020"
  title_pt: "Mockup CNPJ Alfanumérico — Especificação Técnica"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "31/07/2026"
  updated: "31/07/2026"
  language: pt-BR
---

# tec-req-0020 — Mockup CNPJ Alfanumérico (Especificação Técnica)

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** `tec-req-0020`
- **Título:** Mockup CNPJ Alfanumérico — Especificação Técnica
- **Data de criação:** 31/07/2026
- **Última atualização:** 31/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão:** 1.0.0
- **Status:** Rascunho
- **Requisito de negócio relacionado:** req-0020-mockup-cnpj-alfanumerico.md

## Detalhamento

### Classe

```csharp
// Sirb.Validation.Documents.BR.Mockups.CnpjAlfanumerico
public static class CnpjAlfanumerico
{
    public static string Generate();
    public static string GenerateWithMask();
}
```

### Algoritmo

1. Define conjunto de caracteres alfanuméricos: `0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ` (36 caracteres)
2. Gera 12 caracteres aleatórios do conjunto acima
3. Converte cada caractere para seu valor numérico via `CnpjAlfanumericoRule.CharToAsciiValue(char c)` (ASCII - 48):
   - Dígitos '0'-'9' (ASCII 48-57) → 0-9
   - Letras 'A'-'Z' (ASCII 65-90) → 17-42
4. Calcula 1º DV (13ª posição): módulo 11 com pesos `CnpjAlfanumericoRule.CalculateBeforeLastDigitWeight(i)` para i=0..11
5. Calcula 2º DV (14ª posição): módulo 11 com pesos `CnpjAlfanumericoRule.CalculateLastDigitWeight(i)` para i=0..12 (inclui 1º DV com peso 2)
6. Converte array de 14 valores inteiros para string alfanumérica via `IntArrayExtensions.ConvertToString`:
   - Valores 0-9 → '0'-'9'
   - Valores 17-42 → 'A'-'Z' (valor + 48)
7. `GenerateWithMask()` chama `Generate()` e aplica `PlaceCnpjAlfanumericoMask()` (extension method do req-0021)

## Rastreabilidade

- `Documents/BR/Mockups/CnpjAlfanumerico.cs`
- `Documents/BR/Rules/CnpjAlfanumericoRule.cs` (pesos e cálculo de DV)
- `Extensions/CnpjAlfanumericoExtension.cs` (PlaceCnpjAlfanumericoMask)

## Histórico

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação |