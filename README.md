# .NET Microservices Sample using RabbitMQ
This is a first sample of solution using .NET Core as the Web Application/Microservices and using RabbitMQ as Message Broker. 

## The Goal
The basic idea of this solution is to maintain a Banking Microservice that receives Transfer Requests and delivers them to the Transfer Microsrevice, that is who actually does the job. Considering that scenario, we can see a synchronous communication (Web Application Back-End -> Banking Microservice) and a asynchronous communication (Banking Microservice -> RabbitMQ Queue -> Transfer Microservice).

## Release Notes
### V1.0
The solution is functional, with a simple page that inputs some transfer data, and requests to the banking microservice to do the job. In the end, a record in the database should exists with the same data, but stored by another microservice.
There are many things to improve to next versions (be my guest), like:
- Extract RabbitMQ server configuration to a configuration provider.
- Improve the UI with a better looking and add some response to the operation.
- Failure controls.
- Authentication.
- And much more... 

## Requirements
To be able to execute this solution, the requirements are all about having a RabbitMQ for Messaging between microservices and a SQL Server Instance for storaging some data (for both microservices, the same server could be used, considering this sample situation obviously).

### RabbitMQ
To install and configure a simple RabbitMQ Server Instance, use the [RabbitMQ Site](https://www.rabbitmq.com/) to get and install the last version of it (together to Erlang, that is the RabbitMQ's pre-requirement). The current configuration to this server should be placed at the *BankingMicroRabbit.Infra.Bus.RabbitMQBus.cs* (this should be improved in the future to get this information from some configuration provider).

### SQL Server
Any SQL Server could be used to execute this solution (even the local one). A tutorial for this installation could be found [here](https://docs.microsoft.com/sql/database-engine/install-windows/install-sql-server?view=sql-server-ver15). The connection strings should be placed on the *appSettings.json* of the API projects.


