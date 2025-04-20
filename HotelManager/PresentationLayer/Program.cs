using ServiceLayer;

namespace PresentationLayer
{
    internal static class Program
    {
        static async Task SeedAdminIfNotExists()
        {
            var userManager = new UserManager();
            var allUsers = await userManager.ReadAllAsync();

            if (!allUsers.Any(u => u.Role == Role.Administrator))
            {
                var admin = new User(
                    Guid.NewGuid(),
                    "admin",
                    "admin123",
                    "Admin",
                    "Administrator",
                    "User",
                    new DateTime(1980, 1, 1),
                    "+0000000000",
                    "admin@example.com",
                    DateTime.Now,
                    true,
                    null,
                    Role.Administrator
                );

                await userManager.CreateAsync(admin);
                MessageBox.Show("Default admin created:\nUsername: admin\nPassword: admin123", "Admin Seeded");
            }
        }
        static async Task SeedReceptionistIfNotExists()
        {
            var userManager = new UserManager();
            var allUsers = await userManager.ReadAllAsync();

            if (!allUsers.Any(u => u.Role == Role.Receptionist))
            {
                var receptionist = new User(
                    Guid.NewGuid(),
                    "reception",
                    "reception123",
                    "Reception",
                    "Receptionist",
                    "User",
                    new DateTime(2000, 1, 1),
                    "+0000000010",
                    "reception@example.com",
                    DateTime.Now,
                    true,
                    null,
                    Role.Receptionist
                );

                await userManager.CreateAsync(receptionist);
                MessageBox.Show("Default receptionist created:\nUsername: reception\nPassword: reception123", "Receptionist Seeded");
            }
        }
        static async Task SeedWorkerIfNotExists()
        {
            var userManager = new UserManager();
            var allUsers = await userManager.ReadAllAsync();

            if (!allUsers.Any(u => u.Role == Role.Worker))
            {
                var receptionist = new User(
                    Guid.NewGuid(),
                    "worker",
                    "worker123",
                    "Worker",
                    "Worker",
                    "User",
                    new DateTime(1970, 1, 1),
                    "+0000000010",
                    "worker@example.com",
                    DateTime.Now,
                    true,
                    null,
                    Role.Worker
                );

                await userManager.CreateAsync(receptionist);
                MessageBox.Show("Default worker created:\nUsername: worker\nPassword: worker123", "Worker Seeded");
            }
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Seed the admin user if no admins exist
            SeedAdminIfNotExists().GetAwaiter().GetResult();
            SeedReceptionistIfNotExists().GetAwaiter().GetResult();
            SeedWorkerIfNotExists().GetAwaiter().GetResult();

            Application.Run(new LoginForm());

            
        }
    }
}