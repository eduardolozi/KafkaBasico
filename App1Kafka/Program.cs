// See https://aka.ms/new-console-template for more information
using App1Kafka;

var producer = new Producer();
await producer.EnviarMensagem("Oi");
await producer.EnviarMensagem("Sou o Eduardo");
await producer.EnviarMensagem("Tenho 22 anos");
await producer.EnviarMensagem("Sou fã de futebol");
await producer.EnviarMensagem("Gosto de backend");
await producer.EnviarMensagem("Vamo testar isso daqui");
await producer.EnviarMensagem("Valeu");
