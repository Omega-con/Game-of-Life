---
applyTo: "tests/**/*.cs"
---

# Guidelines for test cases in repositories used in Programación II

Test cases in repositories used in the Programación II course must follow
these guidelines:

* There should be a folder named `test` or a folder named `tests`, but not both,
  in the workspace root folder.

* In that `test` or `tests` folder, there should be a subfolder with test cases
  for each `.csproj` library project in [src](../../src/) subfolders. The [main
  program](../../src/Program/Program.csproj) is not a library, so this rule
  doesn't apply to that project.

* The name of the test project and the folder it resides in should match the
  library project it tests, followed by `Tests` or `.Tests`.

* The namespace of the test project should match the namespace of the classes
  under test, followed by `.Tests`.

* Test methods should use the convention
  `MethodName_StateUnderTest_ExpectedBehavior`.

* Since this convention uses underscores, there should be a `.editorconfig` file
  configured to ignore warnings in identifiers using underscores. That file
  should be in the folder named `test` or `tests` mentioned above.

* Test methods should use fluent assertions when possible with `Assert.That()`.
