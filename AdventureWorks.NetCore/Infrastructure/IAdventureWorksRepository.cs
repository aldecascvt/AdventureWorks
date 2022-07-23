using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorks.NetCore.Repository.Models;

namespace AdventureWorks.NetCore.Infrastructure
{
    public interface IAddresesRepository : IRepository<Address>
     {

        IEnumerable<Address> GetTopVisitedAddresses();

    }
}
