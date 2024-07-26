using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    internal interface IRoleData
    {
        public async Task<Role> GetByName(string name)
        {
            return await this.context.Roles.AsNoTraking().Where(item = > item.Name == name).FirstOrDefaultAsync();
        }
        
    }
}
