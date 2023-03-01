using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseContext.Entities
{
    public class KitchenUsers : IValidate<KitchenUsers>
    {
        [Key]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string PassWord { get; set; }

        public static bool Validate(string username, string password, DbSet<KitchenUsers> Table)
        {
            var valid = from login in Table
                        where login.UserName == username && login.PassWord == password
                        select login;

            return valid.Any();
        }
    }
}
