# eClinic MS SQL Database

## Run in docker

### Needed software

Only docker.

### How to run

Run following command.

If you want a database with empty tables:

```
docker run -p 1433:1433 -d sbandowski/sqlserver:db-with-tables
```

If you want a database and tables with sample data:

```
docker run -p 1433:1433 -d sbandowski/sqlserver:db-with-tables-and-values
```

If you want a database and tables with sample data, triggers and procedures:

```
docker run -p 1433:1433 -d sbandowski/sqlserver:db-with-tables-values-triggers-procedures
```

After this you should be able to see a running docker container when typing ``` docker ps ``` command in bash/cmd/powershell.

### How to connect to a database using Microsoft SQL Managment Studio (win) or Azure Data Studio (macOS)

1. Check IP of Ethernet adapter vEthernet (DockerNAT). You can do it using ipconfig (win) or ifconfig (linux) commands.
2. When connecting to database in SSMS type in IP of your DockerNAT as Server Name.
3. Change Authentication to SQL Server Authentication (SMSS) or SQL Login (Azure).
4. Login: sa , Password: Qwerty123!

NOTE: Password is set as an environment variable.
      If you dont want to use SMSS or Azure you can try some other management tool on your own.

### How to save changes before stopping and removing container

TBD

## Run on Windows

TBD
