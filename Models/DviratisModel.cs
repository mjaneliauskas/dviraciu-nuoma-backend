namespace dviraciu_nuoma_backend.Models
{
    public class DviratisModel
    {
        public Guid Id { get; set; }
        public string dviracioPavadinimas { get; set; }
        public DviracioTipasEnum DviracioTipas { get; set; }
        public double DviracioKaina { get; set; }
        public string DviracioSpecifikacija { get; set; }
        public DviracioStatusasEnum DviracioStatusas { get; set; }
    }
}
