# nosted-mvc

Nuget packeges som må innstaleres:
//De nyeste versjonene for .net8 skapte problemer hold dere til 7 foreløpig
Pomelo.EntityFrameworkCore.MySql	7.0.0	(Rider)
Microsoft.EntityFrameworkCore	7.0.12
Microsoft.EntityFrameworkCore.Design	7.0.12
Microsoft.EntityFrameworkCore.Proxies	7.0.12
Microsoft.EntityFrameworkCore.SqlServer	7.0.12
Microsoft.EntityFrameworkCore.Tools	7.0.12

2. Start a mariadb container using the localdirectory "database" to store the data:
Bash (Mac and Linux)
docker run --rm --name mariadb -p 3308:3306/tcp -v "$(pwd)/database":/var/lib/mysql -e MYSQL_ROOT_PASSWORD=12345 -d mariadb:10.5.11	
Powershell (Windows)
docker run --rm --name mariadb -p 3308:3306/tcp -v "%cd%\database":/var/lib/mysql -e MYSQL_ROOT_PASSWORD=12345 -d mariadb:10.5.11

3. Enter the database and create the database and table for this skeleton:
docker exec -it mariadb mysql -p
When prompted enter the password (12345), then type create Db:
Create database Nosted;

4. Run migration:
   dotnet ef migrations add initial
   dotnet ef database update
