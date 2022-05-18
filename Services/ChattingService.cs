using ChatApp2Docs.Data;
using ChatApp2Docs.Models.VMs;
using System.Collections.Generic;
using System.Linq;

namespace ChatApp2Docs.Services
{
    public class ChattingService : IChattingService
    {
        private readonly ApplicationDbContext _db;
        public ChattingService(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<UserVM> getUsersList()
        {
            return (from user in _db.Users
                    select new UserVM
                    {
                        Id = user.Id,
                        Name = user.Email
                    }).ToList();
        }
    }
}
