# AvaliacaoFioTecAnalista2
Projeto desenvolvido como avaliação para o processo seletivo da FioTec para vaga de Analista II.

Foram utilizadas as seguintes tecnologias para o desenvolvimento:
- .NET 7
- Entity Framework Core
- Fluent Validation
- SQL Server
- Docker
- Swagger

O objetivo do projeto é recuperar a quantidade de pessoas vacinadas pela vacina Pfizer em uma determinada data no estado do Rio de Janeiro e adicionar a um relatório,
salvando os usuários que utilizarem a API.

Como fonte de dados, foi utilizada a API do DataSus -> https://opendatasus.saude.gov.br/dataset/covid-19-vacinacao .

Segue abaixo o diagrama de entidade-relacionamento das entidades do banco de dados.

![DiagramaEntidadeRelacionamentoBD](https://user-images.githubusercontent.com/88674628/229333668-db0fb99c-d275-4bc2-a379-f96d60f37d2a.PNG)

Por mais que o relacionamento e criação das tabelas no banco foram feitas pelo entity framework, está disponível o sql referente a criação de cada tabela.
