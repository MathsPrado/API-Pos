# EstudanteWork API (API-Pos)

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=flat&logo=dotnet)
![Entity Framework Core](https://img.shields.io/badge/EF%20Core-10.0-512BD4?style=flat&logo=nuget)
![Status](https://img.shields.io/badge/Status-Em%20Desenvolvimento-yellow)

Esta é a API backend do projeto **EstudanteWork**, responsável por gerenciar as regras de negócio e persistência de dados. A aplicação foi construída utilizando **ASP.NET Core Web API** e serve como base de dados para o front-end [Web-Pos](https://github.com/MathsPrado/Web-Pos).

## 🚀 Tecnologias Utilizadas

O projeto foi desenvolvido com as seguintes tecnologias:

- **[C#](https://docs.microsoft.com/en-us/dotnet/csharp/)** - Linguagem de programação.
- **[.NET 6](https://dotnet.microsoft.com/download/dotnet/10.0)** - Framework de desenvolvimento.
- **[ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/)** - Framework para construção de APIs web.
- **[Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)** - ORM para manipulação de dados.
- **SQL Server** (ou *PostgreSQL/MySQL* - ajuste conforme seu banco) - Banco de dados.
- **Swagger** - Documentação interativa da API.

## ⚙️ Pré-requisitos

Antes de começar, certifique-se de ter instalado em sua máquina:

1. **[.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)**.
2. Um editor de código, como o **[Visual Studio 2026](https://visualstudio.microsoft.com/)** ou **[VS Code](https://code.visualstudio.com/)**.
3. Um servidor de banco de dados (SQL Server LocalDB, Docker, etc.).

## 🔧 Configuração e Execução BD

1. **Clone o repositório:**
   ```bash
   git clone [https://github.com/MathsPrado/API-Pos.git](https://github.com/MathsPrado/API-Pos.git)
   cd API-Pos

   ## 🔧 Configuração e Execução

### 2. Configure a String de Conexão
Abra o arquivo `appsettings.json` e verifique se a string de conexão aponta para o seu banco de dados local corretamente.

### 3. Aplique as Migrations (Banco de Dados)
Se estiver usando o Entity Framework, execute o comando abaixo para criar o banco de dados:

```bash
dotnet ef database update
```

### 4. Execute a API
Para rodar a aplicação:
```bash
dotnet run
```

### 5. Acesse a Documentação
Com a API rodando, acesse o Swagger para testar os endpoints:

> https://localhost:7001/swagger

## 📂 Estrutura do Projeto
A estrutura básica segue os padrões do ASP.NET Core:

* **Controllers/**: Define os endpoints da API.
* **Models/**: Classes de domínio e entidades do banco.
* **Data/**: Contexto do banco de dados (DbContext) e configurações do EF Core.
* **Migrations/**: Histórico de versionamento do esquema do banco de dados.

## 🔗 Projetos Relacionados
* **Front-end:** [Web-Pos](https://github.com/MathsPrado/Web-Pos) - Interface Blazor que consome esta API.


