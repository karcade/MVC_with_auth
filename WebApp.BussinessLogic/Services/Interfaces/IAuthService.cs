using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Common.ViewModels;
using WebApp.Common.ViewModels.Auth;
using WebApp.Model.DatabaseModels;

namespace WebApp.BussinessLogic.Services.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(User user);
        TokenModel GetToken(User user);
    }
}
