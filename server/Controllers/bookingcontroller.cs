using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using server.Repositories;
using sheltermini.server.Repositories;
using sheltermini.Shared;
using System.Diagnostics;

namespace server.Controllers
{
    [ApiController]
    [Route("api/bookinglisten")]
    public class bookingcontroller : ControllerBase
    {
        private IBookingRepos mRepo;
        public bookingcontroller(IBookingRepos repo)
        {
            mRepo = repo;
        }

        [EnableCors("policy")]
        [HttpGet]
        public IEnumerable<Booking> Get()
        {
            Shelter shelter = new Shelter();
            Console.WriteLine("get ");
            return mRepo.getAll(shelter);  
        }
        [EnableCors("policy")]
        [HttpPost]
        public void AddBook(Booking booking)
        {
            Console.WriteLine("post " + booking.FullName);
            mRepo.AddBook(booking);

        }

        [EnableCors("policy")]
        [HttpDelete("{shelterId}")]
        public void DeleteSingle(string shelterId)
        {
            // Console.WriteLine("delete " + shelterId.);
            mRepo.DeleteSingle(shelterId);
        }
    }
    }
    
    
