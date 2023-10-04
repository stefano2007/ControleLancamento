namespace ControleLancamento.Application.DTOs
{
    public class UserAccountDTO
    {
        public int Id { get; set; }
        public AccountDTO Account { get; set; }
        public UserDTO User { get; set; }
        public bool IsUserMain { get; set; }
        public DateTime DateCreate { get; set; }
    }
}
