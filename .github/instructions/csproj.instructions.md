---
applyTo: "src/**/*.csproj,tests/**/*.csproj"
---

# Guidelines for .csproj files in repositories used in Programación II

All .csproj files in repositories used in the Programación II course must
follow these guidelines to ensure consistent documentation.

* Use C# version 6.0, specified via `<LangVersion>6</LangVersion>`.

* Do not use nullables, specified via `<Nullable>disable</Nullable>`.

* Versions of referenced libraries must be the latest available version.

* Test projects may not have XML comments; it is not necessary to specify
  `<GenerateDocumentationFile>true</GenerateDocumentationFile>`.

* Other projects must have XML comments, specified via
  `<GenerateDocumentationFile>true</GenerateDocumentationFile>`.

* Roslyn Analyzers should be enabled, specified via
  `<EnableNETAnalyzers>true</EnableNETAnalyzers>`.

* Code analysis should be set to "All", specified via
  `<AnalysisMode>All</AnalysisMode>`.

* Code style enforcement should be enabled in library projects, specified via
  `<EnforceCodeStyleInBuild>true</EnforceCodeStyleInBuild>`. Test projects
  might not have this enabled.
