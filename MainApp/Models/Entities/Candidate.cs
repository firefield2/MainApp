using System.Collections.Generic;
using MongoDB.Bson;
using MainApp.Interfaces;

namespace MainApp.Models.Entities
{
    public class Candidate :IBson
    {
        public enum State
        {
            Presented,
            Interview,
            Rejected,
            Accepted
        }
        public ObjectId PersonId { get; set; }
        public ObjectId ContractId { get; set; }
        public State CandidateState { get; set; }
        public ObjectId Id { get; set; }
    }
}