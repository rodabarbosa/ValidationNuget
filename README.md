# Sirb.Validation

Biblioteca .NET para validação, formatação (máscara) e geração de documentos brasileiros, além de utilitários de string.

[![NuGet](https://img.shields.io/nuget/v/Sirb.Validation.svg)](https://www.nuget.org/packages/Sirb.Validation)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![Quality gate status](https://sonarcloud.io/api/project_badges/measure?project=rodabarbosa_ValidationNuget&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=rodabarbosa_ValidationNuget)

## Documentos suportados

| Documento                             | Validação | Máscara | Geração |
| ------------------------------------- | :-------: | :-----: | :-----: |
| CPF                                   |     ✔     |    ✔    |    ✔    |
| CNPJ                                  |     ✔     |    ✔    |    ✔    |
| CNPJ Alfanumérico (IN RFB 2.229/2024) |     ✔     |    ✔    |    ✔    |
| PIS                                   |     ✔     |    ✔    |    ✔    |
| Título de Eleitor                     |     ✔     |    ✔    |    ✔    |
| Inscrição Estadual (todos os estados) |     ✔     |    ✔    |    ✔    |
| Renavam                               |     ✔     |    —    |    ✔    |

## Instalação

```shell
dotnet add package Sirb.Validation
```

## Uso rápido

### Validação

```csharp
using Sirb.Validation.Exceptions;
using Sirb.Validation.Extensions;
using Sirb.Validation.Documents.BR.Validation;

// CPF
bool cpfValido = "123.456.789-09".IsCpfValid();

// CNPJ
bool cnpjValido = "12.345.678/0001-95".IsCnpjValid();

// CNPJ Alfanumérico (IN RFB 2.229/2024)
bool cnpjAlfanumericoValido = "12ABC34501DE35".IsCnpjAlfanumericoValid();

// PIS
bool pisValido = "123.45678.90-1".IsPisValid();

// Título de Eleitor
bool tituloValido = "12345678901234".IsTituloEleitorValid();

// Renavam
bool renavamValido = "12345678901".IsRenavamValid();

// Inscrição Estadual (requer o enum State para identificar o estado)
using Sirb.Validation.Documents.BR.Enumeration;

bool ieValida = InscricaoEstadualValidation.IsValid(State.SP, "123456789.123");
bool ieValidaRJ = InscricaoEstadualValidation.IsValid(State.RJ, "12.345.67-8");
```

### Máscara / formatação

```csharp
using Sirb.Validation.Exceptions;
using Sirb.Validation.Extensions;
using Sirb.Validation.Documents.BR.Validation;
using Sirb.Validation.Documents.BR.Enumeration;

// CPF
string cpfFormatado = "12345678909".PlaceCpfMask();       // "123.456.789-09"

// CNPJ
string cnpjFormatado = "12345678000195".PlaceCnpjMask();  // "12.345.678/0001-95"

// CNPJ Alfanumérico
string cnpjAlfaFormatado = "12ABC34501DE35".PlaceCnpjAlfanumericoMask();  // "12.ABC.345/01DE-35"

// PIS
string pisFormatado = "12345678901".PlacePisMask();       // "123.45678.90-1"

// Título de Eleitor
string tituloFormatado = "12345678901234".PlaceTituloEleitorMask();

// Inscrição Estadual (requer o enum State)
string ieFormatada = InscricaoEstadualValidation.PlaceMask(State.SP, "123456789123");
string ieFormatadaBA = InscricaoEstadualValidation.PlaceMask(State.BA, "123456789");

// Remover máscara
string ieSemMascara = InscricaoEstadualValidation.RemoveMask("12.345.678-9");
```

### Geração (somente para testes)

```csharp
using Sirb.Validation.Documents.BR.Mockups;
using Sirb.Validation.Documents.BR.Enumeration;

string cpf = Cpf.Generate();
string cnpj = Cnpj.Generate();
string cnpjAlfa = CnpjAlfanumerico.Generate();  // CNPJ Alfanumérico (IN RFB 2.229/2024)
string pis = Pis.Generate();
string titulo = TituloEleitor.Generate();
string renavam = Renavam.Generate();

// Geração de Inscrição Estadual (requer o enum State)
string ie = InscricaoEstadual.Generate(State.SP);
string ieBA = InscricaoEstadual.Generate(State.BA);
```

> **Nota:** Os métodos de geração de documentos existem exclusivamente para auxiliar desenvolvedores durante testes. Não utilize valores gerados em produção.

### Utilitários de string

```csharp
using Sirb.Validation.Extensions;

"abc123".OnlyNumbers();           // "123"
"abc123".NoNumbers();             // "abc"
"123.456-78".RemoveMask();        // "12345678"
"olá mundo".ToCapitalizeAll();    // "Olá Mundo"
"olá mundo".ToCapitalize();       // "Olá mundo"
"café".RemoveLatinCharacters();   // "cafe"
"abc".Reverse();                  // "cba"
```

## Compatibilidade

.NET 8 | .NET 9 | .NET 10

## Histórico de versões

### 1.6.0

- Inclusão de validação, máscara e geração de CNPJ Alfanumérico (novo formato RFB IN 2.229/2024).
- Novos métodos: `IsCnpjAlfanumericoValid()`, `PlaceCnpjAlfanumericoMask()`, `CnpjAlfanumerico.Generate()`.
- Retrocompatível com CNPJ numérico.

### 1.5.0

- Removido suporte a .NET Framework, .NET Standard, .NET Core 3.1, .NET 5, 6 e 7.
- Compatível apenas com .NET 8, 9 e 10.

### 1.4.0

- Inclusão de compatibilidade a .NET 9.

### 1.3.1

- Inclusão de compatibilidade a .NET 8.
- Bug fix.

### 1.3.0

- Inclusão de compatibilidade a .NET 7.0.

### 1.2.1

- Alterado para que dependência seja uma versão mínima e não uma versão fixa.
- Métodos foram divididos em menores partes para melhor tratamento de complexidade.
- Máscara para CPF e CNPJ convertida para extensão com acesso público.
- Máscara para Inscrição Estadual convertida para extensão com acesso público.

### 1.2.0

- Inclusão de compatibilidade a .NET 6.0.

### 1.1.0

- Inclusão de compatibilidade a .NET 5.

### 1.0.2

- Inclusão de validador de Renavam.
- Inclusão de gerador de Renavam.

### 1.0.1

- Melhoramento de performance.
- Incluso pacote para .NET Core 3.

### 1.0.0

- Disponibilizado validadores para CPF, CNPJ, PIS e Título de Eleitor.

## Licença

[MIT](LICENSE) — Desde 2018.

Repositório: [github.com/rodabarbosa/ValidationNuget](https://github.com/rodabarbosa/ValidationNuget)
