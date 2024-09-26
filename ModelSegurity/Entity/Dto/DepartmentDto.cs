

namespace Entity.Dto
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
        //country
        public int CountryId { get; set; }
        public string ? Country { get; set; }
    }
}
