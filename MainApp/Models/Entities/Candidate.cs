using System.Collections.Generic;
using MongoDB.Bson;

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
        public ObjectId ContractId { get; set; }
        public State CandidateState { get; set; }
        public ObjectId Id { get; set; }
    }
}