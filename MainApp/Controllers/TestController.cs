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
        //WARNING --!-- NUCLEAR WASTELAND --!--  FOR NUCLEAR TESTS ONLY

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
                        ExpectedSalary = 10000,
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
                        Files = new List<File>() {
                            new File() {
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
                        PersonsForContract = 3,
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
                        CandidateId = new ObjectId(),
                        FinalSalary = 10000,
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
                case 7:
                    Repository<AppDictionary> database7 = new Repository<AppDictionary>("Dictionary");
                    database7.Add(new AppDictionary()
                    {
                        Skills =new List<DictionarySkill>
                        {
                            new DictionarySkill()
                            {
                                Type = "Language",
                                Name = "Angielski"
                            },
                            new DictionarySkill()
                            {
                                Type = "Programing Language",
                                Name = "JS"
                            }
                        },
                        SkillTypes = new List<string>
                        {
                            "Language",
                            "Programing Language"
                        }
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