using System.Collections.Generic;
using Worker.Italia.Entities;

namespace Worker.Italia.Services.Lazio
{
    public interface ILazioService
    {
        void SendCreateEntityCommand(LazioEntity entity);
        void CreateEntity(LazioEntity entity);
        List<LazioEntity> GetAll();
    }
}