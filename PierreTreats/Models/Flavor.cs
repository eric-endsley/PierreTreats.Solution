using System.Collections.Generic;

namespace PierreTreats.Models
{
    public class Flavor
    {
        public Flavor()
        {
            this.Treats = new Hashset<TreatFlavor>();
        }

        public int FlavorId { get; set; }
        public string FlavorName { get; set; }

        public virtual ICollection<TreatFlavor> Treats { get; set;}
    }
}