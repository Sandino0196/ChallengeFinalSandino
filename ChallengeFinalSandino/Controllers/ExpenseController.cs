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
    public class ExpenseController : Controller
    {
        private readonly AppDbContext context;

        public ExpenseController()
        {

        }

        public ExpenseController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Expense> Get()
        {
            return context.Expense.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Expense Get(int id)
        {
            return context.Expense.FirstOrDefault(e => e.ID_Expense == id);
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]Expense value)
        {
            try
            {
                context.Expense.Add(value);
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
        public ActionResult Put(int id, [FromBody]Expense value)
        {
            if(value.ID_Expense == id)
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
            var value = context.Expense.FirstOrDefault(e => e.ID_Expense == id);
            if (value.ID_Expense == id)
            {
                context.Expense.Remove(value);
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
