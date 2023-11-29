using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;


namespace SmtpProg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SendMail();
            }
            catch {
                Console.WriteLine("$ Error?");
            }
        }

        public static void SendMail()
        {
            try
            {
                //EMAIL from
                var Mailfrom = new MailAddress("zdanila027@gmail.com", "ME");
                //EMAIL TO
                var Mailto = new MailAddress("kskfbdoc@gmail.com");
                //mail 
                var m = new MailMessage(Mailfrom, Mailto);
                //Header
                m.Subject = "TEST";
                // MailText
                m.Body = "HELLO WORLD";

                //медот для отправки файла 
                m.Attachments.Add(new Attachment("C:/Users/danil/OneDrive/Документы/ComputerScience/SmtpProg/TEST.txt"));

                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                // логин и пароль
                smtp.Credentials = new NetworkCredential("zdanila027@gmail.com", "nosrqyfdodtqyttc");
                smtp.EnableSsl = true;
                smtp.Send(m);
                Console.Write("Message Sending");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eror on Message Sending  {ex.Message}");
            }
        }
    }
}
