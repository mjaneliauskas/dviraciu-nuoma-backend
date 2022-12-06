using dviraciu_nuoma_backend.Models;
using dviraciu_nuoma_backend.Repository;

namespace dviraciu_nuoma_backend.Services
{
    public class DviratisService : IDviratisService
    {
        private readonly IDviratisRepository _dviratisRepository;
        public DviratisService(IDviratisRepository dviratisRepository) {
            _dviratisRepository = dviratisRepository;
        }

        public bool SukurtiDvirati(string modelioPavadinimas, DviracioTipasEnum tipas, double kaina, string specifikacija)
        {
            var dviratis = new DviratisModel()
            {
                DviracioKaina = kaina,
                DviracioSpecifikacija = specifikacija,
                DviracioStatusas = DviracioStatusasEnum.LAISVAS,
                DviracioTipas = tipas,
                dviracioPavadinimas = modelioPavadinimas
            };
            _dviratisRepository.Add(dviratis);
            return true;
        }
        public List<DviratisModel> GetAll(DviracioStatusasEnum? filtras)
        {
            return _dviratisRepository.GetAll().Where(dviratis => (filtras!= null &&dviratis.DviracioStatusas == filtras) || filtras == null).ToList();
        }

        public bool IstrintiDvirati(Guid dviracioId)
        {
            var dviratis = _dviratisRepository.Get(dviratis => dviratis.Id.Equals(dviracioId)).FirstOrDefault();
            if (dviratis == null) return false;
            if (dviratis.DviracioStatusas == DviracioStatusasEnum.ISTRINTAS) return false;
            PakeistiDviracioStatusa(dviracioId, DviracioStatusasEnum.ISTRINTAS);
            return true;
        }
        public bool PakeistiDviracioStatusa(Guid dviracioId, DviracioStatusasEnum statusas)
        {
            var dviratis = _dviratisRepository.Get(dviratis => dviratis.Id.Equals(dviracioId)).FirstOrDefault();
            if (dviratis == null) return false;
            dviratis.DviracioStatusas = statusas;
            _dviratisRepository.Update(dviratis);
            return true;

        }
        public bool PakeistiDviracioStatusa(DviratisModel dviratis, DviracioStatusasEnum statusas)
        {
            dviratis.DviracioStatusas = statusas;
            _dviratisRepository.Update(dviratis);
            return true;

        }

        public bool IstrintiDviratiPermament(Guid dviracioId)
        {
            var dviratis = _dviratisRepository.Get(dviratis => dviratis.Id.Equals(dviracioId)).FirstOrDefault();
            if (dviratis == null) return false;
            if (dviratis.DviracioStatusas == DviracioStatusasEnum.UZIMTAS) return false;
            _dviratisRepository.Delete(dviratis);
            return true;
        }

        public DviratisModel? GetById(Guid dviracioId)
        {
            return _dviratisRepository.Get(dviratis => dviratis.Id.Equals(dviracioId)).FirstOrDefault();
        }

        public string GetDviracioSpecifikacijaById(Guid dviracioId)
        {
            var dviratis = GetById(dviracioId);
            if (dviratis == null) return "Toks dviratis neegzistuoja";
            return dviratis.DviracioSpecifikacija;
        }
    }

    public interface IDviratisService
    {
        bool SukurtiDvirati(string modelioPavadinimas, DviracioTipasEnum tipas, double kaina, string specifikacija);
        List<DviratisModel> GetAll(DviracioStatusasEnum? filtras);
        bool IstrintiDvirati(Guid dviracioId);
        bool IstrintiDviratiPermament(Guid dviracioId);
        DviratisModel? GetById(Guid dviracioId);
        string GetDviracioSpecifikacijaById(Guid dviracioId);
        bool PakeistiDviracioStatusa(DviratisModel dviratis, DviracioStatusasEnum statusas);
        bool PakeistiDviracioStatusa(Guid dviracioId, DviracioStatusasEnum statusas);
    }
}
