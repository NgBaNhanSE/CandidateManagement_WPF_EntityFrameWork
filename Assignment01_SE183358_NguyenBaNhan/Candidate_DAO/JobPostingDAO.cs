using Candidate_BusinessObjects;
using Candidate_BussinessDAO;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_DAO
{
    public class JobPostingDAO
    {
        private CandidateManagementContext _context;
        private static JobPostingDAO instance;
        public static JobPostingDAO Instance
        {
            get

            {
                if (instance == null)
                {
                    instance = new JobPostingDAO();
                }
                return instance;

            }
        }
        public JobPostingDAO()
        {
            _context = new CandidateManagementContext();
        }
        public JobPosting GetJobPostingById(string jobId)
        {
            return _context.JobPostings.FirstOrDefault(m => m.PostingId.Equals(jobId));
        }
        public List<JobPosting> GetJobPostingByTitle(string title)
        {
            return _context.JobPostings.Where(x => x.JobPostingTitle.Contains(title)).ToList();
        }
        public List<JobPosting> GetJobPostings()
        {
            return _context.JobPostings.ToList();   

        }
        public bool AddJobPosting(JobPosting jobPosting)
        {
            bool result = false;
            JobPosting _jobPosting = this.GetJobPostingById(jobPosting.PostingId);

            try
            {
                if (_jobPosting == null)
                {
                    _context.JobPostings.Add(jobPosting);
                    _context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception e)
            {
                //write log
                throw new Exception(e.Message);
            }
            return result;
        }
        public bool UpdateJobPosting(JobPosting jobPosting)
        {
            bool result = false;
            JobPosting _jobPosting = this.GetJobPostingById(jobPosting.PostingId);
            try
            {
                if (_jobPosting != null)
                {

                    _context.Entry(_jobPosting).State = EntityState.Detached;
                    _context.Entry<JobPosting>(jobPosting).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                    _context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception e)
            {
                // Log the exception
                throw new Exception(e.Message);
            }
            return result;
        }
        public bool DeleteJobPosting(string jobId)
        {
            bool result = false;
            JobPosting jobPosting = this.GetJobPostingById(jobId);
            try
            {
                if (jobPosting != null)
                {
                    _context.JobPostings.Remove(jobPosting);
                    _context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception e)
            {
                // Log the exception
                throw new Exception(e.Message);
            }
            return result;
        }
    }
}
