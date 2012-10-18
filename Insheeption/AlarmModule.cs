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

        public EmailAlarm(string mailAccount, string displayName, string password, string host, int port)
        {
            this.mailAccount = new MailAddress(mailAccount, displayName);
            this.password = password;
            this.host = host;
            this.port = port;
        }

        public void callAlarm(int sheepID, DatabaseModule sender)
        {
            
        }

        public void sendMail(string to, string toName, string subject, string message)
        {
            MailAddress toAddress = new MailAddress(to);
            SmtpClient client = new SmtpClient
                                {
                                    Host = host,
                                    Port = port,
                                    EnableSsl = true,
                                    DeliveryMethod = SmtpDeliveryMethod.Network,
                                    UseDefaultCredentials = false,
                                    Credentials = new NetworkCredential(mailAccount.Address, password)
                                };

            using (var message1 = new MailMessage(mailAccount, toAddress)
                    {
                        Subject = subject,
                        Body = message
                    })
            {
                client.Send(message1);
            }
        }

    }
}