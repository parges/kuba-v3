﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using kubaapi.DTO;
using kubaapi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kuba_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json", "application/json-patch+json", "multipart/form-data")]
    public class PatientController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly IHostingEnvironment _environment;
        private readonly ImageUploader.Helper.IImageHandler _imageHandler;

        private string _imagePath;

        public PatientController(DBContext context, IHostingEnvironment environment, ImageUploader.Helper.IImageHandler imageHandler)
        {
            _context = context;
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
            _imageHandler = imageHandler;
            _imagePath = _environment.ContentRootPath + @"\Resources\Images";
        }

        // GET: api/Patient
        [HttpGet]
        public ActionResult<List<Patient>> GetAll()
        {
             return _context.Patients.ToList();
        }

        // GET: api/Patient/5
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
            /*var image = System.IO.File.OpenRead(_imagePath + );#1#
            patient.Avatar = item.Avatar;*/

            return item;
        }

        /*// GET: api/Patient/5
        [HttpGet("{filename}", Name = "GetImage")]
        public IActionResult GetImage(string filename)
        {
            var patient = _context.Patients.Where(x => x.Avatar == filename);

            var bytes = System.IO.File.ReadAllBytes(_imagePath + filename);

            return File(bytes, "application/image");

            /*PatientDto patient = new PatientDto();
            patient.Id = item.Id;
            patient.Firstname = item.Firstname;
            patient.Lastname = item.Lastname;
            patient.Birthday = item.Birthday;
            patient.Tele = item.Tele;
            /*var image = System.IO.File.OpenRead(_imagePath + );#2#
            patient.Avatar = item.Avatar;#1#

        }*/

        // POST: api/Patient
        [HttpPost]
        public ActionResult Create(Patient item)
        {
            _context.Patients.Add(item);
            _context.SaveChanges();

            return Ok();
            //return CreatedAtRoute("Get", new {id = item.Id}, item);
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
            }*/

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

        
        
    }
}
