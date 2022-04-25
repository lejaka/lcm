using System;
using Microsoft.EntityFrameworkCore;

namespace LCM.Models

{
    public class FixedFSEs
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string FSEName { get; set; }
        public int FSELevel_ID { get; set; }
        public int Mil2525Code_ID { get; set; }
        public int ParentFSE_ID { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime? LastUpdateDateTime { get; set; }

    }
}