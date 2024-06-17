# API de Assinatura

Esta API de Assinatura foi desenvolvida como parte do trabalho final de TADS pelos alunos:

- **Ryan Breda Santos**  
    RGA: 2021.1906.005-0
    
- **Otávio Benatti Dias**  
    RGA: 2021.1906.014-0
    

Construída com ASP.NET Core 6.0, EF Core e MailKit, a API permite que os usuários se inscrevam em boletins informativos meteorológicos com diferentes frequências, utilizando um servidor SMTP para o envio de e-mails.

## Pré-requisitos

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [MySQL](https://www.mysql.com/downloads/) (ou banco de dados compatível)

## Primeiros Passos

### Clonar o Repositório

```
https://github.com/ryan-bs/Weather.git
```

### Configuração

#### Configuração do Banco de Dados

1. Crie um banco de dados MySQL para o projeto.
    
2. Atualize a string de conexão em `appsettings.json`:
    
```
{
  "ConnectionStrings": {
    "NewsletterConnection": "server=localhost;database=Newsletter;user=root;password=sua_senha"
  },
  "EmailSettings": {
    "SmtpServer": "smtp.ethereal.email",
    "Port": 587,
    "Username": "seu_usuario_ethereal",
    "Password": "sua_senha_ethereal",
    "From": "seu_email@ethereal.email"
  }
}
```

#### Configuração de E-mail

Substitua os valores de espaço reservado na seção `EmailSettings` pelos detalhes do seu servidor SMTP. Você pode usar o Ethereal Email para fins de teste.

### Instalando Dependências

Navegue até o diretório do projeto e execute:

```
dotnet restore
```

### Executando Migrações

Aplique as migrações do Entity Framework para criar o esquema do banco de dados:

```
Update-Database
```

### Compilando o Projeto

```
dotnet build
```

### Executando o Projeto
```
dotnet run
```
\
A API estará disponível em `https://localhost:5001` ou `http://localhost:5000`.

## Endpoints da API

### Assinar

- **URL:** `/subscription`
- **Método:** `POST`
- **Descrição:** Inscrever-se no boletim informativo.
- **Corpo da Requisição:**
   
```
{
    "email": "exemplo@exemplo.com",
    "frequency": "Weekly"
}
```
    
- **Resposta:** 201 Created

### Cancelar Assinatura

- **URL:** `/subscription/{id}`
- **Método:** `DELETE`
- **Descrição:** Cancelar a assinatura do boletim informativo.
- **Resposta:** 204 No Content

### Obter Todas as Assinaturas

- **URL:** `/subscription`
- **Método:** `GET`
- **Descrição:** Recuperar todas as assinaturas.
- **Resposta:** 200 OK

### Obter Assinatura por ID

- **URL:** `/subscription/{id}`
- **Método:** `GET`
- **Descrição:** Recuperar uma assinatura por ID.
- **Resposta:** 200 OK

## Desenvolvimento

### Swagger

O Swagger é usado para documentação e teste da API. Você pode acessá-lo em `/swagger` quando a aplicação estiver em execução.

### Ferramentas e Pacotes

- [MailKit](https://github.com/jstedfast/MailKit) para envio de e-mails.
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) para operações de banco de dados.
- [Pomelo.EntityFrameworkCore.MySql](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql) para suporte a banco de dados MySQL.
- [Swashbuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) para Swagger.

### Resolução de Problemas

Se você encontrar problemas, certifique-se de que todas as dependências estão instaladas e o banco de dados está configurado corretamente. Verifique a string de conexão e as configurações de e-mail em `appsettings.json`.

Para obter um registro detalhado, você pode ajustar a seção `Logging` em `appsettings.json`:

```
"Logging": {
  "LogLevel": {
    "Default": "Debug",
    "Microsoft.AspNetCore": "Debug"
  }
}
```