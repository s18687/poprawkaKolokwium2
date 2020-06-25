using System;
using System.Collections.Generic;

namespace poprawka.Models
{
    public partial class ChampionshipTeam
    {
        public int IdTeam { get; set; }
        public int IdChampionship { get; set; }
        public float Score { get; set; }

        public virtual Championship IdChampionshipNavigation { get; set; }
        public virtual Team IdTeamNavigation { get; set; }
    }
}
