using EASendMail; //add EASendMail namespace
using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Net.Security;


class Program
{
    static void Main(string[] args)
    {
      //System.Console.WriteLine(new System.Net.WebClient().DownloadString("http://156.69.0.177:8000/rps/"));
      

        var a = "a"; //printer administracija (178)
        var Printer2 = "a"; //Hodnik skali 174
        var Printer3 = "a"; //smetkovotstvo (182)
        var Printer4 = "a"; //IARC kanc (171)
        var Printer5 = "a"; //HP LaserJet MFP M130fw - fani kanc (172)
        var Printer6 = "a"; //HP LaserJet 1320 - hala2 elektricari (176)
        var Printer7 = "a"; //IARC kanc (179)




        //printer 1 administracija
        try
        {
            a = new System.Net.WebClient().DownloadString("http://156.69.0.178/info_deviceStatus.html?tab=Status&menu=DevStatus");
        }
        catch
        {
            a = "WIDTH:404% \n MARGIN BACKGROUND COLOR #000000" +
                "WIDTH:404% \n MARGIN BACKGROUND COLOR #00FFFF" +
                "WIDTH:404% \n MARGIN BACKGROUND COLOR #FF00FF" +
                "WIDTH:404% \n MARGIN BACKGROUND COLOR #FFFF00";
        }

        //printer 2 Hodnik skali
        try
        {
            Printer2 = new System.Net.WebClient().DownloadString("http://156.69.0.174/startwlm/Hme_Toner.htm");
            //   System.Console.WriteLine(new System.Net.WebClient().DownloadString("http://156.69.0.174/startwlm/Hme_Toner.htm"));

        }
        catch (Exception)
        {
            Printer2 = "Renaming[0] = 404%";
        }

        //printer 3 Smetkovotstvo
        try
        {
             Printer3 = new System.Net.WebClient().DownloadString("http://156.69.0.182/js/jssrc/model/startwlm/Hme_Toner.model.htm");

            //System.Console.WriteLine(new System.Net.WebClient().DownloadString("http://156.69.0.182/js/jssrc/model/startwlm/Hme_Toner.model.htm"));
        }
        catch (Exception)
        {

            Printer3= "_pp.Renaming.push(parseInt('404";
        }

       //printer 4 IACR kanc
        try
        {
            Printer4 = new System.Net.WebClient().DownloadString("http://156.69.0.171/Information/supplies_status.htm");
        }
        catch
        {
            Printer4 = "var BlackTonerPer = 404";
        }
        //printer 5 fani kanc
        try
        {
            Printer5 = new System.Net.WebClient().DownloadString("http://156.69.0.172/hp/device/info_suppliesStatus.html?tab=Home&amp;menu=SupplyStatus");
        }
        catch
        {
            Printer5 = "<tr>\n <td style= WIDTH:404% \n BACKGROUND-COLOR: #000000;";
        }

        //printer 6 - hala2 elektricari
        try
        {
            Printer6=new System.Net.WebClient().DownloadString("http://156.69.0.176/hp/device/info_deviceStatus.html");
        }
        catch
        {
            Printer6 = "<table border width=404% bgcolor= #000000";
         }

        //printer 7 -IACR kanc
        try
        {
            Printer7 = new System.Net.WebClient().DownloadString("http://156.69.0.179/hp/device/info_suppliesStatus.html?tab=Status&amp;menu=SupplyStatus");
        }
        catch
        {
            Printer7 = "<td style= WIDTH:404% BACKGROUND-COLOR:  #000000" +
               "<td style= WIDTH:404% BACKGROUND-COLOR:  #00FFFF" +
               "<td style= WIDTH:404% BACKGROUND-COLOR:  #FF00FF" +
               "<td style= WIDTH:404% BACKGROUND-COLOR:  #FFFF00";
        }

       // Step 1: create new Regex.

        //printer 1
        Regex regex = new Regex(@"WIDTH:(\d+)%.+(\n|\r|\r\n).+MARGIN.+BACKGROUND.+COLOR.+#000000");
        Regex regex2 = new Regex(@"WIDTH:(\d+)%.+(\n|\r|\r\n).+MARGIN.+BACKGROUND.+COLOR.+#00FFFF");
        Regex regex3 = new Regex(@"WIDTH:(\d+)%.+(\n|\r|\r\n).+MARGIN.+BACKGROUND.+COLOR.+#FF00FF");
        Regex regex4 = new Regex(@"WIDTH:(\d+)%.+(\n|\r|\r\n).+MARGIN.+BACKGROUND.+COLOR.+#FFFF00");
       
        //printer 2 {
        Regex PrinterB1 = new Regex(@"Renaming\[0\]\s+=\s+(\d{1,3})");
        
        //printer 3{
        Regex PrinterC = new Regex(@"_pp.Renaming.push.+parseInt.+'(\d+)");
        
        //printer4{
        Regex PrinterD = new Regex(@"var.+BlackTonerPer.+= (\d\d+)");

        //priter 5
        Regex PrinterE = new Regex(@"<tr>\n.+<td style=.WIDTH:(\d+)%.+\n.+BACKGROUND-COLOR:.+#000000;");
        //
        //printer 6
        Regex PrinterF = new Regex(@"<table.+border.+width=(\d+)%.+bgcolor=.#000000");
        //printer7

        Regex PrinterG1 = new Regex(@"<td style=.WIDTH:(\d+)%.+BACKGROUND-COLOR:.+#000000");
        Regex PrinterG2 = new Regex(@"<td style=.WIDTH:(\d+)%.+BACKGROUND-COLOR:.+#00FFFF");
        Regex PrinterG3 = new Regex(@"<td style=.WIDTH:(\d+)%.+BACKGROUND-COLOR:.+#FF00FF");
        Regex PrinterG4 = new Regex(@"<td style=.WIDTH:(\d+)%.+BACKGROUND-COLOR:.+#FFFF00");

        
        // Step 2: call Match on Regex instance.
        Match match = regex.Match(a);
        Match match2 = regex2.Match(a);
        Match match3 = regex3.Match(a);
        Match match4 = regex4.Match(a);

        //printer2
        Match zavtorprinter = PrinterB1.Match(Printer2);

        //Printer3
        Match print3 = PrinterC.Match(Printer3);
        //Printer4
        Match print4 = PrinterD.Match(Printer4);
        //printer 5
        Match print5 = PrinterE.Match(Printer5);
        //Printer 6
        Match print6 = PrinterF.Match(Printer6);
        //Printer7
        Match print71 = PrinterG1.Match(Printer7);
        Match print72 = PrinterG2.Match(Printer7);
        Match print73 = PrinterG3.Match(Printer7);
        Match print74 = PrinterG4.Match(Printer7);
        //

        

        // Step 3: test for Success.
        if (match.Success)
        {
            //grupi za printerite
            Group Boja1 = match.Groups[1];
            Group Boja2 = match2.Groups[1];
            Group Boja3 = match3.Groups[1];
            Group Boja4 = match4.Groups[1];
            //
            Group printer2 = zavtorprinter.Groups[1];
            //
            Group printer3 = print3.Groups[1];
            //
            Group printer4 = print4.Groups[1];
            //
            Group printer5 = print5.Groups[1];
            //
            Group printer6 = print6.Groups[1];
            //
            Group printer71 = print71.Groups[1];
            Group printer72 = print72.Groups[1];
            Group printer73 = print73.Groups[1];
            Group printer74 = print74.Groups[1];
            
            //pretvorajne
        
                int x1 = Int32.Parse(Boja1.Value);
                int x2 = Int32.Parse(Boja2.Value);
                int x3 = Int32.Parse(Boja3.Value);
                int x4 = Int32.Parse(Boja4.Value);
                int x5 = Int32.Parse(printer2.Value);
                int x6 = Int32.Parse(printer3.Value);
                int x7 = Int32.Parse(printer4.Value);
                int x8 = Int32.Parse(printer5.Value);
                int x9 = Int32.Parse(printer6.Value);
                int x10 = Int32.Parse(printer71.Value);
                int x11 = Int32.Parse(printer72.Value);
                int x12 = Int32.Parse(printer73.Value);
                int x13 = Int32.Parse(printer74.Value);
            
             
            DateTime dateTime = DateTime.Now;
            //
            Console.WriteLine("Black: " + Boja1 + "% ");
            Console.WriteLine("Cyan: " + Boja2 + "%");
            Console.WriteLine("Magenta: " + Boja3 + "%");
            Console.WriteLine("Yellow: " + Boja4 + "%");
                        
            //
            Console.WriteLine("vtor printer\nKyocera FS-6525MFP - Hodnik Skali: " + printer2.Value + "%");
            
            //
            Console.WriteLine("tret printer\nKyocera M2040dn - Smetkovotstvo: " + printer3.Value + "%");
            //
            Console.WriteLine("Cetvrt printer\n SCX-4x25 Series  - iacr kanc: " + x7 + "%");
            //
            Console.WriteLine("Peti printer\n  " + x8 + "%");
            //
            Console.WriteLine("Sesti " + x9 + "%");
            ///

            Console.WriteLine("sedmiB " + x10 + "%");
            Console.WriteLine("sedmiC " + x11 + "%");
            Console.WriteLine("sedmiM " + x12 + "%");
            Console.WriteLine("sedmiY " + x13 + "%");

            int lowcolor = 4;
            int redalert = 0;

            Console.WriteLine("Low color show here->");


            if (x1 <= lowcolor)
            {
                Console.WriteLine("Black " + x1);
                redalert = redalert + 1;
            }

            if (x2 <= lowcolor)
            {
                Console.WriteLine("Cyan " + x2);
                redalert = 1;
            }

            if (x3 <= lowcolor)
            {
                Console.WriteLine("Magenta " + x3);
                redalert = 1;
            }

            if (x4 <= lowcolor)
            {
                Console.WriteLine("Yellow " + x4);
                redalert = 1;
            }
            if (x5 <= lowcolor)
            {
                Console.WriteLine("printer2 " + x5);
                redalert = 1;
            }
            if (x6 <= lowcolor)
            {
                Console.WriteLine("printer3 " + x6);
                redalert = 1;
            }

            if (x7 <= lowcolor)
            {
                Console.WriteLine("printer4 " + x7);
                redalert = 1;
            }
            if (x8<=lowcolor)
            {
                Console.WriteLine("printer5 " + x8);
                redalert = 1;
            }
            if(x9<=lowcolor)
            {
                Console.WriteLine("printer6" + x9);
                redalert = 1;

            }


            Console.WriteLine("END-Low color");



           
           if (redalert >=1 || x1==404 || x2 == 404 || x3 == 404 || x4 == 404 || x5==404 || x6==404 || x7 == 404 ||x8==404 ||x9==404)
            {

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

                    oMail.TextBody = ("Printer's Status Alert!!!" + dateTime +
                        "\n-1.  HP Color LaserJet CP1515n \nAdministracija:\n" +
                        "-Black:" + Boja1 +
                        "%\n-Cyan:" + Boja2 +
                        "%\n-Magenta:" + Boja3 +
                        "%\n-Yellow:" + Boja4 +
                        "%\n***\n-2.  Kyocera FS-6525MFP \nHodnik - skali:" + printer2 +
                        "%\n***\n-3.  Kyocera M2040dn \nSmetkovotstvo:" + printer3 +
                        "%\n***\n-4. Samsung SCX-4x25 Series\n IACR kanc: " + printer4 +
                        "%n***\n-5. HP LaserJet MFP M130fw - fani kanc" +
                        "\n BLACK" + printer5 + "%" +
                        "\n***\n-6. HP LaserJet 1320 - Elekrcari: " + printer6 + " % ");

                   
                    // Gmail SMTP server address
                    SmtpServer oServer = new SmtpServer("smtp.gmail.com");
                    // Gmail user authentication
                    // For example: your email is "gmailid@gmail.com", then the user should be the same

                    Console.WriteLine("email:");

                    oServer.User = "aleksandarp.work@gmail.com";
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

          Console.ReadLine();
        }
    }

   
}


