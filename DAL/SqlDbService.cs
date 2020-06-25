using poprawka.DTO.Requests;
using poprawka.DTO.Responses;
using poprawka.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace poprawka.DAL
{
    public class SqlDbService : IDbService
    {
        private readonly s18687Context _context;

        public SqlDbService(s18687Context context)
        {
            _context = context;
        }

        public GetPetsResponse GetPets(int? year)
        {
            List<Pet> pets;
            if (year != null)
            {
                pets = _context.Pet
                    .Where(x => x.DateRegistered.Year.Equals(year))
                    .OrderBy(x => x.DateRegistered)
                    .ToList(); ;
            }
            else
            {
                pets = _context.Pet
                    .OrderBy(x => x.DateRegistered)
                    .ToList(); ;
            }

            var response = new GetPetsResponse();
            foreach (var pet in pets)
            {
                var volunteers = new List<Volunteer>();
                foreach (var petVolunteer in _context.VolunteerPet.Where(x => x.IdPet.Equals(pet.IdPet)).ToList())
                {
                    volunteers.Add(_context.Volunteer.Single(x => x.IdVolunteer.Equals(petVolunteer.IdVolunteer)));
                }
                response.PetsAndVolunteers.Add(new PetAndVolunteers
                {
                    Pet = pet,
                    Volunteers = volunteers
                });
            }

            return response;
        }

        public Pet PostPet(PostPetRequest request)
        {
            var breedExists = _context.BreedType.Any(x => x.Name.Equals(request.BreedName));
            if (!breedExists)
            {
                _context.BreedType.Add(new BreedType
                {
                    IdBreedType = _context.BreedType.Max(x => x.IdBreedType) + 1,
                    Name = request.Name,
                    Description = null
                });
            }

            var pet = new Pet
            {
                IdPet = _context.Pet.Max(x => x.IdPet) + 1,
                IdBreedType = _context.BreedType.Single(x => x.Name.Equals(request.BreedName)).IdBreedType,
                Name = request.Name,
                IsMale = request.IsMale == 1,
                DateRegistered = request.DateRegistered,
                ApprocimateDateOfBirth = request.ApprocimatedDateOfBirth,
                DateAdopted = DateTime.Now
            };
            _context.Pet.Add(pet);
            _context.SaveChanges();
            return pet;
        }
    }
}
