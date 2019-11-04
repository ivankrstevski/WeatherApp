# Weather App

## Application start:

1. You need to check and configure if needs, the **DefaultConnection** property in the file **Web.config** 
that is included into the project **WeatherApp.API**, so the database can be created according to the configuration.

Now the connection string looks like the one below:

```
<connectionStrings>
	<add name="DefaultConnection" providerName="MySql.Data.MySqlClient" connectionString="Server=localhost;Port=3306;Database=weatherdb;Uid=root;Pwd=admin;" />
</connectionStrings>
```

2. Right click on the project **WeatherApp.API** and click the option **Set as StartUp Project**. 



  