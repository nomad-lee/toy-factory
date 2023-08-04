namespace BaseProject.Models
{
    public class LoginModel
    {
        public int Id { get; set; }
        public string pw { get; set; }

        public List<LoginLogModel> LoginLogModels { get; } = new List<LoginLogModel>();
    }
}
