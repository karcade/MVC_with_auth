using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Common.ViewModels.Auth
{
    public class TokenModel
    {
        public string Token { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
    }
}
