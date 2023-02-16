using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TacoBellAPI.Controllers
{
    [Route("api/[controller]")]
    public class BurritosController : Controller
    {
         
            private TacoBellDbContext dbContext = new TacoBellDbContext();

            [HttpGet]
            public List<Burrito> GetAll()
            {

                return dbContext.Burritos.ToList();
            }

        [HttpGet("{Id}")]
        public List<Burrito> CheckId(int Id)
        {
            return dbContext.Burritos.Where(b => b.Id == Id).ToList();
        }

        [HttpGet("Bean")]

        public List<Burrito> BeanCheck(bool bean)
        {

            if (bean == true)
            {

                return dbContext.Burritos.Where(b => b.Bean == true).ToList();
            }
            else
            {
                return dbContext.Burritos.Where(b => b.Bean == false).ToList();
            }
        }

            [HttpPost]
        public Burrito Addburrito(string name, float cost, bool bean)
            {
                Burrito newburrito= new Burrito(name, cost, bean);
                dbContext.Burritos.Add(newburrito);
                dbContext.SaveChanges();
                return newburrito; //Common practice to return new object
            }

        
    }
}

