# Implementation Plan: 100% Code Coverage Tests

**Status:** IN REVIEW

## Overview

Adicionar testes unitários ao projeto `Sirb.Validation` para atingir **100% de cobertura de linhas e branches** (atual: 94,5% linhas, 73,4% branches; 121 linhas e 258 branches não cobertos em 82 arquivos). A estratégia categoriza os gaps em 6 ondas: arquivos com 0% de cobertura, testes de null/edge para classes de validação, testes de null/edge para validações de IE, testes de null/empty para extensões, testes de mockups probabilísticos, e branches mortos que exigem correção de código-fonte.

**Baseline atual (medido via `dotnet test --collect:"XPlat Code Coverage"` + reportgenerator):**
- Line rate: 94,48% (2072/2193 linhas cobertas, 121 não cobertas)
- Branch rate: 73,37% (711/969 branches cobertos, 258 não cobertos)
- Testes existentes: 1527 (todos passando)
- `InternalsVisibleTo` configurado para `Sirb.Validation.Test` → classes `internal` são acessíveis

## Arquitetura Decisions

- **ADR-0001**: Testes de mockup probabilísticos usarão loops com 2000+ iterações para cobrir branches aleatórios. Para probabilidades < 0,1%, usar reflection em métodos privados.
- **ADR-0002**: Para branches verdadeiramente mortos (código impossível de atingir), o plano registra como `⏳ PENDENTE` — a cobertura de 100% exige correção de código-fonte, que está fora do escopo deste plano (política: apenas adição de testes).
- **ADR-0003**: IE validations `internal` são testadas diretamente via `InternalsVisibleTo`, sem passar pelo `InscricaoEstadualValidation.IsValid` que faz null-check antecipado.

## Task List

### Wave 1: Arquivos com 0% de cobertura (independente, paralelável)

- [ ] **Task 1**: `IntArrayExtension.cs` — teste direto do método `ConvertToString(int[])`
  - **Arquivo de teste**: criar `Sirb.Validation.Test/Extensions/IntArrayExtensionTest.cs`
  - **Casos de teste**: array vazio, array com dígitos 0-9, array com múltiplos dígitos
  - **Aceitação**: 100% L e B para `IntArrayExtension.cs`
  - **Owner**: `tester-quality` + `csharp-expert`
  - **Escopo**: XS (1 arquivo de teste)
  - **Arquivos tocados**: `Sirb.Validation.Test/Extensions/IntArrayExtensionTest.cs`

- [ ] **Task 2**: `InscricaoEstadualAc.cs` (mockup) — corrigir teste contornado e testar saída de `Generate()`
  - **Observação**: O teste existente (`InscricaoEstadualAcreMockupTest`) tem `Assert.True(true); return;` (contornado). O comentário indica bug conhecido: o mockup de AC gera IEs que falham na validação.
  - **Arquivo de teste**: modificar `Sirb.Validation.Test/Mockups/InscricaoEstadualAcreMockupTest.cs`
  - **Casos de teste**: gerar múltiplos CPFs via `InscricaoEstadual.Generate(State.AC)`, validar formato (13 dígitos, prefixo "01") sem validar (bug conhecido)
  - **Aceitação**: 100% L e B para `InscricaoEstadialAc.cs`
  - **Owner**: `tester-quality` + `csharp-expert`
  - **Escopo**: S (1 arquivo modificado)
  - **Arquivos tocados**: `Sirb.Validation.Test/Mockups/InscricaoEstadualAcreMockupTest.cs`

### Wave 2: Testes de null/edge para classes de validação (independente, paralelizável)

- [ ] **Task 3**: `CpfValidation.cs` — cobrir PlaceMask(null/empty), GetIssuingState (todos os 10 cases + throw + default), GetModulusForDigitComparison(value==10)
  - **Arquivo de teste**: modificar `Sirb.Validation.Test/Validations/CpfValidationTest.cs`
  - **Casos de teste**:
    - `PlaceMask(null)` → retorna null/default
    - `PlaceMask("")` → retorna null/default
    - `PlaceMask("  ")` → retorna null/default
    - `GetIssuingState` com CPF válido para cada caso 0-9 (gerar via `Cpf.Generate(State.XX)` para estados 0-9)
    - `GetIssuingState` com CPF inválido → `InvalidOperationException`
  - **Aceitação**: 100% L e B para `CpfValidation.cs` (exceto `default` case — ⏳ PENDENTE)
  - **Owner**: `tester-quality` + `csharp-expert`
  - **Escopo**: M (1 arquivo modificado, 15+ novos casos)
  - **Arquivos tocados**: `Sirb.Validation.Test/Validations/CpfValidationTest.cs`

- [ ] **Task 4**: `InscricaoEstadualValidation.cs` — RemoveMask(null), PlaceMask(null/empty/whitespace), IsValid(null/empty)
  - **Arquivo de teste**: criar `Sirb.Validation.Test/Validations/InscricaoEstadualValidationTest.cs`
  - **Casos de teste**:
    - `RemoveMask(null)` → retorna null
    - `PlaceMask(State.SP, null)` → retorna null
    - `PlaceMask(State.SP, "")` → retorna null
    - `PlaceMask(State.SP, "  ")` → retorna null
    - `PlaceMask(State.SP, "123456789123")` → máscara aplicada
    - `IsValid(State.SP, null)` → false
    - `IsValid(State.SP, "")` → false
  - **Aceitação**: 100% L e B para `InscricaoEstadualValidation.cs`
  - **Owner**: `tester-quality` + `csharp-expert`
  - **Escopo**: S (1 arquivo novo)
  - **Arquivos tocados**: `Sirb.Validation.Test/Validations/InscricaoEstadualValidationTest.cs`

- [ ] **Task 5**: `PisValidation.cs` — IsValid(null), PlaceMask(null/empty), RemoveMask(null)
  - **Arquivo de teste**: modificar `Sirb.Validation.Test/Validations/PisValidationTest.cs`
  - **Casos de teste**:
    - `IsValid(null)` → false
    - `IsValid("")` → false
    - `IsValid("   ")` → false (após RemoveMask/OnlyNumbers → empty)
    - `PlaceMask(null)` → null
    - `PlaceMask("")` → null
    - `RemoveMask(null)` → null
  - **Aceitação**: 100% L e B
  - **Owner**: `tester-quality`
  - **Escopo**: S (1 arquivo)
  - **Arquivos tocados**: `Sirb.Validation.Test/Validations/PisValidationTest.cs`

- [ ] **Task 6**: `RenavamValidation.cs` — IsValid(null), IsValid(c valor com length inválido)
  - **Arquivo de teste**: modificar `Sirb.Validation.Test/Validations/RenavamValidationTest.cs`
  - **Casos de teste**:
    - `IsValid(null)` → false
    - `IsValid("")` → false
    - `IsValid("123")` → false (length != 9 && != 11)
    - `RemoveMask(null)` → null (cobertura de StringExtension.RemoveMask)
  - **Aceitação**: 100% L e B
  - **Owner**: `tester-quality`
  - **Escopo**: S (1 arquivo)
  - **Arquivos tocados**: `Sirb.Validation.Test/Validations/RenavamValidationTest.cs`

- [ ] **Task 7**: `TituloEleitorValidation.cs` — IsValid(null), PlaceMask(null/empty), digit > 9 case
  - **Arquivo de teste**: modificar `Sirb.Validation.Test/Validations/TituloEleitorValidationTest.cs`
  - **Casos de teste**:
    - `IsValid(null)` → false
    - `PlaceMask(null)` → null
    - `PlaceMask("")` → null
    - `PlaceMask("  ")` → null
    - `IsValid` com título gerado onde `total % 11 > 9` (digit > 9 → 0) — verificar via loop
  - **Aceitação**: 100% L e B
  - **Owner**: `tester-quality`
  - **Escopo**: S (1 arquivo)
  - **Arquivos tocados**: `Sirb.Validation.Test/Validations/TituloEleitorValidationTest.cs`

- [ ] **Task 8**: `CnpjAlfanumericoValidation.cs` — linha 84 (`!char.IsDigit(value[13])`)
  - **Arquivo de teste**: modificar `Sirb.Validation.Test/Validations/CnpjAlfanumericoValidationTests.cs`
  - **Casos de teste**: CNPJ alfanumérico com 14 chars, value[12] é dígito, value[13] não é dígito (ex: "1234567890123A")
  - **Aceitação**: 100% L e B
  - **Owner**: `tester-quality`
  - **Escopo**: S (1 arquivo)
  - **Arquivos tocados**: `Sirb.Validation.Test/Validations/CnpjAlfanumericoValidationTests.cs`

- [ ] **Task 9**: `CnpjValidation.cs` — PlaceMask(null/empty/whitespace), IsValid(null/empty)
  - **Arquivo de teste**: modificar `Sirb.Validation.Test/Validations/CnpjValidationTest.cs`
  - **Casos de teste**:
    - `PlaceMask(null)` → null
    - `PlaceMask("")` → null
    - `PlaceMask("   ")` → null
    - `PlaceMask("12.345.678/0001-95")` → máscara aplicada
    - `IsValid(null)` → false (via RemoveMask → OnlyNumbers → null → HasValidParams)
    - `IsValid("")` → false
    - `IsValid("123")` → false (wrong length)
  - **Aceitação**: 100% L e B
  - **Owner**: `tester-quality`
  - **Escopo**: S (1 arquivo)
  - **Arquivos tocados**: `Sirb.Validation.Test/Validations/CnpjValidationTest.cs`

- [ ] **Task 10**: `StringExtension.cs` — RemoveMask(null)
  - **Arquivo de teste**: modificar `Sirb.Validation.Test/Extensions/StringExtensionTest.cs`
  - **Casos de teste**: `null.RemoveMask()` → null (cobertura do `?.` no null path)
  - **Aceitação**: 100% L e B para `StringExtension.cs`
  - **Owner**: `tester-quality`
  - **Escopo**: XS (1 arquivo)
  - **Arquivos tocados**: `Sirb.Validation.Test/Extensions/StringExtensionTest.cs`

- [ ] **Task 11**: `StateNotFoundException.cs` — null/empty message
  - **Arquivo de teste**: modificar `Sirb.Validation.Test/Exceptions/StateNotFoundExceptionTest.cs`
  - **Casos de teste**:
    - `new StateNotFoundException(null as string)` → Message = "State not found"
    - `new StateNotFoundException("")` → Message = "State not found"
    - `StateNotFoundException.ThrowIf(true, null)` → throws (cobertura de `null?.Trim()`)
  - **Aceitação**: 100% L e B
  - **Owner**: `tester-quality`
  - **Escopo**: S (1 arquivo)
  - **Arquivos tocados**: `Sirb.Validation.Test/Exceptions/StateNotFoundExceptionTest.cs`

### Checkpoint: Wave 1 + 2

- [ ] Build sem erros
- [ ] Todos os testes existentes continuam passando
- [ ] Linhas e branches dos arquivos da Wave 1-2 em 100%

### Wave 3: Testes de null/edge para validações de IE (independente, paralelizável)

**Estratégia**: Cada IE validation é uma classe `internal` (ou `public`) que implementa `IInscricaoEstadualValidation` (também `internal`). Para cobrir o branch `?.` null, os testes chamam a validação interna diretamente (não através de `InscricaoEstadualValidation.IsValid` que faz null-check antecipado).

- [ ] **Task 12**: Teste consolidado de null/empty para todas as 27 IE validations
  - **Arquivo de teste**: criar `Sirb.Validation.Test/Validations/Ie/InscricaoEstadualValidationNullTest.cs`
  - **Casos de teste**: data-driven com `typeof(...)` para todas as 27 classes. Para cada classe, chamar `IsValid(null)` e `IsValid("")` diretamente.
    - Classes sem null check (Pernambuco, Piaui, SaoPaulo): usar `Assert.Throws<NullReferenceException>`
    - Classes com null check (demais): `Assert.False(result)`
  - **Aceitação**: Cobertura do `?.` null branch em todas as 27 IE validation classes
  - **Owner**: `tester-quality` + `csharp-expert`
  - **Escopo**: M (1 arquivo, 27 × 2 casos via Theory)
  - **Arquivos tocados**: `Sirb.Validation.Test/Validations/Ie/InscricaoEstadualValidationNullTest.cs`

- [ ] **Task 13**: IE validations com branches específicos — Amapa ranges + Goias rest==1 + Pará/Maranhão/Roraima prefixos + Tocantins 9-digit
  - **Arquivos de teste**: modificar arquivos existentes em `Sirb.Validation.Test/Validations/Ie/`
    - `InscricaoEstadualValidationApTest.cs`: adicionar casos para as 3 faixas de `GetDigitVarification` (3017001-3019022 → digitVerification=1; 3000001-3017000 → digitVerification=0; >=3019023 → digitVerification=0)
    - `InscricaoEstadualValidationGoTest.cs`: adicionar caso onde `rest == 1` com valor >= 10103105 (digit=1)
    - `InscricaoEstadualValidationMaTest.cs`: adicionar caso com length != 9 e não começa com "12"
    - `InscricaoEstadualValidationPaTest.cs`: adicionar caso com length != 9 e não começa com "15"
    - `InscricaoEstadualValidationRrTest.cs`: adicionar caso com length != 9 e não começa com "24"
    - `InscricaoEstadualValidationToTest.cs`: adicionar caso de 9 dígitos (ver Task 15)
  - **Aceitação**: Branches específicos cobertos
  - **Owner**: `tester-quality`
  - **Escopo**: L → DECOMPOSER em tasks menores
  - **Arquivos tocados**: 6 arquivos de teste IE existentes

> **Decomposição da Task 13** (L → S/M):
> - **Task 13a**: AmapaValidation ranges → modificar `InscricaoEstadualValidationApTest.cs` (S)
> - **Task 13b**: GoiasValidation rest==1 → modificar `InscricaoEstadualValidationGoTest.cs` (S)
> - **Task 13c**: Maranhao/Para/Roraima prefix branches → modificar 3 arquivos de teste (M)
> - **Task 13d**: Tocantins 9-digit path → ⏳ PENDENTE (bug no código: `Substring(1, value.Length)` lança exceção quando length==9)

- [ ] **Task 14**: IE validations com branches de `||` não cobertos (Alagoas, Ceara, SantaCatarina, Sergipe, RioGrandeDoSul, EspiritoSanto, Paraiba, MatoGrossoDoSul, DistritoFederal, MinasGerais)
  - **Arquivos de teste**: modificar arquivos de teste IE existentes
  - **Casos de teste**: adicionar casos que ativam branches de `||` não cobertos (ex: value[2] not in allowedDigits para Alagoas; digit == 10 ou 11 para outras)
  - **Aceitação**: Branches `||` cobertos
  - **Owner**: `tester-quality`
  - **Escopo**: M (7-8 arquivos)
  - **Arquivos tocados**: 7-8 arquivos de teste IE existentes

### Checkpoint: Wave 3

- [ ] Build sem erros
- [ ] Todos os testes existentes continuam passando
- [ ] IE validations: todas as branches `?.` cobertas

### Wave 4: Testes de null/empty para extensões (independente, paralelizável)

**Estratégia**: Cada classe de extensão IE mask tem o mesmo padrão: `value?.OnlyNumbers()` + `string.IsNullOrEmpty(cleanValue) ? default : Regex.Replace(...)`. Adicionar testes de null e empty string para cada uma.

- [ ] **Task 15**: Testes de null/empty para extensões de AC, AL, AP, AM, BA (5 arquivos)
  - **Arquivos**: `AcreExtensionTest`, `AlagoasExtensionTest`, `AmapaExtensionTest`, `AmazonasExtensionTest`, `BahiaExtensionTest`
  - **Casos de teste**: `null.MethodName()` → null; `"".MethodName()` → null
  - **Owner**: `tester-quality`
  - **Escopo**: S (5 arquivos)

- [ ] **Task 16**: Testes de null/empty para extensões de CE, DF, ES, GO, MA (5 arquivos)
  - **Arquivos**: `CearaExtensionTest`, `DistritoFederalExtensionTest`, `EspiritoSantoExtensionTest`, `GoiasExtensionTest`, `MaranhaoExtensionTest`
  - **Owner**: `tester-quality`
  - **Escopo**: S (5 arquivos)

- [ ] **Task 17**: Testes de null/empty para extensões de MG, MS, MT, PA, PB, PE, PI (7 arquivos)
  - **Owner**: `tester-quality`
  - **Escopo**: S (7 arquivos)

- [ ] **Task 18**: Testes de null/empty para extensões de PR, RJ, RN, RO, RR, RS, SC, SE, SP, TO (10 arquivos)
  - **Owner**: `tester-quality`
  - **Escopo**: M (10 arquivos)

- [ ] **Task 19**: Testes de null/empty para `StringExtension.RemoveMask` e `EspiritoSantoExtension`
  - **Owner**: `tester-quality`
  - **Escopo**: XS (2 arquivos)

### Checkpoint: Wave 4

- [ ] Build sem erros
- [ ] Extension classes: 100% branch coverage

### Wave 5: Cobertura de mockups (independente, paralelizável)

**Estratégia**: Mockups usam `Random` não controlável. Para branches probabilísticos, rodar `Generate()` em loops (2000+ iterações). Para probabilidades < 0,1%, usar reflection em métodos privados.

- [ ] **Task 20**: Mockups IE — loop de Generate (2000 iterações) para todos os estados
  - **Arquivos de teste**: modificar arquivos de teste de mockup existentes
  - **Casos de teste**: para cada estado, rodar `InscricaoEstadual.Generate(State.XX)` 2000x e validar
  - **Owner**: `tester-quality` + `csharp-expert`
  - **Escopo**: L → DECOMPOSER

> **Decomposição**:
> - **Task 20a**: Mockups com branches simples (SC, RS, RJ, ES, MA, PA, MS, RO, AL, CE, DF, PB, PE, PI) — 14 arquivos (M)
> - **Task 20b**: Mockups com branches complexos (GO, TO, AP, BA, RN, SP, MG) — modificar 7 arquivos (M)
> - **Task 20c**: AC mockup — corrigir teste contornado (S) (mesmo que Task 2)

- [ ] **Task 21**: Mockup `InscricaoEstadialAp` — branches de baixa probabilidade via reflection
  - **Caso**: `CalculateLastDigit` private static com ranges < 0,2% de probabilidade
  - **Casos de teste**: usar reflection para chamar `CalculateLastDigit` com inputs controlados:
    - `x` na faixa [3017001, 3019022] → auxDigit=1, +9
    - `x` na faixa [3000001, 3017000] → auxDigit=0, +5
    - `digit == 10` → return 0
    - `digit == 11` → return auxDigit
    - `digit` normal → return digit
  - **Owner**: `tester-quality` + `csharp-expert`
  - **Escopo**: S (1 arquivo, reflection)

- [ ] **Task 22**: Mockup `InscricaoEstadualGO` — branches de baixa probabilidade via reflection
  - **Caso**: `CalculateLastDigit` private static com `remainder == 1` + range check
  - **Casos de teste**: reflection para chamar `CalculateLastDigit` com:
    - `remainder == 1` && value in [10103105, 10119997] → return 1
    - `remainder == 1` && value fora do range → return 0
    - `remainder == 0` → return 0
    - `remainder > 1` → return 11 - remainder
  - **Owner**: `tester-quality` + `csharp-expert`
  - **Escopo**: S

- [ ] **Task 23**: Mockup `TituloEleitor` — cobrir `remainder > 9` em `GetDigitValue`
  - **Arquivo de teste**: modificar `Sirb.Validation.Test/Mockups/TituloEleitorMockupTest.cs`
  - **Casos de teste**: rodar `TituloEleitor.Generate()` 500x (probabilidade ~9% por chamada de `remainder == 10`)
  - **Owner**: `tester-quality`
  - **Escopo**: XS (1 arquivo)

- [ ] **Task 24**: Mockup `CnpjAlfanumerico` — cobrir `IntArrayExtensions.ConvertToString` else branch (line 90)
  - **Arquivo de teste**: criar ou modificar teste
  - **Casos de teste**: chamar `IntArrayExtensions.ConvertToString(new[] { 15 })` (valor fora de 0-9 e 17-42) → char '0'
  - **Owner**: `tester-quality`
  - **Escopo**: XS

- [ ] **Task 25**: Mockup `Cpf` — testar todos os 10 estados para `GetIssuingState`
  - **Arquivo de teste**: modificar `Sirb.Validation.Test/Mockups/CpfMockupTest.cs`
  - **Casos de teste**: `Cpf.Generate(State.AC)` ... `Cpf.Generate(State.MA)` → validar e chamar `GetIssuingState`
  - **Owner**: `tester-quality`
  - **Escopo**: S

- [ ] **Task 26**: Mockups restantes — BA, RN, SP, MG com branches probabilísticos
  - **Casos de teste**: rodar Generate em loops (2000x) para BA (GetRandomLength), RN (GetRandomLength, TotalBase), SP (CalculateBeforeLastWeight index>6)
  - **Owner**: `tester-quality`
  - **Escopo**: M (3 arquivos de mockup)

### Checkpoint: Wave 5

- [ ] Mockups: 100% L, 100% B (exceto branches documentados como PENDENTE)
- [ ] Todos os testes existentes continuam passando

### Wave 6: Branches mortos — ⏳ PENDENTE (requer alteração de código-fonte)

Os seguintes branches são **impossíveis de cobrir** com testes porque o código-fonte contém branches mortos (bugs):

- [ ] **Task 27**: `InscricaoEstadualRioGrandeDoNorteValidation.cs` — `weight < 9 && weight > 10` é sempre falso (dead branch). Não pode ser coberto sem corrigir o código-fonte (provavelmente `&&` deveria ser `||`).
  - **Owner**: `architecture` (decisão de ADR) → depois `csharp-expert`
  - **Escopo**: XS (correção de 1 linha)
  - **Status**: ⏳ PENDENTE — bloqueado por política de "apenas adição de testes"

- [ ] **Task 28**: `InscricaoEstadualTocantinsValidation.cs` — `value.Substring(1, value.Length)` lança `ArgumentOutOfRangeException` quando `value.Length == 9`. O branch pode ser "coberto" com `Assert.Throws`, mas é código defasado.
  - **Owner**: `architecture` → depois `csharp-expert`
  - **Status**: ⏳ PENDENTE — bug de Substring

- [ ] **Task 29**: `InscricaoEstadualPernambucoValidation.cs` + `InscricaoEstadualPiauiValidation.cs` + `InscricaoEstadualSaoPauloValidation.cs` — NullReferenceException quando `ieNumber` é null (faltando null check).
  - **Owner**: `architecture` → depois `csharp-expert`
  - **Status**: ⏳ PENDENTE — falta null check

- [ ] **Task 30**: `CpfValidation.cs` — `default` case no switch de `GetIssuingState` (case implícito não atingível, pois o 9º dígito do CPF é sempre 0-9).
  - **Owner**: `architecture` → depois `csharp-expert`
  - **Status**: ⏳ PENDENTE — dead default case

### Checkpoint: Wave 6

- [ ] Todos os branches mortos documentados
- [ ] Decisão de correção de código-fonte registrada em ADR

### Wave 7: Correção de código-fonte (após aprovação de ADR)

- [ ] **Task 31**: `InscricaoEstadualRioGrandeDoNorteValidation.cs` — corrigir `weight < 9 && weight > 10` → `(weight < 9 || weight > 10)`
- [ ] **Task 32**: `InscricaoEstadualTocantinsValidation.cs` — corrigir `value.Substring(1, value.Length)` → `value.Substring(2)`
- [ ] **Task 33**: `InscricaoEstadualPernambucoValidation.cs` — adicionar null check
- [ ] **Task 34**: `InscricaoEstadualPiauiValidation.cs` — adicionar null check
- [ ] **Task 35**: `InscricaoEstadualSaoPauloValidation.cs` — adicionar null check
- [ ] **Task 36**: `CpfValidation.cs` — remover `default` case do switch (ou marcar como unreachable)
- [ ] **Task 37**: Adicionar testes que cobrem os branches corrigidos
- [ ] **Task 38**: Re-executar coverage para confirmar 100% L e 100% B

### Checkpoint Final

- [ ] Coverage: 100% linhas e 100% branches
- [ ] Todos os 1527+ testes existentes passam
- [ ] Novos testes seguem padrões do projeto (xUnit, [Theory]/[InlineData], [Fact])
- [ ] Build sem erros
- [ ] Nenhuma alteração de comportamento no código-fonte principal (apenas adição de null checks e correção de bugs de Substring/logíncia)

## Risks and Mitigations

| Risk | Impact | Mitigation |
|------|--------|------------|
| Branches mortos em código-fonte (RioGrandeDoNorte, Tocantins, Pernambuco, Piaui, SaoPaulo, CpfValidation default) | Alto — 100% coverage impossível sem correção | Documentado como ⏳ PENDENTE; correção proposta em Wave 7 pós-aprovação |
| Mockups probabilísticos — branches com < 0,1% de probabilidade (AP ranges) | Médio — loops não garantem 100% | Usar reflection para métodos privados quando loops não forem suficientes |
| AC mockup tem bug conhecido (validação falha) | Médio — não pode testar via IsValid | Testar formato do output do Generate() sem validar |
| 82 arquivos com gaps — risco de regressão | Médio — muitos arquivos modificados | Executar build + todos os testes após cada wave |
| CnpjAlfanumerico mockup usa `IntArrayExtensions` (diferente de `IntArrayExtension`) | Baixo — pode causar ambiguidade de extension method | Testar `IntArrayExtension` via fully-qualified call; `IntArrayExtensions` via namespace |

## Dependencies

- Waves 1-4 são independentes e podem ser paralelizadas
- Wave 5 depende parcialmente de Wave 1 (mockup AC test fix) e Wave 2 (Cpf GetIssuingState)
- Wave 6 (correção de código-fonte) depende de aprovação de ADR e deve ser executada após Waves 1-5
- Wave 7 depende de Wave 6

## Parallelization Strategy

- **Safe to parallelize**: Waves 1, 2, 3, 4 (arquivos de teste independentes)
- **Needs coordination**: Wave 5 (mockups compartilham `Cpf.Generate()` e `InscricaoEstadual.Generate()`)
- **Sequential**: Wave 6 → Wave 7 (correção de código depois de documentação)

## Changes

### Added

- `Sirb.Validation.Test/Extensions/IntArrayExtensionTest.cs` — testes para `IntArrayExtension.ConvertToString`
- `Sirb.Validation.Test/Validations/InscricaoEstadualValidationTest.cs` — testes para RemoveMask/PlaceMask/IsValid com null/empty
- `Sirb.Validation.Test/Validations/Ie/InscricaoEstadualValidationNullTest.cs` — testes de null para todas as IE validations
- ~1000 novos casos de teste (loops de mockup + data-driven null tests)

### Modified

- `Sirb.Validation.Test/Validations/CpfValidationTest.cs` — adicionar GetIssuingState, PlaceMask, GetModulusForDigitComparison
- `Sirb.Validation.Test/Validations/PisValidationTest.cs` — adicionar null/edge cases
- `Sirb.Validation.Test/Validations/RenavamValidationTest.cs` — adicionar null/edge cases
- `Sirb.Validation.Test/Validations/TituloEleitorValidationTest.cs` — adicionar null + digit>9
- `Sirb.Validation.Test/Validations/CnpjAlfanumericoValidationTests.cs` — adicionar value[13] test
- `Sirb.Validation.Test/Validations/CnpjValidationTest.cs` — adicionar null/edge cases
- `Sirb.Validation.Test/Exceptions/StateNotFoundExceptionTest.cs` — adicionar null/empty message
- `Sirb.Validation.Test/Extensions/StringExtensionTest.cs` — adicionar RemoveMask(null)
- 24 IE extension test files — adicionar null/empty tests
- 27 IE validation test files — adicionar null/empty tests + specific branches
- 16 IE mockup test files — adicionar loops e corrigir AC bypass
- `Sirb.Validation.Test/Mockups/CpfMockupTest.cs` — adicionar todos os 10 estados
- `Sirb.Validation.Test/Mockups/TituloEleitorMockupTest.cs` — aumentar iterações

## Open Questions

- ⏳ **PENDENTE**: A correção de branches mortos (Wave 6-7) exige alterações no código-fonte principal (`InscricaoEstadualRioGrandeDoNorteValidation`, `InscricaoEstadualTocantinsValidation`, `InscricaoEstadualPernambucoValidation`, `InscricaoEstadualPiauiValidation`, `InscricaoEstadualSaoPauloValidation`, `CpfValidation`). A política atual permite apenas adição de testes. **Precisa aprovação do usuário para modificar código-fonte.**
