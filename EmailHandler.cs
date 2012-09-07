using System.ComponentModel;
using ActiveUp.Net.Mail;
namespace Email {
    public class EmailHandler {
        public EmailHandler(string from, string to) {
            this.from = from;
            this.to = to;
        }

        public void checkAvailability(RunWorkerCompletedEventHandler target) {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new System.ComponentModel.DoWorkEventHandler(checkAvailability);
            worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(target);
            worker.RunWorkerAsync();
        }

        public void checkAvailability(object sender, System.ComponentModel.DoWorkEventArgs e) {
            try {
                System.Net.Sockets.TcpClient clnt = new System.Net.Sockets.TcpClient("smtp.gmail.com", 587);
                clnt.Close();
                e.Result = EmailResponse.ServerReachable;
            } catch {
                e.Result = EmailResponse.ServerUnreachable;
            }
        }

        private string from, to, body, title;
        public void sendEmail(string new_title, string new_body, RunWorkerCompletedEventHandler target) {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new System.ComponentModel.DoWorkEventHandler(sendEmail);
            worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(target);
            body = new_body;
            title = new_title;
            worker.RunWorkerAsync();

        }

        private void sendEmail(object sender, System.ComponentModel.DoWorkEventArgs e) {
            Message mail = new Message();
            mail.From = new Address(from);
            mail.To.Add(new Address(to));

            mail.Subject = title;

            mail.Priority = MessagePriority.Normal;

            MimeBody body = new MimeBody(BodyFormat.Text);
            body.Text = this.body;
            mail.BodyText = body;

            //            mail  .Headers.Add("Disposition-Notification-To", "<" + email_sender + ">");
            // mail.Attachments.Add(Server.MapPath("/"));

            SmtpClient.DirectSend(mail);


            e.Result = EmailResponse.EmailSent;
        }
        public static bool validateEmailAddress(string email) {
            if (email.Contains("@")) {
                //                if (email.Split('@', 2)[1].Contains("."))
                return true;
            }
            return false;
        }
    }
}
