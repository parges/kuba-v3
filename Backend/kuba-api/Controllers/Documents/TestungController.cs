using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using kubaapi.Models;
using kubaapi.utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kuba_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    public class TestungController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly IHostingEnvironment _environment;

        public TestungController(DBContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }

        // GET: api/Documents
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestungByUser(int Id)
        {
            var testung = _context.Testungen.Where(x => x.PatientId == Id)
                .Include(x => x.Chapters)
                .ThenInclude(y => y.Questions).ToList();

            QueryResponse<Testung> response = new QueryResponse<Testung>();
            response.Items = testung;
            response.TotalRecords = 1;
            return Ok(response);
        }

        // PUT: api/Patient/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, Testung item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var testung = _context.Testungen.SingleOrDefault(m => m.Id == id);
            if (item == null)
            {
                return NoContent();
            }
            testung.Date = DateTime.Now;
            testung.Name = "Testung von "; // + _patient.Firstname + "_" + _patient.Lastname;
            /*testung.Questions = new List<TestungQuestion>();*/

            /*foreach (TestungQuestion question in item.Questions)
            {
                testung.Questions.Add(question);
            }*/
            
            _context.Testungen.Update(testung);
            await _context.SaveChangesAsync();
            return Ok(testung);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var patient = _context.Patients.Find(id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        }
    }
