# APIWrap

A C# wrapper for <a href="https://github.com/wodosharlatan/REST-API-DB">my awesome REST API</a>



## Installation

<AD NAME HERE!> can be installed via NuGet Package Manager:

```powershell
Install-Package <AD NAME HERE!> -Version 1.0.0
```
Or through the dotnet CLI:

```bash
dotnet add package <AD NAME HERE!> --version 1.0.0
```



## Usage
First, you need to create an instance of the  <AD NAME HERE!> class by passing your API key as a parameter:

```csharp
<AD NAME HERE!> api = new <AD NAME HERE!>("your_api_key_here");
```
After creating the instance you can freely use the package



# Methods

1.  ## Inserting new user
To insert a new user into the API, call the `InsertNewUser` method and pass the username and password as parameters:

```csharp
bool result = await api.InsertNewUser("username", "password");
```
The method returns a boolean value indicating whether the operation was successful or not.



2.  ## Getting all users
To get all users from the API, call the `GetAllUsers` method:

```csharp
string result = await api.GetAllUsers();
```

The method returns a string containing the JSON response from the API.




3.  ## Getting all products
To get all products from the API, call the `GetAllProducts` method:

```csharp
string result = await api.GetAllProducts();
```
The method returns a string containing the JSON response from the API.



