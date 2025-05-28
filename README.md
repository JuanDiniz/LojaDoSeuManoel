📦 Loja do Seu Manoel – API de Embalagem
📝 Descrição
Esta API calcula automaticamente a melhor forma de embalar os produtos de um pedido, usando caixas pré-definidas, otimizando o espaço e minimizando o número de caixas necessárias.

A aplicação foi desenvolvida como parte de uma avaliação técnica e oferece:

Processamento de pedidos via API

Cálculo de embalagens com base nas dimensões dos produtos e caixas

Autenticação básica para proteger o acesso

Testes unitários para validar a lógica de negócio

🚀 Tecnologias Utilizadas
.NET 8.0

ASP.NET Core Web API

Docker e Docker Compose

SQL Server (em container)

xUnit (para testes)

Swagger (documentação e testes da API)

📂 Como Rodar o Projeto
Pré-requisitos
Docker e Docker Compose instalados

.NET SDK 8.0 ou superior (caso queira rodar local sem docker)

Passos
1️⃣ Clone o repositório:

bash
Copiar
Editar
git clone https://github.com/seu-usuario/seu-repositorio.git  
cd seu-repositorio  
2️⃣ Rode o projeto com Docker Compose:

bash
Copiar
Editar
docker-compose up --build  
3️⃣ Acesse o Swagger UI para testar a API:

bash
Copiar
Editar
http://localhost:5000/swagger  
🔐 Autenticação (Basic Auth)
Para acessar a API, utilize as seguintes credenciais:

Usuário: admin

Senha: 1234

🔑 No Swagger, clique em Authorize, selecione o esquema basic, e informe as credenciais.

📬 Exemplo de Entrada (JSON)
json
Copiar
Editar
{
  "pedidos": [
    {
      "pedido_id": 1,
      "produtos": [
        { "produto_id": "A", "dimensoes": { "altura": 30, "largura": 20, "comprimento": 10 } },
        { "produto_id": "B", "dimensoes": { "altura": 15, "largura": 10, "comprimento": 5 } }
      ]
    }
  ]
}
📤 Exemplo de Saída (JSON)
json
Copiar
Editar
{
  "pedidos": [
    {
      "pedido_id": 1,
      "caixas": [
        {
          "caixa_id": "Caixa 2",
          "produtos": ["A", "B"]
        }
      ]
    }
  ]
}
🧪 Testes Unitários
Os testes estão localizados na pasta /LojaDoSeuManoel.Tests e podem ser executados via:

bash
Copiar
Editar
dotnet test  
📌 Observações
A API está configurada para rodar via Docker, incluindo o SQL Server.

Caso deseje rodar sem Docker, configure o appsettings.json com sua connection string local.

