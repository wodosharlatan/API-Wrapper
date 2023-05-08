# APIWrap

A C# wrapper for <a href="https://github.com/wodosharlatan/REST-API-DB">my awesome REST API</a>



## Installation

<ADD NAME HERE!> can be installed via NuGet Package Manager:

```powershell
Install-Package <ADD NAME HERE!> -Version 1.0.0
```
Or through the dotnet CLI:

```bash
dotnet add package <ADD NAME HERE!> --version 1.0.0
```

## Usage
First, you need to create an instance of the  <ADD NAME HERE!> class by passing your API key as a parameter:

```csharp
<ADD NAME HERE!> api = new <ADD NAME HERE!>("your_api_key_here");
```
After creating the instance you can freely use the package

# Methods

## 1.  Inserting new user
To insert a new user into the API, call the `InsertNewUser` method and pass the username and password as parameters:

```csharp
bool result = await api.InsertNewUser("username", "password");
```
The method returns a boolean value indicating whether the operation was successful or not.

## 2.   Getting all users
To get all users from the API, call the `GetAllUsers` method:

```csharp
string result = await api.GetAllUsers();
```

The method returns a string containing the JSON response from the API.


## 3.  Getting all products
To get all products from the API, call the `GetAllProducts` method:

```csharp
string result = await api.GetAllProducts();
```
The method returns a string containing the JSON response from the API.


## 4.   Getting product by ID
To get a product by ID from the API, call the GetProductByID method and pass the ID as a parameter:

```csharp
string result = await api.GetProductByID(1);
```

The method returns a string containing the JSON response from the API.

## 5. Inserting new product
To insert a new product into the API, call the InsertNewProduct method and pass the product name, unit, count, and added by as parameters:

```csharp
bool result = await api.InsertNewProduct("product_name", "unit", "count", "added_by");
```

The method returns a boolean value indicating whether the operation was successful or not.

## 6. Deleting product by ID
To delete a product by ID from the API, call the DeleteProductByID method and pass the ID as a parameter:

```csharp
string result = await api.DeleteProductByID(1);
```

The method returns a string containing the JSON response from the API.

## 7. Getting count of products
To get the count of products from the API, call the GetCountOfProducts method:

```csharp
int count = await api.GetCountOfProducts();
```
The method returns an integer value containing the count of products.

## 8. Updating existing product
To update an existing product in the API, call the UpdateExistingProduct method and pass the product ID, product name, unit, count, and added by as parameters:

```csharp
bool result = await api.UpdateExistingProduct(1, "product_name", "unit", "count", "added_by");
```
The method returns a boolean value indicating whether the operation was successful or not.

# License
APIWrap is released under the MIT License. See <a href="https://github.com/wodosharlatan/API-Wrapper/edit/main/LICENSE">LICENSE</a> for details.

