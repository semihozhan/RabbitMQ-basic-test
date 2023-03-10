using RabbitMQ.Client;
using System;
using System.Text;
using System.Xml;

namespace RabbitMQ.publisher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.Uri= new Uri("amqps://kasdajfs:dejCFCnqfxsAJWQhSZyXXAVTlYsJsnRv@chimpanzee.rmq.cloudamqp.com/kasdajfs");

            using var connection = factory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare("hello-queue", true, false, false);

            string message = "rabbitmq first step";

            var messageBoddy = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(string.Empty, "hello-queue", null, messageBoddy);

            Console.WriteLine("mesaj iletildi");

            Console.ReadLine();
            
        }
    }
}
