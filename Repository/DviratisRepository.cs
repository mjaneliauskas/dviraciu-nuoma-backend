using dviraciu_nuoma_backend.Models;
using System.Numerics;

namespace dviraciu_nuoma_backend.Repository
{
    public class DviratisRepository : GenericRepository<DviratisModel>, IDviratisRepository
    {
        public DviratisRepository(DatabaseContext context) : base(context)
        {
            DatabaseContext.SeedDatabase(context);
        }
    }
}
