using ChatApp2Docs.Models.VMs;
using System.Collections.Generic;

namespace ChatApp2Docs.Services
{
    public interface IChattingService
    {
        public List<UserVM> getUsersList();
    }
}
