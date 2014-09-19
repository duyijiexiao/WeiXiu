using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.ServiceReference3;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            //Service1Client client = new Service1Client();

            Mess mess = new Mess();
            mess.Phone = "13718511828";
            mess.Message1 = "验证码是3233332";
            mess.SourceIP = "128.123.2.6";
            mess.Token = "asdf";
            //client.Send(mess);
            //client.Close();


       MessageServiceSoapClient c = new MessageServiceSoapClient();
       var asdf=     c.MessageAdd(mess);

        }
    }
}
