# TerraSegura API

API para monitoramento de regiões e sensores ambientais, desenvolvida em .NET 8.

---

## Sumário

- [Requisitos](#requisitos)
- [Configuração e Execução](#configuração-e-execução)
- [Acesso à API](#acesso-à-api)
- [Endpoints Principais](#endpoints-principais)
- [Exemplos de Requisições](#exemplos-de-requisições)
- [Testes](#testes)

---

## Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- Banco de dados Oracle (ou outro configurado no projeto)
- Ferramenta para requisições HTTP (ex: [Postman](https://www.postman.com/), [curl](https://curl.se/))

---

## Configuração e Execução

1. **Clone o repositório:**

git clone <url-do-repositorio> cd TerraSegura

2. **Execute a aplicação:**

dotnet run --project TerraSegura

---

A API estará disponível em 
•	Swagger:
https://localhost:7021/swagger
ou
http://localhost:5182/swagger
•	API endpoint:
https://localhost:7021/RegiaoMonitorada
ou
http://localhost:5182/RegiaoMonitorada

---

## Acesso à API

Por padrão, não há autenticação configurada. Basta acessar os endpoints via HTTP.

---

## Endpoints Principais

### Regiões Monitoradas

- **GET** `/RegiaoMonitorada`  
  Lista todas as regiões monitoradas (com sensores associados).

- **POST** `/RegiaoMonitorada`  
  Cria uma nova região monitorada.

  **Exemplo de JSON:**
  
  { "nome": "Tatuapé", "descricao": "Bairro monitorado para enchentes.", "latitude": -23.5603, "longitude": -46.5972, "nivelRisco": "Critico" }

### Sensores de Leitura

- **GET** `/SensorLeitura`  
  Lista todas as leituras de sensores.

- **POST** `/SensorLeitura`  
  Cria uma nova leitura de sensor.

  **Exemplo de JSON:**

  { "regiaoMonitoradaId": "72685af4-975d-4bd2-9db0-79f4acde15e4", "tipoSensor": "Inclinacao", "valor": 14.7, "dataHora": "2025-06-09T08:45:00Z" }
