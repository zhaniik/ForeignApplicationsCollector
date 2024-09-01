using ForeignApplicationsCollector.Models;
using ForeignApplicationsCollector.Data;

namespace ForeignApplicationsCollector.Services
{
    public class ApplicationsService
    {
        private readonly ApplicationDbContext _context;

        public ApplicationsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddApplication(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public List<User> GetApplications()
        {
            return _context.Users.ToList();
        }

        public bool UpdateApplication(int id, UpdatingUser updatedUser)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.Name = updatedUser.Name;
                user.Email = updatedUser.Email;
                user.PhoneNumber = updatedUser.PhoneNumber;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
