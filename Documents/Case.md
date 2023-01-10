# Case The Cat API
(https://thecatapi.com/)



# Configuração de ambiente
## Postgresql e PgAdmin com tecnologia de composição

## [](https://github.com/khezen/compose-postgres/blob/master/README.md#requirements)Requisitos:

-   docker >= 17.12.0+
-   docker-compose

## [](https://github.com/khezen/compose-postgres/blob/master/README.md#quick-start)Começo rápido

-   Clone ou baixe este repositório
-   Entre no diretório, `cd compose-postgres`
-   Execute este comando`docker-compose up -d`

## [](https://github.com/khezen/compose-postgres/blob/master/README.md#environments)ambientes

Este arquivo Compose contém as seguintes variáveis ​​de ambiente:

-   `POSTGRES_USER`o valor padrão é **postgres**
-   `POSTGRES_PASSWORD`o valor padrão é **changeme**
-   `PGADMIN_PORT`o valor padrão é **5050**
-   `PGADMIN_DEFAULT_EMAIL`o valor padrão é **[pgadmin4@pgadmin.org](mailto:pgadmin4@pgadmin.org)**
-   `PGADMIN_DEFAULT_PASSWORD`o valor padrão é **admin**

## [](https://github.com/khezen/compose-postgres/blob/master/README.md#access-to-postgres)Acesso ao postgres:

-   `localhost:5432`
-   **Nome de usuário:** postgres (como padrão)
-   **Senha:** changeme (como padrão)

## [](https://github.com/khezen/compose-postgres/blob/master/README.md#access-to-pgadmin)Acesso ao PgAdmin:

-   **URL:**  `http://localhost:5050`
-   **Nome de usuário:** [pgadmin4@pgadmin.org](mailto:pgadmin4@pgadmin.org) (como padrão)
-   **Senha:** admin (como padrão)

## [](https://github.com/khezen/compose-postgres/blob/master/README.md#add-a-new-server-in-pgadmin)Adicione um novo servidor no PgAdmin:

-   **Nome/endereço do host**  `postgres`
-   **Porta**  `5432`
-   **Nome de usuário** como `POSTGRES_USER`, por padrão:`postgres`
-   **Senha** como `POSTGRES_PASSWORD`, por padrão`changeme`

## [](https://github.com/khezen/compose-postgres/blob/master/README.md#logging)Exploração 

Não há uma maneira fácil de configurar a verbosidade do log pgadmin e pode ser opressiva às vezes. É possível desativar o log do pgadmin no nível do contêiner.

Adicione o seguinte ao `pgadmin`serviço no `docker-compose.yml`:

```
logging:
  driver: "none"
```
