using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Runtime.CompilerServices;

namespace WFApp
{

    public class DataChangedEventArgs : EventArgs
    {
        public DataTable? dt { set; get; }
        public string name { set; get; } = "";
    }
    internal static class Program
    {
        public static event EventHandler<DataChangedEventArgs> ?DataChanged;
        public static void fireDataChanged(object sender, DataChangedEventArgs args) 
        {
            DataChanged?.Invoke(sender, args);
        }
        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<FormContainer>()
                    .AddLogging(configure => { configure.AddDebug(); }) ;
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var services = new ServiceCollection();
            ConfigureServices(services);
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                Application.Run(serviceProvider.GetRequiredService<FormContainer>());
            }
        }
    }
}