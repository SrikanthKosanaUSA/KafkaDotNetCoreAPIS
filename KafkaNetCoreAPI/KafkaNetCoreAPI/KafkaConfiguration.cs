using Confluent.Kafka;

namespace KafkaNetCoreAPI
{
    public class KafkaConfiguration : ProducerConfig
    {
        public string bootstrapservers { get; set; }

        public string topic { get; set; }
    }
}