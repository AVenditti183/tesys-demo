using System;
using System.Collections.Generic;
using System.Linq;
using MassTransit;
using Worker.Italia.Entities;
using Worker.Italia.Messages.Internal;

namespace Worker.Italia.Services.Lazio
{
    public class LazioService : ILazioService
    {
        private readonly IBus bus;
        private List<LazioEntity> lst;
        private int count;

        public LazioService(IBus bus)
        {
            this.bus = bus;
            lst = new List<LazioEntity>();
            count = 0;
        }

        public void SendCreateEntityCommand(LazioEntity entity)
        {
            var message = new CreateLazioCommand
            {
                Name = entity.Name,
                LastName = entity.LastName
            };

            bus.Publish(message);
        }

        public void CreateEntity(LazioEntity entity)
        {
            count++;
            if (count % 2 == 0)
                throw new Exception();

            entity.Id = lst.Any() ? lst.Max(s => s.Id) + 1 : 1;
            //entity.Id = (lst
            //    .OrderByDescending(s => s.Id)
            //    .FirstOrDefault()?.Id ?? 0) + 1;

            lst.Add(entity);
        }

        public List<LazioEntity> GetAll()
            => lst;
    }
}