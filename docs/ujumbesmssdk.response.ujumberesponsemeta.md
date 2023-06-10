# UjumbeResponseMeta

Namespace: UjumbeSmsSdk.Response

Represents the meta information in the Ujumbe response.

```csharp
public class UjumbeResponseMeta
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [UjumbeResponseMeta](./ujumbesmssdk.response.ujumberesponsemeta.md)

## Properties

### **Recipients**

Gets or sets the recipients in the response.

```csharp
public long Recipients { get; set; }
```

#### Property Value

[Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64)<br>

### **CreditsDeducted**

Gets or sets the credits deducted in the response.

```csharp
public decimal CreditsDeducted { get; set; }
```

#### Property Value

[Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)<br>

### **AvailableCredits**

Gets or sets the available credits in the response.

```csharp
public object AvailableCredits { get; set; }
```

#### Property Value

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>

### **UserEmail**

Gets or sets the email of the user in the response.

```csharp
public string UserEmail { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **DateTime**

Gets or sets the date and time information in the response.

```csharp
public UjumbeResponseDateTime DateTime { get; set; }
```

#### Property Value

[UjumbeResponseDateTime](./ujumbesmssdk.response.ujumberesponsedatetime.md)<br>

## Constructors

### **UjumbeResponseMeta()**

```csharp
public UjumbeResponseMeta()
```
