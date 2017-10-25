using MainApp.Models;
using MainApp.Models.Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MainApp.Controllers
{
    public class TestController : ApiController
    {

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            switch (id)
            {
                case 1:
                    Repository<Person> database1 = new Repository<Person>("persons");
                    database1.Add(new Person()
                    {
                        City = "test",
                        Country = "test",
                        PhoneNumber = "111222333",
                        StreetAndNumber = "Testowa 22",
                        ZipCode = "00-555",
                        AvailabilityInDays = 30,
                        FirstName = "test",
                        LastName = "test",
                        Price = 10000,
                        Skills = new List<Skill>() {
                            new Skill() {
                                Level = "test",
                                Name = "JS"
                            }
                        },
                        Expirience = new List<WorkExpirience>() {
                            new WorkExpirience() {
                                CompanyName = "test",
                                Description= "test",
                                EndWork = DateTime.Now.Date,
                                StartWork = DateTime.Now.Date,
                            }
                        },
                        Files = new List<Cv>() {
                            new Cv() {
                                FileId = new ObjectId(),
                                Description = "test",
                                Name = "test",
                            }
                        }
                    });
                    break;
                case 2:
                    Repository<Company> database2 = new Repository<Company>("companies");
                    database2.Add(new Company()
                    {
                        Contacts = new List<Contact>() {
                            new Contact() {
                                FullName = "test",
                                PhoneNumber = "test"
                            }
                        },
                        City = "test",
                        Country = "test",
                        Name = "test",
                        StreetAndNumber = "test 22",
                        ZipCode = "05-00d"
                    });
                    break;
                case 3:
                    Repository<ContactHistory> database3 = new Repository<ContactHistory>("contactHistories");
                    database3.Add(new ContactHistory() {
                        CandidateId = new ObjectId(),
                        Events = new List<ContactEvent>() {
                            new ContactEvent() {
                                Date = DateTime.Now,
                                Description = "test"
                            }
                        }
                    });
                    break;
                case 4:
                    Repository<Contract> database4 = new Repository<Contract>("contracts");
                    database4.Add(new Contract() {
                        CompanyId = new ObjectId(),
                        ContractState = Contract.State.Opened,
                        AvailabilityInDays = 30,
                        NeededPersons = 3,
                        StillNeededPersons = 2,
                        Salary = 1000,
                        Skills = new List<Skill>()
                        {
                            new Skill()
                            {
                                Level = "master",
                                Name = "JS"
                            }
                        }
                    });
                    break;
                case 5:
                    Repository<FinishedContract> database5 = new Repository<FinishedContract>("finishedContracts");
                    database5.Add(new FinishedContract()
                    {
                        CompanyId = new ObjectId(),
                        PersonId = new ObjectId(),
                        Salary = 10000,
                        WorkEnd = DateTime.Now,
                        WorkStart = DateTime.Now
                    });
                    break;
                case 6:
                    Repository<Candidate> database6 = new Repository<Candidate>("candidates");
                    database6.Add(new Candidate()
                    {
                        ContractId = new ObjectId(),
                        CandidateState = Candidate.State.Rejected
                        
                    });
                    break;
                default:
                    break;
            }
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}