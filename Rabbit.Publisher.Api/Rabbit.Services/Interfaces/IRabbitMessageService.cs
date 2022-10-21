using Rabbit.Model.Entities;

namespace Rabbit.Services.Interfaces
{
    public interface IRabbitMessageService
    {
        void SendMessage(RabbitMessage message);
    }
}
