using Entity.Model.Security;

namespace Entity.Dto
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public string ? Department { get; set; }
        public bool State { get; set; }
    }
}
