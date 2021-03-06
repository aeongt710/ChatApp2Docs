using ChatApp2Docs.Models.APIResponseModels;
using ChatApp2Docs.Models.VMs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatApp2Docs.Services
{
    public interface IChattingService
    {
        public List<UserVM> getUsersList(string userName);
        public Task<int> sendPublicMessage(string message, string name);
        public Task<int> sendPrivateMessage(apiPOST message);
        public Task<List<GlobalChatMessage>> GetGlobalMessages(string user);
        public bool UserExists(string name);
        public Task<List<PrivateChatMessage>> GetPrivateMessages(apiPOST users);
    }
}
