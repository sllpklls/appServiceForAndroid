using appServiceForAndroid.Data;
using appServiceForAndroid.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Player = appServiceForAndroid.Data.Player;

namespace appServiceForAndroid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {   private readonly MyDbContext _context;
        public PlayerController(MyDbContext context)
        {
            _context = context;
        }
        
        //public static List<Player> players = new List<Player>();
        

        [HttpGet]
        public IActionResult getAll()
        {
            var dsLoai = _context.Players.ToList();
            return Ok(dsLoai);
        }
        [HttpGet("{Name}")]
        public IActionResult GetByName(string Name)
        {
            var dsLoai = _context.Players.SingleOrDefault(pl => pl.Name == Name);
            if (dsLoai != null) return Ok(dsLoai);
            else return NotFound();
        }
        [HttpPost]
        public IActionResult Create(Player player)
        {
            try
            {
                Player pl = new Player
                {
                    Name = player.Name,
                    Max = player.Max
                };
                _context.Add(player);
                _context.SaveChanges();
                return Ok(pl);
            }
            catch 
            {
                return BadRequest();
            }
            
            
        }

        
    }
}
