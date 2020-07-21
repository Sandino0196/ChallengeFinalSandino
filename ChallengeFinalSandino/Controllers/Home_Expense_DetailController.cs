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
    public class Home_Expense_DetailController : Controller
    {
        private readonly AppDbContext context;

        public Home_Expense_DetailController()
        {

        }

        public Home_Expense_DetailController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Home_Expense_Detail> Get()
        {
            return context.Home_Expense_Detail.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Home_Expense_Detail Get(int idHome_Expense, string idUser)
        {
            return context.Home_Expense_Detail.FirstOrDefault(e => e.ID_Home_Expense == idHome_Expense && e.ID_User == idUser);
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]Home_Expense_Detail value)
        {
            try
            {
                context.Home_Expense_Detail.Add(value);
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
        public ActionResult Put(int idHome_Expense, string idUser, [FromBody]Home_Expense_Detail value)
        {
            if (value.ID_Home_Expense == idHome_Expense && value.ID_User == idUser)
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
        public ActionResult Delete(int idHome_Expense, string idUser)
        {
            var value = context.Home_Expense_Detail.FirstOrDefault(e => e.ID_Home_Expense == idHome_Expense && e.ID_User == idUser);
            if (value.ID_Home_Expense == idHome_Expense && value.ID_User == idUser)
            {
                context.Home_Expense_Detail.Remove(value);
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
