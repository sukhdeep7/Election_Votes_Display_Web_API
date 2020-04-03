using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Election_Votes_Display_Web_API.Business
{
    //Candidate vote details business class
    public class CandidateVote
    {
        public int Id { get; set; }

        public string Candidate { get; set; }

        public string Party { get; set; }

        public int NumberOfVotes { get; set; }

    }
}
