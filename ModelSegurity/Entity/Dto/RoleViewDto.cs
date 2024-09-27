using Entity.Model.Security;

namespace Entity.Dto
{
    public class RoleViewDto
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string ? Role { get; set; }
        public int ViewId { get; set; }
        public string ? View { get; set; }

        public bool State { get; set; }
    }
}
