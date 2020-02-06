# MassTransit Conole example with RabbitMQ transport

To run this example, you need a rabbitmq server.

## Install rabbitmq as docker container

1. Docker install [if needed](https://www.docker.com/products/docker-desktop)
2. Install rabbitmq
```
docker pull rabbitmq:3-management
docker run -d -p 15672:15672 -p 5672:5672 --name rabbit-test-for-medium rabbitmq:3-management
```
3. (optional) open windows firewall ports
Run wf.msc
```
outbound ports add - tcp 15672, 5672
give rule a name: rabbitmq
```
