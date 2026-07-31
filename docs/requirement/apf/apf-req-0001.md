---
type: apf
title: "APF — req-0001 — CPF — Validação e Máscara"
description: "Análise de Pontos de Função do requisito req-0001: 12 PF em 4 funções de transação."
resource: "./requirement/apf/apf-req-0001.md"
tags: [apf, pontos-de-funcao]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "apf-req-0001"
  title_pt: "APF — req-0001"
  version: "1.0.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "27/07/2026"
  language: pt-BR
---

# APF — Análise de Pontos de Função — req-0001

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** `apf-req-0001`
- **Requisito:** req-0001 — CPF — Validação e Máscara
- **Data de criação:** 27/07/2026
- **Última atualização:** 27/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão:** 1.0.0
- **Status:** Aprovado

## Contagem de Pontos de Função

### Premissas

- Biblioteca stateless, sem UI, sem banco de dados.
- A contagem considera funções de transação (EE, SE, CE) expostas como API pública.
- Não há arquivos lógicos internos (ALI) ou externos (AIE).

### Funções de Transação

| Tipo | Função | Descrição | Complexidade | DERs | ARs | PF |
| ---- | ------ | --------- | ------------ | ---- | --- | -- |
| EE (External Input) | `IsCpfValid(string value)` | Validação de entrada — recebe string, retorna bool | Baixa | 2 (string value, bool retorno) | 0 | 3 |
| EE | `PlaceCpfMask(string value)` | Formatação — recebe string, retorna string mascarada | Baixa | 2 (string value, string retorno) | 0 | 3 |
| EE | `GetIssuingState(string value)` | Identificação de estado emissor — recebe string, retorna string | Baixa | 2 (string value, string retorno) | 0 | 3 |
| CE (External Inquiry) | `RemoveMask()` (via StringExtension.OnlyNumbers) | Consulta simples — recebe string, retorna apenas dígitos | Baixa | 2 (string value, string retorno) | 0 | 3 |

### Detalhamento da Complexidade

- **EE (External Input)** — cada método é uma entrada externa que processa dados e retorna um resultado.
  - IsCpfValid: 2 DERs (entrada string + saída bool), 0 ARs → Baixa → 3 PF
  - PlaceCpfMask: 2 DERs (entrada string + saída string), 0 ARs → Baixa → 3 PF
  - GetIssuingState: 2 DERs (entrada string + saída string), 0 ARs → Baixa → 3 PF
- **CE (External Inquiry)** — consulta que retorna dados processados.
  - RemoveMask/OnlyNumbers: 2 DERs (entrada string + saída string), 0 ARs → Baixa → 3 PF

### Resumo

| Tipo | Quantidade | PF Unitário | Subtotal |
| ---- | ---------- | ----------- | -------- |
| EE | 3 | 3 | 9 |
| CE | 1 | 3 | 3 |
| **Total** | **4** | | **12 PF** |

### Justificativa

- A biblioteca é puramente computacional, sem estado, sem persistência, sem interface.
- Cada método público é uma função de transação independente.
- IsCpfValid, PlaceCpfMask e GetIssuingState são interfaces de entrada que validam/transformam dados → EE.
- RemoveMask/OnlyNumbers é uma consulta simples de filtragem → CE.
- Não há EO (External Output) pois nenhum método gera relatórios ou saídas formatadas para outro sistema.
- Não há ALI (Arquivo Lógico Interno) ou AIE (Arquivo de Interface Externa) pois a biblioteca não mantém dados.

## Consolidação

- **Total de PF para req-0001:** 12 PF
- **Documento consolidado:** `docs/tamanho-aplicacao.md` (atualizado separadamente)

## Histórico de alterações

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 27/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação do documento |
