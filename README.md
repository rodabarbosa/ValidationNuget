# Sirb.Validation

Biblioteca .NET para validação, formatação (máscara) e geração de documentos brasileiros.

[![NuGet](https://img.shields.io/nuget/v/Sirb.Validation.svg)](https://www.nuget.org/packages/Sirb.Validation)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)

## Documentos suportados

| Documento                             | Validação | Máscara | Geração |
| ------------------------------------- | :-------: | :-----: | :-----: |
| CPF                                   |     ✔     |    ✔    |    ✔    |
| CNPJ                                  |     ✔     |    ✔    |    ✔    |
| PIS                                   |     ✔     |    ✔    |    ✔    |
| Título de Eleitor                     |     ✔     |    ✔    |    ✔    |
| Inscrição Estadual (todos os estados) |     ✔     |    ✔    |    ✔    |
| Renavam                               |     ✔     |    —    |    ✔    |

## Instalação

```shell
dotnet add package Sirb.Validation
```

## Uso rápido

```csharp
using Sirb.Validation.Extensions;
using Sirb.Validation.Exceptions;

// Validação
bool cpfValido = "123.456.789-09".IsCpfValid();
bool cnpjValido = "12.345.678/0001-95".IsCnpjValid();
bool pisValido = "123.45678.90-1".IsPisValid();
bool tituloValido = "1234567890".IsTituloEleitorValid();
bool renavamValido = "12345678901".IsRenavamValid();

// Máscara
string cpfFormatado = "12345678909".PlaceCpfMask();       // "123.456.789-09"
string cnpjFormatado = "12345678000195".PlaceCnpjMask();  // "12.345.678/0001-95"
string pisFormatado = "12345678901".PlacePisMask();

// Geração (somente para testes)
using Sirb.Validation.Documents.BR.Mockups;

string cpf = Cpf.Generate();
string cnpj = Cnpj.Generate();
string pis = Pis.Generate();
string titulo = TituloEleitor.Generate();
string renavam = Renavam.Generate();
```

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

> **Nota:** Os métodos de geração de documentos existem exclusivamente para auxiliar desenvolvedores durante testes. Não utilize valores gerados em produção.

## Histórico de versões

### 1.4.0

- Removido suporte a .NET Framework, .NET Standard, .NET Core 3.1, .NET 5, 6 e 7.
- Compatível apenas com .NET 8, 9 e 10.

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

[MIT](LICENSE)
