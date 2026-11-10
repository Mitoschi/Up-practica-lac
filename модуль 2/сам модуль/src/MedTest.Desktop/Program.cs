using MedTest.Data;
namespace MedTest.Desktop;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        // An unexpected error is shown and the work continues instead of closing the program.
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        Application.ThreadException += (_, e) =>
            MessageBox.Show("Непредвиденная ошибка: " + e.Exception.Message + Environment.NewLine + "Обновите окно (F5). Если ошибка повторяется, перезапустите программу.",
                "МедТест", MessageBoxButtons.OK, MessageBoxIcon.Error);
        var connection = Environment.GetEnvironmentVariable("MEDTEST_CONNECTION_STRING")
            ?? DatabaseSetup.ConnectionString(DatabaseSetup.DefaultServer, DatabaseSetup.WorkingDatabase);
        var session = new AppSession(new MedDatabase(connection));
        using var login = new LoginForm(session);
        Application.Run(login);
    }
}
