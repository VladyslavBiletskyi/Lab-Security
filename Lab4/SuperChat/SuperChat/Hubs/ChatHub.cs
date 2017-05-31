using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using SuperChat.Models;

namespace SuperChat.Hubs
{
    public class ChatHub : Hub
    {
        static List<User> Users = new List<User>();
        int g = 13;
        public void Send(string name, string message)
        {
            Clients.All.addMessage(name, message);
        }
       
        public void Connect(string userName)
        {
            var id = Context.ConnectionId;
            if (!Users.Any(x => x.ConnectionId == id))
            {
                User previous = null ;
                if (Users.Count > 0)
                {
                    previous = Users.Last();
                }
                Users.Add(new User { ConnectionId = id, Name = userName, Key = g });
                Clients.Client(id).setKey(g);
                if (previous != null)
                {
                    Clients.Client(previous.ConnectionId).SignNewKey(id);
                }
                // Посылаем сообщение текущему пользователю
                Clients.Caller.onConnected(id, userName, Users);
                
                // Посылаем сообщение всем пользователям, кроме текущего
                Clients.AllExcept(id).onNewUserConnected(id, userName);
                Clients.Caller.SignAllKeys(Users.Where(x => x.ConnectionId != id));
            }
        }

        public void ApplyNewKeys(List<User> users)
        {
            foreach (var user in users)
            {
                var old= Users.FirstOrDefault(x => x.ConnectionId == user.ConnectionId);
                if (old != null)
                {
                    old.Key = user.Key;
                    Clients.Client(old.ConnectionId).SetKey(user.Key);
                }
            }
        }

        public void ApplyKey(int key, string id)
        {
            var user = Users.FirstOrDefault(x => x.ConnectionId == id);
            if (user != null)
            {
                user.Key = key;
                Clients.Client(id).setKey(key);
            }
        }
    }
}