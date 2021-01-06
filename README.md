# ♻ Projeto Locais de Reciclagem

A secretaria de Meio-Ambiente da cidade de São José dos Campos precisa gerenciar todos os locais de reciclagem conhecidos na cidade, para prestação de contas ao estado de São Paulo.
Eles possuem uma listagem de todos os endereços já conhecidos em Excel com as respectivas capacidades de armazenamento em metros cúbicos, portanto, está listagem deve estar disponível em um sistema Web aos responsáveis da área, como também, a possibilidade desta base ser atualizada na própria ferramenta de gestão, possibilitando a inclusão de novos pontos de reciclagem, modificação de endereço, ou, até a remoção dos mesmos.
 
## 🚀 Index
- ⚙ [Tecnologies](#-tecnologies)
- 💻 [How to use](#-how-to-use)

## ⚙ Tecnologias e Metodologias utilizadas

- Linguagem de Programação C#
- Framework .Net 5.0
- EntityFrameworkCore 5.0.1
- Banco de Dados Relacional com SQL Server 
- Biblioteca Flunt
- Arquitetura de modelagem MVC
- Design pattern Repositories
- Utilização da ferramenta do .NET - Migrations do Entity Framework
- Cors
- Aplicação Web Api com React
- Javascript
- HTML5
- CSS3
- ReactJS
- NodeJS
- react
- react-dom
- react-router-dom
- react-scripts
- react-google-maps
- react-geocode
- react-google-autocomplete
- antd

## 💻 How to use

> Clonar o repositório
```bash
    git clone 
```

> Para configurar o banco de dados deve acessar a classe DataContext que está localizada no path ProjetoLocaisDeReciclagemCSJ.Data, ao entrar na classe mencinada ir até a linha 13 do arquivo e alterar o a string de conexão dentro do método UseSqlServer()

> Entrar na pasta do projeto e depois rodar os comandos para o migration fazer o processo de criação do banco de dados
```bash
    cd ProjetoLocaisDeReciclagemCSJ
```

```c#
    dotnet clean
    dotnet restore
    dotnet build
    dotnet ef migrations add InitialCreate
    dotnet ef database update
```

> Após rodar os comandos acima será criada a pasta Migrations no projeto com arquivos de log de criação

> Para rodar a aplicação deve entrar na pasta que contém a solução e rodar o comando abaixo
```c#
    dotnet watch run
```"# ProjetoLocaisDeReciclagem" 
