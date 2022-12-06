namespace dviraciu_nuoma_backend.Models
{
    public class KelioneModel
    {
        public Guid Id { get; set; }
        public DateTime KelionesPradzia { get; set; }
        public DateTime KelionesPabaiga { get; set; }
        public UserModel Vartotojas { get; set; }
        public DviratisModel Dviratis { get; set; }
    }
}
