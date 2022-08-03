using WebApp.Common.ViewModels;
using WebApp.Model.DatabaseModels;

namespace WebApp.BussinessLogic.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User Get(int id);
        void Create(User User);
        void Update(User User);
        void Delete(int id);
        void Register(RegisterUser registerUser);
        UserModel Login(SignInUser signinUser);
    }
}
