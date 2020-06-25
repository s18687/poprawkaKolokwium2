using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace poprawka.DTO.Requests
{
    public class PostPetRequest
    {
        public string BreedName { get; set; }

        public string Name { get; set; }

        public int IsMale { get; set; }

        public DateTime DateRegistered { get; set; }

        public DateTime ApprocimatedDateOfBirth { get; set; }
    }
}
