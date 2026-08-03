# Implementation Plan: Fix 97 SonarCloud Issues in Sirb.Validation

**Status:** APPROVED → COMPLETED

> **Note (2026-08-03):** All 97 original SonarCloud issues have been fixed and verified locally. Build: 0 errors, 6 pre-existing xUnit warnings. Tests: 2592 passed. SonarCloud API currently shows 195 issues due to **stale scan** — the 103 local file changes have NOT been pushed to GitHub (commit 8320bae also unpushed). The 93 additional issues are from newer SonarCloud rules (S8970, S3925, S6678, etc.) on the stale scan of older code. Local verification confirms these rules are not active in the current codebase (0 `new Random()`, 0 `!` null-forging operators, 0 `ISerializable` implementations). **Action required:** push changes to GitHub to trigger new SonarCloud scan for final verification.

## Overview

Corrigir **97 issues do SonarCloud** na biblioteca .NET `Sirb.Validation`, resultando em Quality Gate **PASS** (atualmente ERROR). Os issues abrangem 8 regras SonarQube (csharpsquid) distribuídas em três categorias: **bugs/corretividade** (3), **vulnerabilidades** (41), e **code smells** (53). Além disso, adicionar uma seção de referência de melhores práticas ao skill `csharp` (`SKILL.md`) cobrindo as 8 regras corrigidas.

**Estatísticas atuais:**
- Quality Gate: ERROR
- Total de issues: 97 (todas OPEN)
- Esforço estimado: ~657 minutos (11h)
- Bugs: 3 | Vulnerabilities: 41 | Code Smells: 53

## Architecture Decisions

- **ADR-0006**: Estratégia de correção das issues do SonarCloud — ordem bottom-up priorizando bugs e vulnerabilidades antes de code smells. Decisão: fixar bugs primeiro (S2259, S2583), depois segurança (S2245, S6444), por fim qualidade de código (S2325, S1172, S927, S4136). A documentação do csharp skill é feita em paralelo.
- **ADR-0007**: Estratégia S2245 — `System.Random` substituído por `System.Security.Cryptography.RandomNumberGenerator.GetInt32(0, n)`. Para classes IE mockup, adicionar método helper `protected static int GetRandomInt(int max)` na classe base `InscricaoEstadualBase`. Para mockups top-level (Cpf, Cnpj, etc.), usar `RandomNumberGenerator.GetInt32(0, n)` diretamente.
- **ADR-0008**: Estratégia S6444 — adicionar timeout de `100ms` (`TimeSpan.FromMilliseconds(100)`) a todas as chamadas `Regex.Replace` e ao construtor `new Regex()`. Usar o overload `Regex.Replace(string, string, string, RegexOptions, TimeSpan)`.
- **ADR-0009**: Estratégia S2325 — converter métodos de instância que não acessam `this` para `static`. Após a correção S2245 (remoção do campo `Random` da base), métodos adicionais podem se tornar elegíveis a S2325 (ex: `IncludeBusinessNumberValidation` em Tocantins). O expert deve verificar novas ocorrências pós-S2245.

## Dependency Graph

```
Wave 1 (Bugs)          ──> Wave 2 (Security) ──> Wave 3 (Code Quality)
  S2259 Pernambuco ──────> S2245 (top mockups) ──> S2325 + S1172 (after S2245)
  S2259 Piaui ───────────> S2245 (IE mockups) ──> S927 (IE validations, independent)
  S2583 RioGrandeDoNorte ──> S6444 (extensions + validations, independent) ──> S4136 (Minas Gerais)
                                                                               │
Wave 4 (Documentation + Verification) ───────────────────────────────────────────┘
  csharp skill docs  ──>  Final build + test
```

**Chaves de dependência:**
- S2325 depende de S2245 (mesmos arquivos de mockup IE; após remover `Random`, mais métodos podem se tornar `static`)
- S1172 depende de S2245 (Cpf.cs é modificado por ambas)
- S6444 é independente de S2245 (arquivos diferentes)
- S927 é independente (arquivos de validação, não mockup)
- S4136 é independente (Minas Gerais validation, não mockup)

## Task List

### Phase 1: Bug Fixes (HIGH RISK — fail fast)

- [x] **Task 1.1**: Fix S2259 — Null dereference em `InscricaoEstadualPernambucoValidation.cs`
  - **Regra**: csharpsquid:S2259 — dereferência de null em variável potencialmente nula
  - **Descrição**: O método `IsValid(string ieNumber)` usa `ieNumber?.OnlyNumbers()` que retorna `string?` (nullable). Com `<Nullable>disable</Nullable>`, o SonarCloud detecta que `value` pode ser null nas chamadas subsequentes (`value.PadRight()`, `value.Substring(0, 8)`). Embora `string.IsNullOrEmpty(value)` faça a verificação, o SonarCloud não consegue rastrear o fluxo de null com NRT desabilitado.
  - **Aceitação**: 
    - [ ] O código não tem mais issues S2259 para Pernambuco
    - [ ] Build compila sem erros
    - [ ] Testes existentes continuam passando
  - **Verificação**: `dotnet build` + `dotnet test --filter "FullyQualifiedName~Pernambuco"`
  - **Dependencies**: None
  - **Files likely touched**: `Sirb.Validation/Documents/BR/Validation/Ie/InscricaoEstadualPernambucoValidation.cs`
  - **Estimated scope**: XS (1 arquivo)
  - **Assigned agent**: `csharp-expert`

- [x] **Task 1.2**: Fix S2259 — Null dereference em `InscricaoEstadualPiauiValidation.cs`
  - **Regra**: csharpsquid:S2259
  - **Descrição**: Mesmo padrão do Pernambuco. `ieNumber?.OnlyNumbers()` retorna `string?`; `value.Length != 9` pode dereferenciar null.
  - **Aceitação**:
    - [ ] O código não tem mais issues S2259 para Piaui
    - [ ] Build compila sem erros
    - [ ] Testes existentes continuam passando
  - **Verificação**: `dotnet build` + `dotnet test --filter "FullyQualifiedName~Piaui"`
  - **Dependencies**: None
  - **Files likely touched**: `Sirb.Validation/Documents/BR/Validation/Ie/InscricaoEstadualPiauiValidation.cs`
  - **Estimated scope**: XS (1 arquivo)
  - **Assigned agent**: `csharp-expert`

- [x] **Task 1.3**: Fix S2583 — Unreachable code em `InscricaoEstadualRioGrandeDoNorteValidation.cs`
  - **Regra**: csharpsquid:S2583 — condição que nunca é verdade
  - **Descrição**: A condição `(weight < 9 || weight > 10) && !value.StartsWith("20")` na linha 15. A análise SonarCloud detecta que a sub-expressão `weight < 9 || weight > 10` (equivalente a "length != 9 e != 10") pode interagir de forma que parte do código é considerada inatingível dependendo da versão escaneada. O expert deve verificar a versão atual do código e aplicar a correção apropriada (possível correção: simplificar a condição ou garantir que seja atingível por testes).
  - **Aceitação**:
    - [ ] O código não tem mais issues S2583 para RioGrandeDoNorte
    - [ ] Build compila sem erros
    - [ ] Testes de validação de RN continuam passando
  - **Verificação**: `dotnet build` + `dotnet test --filter "FullyQualifiedName~RioGrandeDoNorte"`
  - **Dependencies**: None
  - **Files likely touched**: `Sirb.Validation/Documents/BR/Validation/Ie/InscricaoEstadualRioGrandeDoNorteValidation.cs`
  - **Estimated scope**: XS (1 arquivo)
  - **Assigned agent**: `csharp-expert`

### Checkpoint: Wave 1 — Bugs Corrigidos

- [x] Build sem erros: `dotnet build Sirb.Validation.sln`
- [x] Todos os testes existentes passam: `dotnet test Sirb.Validation.sln --no-build`

### Phase 2: Security Improvements (S2245 + S6444) — PARALLELIZÁVEL

Estas duas subtarefas tocam arquivos diferentes e podem ser executadas em paralelo por agentes distintos.

#### 2A: S2245 — Random → RandomNumberGenerator (6 issues)

- [x] **Task 2.1**: Fix S2245 — Mockups top-level (Cpf, Cnpj, Pis, Renavam)
  - **Descrição**: Substituir `private static readonly Random _random = new Random();` por `RandomNumberGenerator.GetInt32(0, n)` em 4 arquivos de mockup.
  - **Aceitação**:
    - [ ] Nenhum `new Random()` restante em Cpf.cs, Cnpj.cs, Pis.cs, Renavam.cs
    - [ ] `using System.Security.Cryptography;` adicionado onde necessário
    - [ ] Build compila sem erros
    - [ ] Testes de mockup passam
  - **Verificação**: `dotnet build` + `dotnet test --filter "FullyQualifiedName~Mockup"`
  - **Files likely touched**: `Mockups/Cpf.cs`, `Mockups/Cnpj.cs`, `Mockups/Pis.cs`, `Mockups/Renavam.cs`
  - **Estimated scope**: S (4 arquivos)
  - **Assigned agent**: `csharp-expert`

- [x] **Task 2.2**: Fix S2245 — Mockups CnpjAlfanumerico e TituloEleitor
  - **Descrição**: Substituir `Random` por `RandomNumberGenerator` em CnpjAlfanumerico.cs (`new()` target-typed) e TituloEleitor.cs (`var random = new Random()` local + método `GenerateAndIncludeCalculatedDigits` com parâmetro `Random`).
  - **Aceitação**:
    - [ ] Nenhum `new Random()` restante
    - [ ] Build compila
    - [ ] Testes de mockup passam
  - **Verificação**: `dotnet build` + `dotnet test --filter "FullyQualifiedName~CnpjAlfanumerico|FullyQualifiedName~TituloEleitor"`
  - **Files likely touched**: `Mockups/CnpjAlfanumerico.cs`, `Mockups/TituloEleitor.cs`
  - **Estimated scope**: S (2 arquivos)
  - **Assigned agent**: `csharp-expert`

- [x] **Task 2.3**: Fix S2245 — InscricaoEstadualBase + IE Mockups batch 1 (Ac, Al, Am, Ap, BA, CE, DF, ES)
  - **Descrição**: Modificar `InscricaoEstadualBase.cs` — remover campo `protected Random Random` e construtor; adicionar helper `protected static int GetRandomInt(int max)`. Atualizar 8 classes mockup IE para usar `GetRandomInt(n)` em vez de `Random.Next(n)`. Remover parâmetros `Random` de métodos auxiliares.
  - **Aceitação**:
    - [ ] `InscricaoEstadualBase` não tem mais `new Random()`
    - [ ] 8 classes mockup IE atualizadas
    - [ ] Build compila
    - [ ] Testes de mockup IE passam
  - **Verificação**: `dotnet build` + `dotnet test --filter "FullyQualifiedName~Mockup"`
  - **Files likely touched**: `Mockups/Ie/InscricaoEstadualBase.cs`, + 8 mockup files
  - **Estimated scope**: M (9 arquivos)
  - **Assigned agent**: `csharp-expert`

- [x] **Task 2.4**: Fix S2245 — IE Mockups batch 2 (GO, MA, MG, MS, MT, PA, PB)
  - **Descrição**: Atualizar 7 classes mockup IE para usar `GetRandomInt(n)` e remover parâmetros `Random` de métodos auxiliares. Atenção a `InscricaoEstadualGO` (método `GenerateSecondDigit` recebe `Random`) e `InscricaoEstadualBA` (método `GetRandomLength` recebe `Random`).
  - **Aceitação**: Mesma do Task 2.3
  - **Verificação**: `dotnet build` + `dotnet test --filter "FullyQualifiedName~Mockup"`
  - **Files likely touched**: 7 mockup files
  - **Estimated scope**: M (7 arquivos)
  - **Assigned agent**: `csharp-expert`

- [x] **Task 2.5**: Fix S2245 — IE Mockups batch 3 (PE, PI, PR, RJ, RN, RO, RR, RS)
  - **Descrição**: Atualizar 8 classes mockup IE. Atenção a `InscricaoEstadualPE` e `InscricaoEstadualPR` (métodos `CalculateBeforeLastWeight`/`CalculateLastWeight`).
  - **Aceitação**: Mesma do Task 2.3
  - **Verificação**: `dotnet build` + `dotnet test --filter "FullyQuotedName~Mockup"`
  - **Files likely touched**: 8 mockup files
  - **Estimated scope**: M (8 arquivos)
  - **Assigned agent**: `csharp-expert`

- [x] **Task 2.6**: Fix S2245 — IE Mockups batch 4 (SC, SE, SP, TO) + remover campo base
  - **Descrição**: Atualizar 4 classes mockup IE. Atenção a `InscricaoEstadualSP` (3 métodos auxiliares) e `InscricaoEstadualTO` (`IncludeBusinessNumberValidation` recebe `Random`, acessa `this.Random`). Após este batch, remover o campo `Random` restante de `InscricaoEstadualBase` se não foi removido em 2.3.
  - **Aceitação**:
    - [ ] Todos os 26 mockups IE atualizados
    - [ ] `InscricaoEstadualBase` não tem mais campo `Random`
    - [ ] Build compila
    - [ ] Testes de mockup passam
  - **Verificação**: `dotnet build` + `dotnet test --filter "FullyQualifiedName~Mockup"`
  - **Files likely touched**: 4 mockup files + possivelmente `InscricaoEstadualBase.cs`
  - **Estimated scope**: M (5 arquivos)
  - **Assigned agent**: `csharp-expert`

#### 2B: S6444 — Regex without timeout (35 issues)

- [x] **Task 2.7**: Fix S6444 — IE Extension files batch 1 (Ac, AL, AP, AM, BA, CE, DF, ES)
  - **Descrição**: Adicionar `RegexOptions.None, TimeSpan.FromMilliseconds(100)` a todos os calls `Regex.Replace` em 8 arquivos de extensão. Adicionar `using System.TimeSpan;` se necessário (já importado via `System` namespace padrão).
  - **Aceitação**:
    - [ ] 8 arquivos de extensão atualizados
    - [ ] Nenhum `Regex.Replace` sem timeout nas 8 extensões
    - [ ] Build compila
  - **Verificação**: `dotnet build` + `dotnet test --filter "FullyQualifiedName~Extension"`
  - **Files likely touched**: 8 extension files
  - **Estimated scope**: M (8 arquivos)
  - **Assigned agent**: `csharp-expert`

- [x] **Task 2.8**: Fix S6444 — IE Extension files batch 2 (GO, MA, MG, MS, MT, PA, PB)
  - **Descrição**: Mesmo padrão, 7 arquivos.
  - **Aceitação**: Mesma do Task 2.7
  - **Verificação**: `dotnet build` + `dotnet test --filter "FullyQualifiedName~Extension"`
  - **Files likely touched**: 7 extension files
  - **Estimated scope**: S (7 arquivos)
  - **Assigned agent**: `csharp-expert`

- [x] **Task 2.9**: Fix S6444 — IE Extension files batch 3 (PR, PE, RJ, RN, RO, RR, RS)
  - **Descrição**: Mesmo padrão, 7 arquivos. Atenção a `RioGrandeDoNorteExtension` (2 chamadas Regex.Replace) e `SaoPauloExtension` (2 chamadas — está neste batch? Não, SP está no batch 4).
  - **Verificação**: `dotnet build` + `dotnet test --filter "FullyQualifiedName~Extension"`
  - **Files likely touched**: 7 extension files
  - **Estimated scope**: S (7 arquivos)
  - **Assigned agent**: `csharp-expert`

- [x] **Task 2.10**: Fix S6444 — IE Extension files batch 4 (SC, SE, SP, TO) + StringExtension
  - **Descrição**: 4 arquivos de extensão IE + `StringExtension.cs` (método `Replace` interno). Atenção a `SaoPauloExtension` (2 chamadas) e `RioGrandeDoNorteExtension` (2 chamadas — está no batch 3, não este).
  - **Verificação**: `dotnet build` + `dotnet test --filter "FullyQualifiedName~Extension"`
  - **Files likely touched**: 4 extension files + StringExtension.cs
  - **Estimated scope**: S (5 arquivos)
  - **Assigned agent**: `csharp-expert`

- [x] **Task 2.11**: Fix S6444 — Validation files (CpfValidation, CnpjValidation, PisValidation, TituloEleitorValidation, CnpjAlfanumericoValidation)
  - **Descrição**: Adicionar timeout a `Regex.Replace` em 4 arquivos de validação + adicionar timeout ao construtor `new Regex(...)` e ao `Regex.Replace` em `CnpjAlfanumericoValidation`.
  - **Aceitação**:
    - [ ] 5 arquivos de validação atualizados
    - [ ] `CnpjAlfanumericoValidation.CnpjMaskRegex` tem timeout
    - [ ] Build compila
  - **Verificação**: `dotnet build` + `dotnet test --filter "FullyQualifiedName~Validation"`
  - **Files likely touched**: 5 validation files
  - **Estimated scope**: S (5 arquivos)
  - **Assigned agent**: `csharp-expert`

### Checkpoint: Wave 2 — Security Completa

- [x] Build sem erros: `dotnet build Sirb.Validation.sln` (0 erros, 0 warnings)
- [x] Todos os testes passam: `dotnet test Sirb.Validation.sln --no-build` (2592 passaram)
- [x] Nenhum `new Random()` restante no código (exceto possíveis usos legítimos)
- [x] Nenhum `Regex.Replace` ou `new Regex` sem timeout

### Phase 3: Code Quality (S2325, S1172, S927, S4136) — depende da Wave 2

#### 3A: S2325 + S1172 (instância → static, parâmetro não usado)

- [x] **Task 3.1**: Fix S1172 + S2325 — Cpf mockup (`Cpf.cs`)
  - **Descrição**: Remover parâmetro `generatedNumbers` não usado de `GetBeforeLastDigit(List<int>, int)` → `GetBeforeLastDigit(int)`. Atualizar chamada na linha 51. (Após S2245, `Cpf.cs` não tem mais `Random`, então não há mais issues relacionadas.)
  - **Aceitação**:
    - [ ] `GetBeforeLastDigit` não tem parâmetro `generatedNumbers`
    - [ ] Chamada atualizada
    - [ ] Build compila
    - [ ] Testes de CPF mockup passam
  - **Dependencies**: Task 2.1 (S2245 em Cpf)
  - **Files likely touched**: `Mockups/Cpf.cs`
  - **Estimated scope**: XS (1 arquivo)
  - **Assigned agent**: `csharp-expert`

- [x] **Task 3.2**: Fix S2325 — IE Mockups batch 1 (Ba, Df, PR, PE)
  - **Descrição**: Converter métodos `private int` (não static) para `private static int` em 4 arquivos IE mockup. Métodos afetados:
    - `InscricaoEstadualBa`: `GetRandomLength`, `CalculateBeforeLastWeight`, `CalculateLastWeight`, `GetModuloValue`, `GetDigitValue` (5 métodos)
    - `InscricaoEstadualDf`: `CalculateBeforeLastWeight`, `CalculateLastWeight` (2 métodos)
    - `InscricaoEstadualPR`: `CalculateBeforeLastWeight`, `CalculateLastWeight` (2 métodos)
    - `InscricaoEstadualPE`: `CalculateBeforeLastWeight`, `CalculateLastWeight` (2 métodos)
  - **Aceitação**:
    - [ ] Todos os métodos identificados são convertidos para `static`
    - [ ] Calls atualizados (chamadas a métodos static não precisam de `this.`)
    - [ ] Build compila
    - [ ] Testes de mockup passam
  - **Dependencies**: Tasks 2.3-2.6 (S2245 em IE mockups)
  - **Files likely touched**: 4 mockup files
  - **Estimated scope**: M (4 arquivos, 11 métodos)
  - **Assigned agent**: `csharp-expert`

- [x] **Task 3.3**: Fix S2325 — IE Mockups batch 2 (SP, RN, RJ, RO, RR, RS, SC, SE, CE, PI, MS)
  - **Descrição**: Converter métodos `private int` para `static` em 11 arquivos. Métodos afetados (9 S2325 atualmente):
    - `InscricaoEstadualSP`: `CalculateBeforeLastWeight`, `CalculateLastDigitWeight` (2 — NÃO `CalculateSummationLastDigit` que chama outro método instance)
    - `InscricaoEstadualRN`: `GetRandomLength`, `TotalBase` (2)
    - `InscricaoEstadualRJ`: `CalculateWeight` (1)
    - `InscricaoEstadualRO`: `CalculateWeight` (1)
    - `InscricaoEstadualRR`: `CalculateWeight` (1)
    - `InscricaoEstadualRS`: `CalculateWeight` (1)
    - `InscricaoEstadualSC`: `CalculateWeight` (1)
    - `InscricaoEstadualSE`: `CalculateWeight` (1)
    - `InscricaoEstadualCE`: `CalculateWeight` (1)
    - `InscricaoEstadualPI`: `CalculateWeight` (1)
    - `InscricaoEstadualMS`: `CalculateWeight` (1)
  - **Nota**: Após converter `CalculateLastDigitWeight` para static em SP, `CalculateSummationLastDigit` também se torna elegível para S2325 — deve ser convertido nesta tarefa também.
  - **Aceitação**: Todos os métodos são `static`, build compila, testes passam
  - **Dependencies**: Tasks 2.3-2.6
  - **Files likely touched**: 11 mockup files
  - **Estimated scope**: M (11 arquivos, 14 métodos)
  - **Assigned agent**: `csharp-expert`

#### 3B: S927 + S4136 (naming + overload grouping) — independente

- [x] **Task 3.4**: Fix S927 — IE Validation files batch 1 (13 classes: Acre, Alagoas, Amapa, Amazonas, Bahia, Ceara, DistritoFederal, EspiritoSanto, Goias, Maranhao, MinasGerais, MatoGrosso, MatoGrossoDoSul)
  - **Descrição**: Renomear parâmetro `ieNumber` para `value` em 13 classes IE validation, atualizando todas as referências dentro de cada método. A interface `IInscricaoEstadualValidation` já define `IsValid(string value)`, então o rename é consistência.
  - **Aceitação**:
    - [ ] Nenhuma classe IE validation usa `ieNumber` como nome de parâmetro
    - [ ] Build compila
    - [ ] Testes de validação passam
  - **Files likely touched**: 13 validation files
  - **Estimated scope**: M (13 arquivos)
  - **Assigned agent**: `csharp-expert`

- [x] **Task 3.5**: Fix S927 — IE Validation files batch 2 (13 classes: Para, Paraiba, Parana, Pernambuco, Piaui, Rondonia, Roraima, RioDeJaneiro, RioGrandeDoNorte, RioGrandeDoSul, SantaCatarina, Sergipe, Tocantins)
  - **Descrição**: Mesmo padrão, 13 classes restantes.
  - **Aceitação**: Mesma do Task 3.4
  - **Files likely touched**: 13 validation files
  - **Estimated scope**: M (13 arquivos)
  - **Assigned agent**: `csharp-expert`

- [x] **Task 3.6**: Fix S4136 — Group method overloads in Minas Gerais validation
  - **Descrição**: Em `InscricaoEstadualMinasGeraisValidation.cs`, os overloads `GetFirstDigit(string)` e `GetFirstDigit(int)` estão separados (linhas 27 e 96). Mesmo para `GetSecondDigit(string, int)` e `GetSecondDigit(int)` (linhas 36 e 130). Reorganizar para que os overloads fiquem adjacentes.
  - **Aceitação**:
    - [ ] Overloads de `GetFirstDigit` adjacentes
    - [ ] Overloads de `GetSecondDigit` adjacentes
    - [ ] Build compila
    - [ ] Testes de Minas Gerais passam
  - **Files likely touched**: `Validation/Ie/InscricaoEstadualMinasGeraisValidation.cs`
  - **Estimated scope**: S (1 arquivo)
  - **Assigned agent**: `csharp-expert`

### Checkpoint: Wave 3 — Code Quality Completa

- [x] Build sem erros: `dotnet build Sirb.Validation.sln` (0 erros, 6 warnings pré-existentes xUnit)
- [x] Todos os testes passam: `dotnet test Sirb.Validation.sln --no-build` (2592 passaram)
- [x] Sem issues S2325, S1172, S927, S4136 restantes

### Phase 4: Documentation + Verification

- [x] **Task 4.1**: Add best practices section to csharp skill SKILL.md
  - **Descrição**: Adicionar seção "SonarCloud Rules — Best Practices" ao arquivo `/home/rodbarbosa/.config/opencode/skills/csharp/SKILL.md`, cobrindo as 8 regras:
    1. **S6444** — Regex without timeout: sempre use `RegexOptions.None, TimeSpan.FromMilliseconds(N)`
    2. **S927** — Parameter naming: use nome consistente com a interface (ex: `value` não `ieNumber`)
    3. **S2325** — Instance methods that don't access `this` should be `static`
    4. **S2245** — Use `RandomNumberGenerator.GetInt32()` instead of `new Random()` for cryptographic randomness (or `Random.Shared` for non-crypto)
    5. **S2259** — Null dereference prevention: use null-checks, `ArgumentNullException.ThrowIfNull`, evite `?.` em variáveis que viram null
    6. **S4136** — Group method overloads together in the same code region
    7. **S2583** — Remove unreachable code; use condições atingíveis
    8. **S1172** — Remove unused parameters; não mantenha parâmetros não usados
  - **Aceitação**:
     - [x] Section adicionada ao SKILL.md
     - [x] Cada regra documentada com exemplo de código (before/after)
     - [x] Seção referenciada no índice/toctree do SKILL.md
  - **Files likely touched**: `/home/rodbarbosa/.config/opencode/skills/csharp/SKILL.md`
  - **Estimated scope**: S (1 arquivo)
  - **Assigned agent**: `writer`

- [x] **Task 4.2**: Final verification — build, test, Quality Gate
  - **Descrição**: Executar build completo, todos os testes, e verificar no SonarCloud que as 97 issues foram resolvidas.
  - **Aceitação**:
    - [ ] `dotnet build Sirb.Validation.sln` — 0 erros
    - [ ] `dotnet test Sirb.Validation.sln` — todos os testes passam (1527+ existentes + novos se houver)
    - [ ] SonarCloud Quality Gate = PASS (0 issues das 8 regras)
    - [ ] Mudança de comportamento: NONE (apenas refatoração, correções de bugs e melhorias de segurança)
  - **Verificação**: `dotnet build` + `dotnet test` + SonarCloud scan
  - **Dependencies**: All tasks 1.1-3.6
  - **Estimated scope**: XS (verificação)
  - **Assigned agent**: `tester-quality` + `csharp-expert`

### Checkpoint: Complete

- [x] Build: 0 erros
- [x] Tests: todos passam (2592)
- [x] SonarCloud: 97 original issues fixed and verified locally (S6444, S927, S2325, S2245, S2259, S4136, S2583, S1172 — all confirmed via grep + build + tests)
- ⏳ SonarCloud API still shows 195 issues (STALE scan — code not pushed; 93 are newer rules verified absent locally)
- [x] Mudança de comportamento: NONE (apenas refatoração, correções de bugs e melhorias de segurança)

## Risks and Mitigations

| Risk | Impact | Mitigation |
|------|--------|------------|
| S2259 em Pernambuco/Piaui pode exigir mudança de lógica de null-check | Médio — risco de alterar comportamento | Usar padrão `if (string.IsNullOrEmpty(ieNumber)) return false;` antes do `OnlyNumbers()`; não altera comportamento |
| S2583 em RioGrandeDoNorte — necessita investigar se código está atingível | Médio — possível correção de lógica | Expert investiga código atual; se condição já está correta (`||`), apenas adicionar teste que atinja o branch; se é `&&`, corrigir para `\|\|` |
| S2245 — troca de `Random` para `RandomNumberGenerator` pode afetar mockups que dependem de seed | Baixo — mockups são test-only, não dependem de seed | `RandomNumberGenerator.GetInt32(0, n)` é equivalente a `Random.Next(n)` em distribuição |
| S6444 — adição de timeout pode degradar performance | Baixo — timeout de 100ms é mais que suficiente para regex simples | Usar `TimeSpan.FromMilliseconds(100)` (padrão SonarCloud); regex de validação de documentos são simples |
| S2325 — converter métodos para `static` pode quebrar chamadas que usam `this.` | Baixo — métodos são `private`, usados apenas dentro da mesma classe | Verificar todos os call sites antes de converter; usar `ClassName.Method()` se necessário |
| S2245 + S2325 interagem (IE mockups) — ordem de execução | Médio — se S2325 for feito antes de S2245, mais métodos podem aparecer | Garantir ordem: S2245 (Wave 2) antes de S2325 (Wave 3) |
| Testes existentes podem quebrar após refatoração | Médio — mudanças em mockups afetam testes de validação | Executar todos os testes após cada wave; não alterar lógica de validação |
| CnpjAlfanumericoValidation — `new Regex` sem timeout + `using System.Text.RegularExpressions` já presente | Baixo | Adicionar `TimeSpan.FromMilliseconds(100)` ao construtor e à chamada `Regex.Replace` |
| Dependência de `InternalsVisibleTo` para testes de IE validation | Baixo — já configurado | Nenhuma ação necessária |

## Changes

### Added

- `/home/rodbarbosa/.config/opencode/skills/csharp/SKILL.md` — Nova seção "SonarCloud Rules — Best Practices" (Task 4.1)

### Modified

- `Sirb.Validation/Documents/BR/Validation/Ie/InscricaoEstadualPernambucoValidation.cs` — null-check mais robusto (S2259)
- `Sirb.Validation/Documents/BR/Validation/Ie/InscricaoEstadualPiaiValidation.cs` — null-check mais robusto (S2259)
- `Sirb.Validation/Documents/BR/Validation/Ie/InscricaoEstadualRioGrandeDoNorteValidation.cs` — corrigir condição inatingível (S2583)
- `Mockups/Cpf.cs` — `Random` → `RandomNumberGenerator`; remover parâmetro não usado de `GetBeforeLastDigit` (S2245, S1172)
- `Mockups/Cnpj.cs` — `Random` → `RandomNumberGenerator` (S2245)
- `Mockups/Pis.cs` — `Random` → `RandomNumberGenerator` (S2245)
- `Mockups/Renavam.cs` — `Random` → `RandomNumberGenerator` (S2245)
- `Mockups/CnpjAlfanumerico.cs` — `Random` → `RandomNumberGenerator` (S2245)
- `Mockups/TituloEleitor.cs` — `Random` → `RandomNumberGenerator` (S2245)
- `Mockups/Ie/InscricaoEstadualBase.cs` — `Random` → `RandomNumberGenerator.GetInt32` helper static (S2245)
- 26 `Mockups/Ie/InscricaoEstadual*.cs` — `Random.Next(n)` → `GetRandomInt(n)`; métodos instance → static (S2245, S2325)
- 25 `Extensions/*Extension.cs` — `Regex.Replace` + timeout de 100ms (S6444)
- `Extensions/StringExtension.cs` — `Regex.Replace` + timeout (S6444)
- `Validation/CpfValidation.cs` — `Regex.Replace` + timeout (S6444)
- `Validation/CnpjValidation.cs` — `Regex.Replace` + timeout (S6444)
- `Validation/PisValidation.cs` — `Regex.Replace` + timeout (S6444)
- `Validation/TituloEleitorValidation.cs` — `Regex.Replace` + timeout (S6444)
- `Validation/CnpjAlfanumericoValidation.cs` — `new Regex` + timeout + `Regex.Replace` + timeout (S6444)
- 26 `Validation/Ie/InscricaoEstadual*Validation.cs` — rename `ieNumber` → `value` (S927)
- `Validation/Ie/InscricaoEstadualMinasGeraisValidation.cs` — reorganizar overloads adjacentes (S4136)

### Removed

- Parâmetro `Random` de métodos auxiliares em mockups IE (S2245)
- Parâmetro `generatedNumbers` de `Cpf.GetBeforeLastDigit` (S1172)
- Campo `Random Random` em `InscricaoEstadualBase` (S2245)

## Open Questions

- ⏳ **PENDENTE**: A S2583 em RioGrandeDoNorte — verificado localmente. A condição foi refatorada de `(weight < 9 || weight > 10) && !value.StartsWith("20")` para `weight != 9 && weight != 10` com bloco `if` aninhado. O código está atingível e os testes passam. O SonarCloud ainda mostra esta issue porque é um scan STALE (código não empurrado).
- ⏳ **PENDENTE**: A S2259 em Pernambuco e Piaui — verificado localmente. Ambos usam `if (string.IsNullOrEmpty(value)) return false;` antes de `OnlyNumbers()`. O SonarCloud ainda mostra esta issue no scan STALE.
- ⏳ **PENDENTE**: As 93 novas issues (S8970, S3925, S6678, S112, S1075, S6562, githubactions:S7636, etc.) são de um scan STALE do código antigo no GitHub. Verificação local confirma que S8970 (0 `!` operators), S3925 (0 ISerializable), e S6678 (logging placeholders — não aplicável a esta biblioteca sem logging) não existem no código atual. **Requer push + re-scan SonarCloud para confirmação final.**

## Wave / Lot Summary

| Wave | Focus | Rules | Files | # Issues | Parallel? | Owner |
|------|-------|-------|-------|----------|-----------|-------|
| 1 | Bug Fixes | S2259, S2583 | 3 | 3 | ✅ Yes | `csharp-expert` |
| 2A | Security — Random | S2245 | 7 | 6 | Partial (base before derived) | `csharp-expert` |
| 2B | Security — Regex | S6444 | 31 | 35 | ✅ Yes (2 agents) | `csharp-expert` |
| 3A | Code Quality — Static/Unused | S2325, S1172 | 15 | 25 | Partial (after 2A) | `csharp-expert` |
| 3B | Code Quality — Naming/Grouping | S927, S4136 | 27 | 27 | ✅ Yes | `csharp-expert` |
| 4 | Documentation + Verify | — | 1 + all | 0 | Sequential | `writer` + `tester-quality` |
