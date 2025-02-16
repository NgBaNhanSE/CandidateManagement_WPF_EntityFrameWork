﻿using Candidate_BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidate_Repository
{
    public interface ICandidateProfileRepo
    {
        public CandidateProfile GetCandidateProfileByID(string id)     ;
        public List<CandidateProfile> GetCandidateProfiles()  ;
        public bool AddCandidateProfile(CandidateProfile candidateProfile);
        public bool DeleteCandidateProfile(string profileID) ;
        public bool UpdateCandidateProfile(CandidateProfile profileID);
        List<CandidateProfile> GetCandidateProfileByNameJob(string? Name, string? jobposting);
    }
}
