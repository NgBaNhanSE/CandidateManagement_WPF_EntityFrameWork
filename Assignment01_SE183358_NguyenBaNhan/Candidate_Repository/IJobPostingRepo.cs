using Candidate_BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repository
{
    public interface IJobPostingRepo
    {
        public JobPosting GetJobPostingById(string jobId);

        public List<JobPosting> GetJobPostings();
        public bool AddJobPosting(JobPosting jobPosting);
        public bool UpdateJobPosting(JobPosting jobPosting);
        public bool DeleteJobPosting(string jobId);
        List<JobPosting> GetJobPostingByTitle(string title);
    }
}
