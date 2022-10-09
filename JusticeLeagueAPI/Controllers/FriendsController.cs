/* ######################################################################################
     Name: Avinash kumar
     Company: Reboot Software Pvt Ltd (https://www.reboot-software.com/)
     License: Free to use (any body can use)
     Caution: do not use in production server.
  ###################################################################################### */

using JusticeLeagueAPI.Data;
using JusticeLeagueAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JusticeLeagueAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JusticeLeagueController : ControllerBase
    {
        List<Hero> _hero = new List<Hero>();
        public JusticeLeagueController()
        {
            _hero = Heroes.heroes;
        }

        //public static List<Friend> Heroes { get => heroes; set => heroes = value; }

        [HttpGet]
        public async Task<ActionResult<List<Hero>>> Get()
        {
            return Ok(_hero);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hero>> Get(int id)
        {
            var superHero = _hero.Find(o => o.Id == id);

            if (superHero == null)
                return BadRequest("Hero not found.");

            return Ok(superHero);
        }

        [HttpPost]
        public async Task<ActionResult<List<Hero>>> AddHero(Hero hero)
        {
            _hero.Add(hero);
            return Ok(_hero);
        }

        [HttpPut]
        public async Task<ActionResult<List<Hero>>> UpdateHero(Hero hero)
        {
            var heros = _hero.Find(o => o.Id == hero.Id);

            if (heros == null)
                return BadRequest("Invalid request.");

            heros.Name = hero.Name;
            heros.FirstName = hero.FirstName;
            heros.Lastname = hero.Lastname;

            return Ok(_hero);
        }

        [HttpDelete]
        public async Task<ActionResult<List<Hero>>> DeleteHero(int id)
        {
            var hero = _hero.Find(o => o.Id == id);

            if (hero == null)
                return BadRequest("Invalid request.");

            _hero.Remove(hero);

            return Ok(_hero);
        }
    }
}
