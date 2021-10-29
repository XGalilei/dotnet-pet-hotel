using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context)
        {
            _context = context;
        }



        [HttpGet]
        public IEnumerable<PetOwner> GetOwners()
        {
            return _context.PetOwners
            //.Include(pet => pet.pets.Count)
            ;
            //Include is probably the way to go, the question is what?
        }

        [HttpGet("{id}")]
        public ActionResult<PetOwner> GetById(int id)
        {
            PetOwner owner = _context.PetOwners
                .SingleOrDefault(owner => owner.id == id);

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

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // Find the bread, by ID
            PetOwner owner = _context.PetOwners.Find(id);

            // Tell the DB that we want to remove this bread
            _context.PetOwners.Remove(owner);

            // ...and save the changes to the database
            _context.SaveChanges(); 
        }
    }
}
