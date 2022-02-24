# University Base
Моё первое приложение на Windows Form и MS SQL. Сделано в первую очередь для изучения SQL и работы с базой данных через оконный графический интерфейс 
### Для запуска нужно
+ Иметь 32 разрядную базу данных
>В проекте уже есть собственная MS SQL база данных **Database1.mdb**
>Чтобы использовать другую, в проекте в классе **Form1.cs** нужно изменить переменную *dataBasePath* указав путь к ней *PATH/YOUR_BASE.mdb*
```C#
private string dataBasePath =  @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=PATH/YOUR_BASE.mdb"
```
+ Дать доступ к системной таблице MS Access **MSysObjects**
>В проекте в классе **MSysWindow.cs** нужно изменить переменную *connString* указав путь к системной таблице MSysObjects, также при использовании другой базы путь к ней *PATH/YOUR_BASE.mdb*
```C#
public static string connString = "Provider = Microsoft.Jet.OLEDB.4.0;" +
        " Data Source = PATH/YOUR_BASE.mdb; " +
        "Persist Security Info = False; " + "Jet OLEDB:Create System Database=true; " +
        @"Jet OLEDB:System database = C:\Users\kondi\AppData\Roaming\Microsoft\Access\System.mdw";
```

