using App2KafkaV2;
var producer = new Producer();
await producer.CriarServidor();
await producer.EnviarMensagem("Essa é a versao 2 do app2");
await producer.EnviarMensagem("Teste da segunda versao da app2");
await producer.EnviarMensagem("Vamo testar isso daqui");
await producer.EnviarMensagem("Abacate");
await producer.EnviarMensagem("Tomate");
