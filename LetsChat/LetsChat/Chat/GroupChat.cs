using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using RestSharp;
using LetsChat.Settings;

namespace LetsChat.Chat
{
    public class GroupChat : Hub
    {
        public void SendMessage(Int64 userId, string name, string message)
        {
            Clients.All.GetMessage(name, message);

            AddMessage(userId, message);
        }

        private static void AddMessage(Int64 userId, string message)
        {
            var client = new RestClient(SystemSettings.ApiPath);
            string url = "api/Message";
            var request = new RestRequest(url, Method.POST);
            request.AddParameter("userId", userId);
            request.AddParameter("message", message);
            var response = client.Execute(request);
        }

        public void Login(string name)
        {
            Clients.All.UserAdded(name);
        }

        public void LogOut(string name, Int64 userId)
        {
            Clients.All.UserLeft(name);
            UpdateUser(userId);
        }

        private static void UpdateUser(Int64 userId)
        {
            var client = new RestClient(SystemSettings.ApiPath);
            string url = "api/User/" + userId;
            var request = new RestRequest(url, Method.PUT);
            var response = client.Execute(request);
        }
    }
}