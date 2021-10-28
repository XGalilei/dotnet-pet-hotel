using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{

    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context)
        {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<PetOwner> GetPets()
        {
            return new List<PetOwner>();
        }

        [HttpGet]
        public IEnumerable<PetOwner> GetPetOwners() 
    {
        return _context.PetOwners
            // Include the `bakedBy` property
            // which is a list of `Baker` objects
            // .NET will do a JOIN for us!
            .Include(owner => owner.id);
    }

        [HttpGet("{id}")]
        public ActionResult<PetOwner> GetById(int id)
        {
            PetOwner owner = _context.PetOwners
                .SingleOrDefault(PetOwner => PetOwner.id == id);

            if (owner is null)
            {
                return NotFound();
            }
            return owner;
        }

        //currently a stub for /POST
        [HttpPost]
        public PetOwner Post(PetOwner owner)
        {
            _context.Add(owner);
            _context.SaveChanges();
            return owner;
        }

        [HttpPut("{id}")]
        public PetOwner Put(int id, PetOwner owner)
        {

            owner.id = id;

            _context.Update(owner);

            _context.SaveChanges();

            return owner;
        }



    }
}
