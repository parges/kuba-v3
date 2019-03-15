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
        public ActionResult<Testung> GetByUser(int Id)
        {
            var testung = _context.Testungen.Where(x => x.Id == Id)
                .Include(x => x.Questions)
                .ThenInclude(x => x.Data).FirstOrDefault();
                            ;
            if (testung == null)
            {
                return NotFound();
            }
            return testung;
        }

        // PUT: api/Patient/5
        [HttpPut("{id}")]
        public ActionResult UpdateAsync([FromRoute] int id, Testung item)
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
            testung.Questions = new List<TestungDetails>();

            foreach (TestungDetails question in item.Questions)
            {
                testung.Questions.Add(question);
            }
            
            _context.Testungen.Update(testung);
            _context.SaveChanges();
            return Ok(testung);
        }

        // POST: api/Patient
        /*[HttpPost]
        public ActionResult Create(Testung item)
        {
            _context.Testung.Add(item);
            _context.SaveChanges();

            return Ok();
            //return CreatedAtRoute("Get", new {id = item.Id}, item);
        }*/

            /*// GET: api/Patient/5
            [HttpGet("{id}", Name = "Get")]
            public ActionResult<Patient> Get(int id)
            {
                var item = _context.Patients.Find(id);
                if (item == null)
                {
                    return NotFound();
                }

                /*PatientDto patient = new PatientDto();
                patient.Id = item.Id;
                patient.Firstname = item.Firstname;
                patient.Lastname = item.Lastname;
                patient.Birthday = item.Birthday;
                patient.Tele = item.Tele;
                /*var image = System.IO.File.OpenRead(_imagePath + );#2#
                patient.Avatar = item.Avatar;#1#

                return item;
            }



            // PUT: api/Patient/5
            [HttpPut("{id}")]
            public ActionResult UpdateAsync([FromRoute] int id, [FromForm] PatientDto item)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var patient = _context.Patients.SingleOrDefault(m => m.Id == id);
                if (patient == null)
                {
                    return NoContent();
                }
                patient.Firstname = item.Firstname;
                patient.Lastname= item.Lastname;
                patient.Birthday= item.Birthday;
                patient.Tele = item.Tele;

                string filename = _imageHandler.UploadImage(item.Avatar, _imagePath).Result;
                patient.Avatar = filename;
                /*var filePath = Path.Combine(_environment.ContentRootPath, @"Resources/Images", item.Avatar.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    item.Avatar.CopyTo(stream);
                }#1#

                _context.Patients.Update(patient);
                _context.SaveChanges();
                return Ok(patient);
            }

            // DELETE: api/ApiWithActions/5
            [HttpDelete("{id}")]
            public ActionResult Delete(long id)
            {
                var patient = _context.Patients.Find(id);
                if (patient == null)
                {
                    return NotFound();
                }

                _context.Patients.Remove(patient);
                _context.SaveChanges();
                return NoContent();
            }
    */



        }
    }
