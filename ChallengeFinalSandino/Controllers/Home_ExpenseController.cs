using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChallengeFinalSandino.Contexts;
using ChallengeFinalSandino.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChallengeFinalSandino.Controllers
{
    [Route("api/[controller]")]
    public class Home_ExpenseController : Controller
    {
        private readonly AppDbContext context;

        public Home_ExpenseController()
        {

        }

        public Home_ExpenseController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Home_Expense> Get()
        {
            return context.Home_Expense.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Home_Expense Get(int id)
        {
            return context.Home_Expense.FirstOrDefault(e => e.ID_Home_Expense == id);
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]Home_Expense value)
        {
            try
            {
                context.Home_Expense.Add(value);
                context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Home_Expense value)
        {
            if (value.ID_Home_Expense == id)
            {
                context.Entry(value).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var value = context.Home_Expense.FirstOrDefault(e => e.ID_Home_Expense == id);
            if (value.ID_Home_Expense == id)
            {
                context.Home_Expense.Remove(value);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
