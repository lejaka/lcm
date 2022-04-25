using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LCM.Models
{
    public class UserGroup
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime? LastUpdateDateTime { get; set; }
    }
}