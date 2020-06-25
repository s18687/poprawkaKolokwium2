using poprawka.DTO.Requests;
using poprawka.DTO.Responses;
using poprawka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace poprawka.DAL
{
    public interface IDbService
    {
        public GetPetsResponse GetPets(int? year);

        public Pet PostPet(PostPetRequest request);
    }
}
