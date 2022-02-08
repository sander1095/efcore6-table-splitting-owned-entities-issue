using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace efcore5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EfCoreController : ControllerBase
    {
        private readonly MyDbContext _db;

        public EfCoreController(MyDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<AbstractBaseClass>> Get()
        {
            return await _db.AbstractEntities.ToListAsync();
        }
    }
}
