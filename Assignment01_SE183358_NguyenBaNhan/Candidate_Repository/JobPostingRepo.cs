using Candidate_BusinessObjects;
using Candidate_DAO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repository
{
    public class JobPostingRepo : IJobPostingRepo
    {
        public JobPosting GetJobPostingById(string jobId)=>JobPostingDAO.Instance.GetJobPostingById(jobId);    
       

        public List<JobPosting> GetJobPostings()=>JobPostingDAO.Instance.GetJobPostings();
        public bool AddJobPosting(JobPosting jobPosting)=> JobPostingDAO.Instance.AddJobPosting(jobPosting);
        public bool UpdateJobPosting(JobPosting jobPosting)=> JobPostingDAO.Instance.UpdateJobPosting(jobPosting);
        public bool DeleteJobPosting(string jobId) => JobPostingDAO.Instance.DeleteJobPosting(jobId);
        public List<JobPosting> GetJobPostingByTitle(string title)=> JobPostingDAO.Instance.GetJobPostingByTitle(title);
    }
}
