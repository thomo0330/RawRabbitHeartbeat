using RawRabbit;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Raw.Rabbit.Heartbeat
{
    class Publisher
    {
        IBusClient _client;
        int _timeBetweenMsg;

        public Publisher(IBusClient client, int timeBetweenMsg)
        {
            _client = client;
            _timeBetweenMsg = timeBetweenMsg;
        }

        public void StartPublishing()
        {
            int n = 1;
            while (n > 0)
            {
                _client.PublishAsync(new HeartbeatMessage { serialNumber = n, timeSent = DateTime.Now });
                n++;
                Thread.Sleep(_timeBetweenMsg * 1000);
            }
        }
    }
}
