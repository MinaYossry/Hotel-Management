using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DatabaseContext.Entities
{
    public class HotelUsers : IValidate<HotelUsers>
    {
        [Key]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string PassWord { get; set; }

        public static bool Validate(string username, string password, DbSet<HotelUsers> Table)
        {
            var valid = from login in Table
                        where login.UserName == username && login.PassWord == password
                        select login;

            return valid.Any();
        }
    }
}
