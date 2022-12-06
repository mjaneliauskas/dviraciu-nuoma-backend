using dviraciu_nuoma_backend.Models;
using System.Numerics;

namespace dviraciu_nuoma_backend.Repository
{
    public class UserRepository: GenericRepository<UserModel>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
            DatabaseContext.SeedDatabase(context);
        }
    }
}
