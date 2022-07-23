using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.NetCore.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveChanges();
        Task<int> SaveChangesAsync();

        Task<int> ExecuteSQLCommand(string sql,params object[] parameters);



    }
}
