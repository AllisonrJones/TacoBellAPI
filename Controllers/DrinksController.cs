using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TacoBellAPI.Controllers
{
    [Route("api/[controller]")]
    public class DrinksController : Controller
    {

        private TacoBellDbContext dbContext = new TacoBellDbContext();

        [HttpGet]
        public List<Drink> GetAll()
        {
            return dbContext.Drinks.ToList();
        }

        [HttpGet("Cost")]
        public List<Drink> FreeDrink(bool Free)
        {
            if (Free == true)
            {
            return dbContext.Drinks.Where(b => b.Cost == 0).ToList();
            }
            else
            {
                return dbContext.Drinks.Where(b => b.Cost == 1.00).ToList();
            }
            
        }

        [HttpGet("Slushie")]

        public List<Drink> IsFrozen(bool Slush)
        {

            if (Slush == true)
            {

                return dbContext.Drinks.Where(b => b.Slushie == true).ToList();
            }
            else
            {
                return dbContext.Drinks.Where(b => b.Slushie == false).ToList();
            }

           
        }
        [HttpPost]
         public  Drink addDrink(string name, float cost, bool slushie)
            {
                Drink newdrink = new Drink(name, cost, slushie);
                dbContext.Add(newdrink);
                dbContext.SaveChanges();

                return newdrink; //Common practice to return new object
            }
    }
}
