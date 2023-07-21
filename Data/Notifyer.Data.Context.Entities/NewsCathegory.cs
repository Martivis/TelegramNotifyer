using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifyer.Data.Context.Entities
{
    public class NewsCathegory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserData> Subscribers { get; set; }
    }
}
