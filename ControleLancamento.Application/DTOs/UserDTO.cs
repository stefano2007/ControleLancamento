namespace ControleLancamento.Application.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Occupation { get; set; }
        public string CellPhone { get; set; }
        public DateTime DateCreate { get; set; }
    }
}
