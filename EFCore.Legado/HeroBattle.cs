using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore.Legado
{
    public partial class HeroBattle
    {
        public int HeroId { get; set; }
        public int BattleId { get; set; }

        public virtual Battle Battle { get; set; }
        public virtual Hero Hero { get; set; }
    }
}
