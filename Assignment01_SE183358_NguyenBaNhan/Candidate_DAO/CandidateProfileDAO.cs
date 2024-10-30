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
    public class CandidateProfileDAO
    {
        private CandidateManagementContext dbContext;
        private static CandidateProfileDAO instance;
        public CandidateProfileDAO()
        {
            dbContext = new CandidateManagementContext();
        }
        public static CandidateProfileDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CandidateProfileDAO();
                }
                return instance;
            }
        }
        public CandidateProfile GetCandidateProfileByID(string id)
        {
            return dbContext.CandidateProfiles.FirstOrDefault(m => m.CandidateId.Equals(id));
        }
        public List<CandidateProfile> GetCandidateProfileByNameJob(string? Name, string? jobposting)
        {
            return dbContext.CandidateProfiles
                .Where(x =>
                    (string.IsNullOrEmpty(Name) || x.Fullname.Contains(Name)) &&
                    (string.IsNullOrEmpty(jobposting) || x.PostingId.Contains(jobposting)))
                .ToList();
        }
        public List<CandidateProfile> GetCandidateProfiles()
        {
            return dbContext.CandidateProfiles.Include("Posting").ToList();
        }
        public bool AddCandidateProfile(CandidateProfile candidateProfile)
        {
            bool result = false;
            CandidateProfile candidate = this.GetCandidateProfileByID(candidateProfile.CandidateId);

            try
            {
                if (candidate == null)
                {
                    dbContext.CandidateProfiles.Add(candidateProfile);
                    dbContext.SaveChanges();
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
        public bool DeleteCandidateProfile(string profileID)
        {
            bool result = false;
            CandidateProfile candidateProfile = this.GetCandidateProfileByID(profileID);
            try
            {
                if (candidateProfile != null)
                {
                    dbContext.CandidateProfiles.Remove(candidateProfile);
                    dbContext.SaveChanges();
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

        public bool UpdateCandidateProfile(CandidateProfile profileID)
        {
            bool result = false;
            CandidateProfile candidateProfile = this.GetCandidateProfileByID(profileID.CandidateId);
            try
            {
                if (candidateProfile != null)
                {

                    dbContext.Entry(candidateProfile).State = EntityState.Detached;
                    dbContext.Entry<CandidateProfile>(profileID).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                    dbContext.SaveChanges();
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

