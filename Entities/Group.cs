using System.ComponentModel.DataAnnotations;

namespace back.Entities
{
    public class Group
    {
        public Group()
        {
            
        }
        public Group(string name, ICollection<Connection> connections)
        {
            Name = name;
            
        }

        [Key]
        public string Name { get; set; }
        public ICollection<Connection> Connections { get; set; } = new List<Connection>();
    }
    
}