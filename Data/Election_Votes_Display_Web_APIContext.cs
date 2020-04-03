using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Election_Votes_Display_Web_API.Business;

namespace Election_Votes_Display_Web_API.Models
{
    //Database connection for business layer.
    public class Election_Votes_Display_Web_APIContext : DbContext
    {
        public Election_Votes_Display_Web_APIContext (DbContextOptions<Election_Votes_Display_Web_APIContext> options)
            : base(options)
        {
        }

        public DbSet<Election_Votes_Display_Web_API.Business.CandidateVote> CandidateVote { get; set; }
    }
}
