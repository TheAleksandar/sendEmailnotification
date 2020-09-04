using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EASendMail; //add EASendMail namespace


class Program
{
    static void Main(string[] args)
    {
        //System.Console.WriteLine(new System.Net.WebClient().DownloadString("http://A.156.69.0.178/info_deviceStatus.html?tab=Status&menu=DevStatus"));
        var a = "a";

        try
        {
            a = new System.Net.WebClient().DownloadString("http://156.69.0.178/info_deviceStatus.html?tab=Status&menu=DevStatus");
        }
        catch
        {
            a = "WIDTH:13% \n MARGIN BACKGROUND COLOR #000000" +
                "WIDTH:13% \n MARGIN BACKGROUND COLOR #00FFFF" +
                "WIDTH:13% \n MARGIN BACKGROUND COLOR #FF00FF" +
                "WIDTH:13% \n MARGIN BACKGROUND COLOR #FFFF00";

        }

        // 
        //\\
        var Printer2 = new System.Net.WebClient().DownloadString("http://156.69.0.174/startwlm/Hme_Toner.htm");
        //   System.Console.WriteLine(new System.Net.WebClient().DownloadString("http://156.69.0.174/startwlm/Hme_Toner.htm"));

        var Printer3 = new System.Net.WebClient().DownloadString("http://156.69.0.182/js/jssrc/model/startwlm/Hme_Toner.model.htm");
        //System.Console.WriteLine(new System.Net.WebClient().DownloadString("http://156.69.0.182/js/jssrc/model/startwlm/Hme_Toner.model.htm"));

        // Step 1: create new Regex.

        //printer 1
        Regex regex = new Regex(@"WIDTH:(\d+)%.+(\n|\r|\r\n).+MARGIN.+BACKGROUND.+COLOR.+#000000");
        Regex regex2 = new Regex(@"WIDTH:(\d+)%.+(\n|\r|\r\n).+MARGIN.+BACKGROUND.+COLOR.+#00FFFF");
        Regex regex3 = new Regex(@"WIDTH:(\d+)%.+(\n|\r|\r\n).+MARGIN.+BACKGROUND.+COLOR.+#FF00FF");
        Regex regex4 = new Regex(@"WIDTH:(\d+)%.+(\n|\r|\r\n).+MARGIN.+BACKGROUND.+COLOR.+#FFFF00");
        //      \\printer1
       

        //printer 2 {
        Regex PrinterB1 = new Regex(@"Renaming\[0\]\s+=\s+(\d{1,3})");
        // \\printer2

        //printer 3{
        Regex PrinterC = new Regex(@"_pp.Renaming.push.+parseInt.+'(\d+)");



        // Step 2: call Match on Regex instance.
        Match match = regex.Match(a);
        Match match2 = regex2.Match(a);
        Match match3 = regex3.Match(a);
        Match match4 = regex4.Match(a);

        //za vtor printer
        Match zavtorprinter = PrinterB1.Match(Printer2);

        //Printer3
        Match print3 = PrinterC.Match(Printer3);


        // Step 3: test for Success.
        if (match.Success)
        {
            Group Boja1 = match.Groups[1];
            Group Boja2 = match2.Groups[1];
            Group Boja3 = match3.Groups[1];
            Group Boja4 = match4.Groups[1];
            //
            Group printer2 = zavtorprinter.Groups[1];
            //
            Group printer3 = print3.Groups[1];



            //pretvorajne

            int x1 = Int32.Parse(Boja1.Value);
            int x2 = Int32.Parse(Boja2.Value);
            int x3 = Int32.Parse(Boja3.Value);
            int x4 = Int32.Parse(Boja4.Value);

            DateTime dateTime = DateTime.Now;
           
            Console.WriteLine("Black: " + Boja1 + "% ");
            Console.WriteLine("Cyan: " + Boja2 + "%");
            Console.WriteLine("Magenta: " + Boja3 + "%");
            Console.WriteLine("Yellow: " + Boja4 + "%");

            Console.WriteLine("end");

            Console.WriteLine("vtor printer\nKyocera FS-6525MFP - Hodnik Skali: " + printer2.Value);

            Console.WriteLine("tret printer\nKyocera M2040dn - Smetkovotstvo: " + printer3.Value);


            int lowcolor = 20;


            Console.WriteLine("Low color show here");


            if (x1 <= lowcolor)
            {
                Console.WriteLine("Black " + x1);
            }

            if (x2 <= lowcolor)
            {

                Console.WriteLine("Cyan " + x2);
            }

            if (x3 <= lowcolor)
            {
                Console.WriteLine("Magenta " + x3);
            }

            if (x4 <= lowcolor)
            {
                Console.WriteLine("Yellow " + x4);
            }

            try
            {
                SmtpMail oMail = new SmtpMail("TryIt");

                // Your gmail email address
                oMail.From = "aleksandarp.work@gmail.com";
                // Set recipient email address
                oMail.To = "aleksandarp@mail.mikrosam.com";

                // Set email subject
                oMail.Subject = "Printer Status";
                // Set email body

                oMail.TextBody = ("Printer's Status"+ dateTime + "\n-1.  HP Color LaserJet CP1515n \nAdministracija:\n" + "-Black:" + Boja1 + "%\n-Cyan:" + Boja2 + "%\n-Magenta:" + Boja3 + "%\n-Yellow:" + Boja4 + "%\n***\n-2.  Kyocera FS-6525MFP \nHodnik - skali:" + printer2 + "%\n***\n-3.  Kyocera M2040dn \nSmetkovotstvo:" + printer3+"%");

                // Gmail SMTP server address
                SmtpServer oServer = new SmtpServer("smtp.gmail.com");
                // Gmail user authentication
                // For example: your email is "gmailid@gmail.com", then the user should be the same

                Console.WriteLine("email:");
                //string email = Console.ReadLine();
               // oServer.User = email;
                oServer.User = "aleksandarp.work@gmail.com";

                Console.WriteLine("password:");

               // string password = Console.ReadLine();
                //oServer.Password = password;
                oServer.Password = "Prilep123";

                // Set 587 port, if you want to use 25 port, please change 587 5o 25
                oServer.Port = 587;
                //587

                // detect SSL/TLS automatically
                oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                Console.WriteLine("start to send email over SSL ...");

                SmtpClient oSmtp = new SmtpClient();
                oSmtp.SendMail(oServer, oMail);

                Console.WriteLine("email was sent successfully!");
            }
            catch (Exception ep)
            {
                Console.WriteLine("failed to send email with the following error:");
                Console.WriteLine(ep.Message);
            }
        }





    }

}


