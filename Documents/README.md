# TheCatAPI

Case para teste conhecimentos, onde será realizado procedimento de consulta de uma API e tratativa de dados e armazenamento em um banco de dados utilizando as seguinte tecnologias 

 - C# com estrutura de consumo de API e ao mesmo tempo serviços RESTFULL
   para distribuição e consulta dos dados. estruturação da API em Swagger.
 - Banco de dados em PostgreSQL em Docker.
 - Recurso de visual de dados estaremos utilizando Pgadmin.

# Case


Case The Cat API
1. Crie uma aplicação na linguagem que desejar para coletar as seguintes informações da API
de Gatos (https://thecatapi.com/):
a. Para cada uma das raças de gatos disponíveis, armazenar as informações de
origem, temperamento e descrição em uma base de dados. (se disponível)
b. Para cada uma das raças acima, salvar o endereço de 3 imagens em uma base de
dados. (se disponível)
c. Salvar o endereço de 3 imagens de gatos com chapéu.
d. Salvar o endereço de 3 imagens de gatos com óculos.
2. Use uma base de dados para armazenar as informações.
3. Utilizando uma linguagem de sua preferência, crie 4 APIs REST:
a. API capaz de listar todas as raças
b. API capaz de listar as informações de uma raça
c. API capaz de a partir de um temperamento listar as raças
d. API capaz de a partir de uma origem listar as raças
4. As APIs acima deverão expor métricas de execução.
5. Crie uma coleção no postman para consumir as APIs criadas.
6. Utilize técnicas ou descreva formas de aplicar os temas qualidade e teste na sua
aplicação (teste unitário, teste regressivo, teste integrado, teste de performance, teste de
resiliência etc)
7. Desenvolva um dashboard utilizando Angular 12+ e um framework de front-end da sua
escolha (Bootstrap, MaterialUI etc. O dashboard deverá:

Corporativo | Interno

a. Exibir a lista de todas as raças de gatos, contendo o nome e a imagem da raça.
b. Em cada card de raças, exibir as informações dessa raça, conforme o item 3.b.
c. Incluir um campo de busca que, à partir de uma origem, liste todas as raças
(usando a api do item 3.d)

8. Publique o projeto no Github e documentar em um README.md os itens abaixo:
a. Documentação do projeto
b. Documentação das APIs
c. Documentação de arquitetura
d. Documentação de como podemos subir uma cópia deste ambiente localmente
e. Manual com prints dos Logs (item 6) e os 3 Dashboards (item 7).