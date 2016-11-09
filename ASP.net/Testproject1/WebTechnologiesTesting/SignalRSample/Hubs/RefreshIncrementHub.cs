using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalRSample.Hubs {
    public class RefreshIncrementHub : Hub {

        private static int count = 0;
        public void IncrementCount() {
            count += 1;
            Clients.All.getCount(count);
        }


    }
}