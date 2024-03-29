# modular-monolith-course1

Code asssociated with [Modular Monolith - Getting Started](https://app.dometrain.com/courses/getting-started-modular-monoliths-in-net) course.


Command to create EntityFramework migation.
```
cd RiverBooks.Web

dotnet ef migrations add Initial -c BookDbContext -p ../RiverBooks.Books/RiverBooks.Books.csproj -s ./RiverBooks.Web.csproj -o Data/Migrations

```

On Ubuntu, install sql server in a docker container using the command:
```
sudo docker pull mcr.microsoft.com/mssql/server:2022-latest
```

Then set up the database using:
```
sudo docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Password123"    -p 1433:1433 --name sql1 --hostname sql1    -d    mcr.microsoft.com/mssql/server:2022-latest
```

Local SQL Server password is 
```
Password123
```