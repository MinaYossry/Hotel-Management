using Login___DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_DbContext.Models;

public partial class Kitchen : IValidate<Kitchen>
{
    public static bool Validate(string username, string password, DbSet<Kitchen> Table)
    {
        var valid = from login in Table
                    where login.UserName == username && login.PassWord == password
                    select login;

        return valid.Any();
    }
}
