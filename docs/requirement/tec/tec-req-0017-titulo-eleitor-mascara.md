---
type: tec-req
title: "tec-req-0017 — Título de Eleitor — Máscara (Especificação Técnica)"
description: "Especificação técnica da aplicação de máscara Título de Eleitor no formato 0000.0000.0000, normalização via RemoveMask/OnlyNumbers, extension method PlaceTituloEleitorMask."
resource: "./requirement/tec/tec-req-0017-titulo-eleitor-mascara.md"
tags: [documento-brasileiro, especificacao-tecnica, mascara, titulo-eleitor]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-31"
verified:
  by: "Rodrigo Araujo Barbosa"
  timestamp: "2026-07-31T02:00:00Z"
  method: "validação com PO"
status: approved
stale_after: "2027-01-31"
domain:
  artifact_id: "tec-req-0017"
  title_pt: "Título de Eleitor — Máscara — Especificação Técnica"
  version: "1.1.0"
  author: "Rodrigo Araujo Barbosa"
  created: "31/07/2026"
  updated: "31/07/2026"
  bundle: "flat"
  language: pt-BR
  req_origem: "req-0017-titulo-eleitor-mascara.md"
  coverage_clarification: "8/8"
---

# tec-req-0017 — Título de Eleitor — Máscara (Especificação Técnica)

## Metadados

> Esta tabela é uma **reflexão** do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

| Campo | Valor |
|---|---|
| **Código do documento** | `tec-req-0017` |
| **Título** | Título de Eleitor — Máscara — Especificação Técnica |
| **Versão** | 1.1.0 |
| **Autor** | Rodrigo Araujo Barbosa |
| **Data de criação** | 31/07/2026 |
| **Última atualização** | 31/07/2026 |
| **Status** | Aprovado |
| **Bundle** | `flat` |
| **Requisito de negócio** | `req-0017-titulo-eleitor-mascara.md` |
| **Cobertura Clarification** | 8/8 |
| **Tipo OKF** | `tec-req` |

## 1. Resumo do requisito de negócio

- **Requisito de origem:** `req-0017-titulo-eleitor-mascara.md` (versão 1.0.0)
- **Síntese do "o quê":** Aplicar máscara `0000.0000.0000` a strings contendo Título de Eleitor, com normalização prévia (remoção de não-dígitos) e tratamento de bordas (null/vazio → null).
- **Síntese do "por quê":** Padronizar formatação de Título de Eleitor em aplicações .NET, garantindo conformidade com layout oficial do TSE.

## 2. Detalhamento técnico completo

### 2.1 Arquitetura de camadas

```
Extensions (API Pública)
  └── TituloEleitorExtension.cs            (PlaceTituloEleitorMask via extension method)
Validation (Orquestração)
  └── TituloEleitorValidation.cs           (PlaceMask, RemoveMask delega para StringExtension)
Extensions (Utilitários)
  └── StringExtension.cs                   (OnlyNumbers — regex [^\d])
```

### 2.2 Algoritmo de máscara

**Formato:** `0000.0000.0000` (12 dígitos)

**Regex:** `(\d{4})(\d{4})(\d{4})` → substituição `$1.$2.$3`

**Fluxo:**
1. Verifica se entrada é null, vazia ou whitespace → retorna `default` (null)
2. Chama `value.RemoveMask()` → `StringExtension.OnlyNumbers()` → regex `[^\d]`
3. Aplica `Regex.Replace` com padrão acima
3. Retorna string formatada

### 2.3 Validações de entrada

| Entrada | Comportamento |
|---------|---------------|
| `null` | Retorna `null` |
| `""` (vazio) | Retorna `null` |
| `"   "` (whitespace) | Retorna `null` (Trim + IsNullOrEmpty) |
| `"123456789012"` (12 dígitos) | Retorna `"1234.5678.9012"` |
| `"1234.5678.9012"` (já formatado) | Retorna `"1234.5678.9012"` (idempotente) |
| `"12a3.45b6.78c9.0d12"` (com letras) | Retorna `"1234.5678.9012"` (normaliza) |
| `"12345678901"` (11 dígitos) | Retorna `"12345678901"` (regex não casa, normalizado) |

**Nota:** O método **não valida** o Título (dígitos verificadores, UF). Apenas formata. Validação é `IsValid` (`req-0004`).

### 2.4 Normalização (RemoveMask)

- Delegado para `StringExtension.OnlyNumbers()`
- Implementação: `Regex.Replace(value, "[^\\d]", "")`
- Remove: pontos, traços, espaços, letras, quaisquer não-dígitos

### 2.5 Namespace e localização

| Componente | Namespace | Arquivo |
|------------|-----------|---------|
| `TituloEleitorValidation.PlaceMask` | `Sirb.Validation.Documents.BR.Validation` | `Documents/BR/Validation/TituloEleitorValidation.cs` |
| `TituloEleitorExtension.PlaceTituloEleitorMask` | `Sirb.Validation.Extensions` | `Extensions/TituloEleitorExtension.cs` |
| `StringExtension.OnlyNumbers` / `RemoveMask` | `Sirb.Validation.Extensions` | `Extensions/StringExtension.cs` |

**Nota:** `TituloEleitorExtension` está corretamente em `Sirb.Validation.Extensions`.

## 3. Regras funcionais e regras de negócio numeradas

### Regras funcionais (RF)

| ID | Descrição | Prioridade | Regra de negócio associada |
| -- | --------- | ---------- | -------------------------- |
| RF-001 | Aplicar máscara `0000.0000.0000` via regex em string normalizada (apenas dígitos) | Alta | RN-001 |
| RF-002 | Normalizar entrada removendo todos caracteres não numéricos antes da máscara | Alta | RN-002 |
| RF-003 | Retornar `null` para entrada null, vazia ou apenas whitespace | Alta | RN-003 |
| RF-004 | Expor como extension method `PlaceTituloEleitorMask()` sobre `string` | Alta | RN-004 |

### Regras de negócio (RN)

| ID | Regra | Origem | Impacto |
| -- | ----- | ------ | ------- |
| RN-001 | Máscara Título: padrão `0000.0000.0000`, regex `(\d{4})(\d{4})(\d{4})` → `$1.$2.$3` | Padrão oficial (TSE) | Formatação |
| RN-002 | Normalização: `RemoveMask()` = `OnlyNumbers()` = regex `[^\d]` remove não-dígitos | Boa prática / Código existente | Normalização |
| RN-003 | Entrada null/vazia/whitespace → `null` (não string vazia) | Comportamento atual | Tratamento de borda |
| RN-004 | API pública: extension method em `TituloEleitorExtension` (namespace `Sirb.Validation.Extensions`) | Design da biblioteca | Descoberta IntelliSense |

## 4. Diagramas técnicos

### 4.1 Diagrama de fluxo — Aplicação de máscara Título de Eleitor

```mermaid
flowchart TD
    A[Entrada: string value] --> B{string.IsNullOrEmpty(value?.Trim())?}
    B -->|Sim| C[return default (null)]
    B -->|Não| D[normalized = value.RemoveMask()]
    D --> E[Regex.Replace(normalized, '(\d{4})(\d{4})(\d{4})', '$1.$2.$3')]
    E --> F[return formatted]
```

### 4.2 Diagrama de sequência

```mermaid
sequenceDiagram
    participant App as Aplicação
    participant Ext as TituloEleitorExtension
    participant Val as TituloEleitorValidation
    participant StrExt as StringExtension

    App->>Ext: "123456789012".PlaceTituloEleitorMask()
    Ext->>Val: TituloEleitorValidation.PlaceMask("123456789012")
    Val->>StrExt: value.RemoveMask() → OnlyNumbers()
    StrExt-->>Val: "123456789012"
    Val->>Val: Regex.Replace → "1234.5678.9012"
    Val-->>Ext: "1234.5678.9012"
    Ext-->>App: "1234.5678.9012"
```

## 5. Exemplos técnicos

### 5.1 Exemplos de código C#

```csharp
using Sirb.Validation.Extensions;
using Sirb.Validation.Documents.BR.Validation;

// --- Extension method (API pública) ---
string mascarado1 = "123456789012".PlaceTituloEleitorMask();       // "1234.5678.9012"
string mascarado2 = "1234.5678.9012".PlaceTituloEleitorMask();     // "1234.5678.9012" (idempotente)
string mascarado3 = "12a3.45b6.78c9.0d12".PlaceTituloEleitorMask(); // "1234.5678.9012" (normaliza)
string nulo1 = "".PlaceTituloEleitorMask();                        // null
string nulo2 = ((string)null).PlaceTituloEleitorMask();            // null
string nulo3 = "   ".PlaceTituloEleitorMask();                     // null

// --- Método interno (camada de validação) ---
string mascarado4 = TituloEleitorValidation.PlaceMask("123456789012"); // "1234.5678.9012"

// --- Normalização direta ---
string apenasDigitos = "1234.5678.9012".RemoveMask();               // "123456789012"
string apenasDigitos2 = "abc123def".OnlyNumbers();                  // "123"
```

### 5.2 Cenários de borda e exceções

| Cenário | Entrada | Resultado | Motivo |
| ------- | ------- | --------- | ------ |
| Título 11 dígitos | `"12345678901"` | `"12345678901"` | Regex não casa (precisa 12), retorna normalizado |
| Título 13 dígitos | `"1234567890123"` | `"1234567890123"` | Regex não casa, retorna normalizado |
| Apenas letras | `"abcdefghijkl"` | `""` (vazio) | OnlyNumbers remove tudo, regex não casa em string vazia |
| Caracteres especiais | `"!@#$%^&*()_+"` | `""` (vazio) | OnlyNumbers remove tudo |

## 6. Rastreabilidade

| Item | Referência |
| ---- | ---------- |
| Requisito de negócio | `req-0017-titulo-eleitor-mascara.md` |
| Requisito de validação base | `req-0004-titulo-eleitor-validacao.md` |
| Classe de validação | `Sirb.Validation/Documents/BR/Validation/TituloEleitorValidation.cs` (linhas 75-84) |
| Extension method API pública | `Sirb.Validation/Extensions/TituloEleitorExtension.cs` (linhas 1-19) |
| Utilitário de normalização | `Sirb.Validation/Extensions/StringExtension.cs` (`OnlyNumbers`, `RemoveMask`) |
| Testes | `Sirb.Validation.Test/Extensions/TituloEleitorExtensionTest.cs` (método `PlaceMask`) |
| Mockup (geração) | `Sirb.Validation/Documents/BR/Mockups/TituloEleitor.cs` (req-0010) |

## 7. Validações realizadas para esta documentação

- [x] `README.md` do projeto analisado
- [x] `req-0017` correspondente lido e referenciado
- [x] Código-fonte analisado: `TituloEleitorValidation.cs`, `TituloEleitorExtension.cs`, `StringExtension.cs`
- [x] Diagramas Mermaid validados (sintaxe)
- [x] Documentações correlatas revisadas (`constituicao.md`, `architecture-tech-stack.md`, `req-0004`)
- [x] Matriz global de risco do sistema atualizada (`system-risk-matrix.md`)
- [x] APF do requisito criado (`apf-req-0017.md`)
- [x] Clarification Log preenchido e sincronizado com o `req-0017` correspondente
- [x] Nenhum item Pendente no Clarification Log que impacte aceite/escopo
- [x] Frontmatter YAML validado: `type` preenchido, `domain.version` incrementado, `domain.author` é nome de usuário
- [x] Tabela `## Metadados` reflete os valores do frontmatter YAML

## 8. Histórico de alterações e Clarification Log

### 8.1 Histórico de alterações

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação do documento |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.1.0 | Atualização de referência ao requisito base renomeado (`req-0004-titulo-eleitor-validacao.md`) |

### 8.2 Clarification Log

| Data | Pergunta | Resposta | Status | Origem | Impacto |
| ---- | -------- | -------- | ------ | ------ | ------- |
| 31/07/2026 | O PlaceMask deve validar o Título antes de mascarar? | Não. Apenas formata. Validação é IsValid (req-0004). | Resolvido | Criação | Define escopo: máscara pura. |
| 31/07/2026 | Qual o comportamento para string com menos de 12 dígitos? | Regex não casa, retorna string normalizada sem máscara. | Resolvido | Criação | Cenário de borda. |
| 31/07/2026 | PlaceTituloEleitorMask está em namespace Extensions? | Sim, `Sirb.Validation.Extensions` (correto). | Resolvido | Criação | Consistência confirmada. |
| 31/07/2026 | O método deve lançar exceção para entrada inválida? | Não. Retorna null para vazio/nulo; outros aplicam regex. | Resolvido | Criação | Comportamento defensivo. |
| 31/07/2026 | Existe método RemoveMask específico para Título? | Não. Usa `StringExtension.OnlyNumbers()` (regex `[^\d]`). | Resolvido | Criação | Reuso de utilitário. |
| 31/07/2026 | A máscara deve preservar caracteres não numéricos? | Não. Remove todos não-dígitos antes de formatar. | Resolvido | Criação | Normalização. |
| 31/07/2026 | Qual a diferença entre PlaceMask e PlaceTituloEleitorMask? | PlaceMask interno em TituloEleitorValidation; PlaceTituloEleitorMask extension público. | Resolvido | Criação | Arquitetura de camadas. |
| 31/07/2026 | O código atual trata whitespace-only como vazio? | Sim. `value?.Trim()` + `string.IsNullOrEmpty`. | Resolvido | Criação | Comportamento confirmado. |

### Cobertura do Clarification (8 áreas)

| # | Área | Status | Ref. entrada no Log | Justificativa (se N/A) |
| - | ---- | ------ | ------------------- | ---------------------- |
| 1 | Atores e personas | Resolvido | Desenvolvedor .NET consumidor | — |
| 2 | Fluxos principais e alternativos | Resolvido | Cenários Gherkin | — |
| 3 | Exceções e erros | Resolvido | Entrada inválida retorna null | — |
| 4 | Integrações externas | Resolvido | N/A — sem dependências | Stateless |
| 5 | Requisitos não-funcionais | Resolvido | p95 < 1ms, ReDoS, API fluente | — |
| 6 | Dados e privacidade | Resolvido | Título sensível; não logar bruto | — |
| 7 | Validações e regras de negócio | Resolvido | RN-001 a RN-004 | — |
| 8 | Critérios de aceite e mensurabilidade | Resolvido | Gherkin + NFRs métricas | — |

**Cobertura atual:** 8/8. **Meta:** 8/8 (OK).