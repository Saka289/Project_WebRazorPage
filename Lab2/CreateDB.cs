using Lab2.Data;

namespace Lab2
{
    public class CreateDB
    {
        public static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<SchoolContext>();
                    context.Database.EnsureCreated();
                    //DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<CreateDB>>();
                    logger.LogError(ex, "An error occurred creating the DB");
                }
            }
        }
    }
}
