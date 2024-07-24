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

        private void BalanceiaTopicoSemConsumer()
        {
            _consumer.Subscribe(new List<string> { "Topico-2", "Topico-2V2"});
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
                        if (result.Message.Value.ToString() == "Topico App2V2 perdeu um ou mais consumers")
                        {
                            BalanceiaTopicoSemConsumer();
                            return;
                        }
                        Console.WriteLine($"Mensagem recebida: {result.Message.Value.ToString()}");
                    });
                }
            } catch(Exception e){
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
