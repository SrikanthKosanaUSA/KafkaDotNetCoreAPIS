using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;

namespace KafkaNetCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ProducerConfig _config;
        private readonly ConsumerConfig _consumerconf;
        private string topic;
        private string consumertopic;

        public ValuesController(KafkaConfiguration config, ConsumerConfiguration consumerconf)
        {
            _config = config;
            topic = config.topic;
            _consumerconf = consumerconf;
            consumertopic = consumerconf.topic;

        }

        // GET api/values
        [HttpGet]
        public string Get()
        {
            KafkaReader reader = new KafkaReader(_consumerconf, topic);
            string message = reader.Reader();
            return message;

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post( string message)
        {
            KafkaWriter writer = new KafkaWriter(_config, topic);
            writer.Writer(message);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
