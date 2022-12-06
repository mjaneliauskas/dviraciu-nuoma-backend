using dviraciu_nuoma_backend.Models;
using System.Numerics;

namespace dviraciu_nuoma_backend.Repository
{
    public class KelioneRepository : GenericRepository<KelioneModel>, IKelioneRepository
    {
        public KelioneRepository(DatabaseContext context) : base(context)
        {
            DatabaseContext.SeedDatabase(context);
        }
    }
}
