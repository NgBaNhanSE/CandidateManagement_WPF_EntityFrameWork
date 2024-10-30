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
    public class HRAccountDAO
    {
        private CandidateManagementContext dbContext;

        private static HRAccountDAO instance = null;

        public static HRAccountDAO Instance
        {
            get
            {
                //Singleton Design Pattern
                if (instance == null)
                {
                    instance = new HRAccountDAO();
                }
                return instance;
            }
        }
        public HRAccountDAO()
        {
            dbContext = new CandidateManagementContext();
        }
        public Hraccount getHraccountByEmail(string email)
        {
            return dbContext.Hraccounts.FirstOrDefault(m => m.Email.Equals(email));
        }
        public List<Hraccount> GetHraccounts()
        {
            return dbContext.Hraccounts.ToList();
        }
        public List<Hraccount> GetHraccountByNameOrRole(string? Name,string? role)
        {

            int? _role = string.IsNullOrEmpty(role) ? (int?)null : int.Parse(role);

            return dbContext.Hraccounts
                .Where(x =>
                    (string.IsNullOrEmpty(Name) || x.FullName.Contains(Name)) &&
                    (!_role.HasValue || x.MemberRole.Equals(_role.Value)))
                .ToList();
        }
        public bool AddHrAccount(Hraccount hraccount)
        {
            bool result = false;
            Hraccount _hraccount = this.getHraccountByEmail(hraccount.Email);

            try
            {
                if (_hraccount == null)
                {
                    dbContext.Hraccounts.Add(hraccount);
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
        public bool UpdateHrAccount(Hraccount hraccount)
        {
            bool result = false;
            Hraccount _hraccount = this.getHraccountByEmail(hraccount.Email);
            try
            {
                if (_hraccount != null)
                {

                    dbContext.Entry(_hraccount).State = EntityState.Detached;
                    dbContext.Entry<Hraccount>(hraccount).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

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
        public bool DeleteHrAccount(string email)
        {
            bool result = false;
            Hraccount hraccount = this.getHraccountByEmail(email);
            try
            {
                if (hraccount != null)
                {
                    dbContext.Hraccounts.Remove(hraccount);
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
