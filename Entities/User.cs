namespace  MomentumRegistrationApi.Entities
{
    public record User :BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set; }
        public string Role { get; set; }
    }
}