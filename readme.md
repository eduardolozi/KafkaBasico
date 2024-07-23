# GUIA PARA A APLICACAO


## Comando para abrir o Bash do Kafka no Docker
docker exec -it kafkamultiplasversoes-kafka-1 /bin/bash


## Comando para um grupo de consumidores ler um topico
kafka-console-consumer --bootstrap-server localhost:9092 --topic Topico-2V2 --group GrupoApp2


