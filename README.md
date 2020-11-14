![Quality Gate](https://sonarcloud.io/api/project_badges/measure?project=br.com%3Amavenquickstart&metric=alert_status)

### 🛠 Tecnologias

As seguintes ferramentas foram usadas na construção do projeto:

- <img src="https://3.bp.blogspot.com/-mxF__jCVkCU/XefJCxxy9WI/AAAAAAAAXyg/AvVFyFT0JAEquOWki4j1sw4hu_RlBZDQwCLcBGAsYHQ/s1600/download-latest-dotnet-core-min.jpg" width="25%" height="25%"> [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.1.401-windows-x64-installer)
- <img src="https://compuclass.com.br/wp-content/uploads/2019/12/capa-curso-sql-server.png" width="25%" height="25%"> [SQL Server](https://docs.microsoft.com/pt-br/sql/sql-server/?view=sql-server-ver15)
- <img src="https://miro.medium.com/max/1050/1*oSRHmPyxs10yG3JFHVlFhg.png" width="25%" height="25%"> [Dapper](https://dapper-tutorial.net/dapper)
- ![Alt text](https://www.newtonsoft.com/content/images/twitterlogo.png) [NewtonSoft](https://www.newtonsoft.com/json)
- <img src="https://miro.medium.com/max/1050/1*QfmtMDpR23DkpSBOEB50FA.png" width="25%" height="25%"> [Angular 10.0.12](https://angular.io/)


<p align="center">MER</p>

![alt text](MER.png)


# SAAS.Api - Estrutura padrão - controllers - projeto principal
## SAAS.Infra - Comunicação com o Banco de Dados - biblioteca de classes
## SAAS.Service - Normaliza os dados da Api com as Stored Procedure - biblioteca de classes
## SAAS.Model -  Modelos, Classes - biblioteca de classes
## SAAS.Front/src -  Angular
## SAAS.Sql -  Banco de dados




```shell
Rodrigo Luiz Madeira Furlaneti - 11 995882409 WhatsApp
```

## Desafio Back-end

Sua tarefa é construir uma aplicação SAAS. A aplicação é um simples repositório para gerenciar médicos com seus respectivos nomes, CPF's, crm's e especialidades. Utilize um repositório Git (público, de sua preferência) para versionamento e disponibilização do código.

A aplicação deve ser construída em .NET Core 3.1, utilizando EF Core com banco de dados PostgreSQL ou SQL SERVER, pode utilizar qualquer lib disponível no NuGET.

A API deverá ser documentada utilizando o formato OpenAPI (antigo Swagger).

### O que será avaliado
Queremos avaliar sua capacidade de desenvolver e documentar um back-end para uma aplicação. Serão avaliados:

* Código bem escrito e limpo;
* Quais libs foram usadas, como e porquê, além do seu conhecimento das mesmas;
* Seu conhecimento em banco de dados, requisições HTTP, APIs REST, etc;
* Sua capacidade de documentação da sua parte da aplicação.
* Organização do repositório

### O mínimo necessário

* Uma aplicação contendo uma API real simples, sem autenticação, que atenda os requisitos descritos abaixo, fazendo requisições à um banco de dados para persistência;
* README.md contendo informações básicas do projeto e como executá-lo;
* OpenAPI da aplicação

### Bônus
Os seguintes itens não são obrigatórios, mas darão mais valor ao seu trabalho (os em negrito são mais significativos para nós)

* **Cuidados especiais com otimização, padrões, entre outros;**
* **Utilização de migrations para configuração do banco de dados utilizado;**
* **Testes Automatizado unitário/integração;**
* **Autenticação e autorização JWT;**
* Pipelines de CI/CD (GitLab, CircleCI, TravisCI, etc);
* Deploy em ambientes reais, utilizando serviços de cloud externos (AWS, Heroku, GCP, etc);
* Sugestões sobre o challenge embasadas em alguma argumentação.

### User Stories

### 0.  A Api deve responder na porta 3000

### 1. Deve haver uma rota para listar todos os profissionais cadastrados:

*GET /medico*

Resposta:

Status: **200 Ok**
 ``` json
  [
      {
          id: 1, // pode ser int ou guid, preferencia para guid,
          nome: "Gabrielle Martins Souza",
          cpf: "652.472.120-96",
          crm: "1010-SC",
          especialidades: [
              "Clínico Geral",
              "Ginicologista"
          ]
      }
  ]
```

### 2. Deve ser possível filtar profissionais utilizando uma busca por especialidade

*GET /medico/ginicologista (ginicologista é a especialidade sendo buscada neste exemplo)*

Resposta:

Status: **200 Ok**
 ``` json
  [
      {
          id: 1,
          nome: "Gabrielle Martins Souza",
          cpf: "652.472.120-96",
          crm: "1010-SC",
          especialidades: [
              "Clínico Geral",
              "Ginicologista"
          ]
      },
      {
          id: 10,
          nome: "Luis Souza Oliveira",
          cpf: "238.677.850-90",
          crm: "1558-SC",
          especialidades: [
              "Ginicologista"
          ]
      },
      {
          id: 12,
          nome: "Leila Barbosa Castro",
          cpf: "979.006.660-01",
          crm: "35965-SC",
          especialidades: [
              "Cardiologista",
              "Ginicologista"
          ]
      }
  ]
```

### 3. Deve haver uma rota para cadastrar um novo médico

* O corpo da requisição deve conter as informações do médico a ser cadastro, sem o Id que deve ser gerado automaticamente pelo servidor. A resposta, em caso de sucesso, deve ser o novo Id gerado.

* Deve realizar as seguintes validações:
1. nome não pode ser vazio ou nulo;
2. nome não pode ser maior que 255 caracteres;
3. cpf deve ser válido;
4. crm não pode ser vazio ou nulo;
5. deve conter no minimo uma especialidade;

Em caso de falha em qualquer uma das validações a cima deve retornar com o status **400 Bad Request** e as respectivas mensagens.

*POST /medico Content-Type: application/json*

``` json
  
    {
        nome: "Giovana Dias Carvalho",
        cpf: "776.077.220-33",
        crm: "2510-SC",
        especialidades: [
            "Clínico Geral",
            "Cardiologista"
        ]
    }
  
```

Resposta:

Status: **200 Ok**

``` json
  15
```

Status: **400 Bad Request**

``` json
  {
      erros: [
          {
              campo: "nome",
              erro: "nome é obrigatorio"
          },
           {
              campo: "cpf",
              erro: "cpf inválido"
          },
      ]
  }
```

### 4: O usuário deve poder remover um médico por id
*DELETE /medico/:id*

Resposta:

Status: **200 Ok**


### Critérios de Aceitação

* A API deve ser real e escrita por você. Ferramentas que criam APIs automaticamente (Loopback, json-server, etc) não são aceitas;
* Todos os requisitos acima devem ser cumpridos, seguindo o padrão de rotas estabelecido;
* Deve haver um documento de OpenAPI (antigo Swagger) descrevendo sua API;
* Se você julgar necessário, adequado ou quiser deixar a aplicação mais completa (bônus!) você pode adicionar outras rotas, métodos, meios de autenticação com usuários, etc;
* Organização do repositório, branch's e commit's;

Quando terminar de realizar o desafio você deverá gravar um vídeo de no máximo 30 minutos, contando pra gente esses principais pontos:

* Um pouco sobre você, o que gosta de fazer, como chegou nessa carreira e tudo mais;
* Como é a sua rotina hoje;
* O que almeja para você num horizonte de médio e longo prazo;
* Compartilhe sua tela no vídeo e mostre o que você construiu no desafio, passando sobre o código e o resultado final, e os pontos que você julga importante para o funcionamento do mesmo;
* As decisões que teve que tomar para construí-lo;


Para conseguir mostrar o seu desafio para nós, você deve baixar uma ferramenta de vídeo chamada Loom. Ela é uma extensão do navegador totalmente gratuita, na qual você poderá gravar o seu desafio seguindo o roteiro que indicamos acima. Para baixar é bem rápido, [clique aqui](https://chrome.google.com/webstore/detail/loom-for-chrome/liecbddmkiiihnedobmlmillhodjkdmb)! Não se esqueça de nos enviar o link do seu vídeo, junto com o seu desafio.

**Não se esqueça de nos enviar o link do seu vídeo, junto com o seu desafio.**



