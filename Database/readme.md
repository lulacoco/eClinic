# eClinic MS SQL Database

## Run in docker

### Needed software

Only docker.

### How to run

Run following command.

```
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YOUR_PASSWORD_HERE" -p 1433:1433 -d sbandowski/sqlserver:test-version
```

After this you should be able to see a running docker container when typing ``` docker ps ``` command in bash/cmd/powershell.

### How to connect to a database using Microsoft SQL Managment Studio

1. Check IP of Ethernet adapter vEthernet (DockerNAT). You can do it using ipconfig (win) or ifconfig (linux) commands.
2. When connecting to database in SSMS type in IP of your DockerNAT as Server Name.
3. Change Authentication to SQL Server Authentication.
4. Login: sa , Password: PASSWORD_YOU_USED_WHEN_TYPING_DOCKER_RUN

### How to save changes before stopping and removing container

TBD

## Run on Windows

TBD
