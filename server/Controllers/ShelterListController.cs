using sheltermini.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sheltermini.server.Repositories;
using Microsoft.AspNetCore.Cors;

namespace sheltermini.server.Controllers
{
    [ApiController]
    [Route("api/booking")]
    public class ShelterListController : ControllerBase
    {

        private IShelterRepository mRepo;

        public ShelterListController(IShelterRepository repo)
        {
            mRepo = repo;
        }

        [HttpGet]
        [EnableCors("policy")]
        public IEnumerable<Shelter> Get()
        {
            Console.WriteLine("get ");
            return mRepo.getAll();
        }

        [HttpPost]
        public void AddItem(Shelter shelter)
        {
            Console.WriteLine("post " + shelter.Name);
            mRepo.Add(shelter);
        }

  /*      [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            mRepo.Delete(id);
        } 
  */
    }
}

