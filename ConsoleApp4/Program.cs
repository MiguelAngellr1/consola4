using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace ConsoleApp2
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string enviaCorreos = string.Empty;

            Console.WriteLine("Desea enviar un correo elecromico ?");
            enviaCorreos = Console.ReadLine();
            if(enviaCorreos == "si")
            {
                string servidor = "smtp.gmail.com";
                int puerto = 587;
                string gmailUser = "ml2297071@gmail.com";
                string gmailPass = "miguelangel2004xdxd01";

                MimeMessage mensaje = new MimeMessage();
                mensaje.From.Add(new MailboxAddress("prueba01",gmailUser));
                mensaje.To.Add(new MailboxAddress("destino",gmailUser));
                mensaje.Subject = "Hola como estas Programador";

                BodyBuilder cuerpoMensaje = new BodyBuilder();
                cuerpoMensaje.HtmlBody = "hola <b>mundo</b>";

                mensaje.Body = cuerpoMensaje.ToMessageBody();

                SmtpClient clienteSmtp = new SmtpClient();
                clienteSmtp.CheckCertificateRevocation = false;
                clienteSmtp.Connect(servidor, puerto, MailKit.Security.SecureSocketOptions.StartTls);
                clienteSmtp.Authenticate(gmailUser,gmailPass);
                clienteSmtp.Send(mensaje);
                clienteSmtp.Disconnect(true);

            }
            Console.WriteLine("correo enviado exitosamente");

            Console.ReadLine();

        }
    }
}