using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public DateTime DeletedAt { get; set; }

        public bool State { get; set; }
        //country
        private int CountryId { get; set; }
        private Country Country { get; set; }
    }
}
