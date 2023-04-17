using sheltermini.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sheltermini.server.Repositories;
using Microsoft.AspNetCore.Cors;
using System.Diagnostics;

namespace sheltermini.server.Controllers
{
    [ApiController]
    [Route("api/shelter")]
    public class ShelterSingleController : ControllerBase
    {

        private IShelterRepository mRepo;

        public ShelterSingleController(IShelterRepository repo)
        {
            mRepo = repo;
        }

        [HttpGet("{shelterId}")]
        [EnableCors("policy")]
        public Shelter GetSingle(string shelterId)
        {
            Debug.WriteLine("get single " + shelterId);
            return mRepo.getSingle(shelterId);
        }
    }
}

