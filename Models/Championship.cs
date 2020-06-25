using System;
using System.Collections.Generic;

namespace poprawka.Models
{
    public partial class Championship
    {
        public Championship()
        {
            ChampionshipTeam = new HashSet<ChampionshipTeam>();
        }

        public int IdChampionship { get; set; }
        public int OfficeNamke { get; set; }

        public virtual ICollection<ChampionshipTeam> ChampionshipTeam { get; set; }
    }
}
