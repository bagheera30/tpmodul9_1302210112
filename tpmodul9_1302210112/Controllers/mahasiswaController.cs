using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tpmodul9_1302210112.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class mahasiswaController : ControllerBase
    {
        private static List<mahasiswa> data= new List<mahasiswa>
        {
            new mahasiswa("muhammad rizki alfian","1302210112"),
            new mahasiswa("RYAN DAVID SIAHAAN","1302200003"),
            new mahasiswa("ANDI ERLANGGA SULISTYO HASAN BHAKTI","1302213077"),
            new mahasiswa("ONESIFORUS RADE PUTRA","1302210105")
        };
        // GET: api/<mahasiswaController>
        [HttpGet]
        public IEnumerable<mahasiswa> Get()
        {
            return data;
        }

        // GET api/<mahasiswaController>/5
        [HttpGet("{id}")]
        public ActionResult< mahasiswa> Get(int id)
        {
            try
            {
                if(data == null || id < 0 || id >= data.Count)
                {
                    return NotFound("data mahasiswa tidak ditemukan");
                }
                return data[id];
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<mahasiswaController>
        [HttpPost]
        public void Post([FromBody] mahasiswa value)
        {
            if (value == null)
            {
                BadRequest("Data mahasiswa tidak valid");
                return; 
            }
            data.Add(value);
            CreatedAtAction(nameof(Get), new { id = data.IndexOf(value) }, value);
        }

        // PUT api/<mahasiswaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] mahasiswa value)
        {
            try
            {
                if (data == null || id < 0 || id >= data.Count || value == null)
                {
                    NotFound("Data mahasiswa tidak ditemukan atau tidak valid"); // Return a NotFound response if data is null, or id is out of range, or value is null
                    return;
                }

                data[id].nama = value.nama;
                data[id].nim = value.nim;

                NoContent();
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message); // Return a BadRequest response if an exception occurs
            }
        }

        // DELETE api/<mahasiswaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                if (data == null || id < 0 || id >= data.Count)
                {
                    NotFound("Data mahasiswa tidak ditemukan"); // Return a NotFound response if data is null, or id is out of range
                    return;
                }

                data.RemoveAt(id);
                NoContent();
            }
            catch(Exception ex) 
            {
                BadRequest(ex.Message);
            }
        }
    }
}
