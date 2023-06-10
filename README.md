# Leave Management System

To create a migration you need to execute the following commands:

```bash
cd ./HR.LeaveManagement.Persistence 
```

```bash
dotnet ef migrations add <NameMigration> --startup-project ../HR.LeaveManagement.Api
```

To update the database you need to execute the following commands:

```bash
cd ./HR.LeaveManagement.Persistence 
```

```bash
dotnet ef database update --startup-project ../HR.LeaveManagement.Api
```