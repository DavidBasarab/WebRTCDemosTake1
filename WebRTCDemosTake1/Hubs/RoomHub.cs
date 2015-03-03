using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebRTCDemosTake1.Hubs
{
    public class RoomHub : Hub
    {
        public override Task OnConnected()
        {
            var task = base.OnConnected();

            Clients.Others.onPeerConnected(this.Context.ConnectionId);

            return task;
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            var task = base.OnDisconnected(stopCalled);
            Clients.Others.onPeerDisconnected(this.Context.ConnectionId);
            return task;
        }

        public void MakeOffer(string calleeServerConnectionId, string offer)
        {
            Clients.Client(calleeServerConnectionId).onOffer(this.Context.ConnectionId, offer);
        }

        public void CandidateFound(string serverConnectionId, string candidate)
        {
            Clients.Client(serverConnectionId).onCandidateFound(this.Context.ConnectionId, candidate);
        }

        public void SendAnswer(string callerServerConnectionId, string answer)
        {
            Clients.Client(callerServerConnectionId).onAnswer(this.Context.ConnectionId, answer);
        }
    }
}
