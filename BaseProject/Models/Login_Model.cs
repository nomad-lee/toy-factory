namespace BaseProject.Models
{
    public class Login_Model
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public List<Login_Log_Model> LoginLogModels { get; } = new List<Login_Log_Model>();
    }
}
