# SurveyApp
### Структура appsettings.json
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "DbConnection": ""
  },
  "AllowedHosts": "*"
}
```
### Строка подключения к базе данных
```
"ConnectionStrings": {
    "DbConnection": "Host={your-host};Database=surveyapp;Username=postgres;Password={your-password};Include Error Detail=true"
  }
```

### Схема базы данных
![DIAGRAMMA-BEZ-NAZVANIY.drawio-1.png](https://s2.radikal.cloud/2024/12/03/DIAGRAMMA-BEZ-NAZVANIY.drawio-1.png)\
Survey - хранит информацию об опросе.\
User - хранит информацию о пользователях.\
UserSurveyBind - связующая таблица между пользователями и опросами. Хранит статус - начат или завершен опрос, время начала и завершения.\
Question - хранит информацию о вопросах.\
Answer - хранит информацию о вариантах ответа.\
Choice - хранит информацию об ответах, выбранных пользователем.
