using WebApp.Model;
using WebApp.BussinessLogic.Services.Interfaces;
using WebApp.Model.DatabaseModels;
using WebApp.Common.ViewModels;
using AutoMapper;
using System.Security.Cryptography;
using System.Text;
using WebApp.BussinessLogic.Services.Implementation;

namespace WebApp.BussinessLogic.Services.Implementation
{
    public class UserService:IUserService
    {
        private readonly ApplicationContext _db;
        private readonly IAuthService _auth;
        private readonly IMapper _mapper;
        public UserService(ApplicationContext db) => _db = db;

        public IEnumerable<User> GetUsers()
        {
            return _db.Users.ToList();
        }

        public User Get(int id)
        {
            return _db.Users.FirstOrDefault(d => d.Id == id);
        }

        public void Create(User User)
        {
            _db.Users.Add(User);
            _db.SaveChanges();
        }

        public void Update(User User)
        {
            if (!_db.Users.Any(d => d.Id == User.Id))
            {
                return;
            }
            _db.Update(User);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            _db.Users.Remove(_db.Users.FirstOrDefault(d => d.Id == id));
            _db.SaveChanges();
        }

        public void Register(RegisterUser registerUser)
        {
            var user = _mapper.Map<RegisterUser, User>(registerUser);
            HashPassword(registerUser.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        private void HashPassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public UserModel Login(SignInUser signinUser)
        {
            var user = _db.Users.SingleOrDefault(x => x.Username == signinUser.Username);
            if (user == null) return null;
            var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(signinUser.Password));
            for (int i = 0; i < computedHash.Length; i++)
                if (computedHash[i] != user.PasswordHash[i]) return null;

            var userModel = _mapper.Map<User, UserModel>(user);
            userModel.Token = _auth.GenerateToken(user);

            return userModel;
        }
    }
}
