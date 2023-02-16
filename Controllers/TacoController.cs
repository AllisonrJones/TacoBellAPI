using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TacoBellAPI.Controllers
{
    [Route("api/[controller]")]
    public class TacoController : Controller
    {
        private TacoBellDbContext dbContext = new TacoBellDbContext();

        [HttpGet]
        public List<Taco> GetAll()
        {
            return dbContext.Tacos.ToList();
        }
        [HttpGet("Shell")]
        public List<Taco> FreeDrink(string shell)
        {
            if (shell == "soft shell")
            {
                return dbContext.Tacos.Where(b => b.SoftShell == true).ToList();
            }
            else if (shell == "dorito")
            {
                return dbContext.Tacos.Where(b => b.Dorito == true).ToList();
            }
            else
            {
                return dbContext.Tacos.ToList();
            }

        }

        [HttpGet("{Name}")]
        public List<Taco> OrderByItem(string Name)
        {
            return dbContext.Tacos.Where(b => b.Name == Name).ToList();
        }

        [HttpDelete]
        public Taco DeleteTacok(string name)
        {
            Taco b = dbContext.Tacos.FirstOrDefault(b => b.Name == name);
            dbContext.Tacos.Remove(b);
            return b;
        }
    }
}

//ANy Changes to DB must dbContext.SaveChanges()