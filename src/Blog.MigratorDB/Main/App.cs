using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using DbUp;
using DbUp.Engine;
using DbUp.ScriptProviders;
using DbUp.Support;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Blog.MigratorDB
{
    public class App
    {
        private readonly ConnectionStringCollection _settings;

        public App(IOptions<ConnectionStringCollection> settings) { _settings = settings.Value; }

        public async Task RunAsync(string[] args)
        {
            try
            {
                /* Inicio de la tarea asíncrona. */
                await Task.Run(() =>
                {
                    /* Cadena de conexión a la Base de Datos tomada desde el archivo AppConfig.json. */
                    var connectionString = _settings.ConnectionStringPostgreSQLServer;

                    /* Drop de la Base de datos */
                    // DropDatabase.For.PostgresqlDatabase(connectionString);
                    /* Creamos la Base de Datos, si no existe... */
                    // EnsureDatabase.For.SqlDatabase(connectionString);
                    EnsureDatabase.For.PostgresqlDatabase(connectionString);

                    /* Configuramos el motor de migración de Base de Datos de DbUp. */
                    UpgradeEngine upgradeEngine = DeployChanges
                        .To
                        .PostgresqlDatabase(connectionString)
                        .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), x => x.StartsWith($"Blog.MigratorDB.SQLScripts.BeforeDeployment.PostgreSQL"), new SqlScriptOptions { ScriptType = ScriptType.RunOnce, RunGroupOrder = 0 })
                        .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), x => x.StartsWith($"Blog.MigratorDB.SQLScripts.Deployment.PostgreSQL"), new SqlScriptOptions { ScriptType = ScriptType.RunOnce, RunGroupOrder = 1 })
                        // .WithScriptsFromFileSystem(@"./SQLScripts/BeforeDeployment/PostgreSQL/")
                        // .WithScriptsFromFileSystem(@"./SQLScripts/Deployment/PostgreSQL/")
                        .WithTransactionPerScript()
                        .LogToConsole()
                        .Build();
                    if (upgradeEngine.IsUpgradeRequired())
                    {
                        /* Ejecutamos la migración de Base de Datos. */
                        var result = upgradeEngine.PerformUpgrade();
                        if (!result.Successful)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(result.Error);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Migración de Base de Datos completada con éxito.");
                            Console.ResetColor();
                        }
                    }
                }).ConfigureAwait(false);
            }
            catch (Exception oEx)
            {
                Console.WriteLine($"Ocurrió un error al realizar este proceso de migración de Base de Datos: {oEx.Message.Trim()}.");
            }
        }
    }
}