---
type: apf
title: "APF — req-0001 — CPF — Validação"
description: "Análise de Pontos de Função do requisito req-0001: 6 PF em 2 funções de transação."
resource: "./requirement/apf/apf-req-0001.md"
tags: [apf, pontos-de-funcao]
generated:
  by: "Opencode — writer"
  timestamp: "2026-07-27"
status: approved
domain:
  artifact_id: "apf-req-0001"
  title_pt: "APF — req-0001"
  version: "1.1.0"
  author: "Rodrigo Araujo Barbosa"
  created: "27/07/2026"
  updated: "31/07/2026"
  language: pt-BR
---

# APF — Análise de Pontos de Função — req-0001

## Metadados

> **Nota:** Esta seção é uma reflexão do frontmatter YAML (bloco `---` no topo do arquivo) para leitura humana. O frontmatter é a fonte primária; qualquer divergência entre os dois deve ser resolvida atualizando o frontmatter primeiro.

- **Código do documento:** `apf-req-0001`
- **Requisito:** req-0001 — CPF — Validação
- **Data de criação:** 27/07/2026
- **Última atualização:** 31/07/2026
- **Autor:** Rodrigo Araujo Barbosa
- **Versão:** 1.1.0
- **Status:** Aprovado

## Contagem de Pontos de Função

### Premissas

- Biblioteca stateless, sem UI, sem banco de dados.
- A contagem considera funções de transação (EE, SE, CE) expostas como API pública.
- Não há arquivos lógicos internos (ALI) ou externos (AIE).
- A formatação (máscara) `PlaceCpfMask`/`PlaceMask` é contabilizada no `apf-req-0014` (requisito independente de máscara).

### Funções de Transação

| Tipo | Função | Descrição | Complexidade | DERs | ARs | PF |
| ---- | ------ | --------- | ------------ | ---- | --- | -- |
| EE (External Input) | `IsCpfValid(string value)` | Validação de entrada — recebe string, retorna bool | Baixa | 2 (string value, bool retorno) | 0 | 3 |
| EE | `GetIssuingState(string value)` | Identificação de estado emissor — recebe string, retorna string | Baixa | 2 (string value, string retorno) | 0 | 3 |

### Detalhamento da Complexidade

- **EE (External Input)** — cada método é uma entrada externa que processa dados e retorna um resultado.
  - IsCpfValid: 2 DERs (entrada string + saída bool), 0 ARs → Baixa → 3 PF
  - GetIssuingState: 2 DERs (entrada string + saída string), 0 ARs → Baixa → 3 PF

### Resumo

| Tipo | Quantidade | PF Unitário | Subtotal |
| ---- | ---------- | ----------- | -------- |
| EE | 2 | 3 | 6 |
| **Total** | **2** | | **6 PF** |

### Justificativa

- A biblioteca é puramente computacional, sem estado, sem persistência, sem interface.
- Cada método público é uma função de transação independente.
- IsCpfValid e GetIssuingState são interfaces de entrada que validam/consultam dados → EE.
- As funções de máscara (PlaceCpfMask, PlaceMask) e remoção de máscara (RemoveMask) foram removidas deste requisito e são contabilizadas em `apf-req-0014` (máscara) e `apf-req-0013` (utilitários).
- Não há EO (External Output) pois nenhum método gera relatórios ou saídas formatadas para outro sistema.
- Não há ALI (Arquivo Lógico Interno) ou AIE (Arquivo de Interface Externa) pois a biblioteca não mantém dados.

## Consolidação

- **Total de PF para req-0001:** 6 PF
- **Documento consolidado:** `docs/tamanho-aplicacao.md` (atualizado separadamente)

## Histórico de alterações

| Data | Autor | Versão | Alteração |
| ---- | ----- | ------ | --------- |
| 27/07/2026 | Rodrigo Araujo Barbosa | 1.0.0 | Criação do documento |
| 31/07/2026 | Rodrigo Araujo Barbosa | 1.1.0 | Remoção das funções de máscara (PlaceCpfMask/RemoveMask) — transferidas para req-0014/req-0013; total 12→6 PF |
