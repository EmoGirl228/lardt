namespace lardota2.Contracts.User
{
    public class GetUserResponse
    {
        public string Id { get; set; } = null!;
        public string User { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string role { get; set; } = null!;
    }
}
