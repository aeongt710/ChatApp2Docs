﻿using ChatApp2Docs.Chat;
using ChatApp2Docs.Data;
using ChatApp2Docs.Models;
using ChatApp2Docs.Models.APIResponseModels;
using ChatApp2Docs.Models.VMs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp2Docs.Services
{
    public class ChattingService : IChattingService
    {
        private ApplicationDbContext _db;
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ChattingService(ApplicationDbContext db, IHubContext<ChatHub> hubContext, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _hubContext = hubContext;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
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
        public async Task<int> sendPublicMessage(string message, string name)
        {
            
            IdentityUser user = await _userManager.FindByNameAsync(name);
            _db.Add(new GlobalMessage
            {
                SenderId = user.Id,
                Text = message,
                Time = DateTime.Now
            });
            await _db.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("ReceivePublicMessage", name, message);
            return 0;
        }
        public async Task<int> sendPrivateMessage(apiPOST message)
        {

            IdentityUser receiver = await _userManager.FindByNameAsync(message.ReceiverName);
            IdentityUser sender = await _userManager.FindByNameAsync(message.SenderName);
            _db.Add(new Message
            {
                SenderId = sender.Id,
                ReceiverId = receiver.Id,
                Text = message.Text,
                Time = DateTime.Now
            });
            await _db.SaveChangesAsync();
            await _hubContext.Clients.Group(message.ReceiverName).SendAsync("ReceivePrivateMessage", message.SenderName, message.Text);
            await _hubContext.Clients.Group(message.SenderName).SendAsync("ReceivePrivateMessage", message.SenderName, message.Text);
            return 0;
        }
    }
}
