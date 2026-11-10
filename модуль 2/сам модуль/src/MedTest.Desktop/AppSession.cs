using Microsoft.Data.SqlClient;
using MedTest.Core;
using MedTest.Data;

namespace MedTest.Desktop;

/// <summary>The database and the signed-in employee, shared by all windows.</summary>
public sealed class AppSession(MedDatabase db)
{
    public MedDatabase Db { get; } = db;
    public AppUser? User { get; private set; }
    public AppUser Actor => User ?? throw new InvalidOperationException("Вход не выполнен.");
    public bool IsAdmin => User?.Role == Role.Admin;
    public bool IsDoctor => User?.Role == Role.Doctor;
    private bool upgraded;

    public async Task<string?> LoginAsync(string login, string password, Role mode)
    {
        // Новые версии приложения дополняют структуру базы (например, единицы показателей) при первом входе.
        if (!upgraded) upgraded = (await Try(() => DatabaseSetup.UpgradeAsync(Db.ConnectionString))).Error == null;
        var (user, error) = await Try(() => Db.LoginAsync(login, password, mode));
        User = user;
        return error;
    }

    public void Logout() => User = null;

    /// <summary>Runs a database call; an expected refusal or a connection problem becomes the message for the status line.</summary>
    public static async Task<(T? Value, string? Error)> Try<T>(Func<Task<T>> call)
    {
        try { return (await call(), null); }
        catch (DomainException ex) { return (default, ex.Message); }
        catch (SqlException ex) { return (default, "Ошибка базы данных: " + ex.Message); }
        catch (InvalidOperationException ex) { return (default, "Ошибка базы данных: " + ex.Message); }
    }

    public static async Task<string?> Try(Func<Task> call)
    {
        var (_, error) = await Try(async () => { await call(); return true; });
        return error;
    }
}
