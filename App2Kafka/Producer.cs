using Confluent.Kafka;
using Confluent.Kafka.Admin;
using System.Runtime.CompilerServices;

namespace App2Kafka
{
    public class Producer
    {
        private readonly TopicSpecification topico = new()
        {
            NumPartitions = 2,
            Name = "Topico-2"
        };
        private readonly string brokerUrl = "localhost:9092";
        private readonly ProducerConfig _config;
        private readonly IProducer<int, string> _producer;
        private readonly AdminClientConfig _adminConfig;
        private readonly IAdminClient _adminClient;

        public Producer()
        {
            _config = new ProducerConfig { BootstrapServers = brokerUrl, Partitioner = Partitioner.Random};
            _adminConfig = new AdminClientConfig { BootstrapServers = brokerUrl };
            _producer = new ProducerBuilder<int, string>(_config).Build();
            _adminClient = new AdminClientBuilder(_adminConfig).Build();
            
        }

        private bool ServidorJaExiste()
        {
            var metadataTopico = _adminClient.GetMetadata(TimeSpan.FromSeconds(15));
            var topicoNoBroker = metadataTopico
                                .Topics
                                .FirstOrDefault(x => x.Topic == topico.Name);
            return topicoNoBroker is not null;
        }

        public async Task CriarServidor()
        {
            var servidorExiste = ServidorJaExiste();
            if (servidorExiste) return;
            await _adminClient.CreateTopicsAsync(new List<TopicSpecification> { topico });
        }

        public async Task EnviarMensagem(string mensagem)
        {
            try
            {
                await _producer.ProduceAsync(topico.Name, new Message<int, string> {Value = mensagem });
                Console.WriteLine($"Mensagem enviada: {mensagem}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.ToString}: Erro ao enviar a mensagem");
            }
        }
    }
}
