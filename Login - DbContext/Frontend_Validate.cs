using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Login_DbContext.Models;
using Login___DbContext;
using System.ComponentModel.DataAnnotations.Schema;

namespace Login_DbContext.Models;

public partial class Frontend : IValidate<Frontend>
{
    public static bool Validate(string username, string password, DbSet<Frontend> table)
    {
        var valid = from login in table
                    where login.UserName == username && login.PassWord == password
                    select login;

        return valid.Any();
    }
}
