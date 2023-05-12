using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model.Identity
{
    public class AppUser : IdentityUser
    {
        public string Gender { get; set; }
        public string DoB { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public Role Role { get; set; }

    }
}
