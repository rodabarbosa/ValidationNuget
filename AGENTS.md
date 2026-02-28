# Agents

## Project Overview

**Sirb.Validation** is a .NET NuGet library for validating, formatting (masking), and generating Brazilian documents (CPF, CNPJ, PIS, Título de Eleitor, Inscrição Estadual, Renavam) along with string utility extensions.

## Project Structure

```text
Sirb.Validation/                  # Main library (NuGet package)
├── Documents/BR/
│   ├── Enumeration/              # Enums (State)
│   ├── Interfaces/               # Contracts
│   ├── Mockups/                  # Document generators (test-only helpers)
│   ├── Rules/                    # Validation rules per document
│   └── Validation/               # Validation and masking logic
├── Exceptions/                   # CPF/CNPJ extensions, custom exceptions
└── Extensions/                   # String and state extension methods

Sirb.Validation.Test/             # Unit tests (xUnit)
├── Extensions/                   # Extension method tests
├── Mockups/                      # Generator tests
├── Validations/                  # Validation logic tests
└── Exceptions/                   # Exception tests

Sirb.Validation.Benchmark/        # BenchmarkDotNet performance tests
```

## Key Conventions

- **Language**: All code and XML documentation must be in English.
- **README.md**: Written in Portuguese (pt-BR) — it is the NuGet package description on nuget.org.
- **Testing**: xUnit with 100% code coverage target. Every public method must have corresponding tests.
- **Target Frameworks**: Multi-target from .NET Framework 4.6 through .NET 8.
- **License**: MIT.

## Available Agents

### C# Expert

Use for implementing new validators, extensions, or modifying existing validation logic. Follows .NET conventions and the established patterns in this codebase.

### Expert .NET software engineer mode instructions

Use for architectural decisions, design pattern guidance, and refactoring strategies for the library.

### TDD Red Phase - Write Failing Tests First

Use when adding new document validation features. Write xUnit tests first that define the expected behavior before implementing the validation logic.

### TDD Green Phase - Make Tests Pass Quickly

Use after writing failing tests to implement the minimal code that satisfies the test requirements.

### TDD Refactor Phase - Improve Quality & Security

Use after tests pass to improve code quality, apply security best practices, and enhance design while keeping tests green.

### csharp-dotnet-janitor

Use for cleanup tasks: removing dead code, modernizing syntax, fixing code style, and reducing technical debt.

### debug

Use when investigating test failures or validation logic bugs.
