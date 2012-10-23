using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;


namespace Insheeption
{
    public class AlarmModule
    {
        private List<Alarm> alarms;

        public AlarmModule()
        {
            alarms = new List<Alarm>();
        }

        public void CallAlarms(int sheepID, DatabaseModule sender)
        {
            foreach (Alarm i in alarms)
                i.callAlarm(sheepID, sender);
        }

        public void AddAlarm(Alarm alarm)
        {
            this.alarms.Add(alarm);
        }
    }

    public interface Alarm
    {
        void callAlarm(int sheepID, DatabaseModule sender);
    }

    public class EmailAlarm : Alarm
    {
        private MailAddress mailAccount;
        private string password, host;
        private int port;

        public EmailAlarm(string mailAccount, string displayName, string password)
        {
            this.mailAccount = new MailAddress(mailAccount, displayName);
            this.password = password;
        }

        public EmailAlarm()
        {
            //Empty Constructor
        }
        public void callAlarm(int sheepID, DatabaseModule sender)
        {
            //Sjekk dis out
        }

        public Boolean sendMail()
        {
            // Opprinnelige parametere til metoden: string to, string toName, string message 

            MailMessage email = new MailMessage();
            email.From = new MailAddress("varsel.insheeption@gmail.com");
            email.Subject = "[]Sheep Alert!";
            email.Body = "<p>Noen har drept sauen din! Logg inn for å se hvem hva og hvor</p><br><i>Vennligst ikke svar på denne eposten</i>s";
            email.IsBodyHtml = true;
            email.To.Add(new MailAddress("rikardeide@gmail.com")); // Mildertidig er det kun én epost her. Men add legger til en hel collection
            SmtpClient smtp = new SmtpClient();
            try
            {
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "varsel.insheeption@gmail.com";
                NetworkCred.Password = "Sau12345";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;//Specify your port No;
                smtp.Send(email);
                return true;

            }
            catch
            {
                email.Dispose();
                smtp = null;
                return false;
            }
        }


    }
}