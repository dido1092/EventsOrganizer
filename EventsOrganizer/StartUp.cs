using EventsOrganizer.Data;
using Microsoft.EntityFrameworkCore;

namespace EventsOrganizer
{
    public static class StartUp
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            EventsOrganizerContext context = new EventsOrganizerContext();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

            //var optionsBuilder = new DbContextOptionsBuilder<EventsOrganizerContext>();

            //optionsBuilder.UseSqlServer(
            //    "Server=server_name;Database=db_name;User Id=username;Password=password;",
            //    sqlServerOptions => sqlServerOptions.EnableRetryOnFailure(
            //        maxRetryCount: 5,
            //        maxRetryDelay: TimeSpan.FromSeconds(10),
            //        errorNumbersToAdd: null
            //    )
            //);

            //using var context = new EventsOrganizerContext(optionsBuilder.Options);

            //// Примерна проверка
            //var count = context.Events!.Count();
            //Console.WriteLine($"Rows in table: {count}");
        }
    }
}