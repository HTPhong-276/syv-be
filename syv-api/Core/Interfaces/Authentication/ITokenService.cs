using Core.Model.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Authentication
{
    public interface ITokenService
    {
        string CreateToken(AppUser appUser);
    }
}
