---
type: tec-req
title: "tec-req-0006 — Inscrição Estadual — Validação (Especificação Técnica)"
description: "Especificação técnica da validação de Inscrição Estadual para todas as 27 UFs + DF, com roteamento por estado. Formatação (máscara) por UF é tratada no tec-req-0018."
resource: "./requirement/tec/tec-req-0006-inscricao-estadual-validacao.md"
tags: [documento-brasileiro, especificacao-tecnica, inscricao-estadual]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "tec-req-0006"
  title_pt: "Inscrição Estadual — Validação — Especificação Técnica"
  version: "1.1.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "31/07/2026"
  language: pt-BR
---

# tec-req-0006 — Inscrição Estadual — Validação (Especificação Técnica)

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** `tec-req-0006`
- **Título:** Inscrição Estadual — Validação — Especificação Técnica
- **Data de criação:** 27/07/2026
- **Última atualização:** 31/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão:** 1.1.0
- **Status:** Aprovado
- **Requisito de negócio relacionado:** req-0006-inscricao-estadual-validacao.md

## 1. Resumo

Validar Inscrição Estadual de qualquer UF utilizando algoritmo específico por estado, com roteamento via enum `State`. Formatação (máscara) por estado é coberta pelo `tec-req-0018`.

## 2. Detalhamento técnico

### Arquitetura

```
InscricaoEstadualValidation (Facade estática)
  ├── IsValid(State uf, string value) → bool
  │   └── Roteia para _validation[uf].IsValid(value)
  └── RemoveMask(string value) → string (OnlyNumbers, normalização de entrada)

Dicionário _validation: Dictionary<State, IInscricaoEstadualValidation>
  ├── 27 entries (AC, AL, AM, AP, BA, CE, DF, ES, GO, MA, MG, MS, MT,
  │               PA, PB, PE, PI, PR, RJ, RN, RO, RR, RS, SC, SE, SP, TO)
  └── Cada entry: new InscricaoEstadualXxxValidation()
```

### Interface

```csharp
public interface IInscricaoEstadualValidation
{
    bool IsValid(string ieValue);
}
```

### Implementações por estado

27 classes em `Documents/BR/Validation/Ie/`, cada uma com algoritmo módulo 11 ou 9 específico daquele estado.

### Exceções

```csharp
// StateNotFoundException — lançada quando estado não está nos dicionários
// (embora todos os 27+1 estejam mapeados, o acesso por chave inexistente lança KeyNotFoundException)
public class StateNotFoundException : Exception
{
    public StateNotFoundException() : base("State not found") { }
    public StateNotFoundException(string message) : base(message) { }
}
```

## 3. Diagrama de sequência

```mermaid
sequenceDiagram
    participant App as Aplicação
    participant Val as InscricaoEstadualValidation
    participant StateEnum as State Enum
    participant IEVal as IInscricaoEstadualValidation (SP)

    App->>Val: IsValid(State.SP, "123.456.789.123")
    Val->>Val: value?.OnlyNumbers()
    Val->>Val: _validation[uf].IsValid(onlyNumbers)
    Val->>IEVal: IsValid("123456789123")
    IEVal-->>Val: true/false
    Val-->>App: bool
```

## 4. Exemplos

```csharp
using Sirb.Validation.Documents.BR.Enumeration;
using Sirb.Validation.Documents.BR.Validation;

// Validação
bool ieSP = InscricaoEstadualValidation.IsValid(State.SP, "123.456.789.123");
bool ieRJ = InscricaoEstadualValidation.IsValid(State.RJ, "12.345.67-8");

// Normalização de entrada
string apenasDigitos = InscricaoEstadualValidation.RemoveMask("12.345.678-9"); // RemoveMask normaliza via OnlyNumbers()
```

## 5. Rastreabilidade

| Item | Caminho |
| ---- | ------- |
| Requisito de negócio | `req-0006-inscricao-estadual-validacao.md` |
| Requisito de máscara (formatação) | `tec-req-0018-inscricao-estadual-mascara.md` |
| Facade | `Documents/BR/Validation/InscricaoEstadualValidation.cs` |
| Interface | `Documents/BR/Interfaces/IInscricaoEstadualValidation.cs` |
| Validações por estado | `Documents/BR/Validation/Ie/InscricaoEstadualXxxValidation.cs` (27 arquivos) |
| Enum State | `Documents/BR/Enumeration/State.cs` |
| Exceção | `Exceptions/StateNotFoundException.cs` |

## 6. Histórico

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 27/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.1.0 | Remoção do conteúdo de máscara (formatação transferida para tec-req-0018); RF/RN renumerados; OnlyNumbers no fluxo |
