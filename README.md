AICopilotMVP
AICopilotMVP is an Agentic RAG (Retrieval-Augmented Generation) system built with .NET and OpenAI Function Calling. It enables non-technical users to query relational databases using natural language by dynamically mapping intent to secure, validated backend tools.
The system features a multi-turn reasoning loop that validates LLM-generated parameters against C# models before execution, ensuring that hallucinated or malicious queries never reach your database.

🚀 Key Features
Natural Language to SQL: Query your database using plain English.
Agentic Reasoning: Uses OpenAI Function Calling to determine which database tools or schemas to access based on user intent.
Type-Safe Validation: LLM outputs are validated against C# POCO models and domain logic before execution.
Clean Architecture: Organized into Domain, Application, Infrastructure, and API layers for high maintainability.
AdventureWorks Integration: Pre-configured to work with the standard industry sample database.

🏗️ Architecture
The project follows Clean Architecture principles to separate concerns:
AICopilot.Domain: Core entities and domain logic.
AICopilot.Application: Interfaces, DTOs, and the core Agentic logic/orchestration.
AICopilot.Infrastructure: Data access (SQL Server), OpenAI service implementation, and external integrations.
AICopilot.API / Presentation: Entry points for user interaction and RESTful endpoints.

🛠️ Prerequisites
.NET 8.0 SDK (or later)
SQL Server (LocalDB or Express)
OpenAI API Key
AdventureWorksLT2019 Database
Database Setup
This project uses the AdventureWorksLT2019 sample database. You can download the .bak file or the creation scripts from the official Microsoft GitHub repository.

⚙️ Getting Started
Clone the Repository:
bash
git clone https://github.com
cd AICopilotMVP
Use code with caution.

Configure Environment Variables:
Update your appsettings.json in the AICopilot.API project:
json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=AdventureWorksLT2019;Trusted_Connection=True;"
  },
  "OpenAI": {
    "ApiKey": "your-api-key-here"
  }
}
Use code with caution.
Run the Application:
bash
dotnet run --project AICopilot.Presentation
Use code with caution.

🛡️ Security & Validation
Unlike "Text-to-SQL" approaches that directly execute LLM-generated code, this project employs a validation loop:
Intent Mapping: LLM identifies the required tool (e.g., GetCustomerOrders).
Parameter Extraction: LLM extracts arguments (e.g., customerId: 5).
C# Validation: The application validates these arguments against existing C# models and database constraints.
Secure Execution: The system executes a predefined, parameterized query rather than raw generated SQL.

🧰 Tech Stack
Language: C#
Framework: .NET Core
AI: OpenAI GPT-4 / GPT-3.5 (Function Calling)
Database: SQL Server
ORM: Entity Framework Core / Dapper
