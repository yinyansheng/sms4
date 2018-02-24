using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace chatServer
{
    class CerClient:RegClient
    {
        private string clientKe;

        public string ClientKe
        {
            get { return clientKe; }
            set { clientKe = value; }
        }

        private string clientTimeTick;

        public string ClientTimeTick
        {
          get { return clientTimeTick; }
          set { clientTimeTick = value; }
        }

    
        public CerClient(){
        
        }

        public CerClient(string username,string clientKe,string clientTimeTick):base(username)
        {
            
            this.clientKe = clientKe;
            this.clientTimeTick = clientTimeTick;
        }

        public override string ToString()
        {
            return username;
        }
    }
}
