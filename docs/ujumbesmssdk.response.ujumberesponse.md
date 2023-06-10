# UjumbeResponse

Namespace: UjumbeSmsSdk.Response

Represents the overall response from Ujumbe.

```csharp
public class UjumbeResponse
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [UjumbeResponse](./ujumbesmssdk.response.ujumberesponse.md)

## Properties

### **Status**

Gets or sets the status information in the response.

```csharp
public UjumbeResponseStatus Status { get; set; }
```

#### Property Value

[UjumbeResponseStatus](./ujumbesmssdk.response.ujumberesponsestatus.md)<br>

### **Meta**

Gets or sets the meta information in the response.

```csharp
public UjumbeResponseMeta Meta { get; set; }
```

#### Property Value

[UjumbeResponseMeta](./ujumbesmssdk.response.ujumberesponsemeta.md)<br>

### **Success**

Gets or sets a value that indicates whether the request was successful or not.

```csharp
public bool Success { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

## Constructors

### **UjumbeResponse()**

```csharp
public UjumbeResponse()
```
