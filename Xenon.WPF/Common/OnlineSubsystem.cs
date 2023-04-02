using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Xenon.WPF.Common
{
    internal class OnlineSubsystem
    {
        public static UdpClient? Client;
        public static async Task<string> SendUDP(string data)
        {
            try
            {
                IPEndPoint serverAddr = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 40800);
                Client = new UdpClient();
                byte[] test = Encoding.UTF8.GetBytes(data);
                await Client.SendAsync(test, test.Length, serverAddr);
                byte[] ReceivedByteArrFromServer = Client.Receive(ref serverAddr);
                Client.Dispose();
                return Encoding.UTF8.GetString(ReceivedByteArrFromServer);
            }
            catch (Exception ex)
            {
                return (ex.ToString());
            }
        }
        
        public static async Task<bool> Login(string username, string password)
        {
            string response = await SendUDP("UserLogin>" + Convert.ToBase64String(Encoding.UTF8.GetBytes(username + ":" + password)));
            if (response.ToLower() == "true")
            {
                return true;
            }
            return false;
        }
    }
}
