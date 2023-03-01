using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseContext.Entities
{
    public interface IValidate<T>
        where T : class
    {
        static abstract bool Validate(string username, string password, DbSet<T> Table);
    }
}
