
# Gestão De Livros

API REST para gerenciamento de livros, desenvolvida em ASP.NET Core com PostgreSQL.


## Autores

- [@Rodrigofeel](https://github.com/Rodrigofeel)


## Funcionalidades

- Cadastro de livros
- Listagens de livros
- Validação dos campos
- Tratamento de erros HTTP
- Integração com banco de dados


## Stack utilizada

- C#
- ASP.NET Core 8.0
- Entity Framework
- PostgreSQL
- Swagger

### Pré-requesitos

- .NET SDK8.0
- PostgreSQL 12

### Ferramenta auxiliar 

Copilot



## Deploy
### Como fazer deploy:
2. **Faça fork ou clone do repositório**
```bash
git clone https://github.com/Rodrigofeel/Gestao-de-livros.git
```


## Variáveis de Ambiente

Para rodar esse projeto, você vai precisar adicionar as seguintes variáveis

- (appsettings.example.json) Preencha esse arquivo com seus dados 'SUA_SENHA_AQUI'

- Crie um banco de dados no PostgreSQL
```sql
CREATE DATABASE gestao_livros;
```
- Restaure as dependências
```bash
cd backend
dotnet restore
```
- Execute as migrations
```bash
dotnet ef database update
```
- Inicia a aplicação
```bash
dotnet run
```

## Testar API
(swagger)
- https://localhost:7XXX/swagger



## Exemplo para teste

- Criar um livro

POST /api/livros    
Content-Type: application/json

{   
  "titulo": "O Senhor dos Anéis",  
  "categoria": "Fantasia",  
  "autor": "J.R.R. Tolkien",  
  "editora": "HarperCollins",  
  "anoPublicado": 1954,  
  "numeroPaginas": 1178,  
  "isbn": "9780544003415",  
  "resumo": "Uma épica jornada pela Terra Média para destruir o Um Anel."  
}

## Endpoints da API

| Método           | Endpoint        | Descrição                         |
| ---------------- | --------------- | --------------------------------- |
| GET    | /api/livros       | Lista todos os livros        |
| GET     | /api/livros/{id}       | Busca um livro por ID      |
| POST    | /api/livros       | Cria um novo livro         |
| PUT     | /api/livros/{id}       | Atualiza um livro existente neutro          |
| DELETE            |  /api/livros/{id}           | Remove um livro        |



## Referência

 - [Referência de API (github)](https://github.com/ddouglss/ApiRest-Youtube)
 - [Criar APIs Web (Microsoft learn)](https://learn.microsoft.com/pt-br/aspnet/core/web-api/?WT.mc_id=dotnet-35129-website&view=aspnetcore-7.0)
 - [Referência de API (github)](https://github.com/LuanRoger/AllInOneAspNet)
  - [Video aula Referência(youtube)](https://www.youtube.com/watch?v=Zwzhrdl-c_k)
## Aprendizados

Esse projeto me ajudou no aprendizado nos fundamentos de ASP.NET CORE, controllers, endpoints, middlawares, CORS, métodos assincronas, PostgreSQL, validações e boas práticas.

