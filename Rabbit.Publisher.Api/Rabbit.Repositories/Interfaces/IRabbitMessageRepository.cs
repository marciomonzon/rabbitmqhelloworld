using Rabbit.Model.Entities;

namespace Rabbit.Repositories.Interfaces
{
    public interface IRabbitMessageRepository
    {
        void SendMessage(RabbitMessage message);
    }
}
