using Candidate_BusinessObjects;
using Candidate_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repository
{
    public class CandidateProfileRepo : ICandidateProfileRepo
    {
        public bool AddCandidateProfile(CandidateProfile candidateProfile)=>CandidateProfileDAO.Instance.AddCandidateProfile(candidateProfile);

        public bool DeleteCandidateProfile(string profileID)=>CandidateProfileDAO.Instance.DeleteCandidateProfile(profileID);

        public CandidateProfile GetCandidateProfileByID(string id)=>CandidateProfileDAO.Instance.GetCandidateProfileByID(id);
        public List<CandidateProfile> GetCandidateProfiles()=>CandidateProfileDAO.Instance.GetCandidateProfiles();

        public List<CandidateProfile> GetCandidateProfileByNameJob(string? Name, string? jobposting)=>CandidateProfileDAO.Instance.GetCandidateProfileByNameJob(Name,jobposting);
        public bool UpdateCandidateProfile(CandidateProfile profileID)=>CandidateProfileDAO.Instance.UpdateCandidateProfile(profileID);
    }
}
