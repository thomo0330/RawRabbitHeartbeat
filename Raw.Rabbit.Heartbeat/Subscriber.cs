using RawRabbit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raw.Rabbit.Heartbeat
{
    class Subscriber
    {
        IBusClient _client;
        int _maxTimeBetween;
        int _maxMsgLost;

        public Subscriber(IBusClient client, int maxTimeBetween, int maxMsgLost)
        {
            _client = client;
            _maxTimeBetween = maxTimeBetween;
            _maxMsgLost = maxMsgLost;
        }

        public void StartSubscribing()
        {
            _client.SubscribeAsync<HeartbeatMessage>(async (msg, context) =>
            {
                Console.WriteLine($"Recieved: {msg.Prop}.");
            });
        }
    }
}
