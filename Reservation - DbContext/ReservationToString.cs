using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation__DbContext.Models;

public partial class Reservation
{
    public override string ToString()
    {
        return $"{Id} | {FirstName} {LastName} | {PhoneNumber}";
    }
}
