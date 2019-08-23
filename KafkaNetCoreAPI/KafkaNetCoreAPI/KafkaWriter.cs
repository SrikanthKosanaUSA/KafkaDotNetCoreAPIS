using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KafkaNetCoreAPI
{
    public class KafkaWriter : IDisposable
    {
        private ProducerConfig _config;
        private string topicName;
        private ProducerBuilder<Null, String> _producer;

        public KafkaWriter(ProducerConfig config, string topic)
        {
            _config = config;
            topicName = topic;
            _producer = new ProducerBuilder<Null, string>(_config);
        }

        public bool Writer(string message)
        {
            var producer = _producer.Build();
            var deliveryReport = producer.ProduceAsync(topicName, new Message<Null, string> { Value = message });
            return true;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
