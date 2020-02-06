using System;
using System.Threading.Tasks;
using MassTransit;

namespace NSvcStart
{
    public class Message
    { 
        public string Text { get; set; }
    }

    class Program
    {
        public static async Task Main()
        {
            try {
                var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
                {
                    var host = sbc.Host(new Uri("rabbitmq://badderboy"), h=>{
                        h.Username("developer");
                        h.Password("developer");
                    });

                    sbc.ReceiveEndpoint("test_queue", ep =>
                    {
                        ep.Handler<Message>(context =>
                        {
                            return Console.Out.WriteLineAsync($"Received: {context.Message.Text}");
                        });
                    });
                });

                await bus.StartAsync(); // This is important!

                await bus.Publish(new Message{Text = "Hi"});
                
                Console.WriteLine("Press any key to exit");
                await Task.Run(() => Console.ReadLine());
                
                await bus.StopAsync();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
