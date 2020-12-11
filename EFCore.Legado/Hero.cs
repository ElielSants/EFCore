using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore.Legado
{
    public partial class Hero
    {
        public Hero()
        {
            HeroBattles = new HashSet<HeroBattle>();
            Weapons = new HashSet<Weapon>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Identity Identity { get; set; }
        public virtual ICollection<HeroBattle> HeroBattles { get; set; }
        public virtual ICollection<Weapon> Weapons { get; set; }
    }
}
