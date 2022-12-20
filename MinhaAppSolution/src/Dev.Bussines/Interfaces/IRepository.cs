using MinhaAp.Busines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Bussines.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
    }
}
