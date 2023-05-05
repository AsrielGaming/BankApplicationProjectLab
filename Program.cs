using BankApplicationProjectLab.PageForms;

namespace BankApplicationProjectLab
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            //Application.Run(new Homepage());
            //Application.Run(new SignUpForm());
            Application.Run(new LoginForm());
        }
    }
}