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
    public class HRAccountRepo : IHRAccountRepo
    {
        public Hraccount GetHraccountByEmail(string email)=>HRAccountDAO.Instance.getHraccountByEmail(email);
        

        public List<Hraccount> GetHraccounts()=>HRAccountDAO.Instance.GetHraccounts();
        public bool AddHrAccount(Hraccount hraccount) => HRAccountDAO.Instance.AddHrAccount(hraccount);
        public bool UpdateHrAccount(Hraccount hraccount) => HRAccountDAO.Instance.UpdateHrAccount(hraccount);
        public bool DeleteHrAccount(string email) =>HRAccountDAO.Instance.DeleteHrAccount(email);
        public List<Hraccount> GetHraccountByNameOrRole(string? Name, string? role) => HRAccountDAO.Instance.GetHraccountByNameOrRole(Name,role);
    }
}
