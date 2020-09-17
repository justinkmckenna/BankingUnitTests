using BankingDomain;
using BankingUnitTests;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankKiosk
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // inversion of control (IOC) container to construct our objects for us
            var instance = Bootstrap().GetInstance<Form1>();
            Application.Run(instance);
        }

        public static Container Bootstrap()
        {
            // "Composition Root"
            var container = new Container();
            container.Options.EnableAutoVerification = false;
            container.Register<ISystemTime, SystemTime>();
            container.Register<ICalculateBankAccountBonuses, StandardBonusCalculator>();
            container.Register<IProvideTheCutoffClock, StandardCutoffClock>();
            container.Register<INotifyTheFeds, WindowsFormsFedNotifier>();
            container.Register<BankAccount>();
            container.Register<Form1>();
            return container;
        }
    }
}
