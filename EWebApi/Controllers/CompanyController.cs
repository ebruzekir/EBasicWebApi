using AutoMapper;
using EWebApi.Data;
using EWebApi.DTO;
using EWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly EWebApiDB _EWebApiDB;
        private readonly IMapper _mapper;
        public CompanyController(EWebApiDB eWebApiDB, IMapper mapper)
        {
            _EWebApiDB = eWebApiDB;

            _mapper = mapper;

        }
        static List<Company> company = new List<Company>();
        // GET: api/<CompanyController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var company = await _EWebApiDB.Company
            .Include(_ => _.contacts).ToListAsync();
            return Ok(company);
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        //public Company Get(int id)
        // {
        //  return company.FirstOrDefault(c => c.CompanyId == id);
        // }
        public async Task<IActionResult> Get(int id)
        {
             var comanybyId = await _EWebApiDB.Company
            .Include(_ => _.contacts).Where(_ => _.CompanyId == id).FirstOrDefaultAsync();
            return Ok(comanybyId);
         }
        // POST api/<CompanyController>
        [HttpPost]
        public async Task<IActionResult> Post(CompanyDTO companyPayload)
        {
            var newCompany = _mapper.Map<Company>(companyPayload);
            _EWebApiDB.Company.Add(newCompany);
             _EWebApiDB.SaveChanges();
            return Created($"/{newCompany.CompanyId}", newCompany);
        }

        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(CompanyDTO companyPayload)
        {
            var updateCompany = _mapper.Map<Company>(companyPayload);
            _EWebApiDB.Company.Update(updateCompany);
            await _EWebApiDB.SaveChangesAsync();
            return Ok(updateCompany);
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var companyToDelete = await _EWebApiDB.Company
            .Include(_ => _.contacts).Where(_ => _.CompanyId == id).FirstOrDefaultAsync();
            if (companyToDelete == null)
            {
                return NotFound();
            }
            _EWebApiDB.Company.Remove(companyToDelete);
            await _EWebApiDB.SaveChangesAsync();
            return NoContent();
        }
    }
}
