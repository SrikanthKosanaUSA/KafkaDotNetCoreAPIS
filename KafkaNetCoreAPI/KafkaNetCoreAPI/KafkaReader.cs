using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KafkaNetCoreAPI
{
    public class KafkaReader : IDisposable
    {
        private ConsumerConfig config;

        private string topicName;

        private ConsumerBuilder<Ignore, string> consumer;

        public KafkaReader(ConsumerConfig conf, string topic)
        {
            config = conf;
            config.AutoOffsetReset = AutoOffsetReset.Earliest;
            topicName = topic;
            consumer = new ConsumerBuilder<Ignore, string>(config);

        }

        public string Reader()
        {
            var consumerBuild = consumer.Build();
            consumerBuild.Subscribe(topicName);
            var result = consumerBuild.Consume();
            string res = result.Value;
            return res;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
