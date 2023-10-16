namespace BuildMe.Application.Configurations
{
    public class ApplicationSettings : IApplicationSettings
    {
        public SQLSettings SQLSettings { get; set; }
        public SMTPSettings SMTPSettings { get; set; }
    }
}
