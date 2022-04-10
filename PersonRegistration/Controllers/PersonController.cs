using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonRegistration.DB;
using PersonRegistration.Models;

namespace PersonRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        PersonsDBContext _context;
        public PersonController(PersonsDBContext context)
        {
            _context = context;
        }
        //ფიზიკური პირის დამატება

        [HttpPost("Add")]
        public ActionResult Add(Person person)
        {
            if(person.BirthDate.AddYears(18) > DateTime.Today)
            {
                return BadRequest("18 წლამდე დარეგისტრირება არ შეიძლება");
            }

            _context.People.Add(person);
            _context.SaveChanges();
            return Ok();
        }
        //ფიზიკური პირის რედაქტირება

        [HttpPost("Update")]
        public ActionResult Update(Person person)
        {
            var myPerson = _context.People.FirstOrDefault(x => x.Id == person.Id);
            if (myPerson == null) return NotFound();

            if (person.BirthDate.AddYears(18) > DateTime.Today)
            {
                return BadRequest("18 წლამდე დარეგისტრირება არ შეიძლება");
            }

            myPerson.FirstName = person.FirstName;
            myPerson.LastName = person.LastName;
            myPerson.Gender = person.Gender;
            myPerson.PN = person.PN;
            myPerson.BirthDate = person.BirthDate;
            myPerson.CityId = person.CityId;
            myPerson.PhoneNumber = person.PhoneNumber;
            myPerson.PhotoPath = person.PhotoPath;

            _context.SaveChanges();
            return Ok();
        }
        //ფიზიკური პირის წაშლა

        [HttpDelete("Delete")]
        public ActionResult Delete(int Id)
        {
            var myPerson = _context.People.FirstOrDefault(x => x.Id == Id);
            if (myPerson == null) return NotFound();
            _context.People.Remove(myPerson);
            _context.SaveChanges();
            return Ok();
        }

        //ფიზიკური პირის ჩვენება

        [HttpGet("ShowPerson")]
        public ActionResult GetPerson(int Id) 
        {
            var myPerson = _context.People.FirstOrDefault(x => x.Id == Id);
            if (myPerson == null) return NotFound();
            return Ok(myPerson);
        }

        //ფიზიკური პირ-ებ-ის ჩვენება

        [HttpGet("ShowPersons")]
        public ActionResult GetPersons()
        {
            var persons = _context.People.ToList();
            return Ok(persons);
        }

        //ფიზიკური პირების ძებნა

        [HttpGet("ShowPersonsByFilter")]
        public ActionResult GetPersons( string? firstName = "", string? lastName="", string? pn="")
        {
            var persons = _context.People.Where(x => x.FirstName.Contains(firstName)
            && x.LastName.Contains(lastName)
            && x.PN.Contains(pn)).ToList();

            if(persons.Count == 0)
            {
                return NotFound();
            }

            return Ok(persons);
        }

    }
}
