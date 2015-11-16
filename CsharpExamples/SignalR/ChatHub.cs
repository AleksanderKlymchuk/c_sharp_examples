using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace SignalR
{
    public class ChatHub : Hub
    {
        static string d="";
        public void Send(string name,string message)
        {
            var n = Context.User.Identity.Name;
            Clients.All.broadCastMessage(name,message);
        }
        public override Task  OnDisconnected(bool stopCalled)
        {
            string connectionId = Context.ConnectionId;
          return  base.OnDisconnected(stopCalled);
        }
        public override  Task OnConnected()
        {
            string connectionId = Context.ConnectionId;
            d=Context.QueryString["info"];
            return base.OnConnected();
        }
        public override Task OnReconnected()
        {
            string connectionId = Context.ConnectionId;
            return base.OnReconnected();
        }

    }
}