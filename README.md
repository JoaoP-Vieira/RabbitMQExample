# RabbitMQExample

How to Use:
1. Intall and configure a RabbitMQ server
2. Clone this project
3. Set up user secrects to the RabbitMQ.API project:
```json
{
	"RabbitMQ": {
		"Uri": "<YOUR-RABBITMQ-CONN-STR>"
	}
}
```
4. Build and run the RabbitMQ.Consumer project
```bash
./RabbitMQ.Consumer "<YOUR-RABBITMQ-CONN-STR>"
```
5. Build and run the RabbitMQ.API project
