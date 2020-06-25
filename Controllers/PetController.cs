using Microsoft.AspNetCore.Mvc;
using poprawka.DAL;
using poprawka.DTO.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace poprawka.Controllers
{
    [ApiController]
    [Route("api/pets")]
    public class PetController : ControllerBase
    {
        private readonly IDbService _service;

        public PetController(IDbService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetPets(int? year)
        {
            IActionResult response;
            try
            {
                response = Ok(_service.GetPets(year));

            }
            catch (Exception e)
            {
                response = BadRequest(e.Message);
            }

            return response;
        }

        [HttpPost]
        public IActionResult PostPet(PostPetRequest request)
        {
            IActionResult response;
            try
            {
                response = Created("Pet created successfully", _service.PostPet(request));
            }
            catch (Exception e)
            {
                response = BadRequest(e.Message);
            }

            return response;
        }
    }
}
