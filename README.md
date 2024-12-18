# Web API E-Commerce com Padrão Saga e Clean Architecture

## Descrição

Este projeto implementa uma Web API para um **e-commerce** utilizando os conceitos de **Clean Architecture** e o **padrão Saga** para orquestrar transações complexas entre diferentes microsserviços, garantindo a consistência dos dados de forma robusta e eficiente. O projeto também emprega o **padrão Strategy** para permitir a flexibilidade e a troca de estratégias em determinados processos do sistema.

## Tecnologias Utilizadas

- **.NET Core 8** (ou superior)
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **Swagger** (para documentação da API)
- **Clean Architecture** (para garantir uma estrutura de código desacoplada e de fácil manutenção)
- **Padrão Saga** (para coordenação de transações distribuídas)
- **Padrão Strategy** (para aplicar diferentes estratégias em partes do processo de e-commerce)

## Funcionalidades

- **Cadastro de Produtos**: Cadastro, edição e exclusão de produtos no catálogo.
- **Orquestração de Transações**: Uso do padrão Saga para garantir que as transações entre sistemas (como pagamento e envio) sejam realizadas com consistência e que qualquer falha seja devidamente tratada.

## Padrão Saga

O padrão Saga foi implementado para gerenciar as transações distribuídas entre os diferentes serviços, garantindo que as ações em sistemas diversos (como pagamento, estoque e envio) sejam realizadas de maneira sequencial, ou caso ocorra uma falha, que as compensações sejam feitas para manter a consistência.

## Clean Architecture

O projeto segue a **Clean Architecture**, que separa o código em diferentes camadas de responsabilidade, permitindo que o sistema seja modular, desacoplado e facilmente testável. As principais camadas são:

1. **Domain**: Contém a lógica de negócio, entidades e as interfaces.
2. **Application**: Implementa a lógica de aplicação, incluindo os casos de uso.
3. **Infrastructure**: Responsável pela implementação das dependências externas, como banco de dados, APIs e sistemas de mensageria.
4. **Web API**: A camada de entrada da aplicação, que expõe os endpoints da API.

Essa abordagem garante que o sistema seja flexível e fácil de modificar, uma vez que mudanças nas camadas externas não afetam diretamente a lógica de negócios.

## Padrão Strategy
Cada estratégia é implementada como uma classe separada, e a escolha da estratégia é feita dinamicamente com base nas condições do pedido.

## Como Executar o Projeto

### Pré-requisitos

- **.NET Core SDK 8** ou superior
- **SQL Server** ou **PostgreSQL** configurado
- **RabbitMQ** ou **Kafka** para mensageria (dependendo da configuração)

### Passos para Rodar a Aplicação

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/ecommerce-saga.git
   cd ecommerce-saga
   ```

2. Restaure as dependências:
   ```bash
   dotnet restore
   ```
3. Inicie a aplicação:
   ```bash
   dotnet run
   ```

4. Acesse a API através do Swagger em: `http://localhost:5000/swagger`
