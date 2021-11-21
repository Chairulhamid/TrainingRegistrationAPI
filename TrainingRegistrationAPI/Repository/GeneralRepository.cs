using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingRegistrationAPI.Context;
using TrainingRegistrationAPI.Repository.Interface;

namespace TrainingRegistrationAPI.Repository
{
    public class GeneralRepository<Context, Entity, Key> : IRepository<Entity, Key>
         where Entity : class
         where Context : MyContext
    {
        private readonly MyContext myContext;
        private readonly DbSet<Entity> entities;

        public GeneralRepository(MyContext myContext)
        {
            this.myContext = myContext;
            entities = myContext.Set<Entity>();
        }

        public int Delete(Key key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entity> Get()
        {
            return entities.ToList();
        }

        public Entity Get(Key key)
        {
            throw new NotImplementedException();
        }

        public int Insert(Entity entity)
        {
            throw new NotImplementedException();
        }

        public int Update(Entity entity, Key key)
        {
            throw new NotImplementedException();
        }
    }
}
