Apunte -> Recuerda añadir los proyecto a la solucion con dotnet sln add Blog.MigratorDB
API ->  Aplication -> Infrastructure -> Domain
dotnet ef dbcontext scaffold "Server=192.168.1.62;Port=9988;Database=postgres;User Id=postgres;Pwd=BLAHBLAH;" Npgsql.EntityFrameworkCore.PostgreSQL --output-dir "temp" --context "dbContext" -f