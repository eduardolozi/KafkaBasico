using Confluent.Kafka;
using Microsoft.Extensions.Hosting;

namespace App2Kafka.Consumer
{
    public class Consumer : BackgroundService
    {
        private readonly ConsumerConfig _consumerConfig;
        private readonly IConsumer<Ignore, string> _consumer;
        public Consumer()
        {
            _consumerConfig = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "GrupoApp2",
                AutoOffsetReset = AutoOffsetReset.Earliest,
            };
            _consumer = new ConsumerBuilder<Ignore, string>(_consumerConfig).Build();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try {
                _consumer.Subscribe("Topico-2");
                while (!stoppingToken.IsCancellationRequested)
                {
                    await Task.Run(() =>
                    {
                        var result = _consumer.Consume(stoppingToken);
                        Console.WriteLine($"Mensagem recebida: {result.Message.Value.ToString()}");
                    });
                }
            } catch{
                Console.WriteLine("Erro ao inscrever-se no tópico");
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _consumer.Close();
            Console.WriteLine("Conexão fechada.");
            await Task.CompletedTask;
        }
    }
}
