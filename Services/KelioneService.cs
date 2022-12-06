using dviraciu_nuoma_backend.Models;
using dviraciu_nuoma_backend.Repository;

namespace dviraciu_nuoma_backend.Services
{
    public class KelioneService : IKelioneService
    {
        private readonly IKelioneRepository _kelioneRepository;
        private readonly IUserService _userService;
        private readonly IDviratisService _dviratisService;
        public KelioneService(IKelioneRepository kelioneRepository, IDviratisService dviratisService, IUserService userService) {
            _kelioneRepository = kelioneRepository;
            _dviratisService = dviratisService;
            _userService = userService;
        }

        public Guid StartKelione(Guid dviracioId, string username)
        {
            var dviratis = _dviratisService.GetById(dviracioId);
            if (dviratis == null) return Guid.Empty;
            if (dviratis.DviracioStatusas != DviracioStatusasEnum.LAISVAS) return Guid.Empty;
            var user = _userService.GetUserByUsername(username);
            if (user == null) return Guid.Empty;
            if (dviratis.DviracioStatusas != DviracioStatusasEnum.ISTRINTAS) _dviratisService.PakeistiDviracioStatusa(dviratis, DviracioStatusasEnum.UZIMTAS);
            var kelione = new KelioneModel()
            {
                Dviratis = dviratis,
                KelionesPradzia = DateTime.Now,
                Vartotojas = user
            };
            var naujaKelione = _kelioneRepository.Add(kelione);
            if (naujaKelione == null) return Guid.Empty;
            return naujaKelione.Id;


        }

        public bool EndKelione(Guid kelionesId)
        {
            var kelione = _kelioneRepository.Get(kelione => kelione.Id.Equals(kelionesId)).FirstOrDefault();
            if (kelione == null) return false;
            kelione.KelionesPabaiga = DateTime.Now;
            if (kelione.Dviratis.DviracioStatusas != DviracioStatusasEnum.ISTRINTAS) _dviratisService.PakeistiDviracioStatusa(kelione.Dviratis, DviracioStatusasEnum.LAISVAS);
            _kelioneRepository.Update(kelione);
            return true;
        }
    }

    public interface IKelioneService
    {
        Guid StartKelione(Guid dviracioId, string username);
        bool EndKelione(Guid kelionesId);
    }
}
