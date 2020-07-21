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
    public class Expense_DetailController : Controller
    {
        private readonly AppDbContext context;

        public Expense_DetailController()
        {

        }

        public Expense_DetailController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Expense_Detail> Get()
        {
            return context.Expense_Detail.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Expense_Detail Get(int idExpense, string idUser)
        {
            return context.Expense_Detail.FirstOrDefault(e => e.ID_Expense == idExpense && e.ID_User == idUser);
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]Expense_Detail value)
        {
            try
            {
                context.Expense_Detail.Add(value);
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
        public ActionResult Put(int idExpense, string idUser, [FromBody]Expense_Detail value)
        {
            if (value.ID_Expense == idExpense && value.ID_User == idUser)
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
        public ActionResult Delete(int idExpense, string idUser)
        {
            var value = context.Expense_Detail.FirstOrDefault(e => e.ID_Expense == idExpense && e.ID_User == idUser);
            if (value.ID_Expense == idExpense && value.ID_User == idUser)
            {
                context.Expense_Detail.Remove(value);
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
