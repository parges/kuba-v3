using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using kubaapi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kuba_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    public class TestungBaseChapterController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly IHostingEnvironment _environment;

        public TestungBaseChapterController(DBContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }

        /*// GET: api/Patient
        [HttpGet]
        public ActionResult<List<TestungBaseChapter>> GetAll()
        {
            /*List<TestungBaseChapter> list = _context.TestungBaseChapters.ToList();
            return list;#1#
        }*/


    }
    }
