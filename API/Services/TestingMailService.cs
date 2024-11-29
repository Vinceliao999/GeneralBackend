namespace API.Services
{
    public class TestingMailService : IMailService
    {
        private readonly string _mailTo = "";
        private readonly string _mailFrom = "";

        public TestingMailService(IConfiguration configuration)
        {
            _mailTo = configuration["MailSettings:mailToAddress"];
            _mailFrom = configuration["MailSettings:mailFromAddress"];
        }

        public void Send(string subject, string message)
        {
            Console.WriteLine($"Send with {nameof(TestingMailService)}");
            Console.WriteLine($"MailTo: {_mailTo}");
            Console.WriteLine($"MailFrom: {_mailFrom}");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Message: {message}");
        }

    }
}
