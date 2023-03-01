using DatabaseContext.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseContext.Context
{
    public class LoginContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=HotelReservationDB;Integrated Security=True;Encrypt=False");
        }

        public virtual DbSet<HotelUsers> HotelUsers { get; set; }
        public virtual DbSet<KitchenUsers> KitchenUsers { get; set;}
    }
}
