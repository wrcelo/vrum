namespace Wrcelo.VrumApp.Domain.Entity
{
    public class User
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role {  get; set; }
    }
}
