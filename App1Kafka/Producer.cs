using Confluent.Kafka;

namespace App1Kafka
{
    public class Producer
    {
        private readonly ProducerConfig _config;
        private readonly IProducer<Null, string> _producer;
        public Producer() 
        {
            _config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092",
            };
            _producer = new ProducerBuilder<Null, string>(_config).Build();
        }

        public async Task EnviarMensagem(string mensagem)
        {
            try
            {
                await _producer.ProduceAsync("Topico-1", new Message<Null, string> { Value = mensagem });
                Console.WriteLine($"Mensagem enviada: {mensagem}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.ToString}: Erro ao enviar a mensagem");
            }
        }
    }
}
