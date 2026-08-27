---
applyTo: "src/**/*.cs,tests/**/*.cs"
---

# Guidelines for C# code in repositories used in Programación II

All C# code in repositories used in the Programación II course must follow these
guidelines:

* Private fields might start with an underscore (_) or not, but the choice
  should be consistent, e.g. every private field uses an underscore or none
  use it.

* Use camelCase for private fields, e.g. `_myField` or `myField`.

* Use PascalCase for public members, e.g. `MyProperty`.

* Interfaces must start with an I, e.g. `IMyInterface`.

* When reviewing identifiers' names, look for names that are vague, misleading,
  overly abbreviated, or inconsistent with their usage or domain.

* Names of classes and interfaces should use nouns or noun phrases, and
  represent domain entities, roles or responsibilities, capabilities or
  contracts, or abstractions.

* Names of methods should use verbs or verb phrases, and represent actions,
  operations, or behaviors.

* Names of non-boolean properties should use nouns or noun phrases, and represent
  characteristics, attributes, or data.

* Names of boolean properties should use adjectives or adjective phrases, or
  verb phrases that imply a true/false value.

* When you propose a better name, always explain why it is better: clarity,
  consistency, intent revealing, domain language, etc.

* Keep suggestions specific: show 'currentName → SuggestedName' and a brief
  rationale.

* If identifiers' names are already good, explicitly say so instead of changing
  them.

* Do not use expression-bodied members for properties and methods.

* Do not use var; always use explicit types.

* Do not use LINQ; use foreach loops instead.

* Use XML comments for all public types and members in library projects. Test
  projects do not require XML comments.

* Member names can be in English or Spanish, but the choice must be consistent
  throughout the project.

* Use `this` when referring to members in the same class, even if it's not
  required by the compiler.
