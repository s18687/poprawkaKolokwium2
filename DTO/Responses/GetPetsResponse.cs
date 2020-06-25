using poprawka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace poprawka.DTO.Responses
{
    public class GetPetsResponse
    {
        public List<PetAndVolunteers> PetsAndVolunteers { get; set; }
    }
}
