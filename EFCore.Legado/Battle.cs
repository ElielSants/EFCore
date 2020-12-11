using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore.Legado
{
    public partial class Battle
    {
        public Battle()
        {
            HeroBattles = new HashSet<HeroBattle>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DtInit { get; set; }
        public DateTime DateEnd { get; set; }

        public virtual ICollection<HeroBattle> HeroBattles { get; set; }
    }
}
