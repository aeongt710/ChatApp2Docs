﻿using ChatApp2Docs.Chat;
using ChatApp2Docs.Data;
using ChatApp2Docs.Models;
using ChatApp2Docs.Models.APIResponseModels;
using ChatApp2Docs.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatApp2Docs.Controllers.Api
{
    [ApiController]
    [Route("api/hubcontext")]
    public class HubAPI:Controller
    {
        private readonly IChattingService _chattingService;
        private readonly ApplicationDbContext _db;
        public HubAPI(IChattingService chattingService, ApplicationDbContext db)
        {
            _db = db;
            _chattingService = chattingService;
        }


        [HttpPost]
        [Route("sendGlobalMessage")]
        public async Task<ActionResult> SendGlobalMessageAsync(apiPOST message)
        {
            CommonResponse<int> commonResponse = new CommonResponse<int>();
            try
            {
                commonResponse.status= _chattingService.sendPublicMessage(message.Text, HttpContext.User.Identity.Name).Result;
            }
            catch(Exception e)
            {
                commonResponse.status = 1;
                commonResponse.message=e.Message;
            }
            return Ok(commonResponse);
        }
        [HttpPost]
        [Route("sendPrivateMessage")]
        public async Task<ActionResult> sendPrivateMessage(apiPOST message)
        {
            CommonResponse<int> commonResponse = new CommonResponse<int>();
            try
            {
                message.SenderName = HttpContext.User.Identity.Name;
                await _chattingService.sendPrivateMessage(message);
            }
            catch (Exception e)
            {
                commonResponse.status = 5;
                commonResponse.message = e.Message;
            }
            return Ok(commonResponse);
        }
        [HttpGet]
        [Route("getGlobalMessages")]
        public  IActionResult getGlobalMessages()
        {
            CommonResponse<List<GlobalChatMessage>> commonResponse = new CommonResponse<List<GlobalChatMessage>>();
            try
            {
                string sender = HttpContext.User.Identity.Name;
                commonResponse.dataenum = _chattingService.GetGlobalMessages(sender).Result;
            }
            catch (Exception e)
            {
                commonResponse.status = 5;
                commonResponse.message = e.Message;
            }
            return Ok(commonResponse);
        }
    }
}
