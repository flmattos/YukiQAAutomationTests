# Yuki QA Automation Tests

This project is an end-to-end test automation setup using:
- [C#](https://learn.microsoft.com/en-us/dotnet/csharp/)
- [Microsoft Playwright](https://playwright.dev/dotnet/)
- [Reqnroll](https://reqnroll.net/) (SpecFlow-compatible BDD)
- NUnit Test Runner

The main objective of this project was to bring a simple, organized structure, which can have improvements 
in the future in terms of features (more complexity on the pages), bring integration with CI/CD and have a separate or integrated report (for example ReportPortal).

## Project Structure
yuki-qa-automation-tests/
```bash
│── Features/
│ ├── Home.feature
│ ├── Invoices.feature
│ └── Privacy.feature
│
│── Steps/
│ ├── HomeSteps.cs
│ ├── InvoicesSteps.cs
│ └── PrivacySteps.cs
│
│── Pages/
│ ├── HomePage.cs
│ ├── InvoicesPage.cs
│ └── PrivacyPage.cs
│
│── Support/ 
│ ├── Hooks.cs 
│ └── World.cs
│
│── PlaywrightTraces/ # Playwright trace reports (generated at runtime)
```
## 🚀 How to Run

1. Install dependencies:
   ```sh
   dotnet build
   ```

2. Open a new terminal and up yuki-qa-automation/yuki-qa-automation-frontend
   ```sh
   cd ../yuki-qa-automation/yuki-qa-automation-frontend/
   dotnet run
   ```
3. Open another terminal and navigate to the test project to run the tests:
   ```sh
   cd ../yuki-qa-automation-tests/
   dotnet test
   ```
4. After exeuction the Playwright traces will be available in the `PlaywrightTraces` folder.
   ```sh
   cd ../yuki-qa-automation-tests/PlaywrightTraces/
   npx playwright show-trace .\trace_{date}_{hour}_.zip
   ```
