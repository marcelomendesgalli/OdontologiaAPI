# OdontologiaAPI

OdontologiaAPI é uma aplicação ASP.NET Core Web API desenvolvida para gerenciamento de clínicas odontológicas, demonstrando princípios de arquitetura de software, design patterns, técnicas de documentação, testes e integração com banco de dados.

## Arquitetura e Design Patterns

Este projeto implementa uma arquitetura em camadas e utilizando diversos design patterns:

1. **Arquitetura em Camadas**:
- Controllers (API)
- Services (Lógica de Negócios)
- Repositories (Acesso a Dados)
- Models (Entidades e DTOs)

2. **Design Patterns**:
- Repository Pattern: Abstração do acesso a dados
- Dependency Injection: Injeção de dependências para baixo acoplamento
- Factory Method: Criação de instâncias de repositórios
- Singleton: Utilizado no ConfigurationManager
- Middleware: Para tratamento global de erros


## Tecnologias Utilizadas

- ASP.NET Core 9.0
- Entity Framework Core para ORM
- Oracle Database para persistência de dados
- Swagger para documentação da API
- JWT para autenticação e autorização
