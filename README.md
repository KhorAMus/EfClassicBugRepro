# EF Classic bug reproduction

Минимальный ASP.NET Core проект на .NET 8 с одной таблицей PostgreSQL.

## Требования

- .NET 8 SDK
- PostgreSQL 15, доступный на `localhost:5433`
- пользователь `postgres` с паролем `1`

Приложение использует `Z.EntityFramework.Classic 7.1.69`, `Z.EntityFramework.Classic.Npgsql 7.1.6` и `Npgsql 6.0.13`.

## Запуск

Запустите:

```powershell
dotnet run
```

При старте приложение автоматически применяет миграции без вызова CLI. Если таблицы `BugRecords` нет, она создаётся. Если в ней нет записей, добавляется одна запись `Initial record`.
