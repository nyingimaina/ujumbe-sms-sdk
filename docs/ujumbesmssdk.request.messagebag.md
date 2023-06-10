# MessageBag

Namespace: UjumbeSmsSdk.Request

Represents a message bag containing phone numbers, message content, and sender information.

```csharp
public class MessageBag
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [MessageBag](./ujumbesmssdk.request.messagebag.md)

## Properties

### **PhoneNumbers**

Gets or sets a HashSet of phone numbers.

```csharp
public HashSet<string> PhoneNumbers { get; set; }
```

#### Property Value

[HashSet&lt;String&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.hashset-1)<br>

### **Numbers**

Gets or sets a comma-separated string representation of the phone numbers.
 This is read-only and gotten from the HashSet of phone numbers.

```csharp
public string Numbers { get; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Message**

Gets or sets the message content.

```csharp
public string Message { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **SenderId**

Gets or sets the sender ID.

```csharp
public string SenderId { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Constructors

### **MessageBag()**

```csharp
public MessageBag()
```
