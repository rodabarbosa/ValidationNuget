---
type: req
title: "req-0020 — Mockup CNPJ Alfanumérico — Geração para Testes"
description: "Geração de CNPJs Alfanuméricos válidos para testes, garantindo massa de dados confiável para aplicações .NET que processem o novo formato RFB (IN 2.229/2024)."
resource: "./requirement/req-0020-mockup-cnpj-alfanumerico.md"
tags: [documento-brasileiro, geracao, teste, cnpj-alfanumerico]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-31"
status: rascunho
domain:
  artifact_id: "req-0020"
  title_pt: "Mockup CNPJ Alfanumérico — Geração para Testes"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "31/07/2026"
  updated: "31/07/2026"
  language: pt-BR
---

# req-0020 — Mockup CNPJ Alfanumérico — Geração para Testes

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** `req-0020`
- **Título:** Mockup CNPJ Alfanumérico — Geração para Testes
- **Data de criação:** 31/07/2026
- **Última atualização:** 31/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão:** 1.0.0
- **Status:** Rascunho

## Intenção

- **Problema:** Testes que dependem de CNPJs Alfanuméricos válidos (novo formato RFB) precisam de massa de dados. Gerar CNPJs alfanuméricos manualmente é propenso a erro e não cobre o algoritmo módulo 11 com conversão ASCII-48.
- **Impacto:** Testes frágeis e dificuldade de reproduzir cenários reais do novo formato.
- **Público:** Desenvolvedores .NET escrevendo testes (métodos marcados como `internal`, visíveis apenas para o projeto de teste via `InternalsVisibleTo`).
- **Critério de sucesso:** Geração de CNPJ Alfanumérico válido (que passa por `IsCnpjAlfanumericoValid`) em < 1 ms, com opção de gerar com ou sem máscara.

## Requisitos funcionais

| ID     | Descrição                                                                                                         | Prioridade |
| ------ | ----------------------------------------------------------------------------------------------------------------- | ---------- |
| RF-001 | Gerar CNPJ Alfanumérico válido aleatório com 14 caracteres (12 alfanuméricos + 2 dígitos verificadores numéricos) | Média      |
| RF-002 | Gerar CNPJ Alfanumérico com máscara `XX.XXX.XXX/XXXX-XX`                                                          | Média      |
| RF-003 | CNPJ Alfanumérico gerado deve passar na validação do req-0019                                                     | Média      |

## Regras de negócio

| ID     | Regra                                                                                                                                                                                               |
| ------ | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| RN-001 | Os 12 primeiros caracteres são alfanuméricos (0-9, A-Z), gerados aleatoriamente. Os 2 últimos são dígitos verificadores numéricos (0-9) calculados pelo algoritmo módulo 11 com conversão ASCII-48. |
| RN-002 | Os dígitos verificadores são calculados reutilizando `CnpjAlfanumericoRule.CalculateDigitValue` com os mesmos pesos do req-0019.                                                                    |
| RN-003 | A classe é `public`, mas o projeto de teste acessa via `InternalsVisibleTo`. Uso em produção é desencorajado.                                                                                       |
| RN-004 | A máscara aplicada em `GenerateWithMask()` segue o padrão `XX.XXX.XXX/XXXX-XX` (mesmo visual do CNPJ numérico).                                                                                     |

## Critérios de aceitação

```gherkin
Funcionalidade: Geração de CNPJ Alfanumérico para testes

  Cenário: Gerar CNPJ Alfanumérico aleatório sem máscara
    Dado que CnpjAlfanumerico.Generate() é chamado
    Então o resultado deve ser uma string de 14 caracteres
    E os 12 primeiros devem ser alfanuméricos (0-9, A-Z)
    E os 2 últimos devem ser dígitos numéricos (0-9)
    E CnpjAlfanumericoValidation.IsValid(resultado) deve retornar True

  Cenário: Gerar CNPJ Alfanumérico com máscara
    Dado que CnpjAlfanumerico.GenerateWithMask() é chamado
    Então o resultado deve seguir o padrão XX.XXX.XXX/XXXX-XX
    E ao remover a máscara, deve ser um CNPJ Alfanumérico válido
    E CnpjAlfanumericoValidation.IsValid(resultado_sem_mascara) deve retornar True
```

## NFRs

| Categoria       | Requisito    | Métrica                                  |
| --------------- | ------------ | ---------------------------------------- |
| Desempenho      | Geração      | < 1 ms                                   |
| Confiabilidade  | Validade     | 100% dos CNPJs gerados devem ser válidos |
| Compatibilidade | Multi-target | Compatível com .NET 8, 9 e 10            |

## Risco local

| ID      | Risco                                                                               | P   | I   | Score | Nível |
| ------- | ----------------------------------------------------------------------------------- | --- | --- | ----- | ----- |
| RSK-034 | CNPJ Alfanumérico gerado inválido (algoritmo de geração divergente do de validação) | 2   | 4   | 8     | Médio |

## Rastreabilidade

- `Documents/BR/Mockups/CnpjAlfanumerico.cs` (métodos `Generate()` e `GenerateWithMask()`)
- `Documents/BR/Rules/CnpjAlfanumericoRule.cs` (reutiliza os mesmos pesos e cálculo de DV)

## Histórico

| Data       | Autor                  | Versão | Alteração |
| ---------- | ---------------------- | ------ | --------- |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.0.0  | Criação   |

## Clarification Log (8/8) — OK

| Data       | Pergunta                                                         | Resposta                                                                      | Status    | Origem  | Impacto                |
| ---------- | ---------------------------------------------------------------- | ----------------------------------------------------------------------------- | --------- | ------- | ---------------------- |
| 31/07/2026 | O Generate deve aceitar parâmetros (ex.: prefixo fixo)?          | Não. Geração totalmente aleatória para simplicidade.                          | Resolvido | Criação | Define escopo          |
| 31/07/2026 | O GenerateWithMask usa PlaceCnpjAlfanumericoMask?                | Sim. Chama `Generate().PlaceCnpjAlfanumericoMask()`.                          | Resolvido | Criação | Confirma implementação |
| 31/07/2026 | Deve validar que não gera sequências repetidas?                  | Sim. O algoritmo módulo 11 naturalmente evita, mas não há checagem explícita. | Resolvido | Criação | Comportamento          |
| 31/07/2026 | O método é thread-safe?                                          | Random não é thread-safe, mas uso em testes costuma ser single-thread.        | Resolvido | Criação | NFR não explícito      |
| 31/07/2026 | Deve haver geração para CNPJ numérico legado também?             | Não. req-0008 já cobre CNPJ numérico. Este é só alfanumérico.                 | Resolvido | Criação | Escopo                 |
| 31/07/2026 | As letras I, O, Q, F devem ser evitadas na geração?              | Não. A RFB recomenda evitar, mas não proíbe. Geração aceita todas A-Z.        | Resolvido | Criação | Alinhado com req-0019  |
| 31/07/2026 | O método GenerateWithMask deve retornar null para entrada vazia? | Não aplicável — GenerateWithMask não recebe parâmetro.                        | Resolvido | Criação | N/A                    |
| 31/07/2026 | Onde ficam os testes?                                            | `Sirb.Validation.Test/Mockups/CnpjAlfanumericoTest.cs`.                       | Resolvido | Criação | Rastreabilidade        |

### Cobertura do Clarification (8 áreas)

| #   | Área                                  | Status    | Ref. entrada no Log             | Justificativa (se N/A)          |
| --- | ------------------------------------- | --------- | ------------------------------- | ------------------------------- |
| 1   | Atores e personas                     | Resolvido | Desenvolvedor .NET testador     | —                               |
| 2   | Fluxos principais e alternativos      | Resolvido | Generate / GenerateWithMask     | —                               |
| 3   | Exceções e erros                      | Resolvido | Random não thread-safe (aceito) | —                               |
| 4   | Integrações externas                  | Resolvido | N/A — stateless                 | Justificativa: sem dependências |
| 5   | Requisitos não-funcionais             | Resolvido | < 1 ms, 100% válidos            | —                               |
| 6   | Dados e privacidade                   | Resolvido | Dados de teste, não produção    | —                               |
| 7   | Validações e regras de negócio        | Resolvido | RN-001 a RN-004                 | —                               |
| 8   | Critérios de aceite e mensurabilidade | Resolvido | Gherkin + NFRs métricas         | —                               |

**Cobertura atual:** 8/8. **Meta:** 8/8 (OK).
