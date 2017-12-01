using RawRabbit;
using System;

namespace Raw.Rabbit.Heartbeat
{
    public class Heartbeat : IHeartbeat
    {
        IBusClient _client;
        Publisher _publisher;
        Subscriber _subscriber;

        public Heartbeat(IBusClient client, int timeBetweenMsg, int maxTimeBetween, int maxMsgLost)
        {
            _client = client;
            _publisher = new Publisher(client, timeBetweenMsg);
            _subscriber = new Subscriber(client , maxTimeBetween, maxMsgLost);
        }

        public void StartHeartbeat()
        {
            _publisher.StartPublishing();
            _subscriber.StartSubscribing();
        }
    }
}
