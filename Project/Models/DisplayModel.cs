using System.Collections.Generic;

namespace Project.Models
{
    public class DisplayModel
    {
        public Animal animal { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}
