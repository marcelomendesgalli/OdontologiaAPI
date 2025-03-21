OdontoGenda
Aplicação ASP.NET MVC para agendamento de consultas odontológicas, com funcionalidades CRUD e interface estilizada com Bootstrap.

Visão Geral do Projeto
OdontoGenda é uma aplicação de gerenciamento de consultas odontológicas que permite ao usuário cadastrar, visualizar, editar e excluir consultas. A aplicação foi desenvolvida com o intuito de facilitar o controle de agendamentos, oferecendo uma interface simples e intuitiva.

A aplicação está construída em ASP.NET MVC Core e utiliza Bootstrap para estilização, seguindo uma estrutura padrão de controlador e views para as ações CRUD.

Funcionalidades
Agendar Consulta: Permite o agendamento de uma nova consulta, com informações como nome do paciente, nome do dentista, data e horário.

Listar Consultas: Exibe todas as consultas agendadas, com opções de editar, visualizar detalhes ou excluir cada consulta.

Editar Consulta: Permite a atualização dos dados de uma consulta já existente.

Excluir Consulta: Remove uma consulta do sistema, com confirmação de exclusão.

Visualizar Detalhes: Exibe detalhes completos de uma consulta.

Inicialização
Para iniciar a aplicação, basta clonar o repositório. No visual studio, após a etapa acima, apenas compile e inicie a aplicação.

Estrutura de Pastas
Controllers: Contém os controladores da aplicação (ConsultaController e HomeController).

Models: Contém os modelos de dados da aplicação, incluindo Consulta.

Views: Exibição das telas.

Consulta: Views relacionadas ao agendamento de consultas (Index, Create, Edit, Delete, Details).

Home: Página inicial padrão do HomeController.

Shared: Contém layouts e scripts compartilhados, como _Layout.cshtml.

Tecnologias Utilizadas:

ASP.NET Core MVC: Framework principal para desenvolvimento da aplicação.

Bootstrap: Biblioteca de CSS para estilização e layout responsivo.

Entity Framework Core (opcional): ORM para manipulação de dados e mapeamento objeto-relacional.

Como Utilizar
Página Inicial: Ao abrir a aplicação, você será direcionado automaticamente para a página de listagem de consultas.

Agendar Nova Consulta: Clique em "Agendar Nova Consulta" para abrir o formulário de criação.

Editar e Excluir: Utilize as opções de editar e excluir em cada consulta da listagem.

Visualizar Detalhes: Clique em "Detalhes" para ver as informações completas de uma consulta específica.

Integrantes
Erick Lopes Silva - RM 553927 Gabriel Sá Bragança - RM 554064 - Marcelo Mendes Galli - RM 553654
