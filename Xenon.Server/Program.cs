using System.Net;
using System.Text;
using System.Net.Sockets;

namespace Xenon.Server
{
    internal class Program
    {
        static UdpClient Client = new(40800);
        static string data = "";
        static void Main(string[] args)
        {
            if (!File.Exists("RuntimeConfiguration.xsdc"))
            {
                File.WriteAllText("RuntimeConfiguration.xsdc", "dev");
            }
            string RuntimeConfiguration = File.ReadAllText("RuntimeConfiguration.xsdc");
            Console.WriteLine("[SERVER:UDP:INITALIZE:DATA]:\n{Author: 4drian.software}\n{Version: 0.1.0.0}\n{Runtime configuration: " + RuntimeConfiguration + "}\n{Started at: " + DateTime.Now + "}\n");
            Console.WriteLine("[SERVER:UDP:INITIALIZE]: Listening");
            try
            {
                Client.BeginReceive(new AsyncCallback(recv), null);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
        }

        static void recv(IAsyncResult res)
        {
            try
            {
                IPEndPoint? RemoteIP = new IPEndPoint(IPAddress.Any, 60240);
                byte[] received = Client.EndReceive(res, ref RemoteIP);
                data = Encoding.UTF8.GetString(received);
                Console.WriteLine("[CLIENT:IPENDPOINT:" + RemoteIP?.ToString() + ":RECEIVE]: " + data);
                byte[] response = Encoding.UTF8.GetBytes("null");
                switch (data.Split('>')[0])
                {
                    case "test":
                        Console.WriteLine("[SERVER:UDP:REQUEST]: Client requested udp debug test");
                        response = Encoding.UTF8.GetBytes("response");
                        break;
                    case "UserLogin":
                        Console.WriteLine("[SERVER:UDP:REQUEST]: Client requested user login");
                        response = Encoding.UTF8.GetBytes(Commands.Account.Login(Encoding.UTF8.GetString(Convert.FromBase64String(data.Split('>')[1])).Split(':')[0], Encoding.UTF8.GetString(Convert.FromBase64String(data.Split('>')[1])).Split(':')[1]).ToString());
                        break;
                    default:
                        Console.WriteLine("[SERVER:UDP:REQUEST]: Client sent unrecognized request");
                        response = Encoding.UTF8.GetBytes("FORBIDDEN");
                        break;
                }
                Client.Send(response, response.Length, RemoteIP);
                Console.WriteLine("[SERVER:UDP:CLIENT:SEND]: " + Encoding.UTF8.GetString(response));
                Client.BeginReceive(new AsyncCallback(recv), null);
            }
            catch (Exception e)
            {
                Console.WriteLine("[SERVERLOG]: Error encountered! \r\n\r\n" + e.ToString());
                Client.BeginReceive(new AsyncCallback(recv), null);
            }
        }
    }
}