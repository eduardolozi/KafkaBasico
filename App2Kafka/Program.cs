using App2Kafka;
var producer = new Producer();
await producer.CriarServidor();
// await producer.BalanceiaTopicoSemConsumer();
await producer.EnviarMensagem("Esse é o Topico 2");
await producer.EnviarMensagem("Teste da segunda aplicacao");
await producer.EnviarMensagem("Kafka é muito massa");
await producer.EnviarMensagem("é muito massa");
