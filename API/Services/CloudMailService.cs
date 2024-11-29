namespace API.Services
{
    public class CloudMailService : IMailService
    {
        private readonly string _mailTo = "";
        private readonly string _mailFrom = "";

        public CloudMailService(IConfiguration configuration)
        {
            _mailTo = configuration["MailSettings:mailToAddress"];
            _mailFrom = configuration["MailSettings:mailFromAddress"];
        }
        public void Send(string subject, string message)
        {
            Console.WriteLine($"Send with {nameof(CloudMailService)}");
            Console.WriteLine($"MailTo: {_mailTo}");
            Console.WriteLine($"MailFrom: {_mailFrom}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");
        }
    }
}
