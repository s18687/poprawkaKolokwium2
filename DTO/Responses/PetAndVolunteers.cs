using poprawka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace poprawka.DTO.Responses
{
    public class PetAndVolunteers
    {
        public Pet Pet { get; set; }

        public List<Volunteer> Volunteers { get; set; }
    }
}
