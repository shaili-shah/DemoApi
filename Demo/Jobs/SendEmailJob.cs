using Quartz;

namespace Demo.Jobs
{
    public class SendEmailJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Running send email..............");
            return Task.CompletedTask;
        }
    }
}