using AdvisorHub.Models;
using Microsoft.EntityFrameworkCore;
namespace AdvisorHub.DAL
{
    public class AdvisorRepository
    {
        private readonly AdvisorDbContext _context;

        public AdvisorRepository(AdvisorDbContext advisorDbcontext)
        {
            _context = advisorDbcontext;
        }

        public List<Advisor> GetAllAdvisors()
        {
            return _context.Advisors.ToList();
        }

        public Advisor GetAdvisorById(int id)
        {
            return _context.Advisors.FirstOrDefault(a => a.Id == id); 
        }
        
        public Advisor AddAdvisor(AdvisorCreationDto advisorCreationDto)
        {
            var advisor = new Advisor
            {
                FirstName = advisorCreationDto.FirstName,
                LastName = advisorCreationDto.LastName,
                Address = advisorCreationDto.Address,
                Phone = advisorCreationDto.Phone,
                Licenses = advisorCreationDto.Licenses,
                Crd = advisorCreationDto.Crd,
                RepId = advisorCreationDto.RepId,
                Osj = advisorCreationDto.Osj,
                NonOsj = advisorCreationDto.NonOsj,
                EmailAddress = advisorCreationDto.EmailAddress,
                IsHybrid = advisorCreationDto.IsHybrid,
                Last4Ssn = advisorCreationDto.Last4Ssn,
                AdditionalRepIds = advisorCreationDto.AdditionalRepIds,
                StateRegistrations = advisorCreationDto.StateRegistrations,
                RiaId = advisorCreationDto.RiaId,
                RiaName = advisorCreationDto.RiaName,
            };

            _context.Advisors.Add(advisor);
            _context.SaveChanges();

            return advisor;
        }

        public void UpdateAdvisor(Advisor advisor)
        {
            _context.Advisors.Update(advisor);
            _context.SaveChanges();
        }

        public void DeleteAdvisorById(int id)
        {
           var advisor = GetAdvisorById(id);
            if (advisor != null)
            {
                _context.Advisors.Remove(advisor);
                _context.SaveChanges();
            }
        }
    }
}
