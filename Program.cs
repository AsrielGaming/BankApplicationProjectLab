using BankApplicationProjectLab.PageForms;
using BankApplicationProjectLab.PopupScreens;

namespace BankApplicationProjectLab
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());

            //Application.Run(new Homepage());
            //Application.Run(new SignUpForm());
            //Application.Run(new Transaction());
            //Application.Run(new UserAccountPage());
            //Application.Run(new AdminControls());
        }
    }
}