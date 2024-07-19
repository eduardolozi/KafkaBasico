using App2Kafka;

var producer = new Producer();
await producer.EnviarMensagem("Esse é o Topico 2");
await producer.EnviarMensagem("Teste da segunda aplicacao");
await producer.EnviarMensagem("Kafka é muito massa");
