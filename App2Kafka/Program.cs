using App2Kafka;
var producer = new Producer();
await producer.CriarServidor();
await producer.EnviarMensagem(1, "Esse é o Topico 2");
await producer.EnviarMensagem(2, "Teste da segunda aplicacao");
await producer.EnviarMensagem(1, "Kafka é muito massa");
await producer.EnviarMensagem(2, "é muito massa");
