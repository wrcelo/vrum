﻿namespace Wrcelo.VrumApp.Infra.Data.Configs
{
    public class RabbitMQConfig
    {
        public string HostName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string QueueName { get; set; }
        public int Port { get; set; }
    }
}
