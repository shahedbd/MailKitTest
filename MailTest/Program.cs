using MailKit.Net.Smtp;
using MimeKit;

namespace MailTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SendEail();
            Console.WriteLine("Success!");
        }

        static void SendEail()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Dev mlbd", "devmlbd@gmail.com"));
            message.To.Add(new MailboxAddress("Shahed", "shahedbddev@gmail.com"));
            message.Subject = "How you doin'?";

            message.Body = new TextPart("plain")
            {
                Text = @"Hey Chandler, I just wanted to let you know that Monica and I were going to go play some paintball, you in? -- Joey"
            };


            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("devmlbd@gmail.com", "TDM%dev@2021!comrade");
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}