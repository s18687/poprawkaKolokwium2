using System;
using System.Collections.Generic;

namespace poprawka.Models
{
    public partial class PlayerTeam
    {
        public int IdTeam { get; set; }
        public int IdPlayer { get; set; }
        public int NumOnShirt { get; set; }
        public string Comment { get; set; }

        public virtual Player IdPlayerNavigation { get; set; }
        public virtual Team IdTeamNavigation { get; set; }
    }
}
