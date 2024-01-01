using Quartz;

namespace Demo.Jobs
{
    public static class ConfigureJobsExtension
    {
        public static void RegisterJobs(this IServiceCollection services, IConfiguration configuration)
        {
            if(configuration is null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            services.AddQuartz(q => {
                var jobKey = new JobKey("SendEmailJob");
                q.AddJob<SendEmailJob>(opts => opts.WithIdentity(jobKey));

                q.AddTrigger(opts => opts.ForJob(jobKey).WithIdentity("SendEmailJob-trigger").WithCronSchedule("0 */5 * * * ?")); // run every 5 minute

            });

            services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
        }
    }
}
