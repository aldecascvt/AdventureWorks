using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.NetCore.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly DbContext _context;
        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public virtual  int ExecuteSQLCommand(string sql, params object[] parameters)
        {
            return  _context.Database.ExecuteSqlRaw(sql, parameters);
        }

        public int SaveChanges() => _context.SaveChanges();


       
    }
}
