Projeto DDD com Entity Framework e Autenticação JWT
Introdução
Este projeto é uma implementação usando a arquitetura Domain Driven Design (DDD) em conjunto com o Entity Framework para persistência de dados. Além disso, inclui autenticação JWT para segurança da API. Abaixo estão os passos necessários para configurar e executar o projeto.

Pré-requisitos
Antes de começar, certifique-se de ter os seguintes pré-requisitos instalados:

Visual Studio (ou Visual Studio Code)
.NET Core SDK
SQL Server
Pacotes NuGet:
Microsoft.AspNetCore.Authentication.JwtBearer
Microsoft.AspNetCore.Identity.EntityFrameworkCore
Microsoft.AspNetCore.Identity.UI
Microsoft.AspNetCore.OpenApi
Microsoft.EntityFrameworkCore.Design
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.Extensions.Identity.Stores
Configuração do Banco de Dados
Abra o arquivo appsettings.json e configure a conexão com o banco de dados SQL Server.
{
  "ConnectionStrings": {
    "DefaultConnection": "SuaCadeiaDeConexao"
  },
  // ...
}
Autenticação JWT
Para acessar a API, você precisará de um token JWT. Existem dois passos para obter um token:

1. Adiciona Usuário Identity
Envie uma requisição para POST /api/AdicionaUsuarioIdentity com os detalhes do usuário para criar uma conta.

Exemplo de requisição:
{
  "UserName": "seuemail@example.com",
  "Password": "SuaSenha@123",
}

Criar Token Identity
Faça uma requisição para POST /api/CriarTokenIdentity com as credenciais do usuário para obter o token JWT.

Exemplo de requisição:

{
  "UserName": "seuemail@example.com",
  "Password": "SuaSenha@123"
}
Executando a API
Abra o projeto no Visual Studio ou Visual Studio Code.
Pressione F5 ou use o comando dotnet run no terminal para iniciar a API.
A API estará disponível em https://localhost:5001 por padrão.
Documentação da API
A documentação da API está disponível em https://localhost:5001/swagger.


