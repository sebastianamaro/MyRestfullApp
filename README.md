# MyRestfullApp

This is the source code for the .NET Exercises.

In order to run the app you should follow these steps:

1.	Run the scripts inside the DB Setup folder
2.	Modify MyRestfullApp\MyRestfullApp.Data\App.Config & MyRestfullApp\MyRestfullApp\Web.config to configure the database connection, search for the MyRestfullAppEntities connection string, change it according to your DB configuration.
3.	Run the app from Visual Studio 2015, or publish it to IIS
4.	When run it will display the default help page

## Routes

This app has two routes. The BASE URL should be http://localhost:4735/Api

1.	Cotizacion
	1.	GET /Cotizacion?moneda=dolar will get the current dolar exchange rate, according to this webservice: https://www.bancoprovincia.com.ar/Principal/Dolar
		Other supported yet not implemented values are peso or real

2.  User
	1.	GET api/User 
	2.	GET api/User/{id}
	3.	POST api/User [UserJSONBODY]
	4.	PUT api/User/{id} [UserJSONBODY]
	5.	DELETE api/User/{id}

UserJSONBody
```
{
	"FirstName":"John",
	"LastName":"Doe",
	"Email":"john@",
	"Password":"pepe"
}
```
