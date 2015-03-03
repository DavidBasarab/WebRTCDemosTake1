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
        //static List<string> peers = new List<string>();

        public override Task OnConnected()
        {
            var task = base.OnConnected();

            //peers.Add(this.Context.ConnectionId);

            //A new Callee has connected.  Tel all potential Callers
            //Clients.Caller.onPeers(peers);
            Clients.Others.onPeerConnected(this.Context.ConnectionId);

            return task;
        }

        //public override Task OnDisconnected(bool stopCalled)
        //{
        //    var task = base.OnDisconnected(stopCalled);
        //    Clients.Others.onPeerDisconnected(this.Context.ConnectionId);
        //    return task;
        //}

        //Relay Offers from the Caller back to the Callee
        public void MakeOffer(string calleeServerConnectionId, string offer)
        {
            Clients.Client(calleeServerConnectionId).onOffer(this.Context.ConnectionId, offer);
        }

        //Relay ICE Candidates from Caller to Callee
        public void CandidateFound(string serverConnectionId, string candidate)
        {
            Clients.Client(serverConnectionId).onCandidateFound(this.Context.ConnectionId, candidate);
        }

        //Relay ICE Candidates from Callee to Caller
        //public void CalleeCandidateFound(string callerServerConnectionId, string candidate)
        //{
        //    Clients.Client(callerServerConnectionId).onCandidateFound(this.Context.ConnectionId, candidate);
        //}

        //Relay Answers to connected clients
        public void SendAnswer(string callerServerConnectionId, string answer)
        {
            Clients.Client(callerServerConnectionId).onAnswer(this.Context.ConnectionId, answer);
        }


    }
}
