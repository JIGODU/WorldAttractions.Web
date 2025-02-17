namespace WorldAttractionsExplorer.DataAccess.DTOs
{
    public class RegisterModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public DateTime DateOfJoin { get; set; } = DateTime.Now;
    }
}
