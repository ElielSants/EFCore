using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore.Legado
{
    public partial class Identity
    {
        public int Id { get; set; }
        public int RealName { get; set; }
        public int HeroId { get; set; }

        public virtual Hero Hero { get; set; }
    }
}
