

**Fluxos (Jornadas) de consumo das API**
```mermaid
graph LR
A[User] -- Jornadas Post --> B(Conteiner Carga de TheCatAPI) --> Z(TheCatAPI.com)
A1[User] -- Jornadas Post --> B2(Breed) --> D(Database)
A2[User] -- Jornadas Post --> B3(List_Raca_Temperament) --> D(Database)
A21[User] -- Jornadas Get --> B31(List_Raca_Temperament Total) --> D(Database)
A3[User] -- Jornadas Post --> B4(List_Raca) --> D(Database)
A4[User] -- Jornadas Post --> B5(List Origin) --> D(Database)
A41[User] -- Jornadas Get --> B51(List Origin) --> D(Database)
B --> D(Database Postgres)
```


**Primero processo realizaria teste unitários para todas as API utilizando** 
 - Unit Teste para os processo validando em **sonarqube** e   Teste de contrato como
 -    [playwriting](https://docs.pactflow.io/docs/bi-directional-contract-testing/)

**Teste de carga usando as metodologias** 
 - **Carga funcional** para identificar o consumo da aplicação para um processo ou uma jornada única.
 - **Carga de Saturação** ou de Capacidade para identificar os ponto de capacidade ou saturação ou definição de BASELINE e threshold para  minha aplicação. 
 - E por ultimo **Stress** para validar todo o ambiente
   ou ate mesmo caos test do ambiente e validação de monitoramento
   capacidade e resiliência da aplicação.

***O importante para a realização de teste processo e que todo o ambiente esteja monitorado, ELK , Dynatrace, NewRelic , Datadog, App Dynamic , etc..*** 