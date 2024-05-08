# dotnet-learning


## Start project

```bash
dotnet new webapi --name <project_name>
```

## Run Project
```bash
dotnet run --project <project_name>.csproj
```

## Add package (dependency)
```bash
dotnet add package <package_name> --version <package_version>
```


## Add migrations

### Install `dotnet ef tools`

```bash
dotnet tool install --global dotnet-ef
```

### Execute migration
```bash
dotnet ef migrations add <migration_name>
```
### Undo migration
```bash
dotnet ef migrations remove
```
### Apply changes to database
```bash
dotnet ef database update
```


## Tips
| aspnet | springboot |      
| :---: | :---: |
| Context | Repository |