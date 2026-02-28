# Copilot Instructions — Sirb.Validation

## Project Context

This is a .NET NuGet library (`Sirb.Validation`) for validating, formatting, and generating Brazilian documents. It is published to nuget.org and the `README.md` serves as the package description on the NuGet gallery.

## Language Rules

- All **code** (class names, method names, variables, parameters) must be in **English**.
- All **XML documentation comments** (`<summary>`, `<param>`, `<returns>`, `<exception>`) must be in **English**.
- The `README.md` is in **Portuguese (pt-BR)** because it is displayed on nuget.org for a Brazilian audience.

## Code Standards

### General

- Target multiple frameworks: .NET Framework 4.6+, .NET Standard 2.0+, .NET Core 3.1, .NET 5–8.
- Use extension methods as the public API surface (e.g., `string.IsCpfValid()`).
- Keep validation logic in dedicated classes under `Documents/BR/Validation/`.
- Keep document generators under `Documents/BR/Mockups/` — these exist only to assist developers during testing.
- Follow existing naming conventions: `Is[Document]Valid`, `Place[Document]Mask`, `Generate`.

### XML Documentation

Every public method, class, and property must have XML documentation in English:

```csharp
/// <summary>
/// Validates whether the given string is a valid CPF number.
/// </summary>
/// <param name="value">The string to validate.</param>
/// <returns><c>true</c> if the value is a valid CPF; otherwise, <c>false</c>.</returns>
public static bool IsCpfValid(this string value)
```

### Code Style

- Use `this string value` for extension method parameters.
- Prefer early returns for invalid input.
- Avoid magic numbers — use named constants.
- Keep methods small and focused (single responsibility).

## Testing Standards

- Framework: **xUnit** (`Xunit` namespace).
- Test project: `Sirb.Validation.Test`.
- Coverage goal: **100%** of all public methods.
- Every public method must have at least one test covering the valid case and one covering the invalid/edge case.
- Use `[Theory]` with `[InlineData]` for parameterized tests.
- Use `[Fact]` for single-case tests.
- Test naming: method name that describes the scenario (e.g., `Validate`, `PlaceMask`, `ReturnFalseForInvalidValue`).
- Test file naming: `[ClassName]Test.cs` mirroring the source structure.
- Test structure follows the source layout:
    - `Extensions/` → tests for extension methods
    - `Validations/` → tests for validation logic
    - `Mockups/` → tests for generators
    - `Exceptions/` → tests for custom exceptions

## Build and Test Commands

```shell
# Restore
dotnet restore

# Build
dotnet build

# Run tests
dotnet test

# Run tests with coverage
dotnet test --collect:"XPlat Code Coverage"
```

## What NOT to Do

- Do not add third-party dependencies without strong justification. The library currently depends only on `System.Globalization`.
- Do not change the `README.md` language to English — it must remain in Portuguese.
- Do not add code without corresponding unit tests.
- Do not use `Assert.True`/`Assert.False` for value comparisons — use specific assertions (`Assert.Equal`, `Assert.Matches`, etc.).
- Do not leave public methods without XML documentation.
