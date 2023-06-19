using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }      
        public string Description { get; set; }
        public int FinishedTasks { get; set; }
        public DateTime CreationTime { get; set; }
        public int Points { get; set; }
        public byte[]? Avatar { get; set; }
    }
    
}
