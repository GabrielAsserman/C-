COMANDOS:

dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Pomelo.EntityFrameworkCore.MySql

dotnet tool install --global dotnet-ef

dotnet ef migrations add InitialCreate

dotnet ef database update

dotnet run
