using Microsoft.EntityFrameworkCore;
using Project.Application.Abstractions.Repositories;
using Project.Domain.Entities;
using Project.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure.Data.Repositories
{
    public class ClientProductRepo : GenericRepo<ClientProduct>, IClientProductRepo
    {
        private readonly MarketDbContext _dbContext;

        public ClientProductRepo(MarketDbContext context) : base(context)
        {
            _dbContext = context;
        }

        // Method for entities with composite keys
        public ClientProduct? GetByCompositeKeyAsync(params object[] keyValues)
        {
            var entityType = _dbContext.Model.FindEntityType(typeof(ClientProduct));
            var keyProperties = entityType!.FindPrimaryKey()!.Properties;

            if (keyProperties.Count != keyValues.Length)
            {
                throw new ArgumentException("The number of key values does not match the number of primary key properties.");
            }

            IQueryable<ClientProduct> query = _dbContext.Set<ClientProduct>();

            for (int i = 0; i < keyProperties.Count; i++)
            {
                var keyProperty = keyProperties[i];
                var keyValue = keyValues[i];
                query = query.Where(e => EF.Property<object>(e, keyProperty.Name).Equals(keyValue));
            }

            return query.FirstOrDefault();
        }
    }
}
