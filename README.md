# TheCatAPI

Case para teste conhecimentos, onde será realizado procedimento de consulta de uma API e tratativa de dados e armazenamento em um banco de dados utilizando as seguinte tecnologias 

 - C# com estrutura de consumo de API e ao mesmo tempo serviços RESTFULL
   para distribuição e consulta dos dados. estruturação da API em Swagger.
 - Banco de dados em PostgreSQL em Docker.
 - Recurso de visual de dados estaremos utilizando Pgadmin.

## Fluxo de Funcionamento

```mermaid
graph LR
A((Usuário)) -- WEB API --> B[Web Service Angular]
A((Usuário)) -- WEB UI --> B1[API SWAGGER]
B -- REST API --> C(API:Desafio)
B1 -- REST API --> C(API:Desafio)
C --> G{TheCat} --> Z(API:TheCat.com)
G --> C	
C --> F[Banco]
```
