using System;
using System.Collections.Generic;

namespace poprawka.Models
{
    public partial class VolunteerPet
    {
        public DateTime DataAccepted { get; set; }
        public int IdPet { get; set; }
        public int IdVolunteer { get; set; }

        public virtual Pet IdPetNavigation { get; set; }
        public virtual Volunteer IdVolunteerNavigation { get; set; }
    }
}
