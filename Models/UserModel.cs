namespace dviraciu_nuoma_backend.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string PrisijungimoVardas { get; set; }
        public string ElPastas { get; set; }
        public string Slaptazodis { get; set; }
        public RoleEnum Role { get; set; }
    }
}
