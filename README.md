# Interviews

Esse projeto é um desafio realizado para um processo de contratação.


Seu escopo se resume em ser possível cadastrar funcionários com suas respectivas contas de FGTS (um valor fixo depositado ao mês correspondente ao salário do funcionário).
Assim como o cadastro também é possível realizar o saque dessa conta. O valor é decidido conforme um limite fixo + adicional por porcentagem da conta.


O projeto possuí uma API Restful, é simples e compacto com a ideia de representar um microsserviço. 
Não foi adicionado um banco de dados para facilitar a execução e criação, visto que o banco apenas armazenaria informações.

Para o tratamento de regra de negócios e retorno ao usuário, estou utilizando o pattern DomainNotification, que implementa uma lista de notificações com mensagens de erro ao usuário.
Esse pattern permite que você retorne mais de um erro ao usuário, diferente de uma simples exception (que retorna uma de cada vez)

Também utilizei AutoMapper para a transição das ViewModels para as Entities do meu Domain.

