# DotEnv Demo (.NET)

This project demonstrates loading environment variables from a `.env` file using DotNetEnv and Microsoft.Extensions.Configuration.

## Files

- `.env`: Key-value pairs for environment variables (e.g., `WelcomeMessage`, `EnvironmentMessage`).
- `DotNetEnvFilesSupport.cs`: Sample program that:
  - Loads `.env` with `DotNetEnv.Env.Load`.
  - Reads values via `DotNetEnv.Env.GetString`.
  - Reads variables via `Environment.GetEnvironmentVariable`.
  - Adds `.env` to configuration with `ConfigurationBuilder.AddDotNetEnv`.
  - Shows parsing without setting env vars via `DotNetEnv.Env.NoEnvVars().Load`.
- `global.json`: Pins the .NET SDK version.

## Prerequisites

- .NET SDK specified in `global.json`.
- NuGet package: `DotNetEnv` (version declared in source).

## Setup

1. Create a `.env` file in this folder:
   ```env
   WelcomeMessage="Hello, World!"
   EnvironmentMessage="This is a sample .env file."
   ```

## Run

From this folder (`DotEnv`), run:

```pwsh
dotnet run DotNetEnvFilesSupport.cs
```

If you have a full project file later, you can run:

```pwsh
dotnet run
```

## Expected Output

- Prints:
  - Welcome message from `Env.GetString`.
  - `EnvironmentMessage` via `Environment.GetEnvironmentVariable`.
  - `WelcomeMessage` via configuration.
  - All parsed key-value pairs from `.env` when using `NoEnvVars().Load()`.

## Notes

- `AddDotNetEnv(".env", LoadOptions.TraversePath())` allows traversing parent directories to locate `.env`.
- `NoEnvVars()` prevents values from being injected into the process environment; use it for parsing only.
