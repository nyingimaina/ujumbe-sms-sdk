# Authorization

Namespace: UjumbeSmsSdk.Request

Represents the authorization details for accessing the Ujumbe SMS API.

```csharp
public class Authorization
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Authorization](./ujumbesmssdk.request.authorization.md)

## Properties

### **ApiKey**

Gets or sets the API key for authentication.

```csharp
public string ApiKey { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **YourEmail**

Gets or sets your email associated with the API key. This is usually the email for the account which you used to obtain the API key.

```csharp
public string YourEmail { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Constructors

### **Authorization()**

```csharp
public Authorization()
```
