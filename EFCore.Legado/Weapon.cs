using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore.Legado
{
    public partial class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int HeroId { get; set; }

        public virtual Hero Hero { get; set; }
    }
}
