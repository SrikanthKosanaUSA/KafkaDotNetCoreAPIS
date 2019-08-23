using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KafkaNetCoreAPI
{
    public class ConsumerConfiguration : ConsumerConfig
    {
        public string bootstrapservers { get; set; }

        public string topic { get; set; }

        public string groupID { get; set; }
    }
}
