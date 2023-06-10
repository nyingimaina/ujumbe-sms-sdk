# Messenger

Namespace: UjumbeSmsSdk

Represents a messenger for sending SMS messages using the Ujumbe SMS API.

```csharp
public class Messenger
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Messenger](./ujumbesmssdk.messenger.md)

## Constructors

### **Messenger()**

Initializes a new instance of the [Messenger](./ujumbesmssdk.messenger.md) class.

```csharp
public Messenger()
```

## Methods

### **SendSingleMessageAsync(MessageBag, Authorization, String, Action&lt;HttpResponseMessage&gt;, Nullable&lt;Int32&gt;)**

Sends a single message using the Ujumbe SMS API.

```csharp
public Task<UjumbeResponse> SendSingleMessageAsync(MessageBag messageBag, Authorization authorization, string url, Action<HttpResponseMessage> onResponse, Nullable<int> countryCode)
```

#### Parameters

`messageBag` [MessageBag](./ujumbesmssdk.request.messagebag.md)<br>
The message bag containing the message details.

`authorization` [Authorization](./ujumbesmssdk.request.authorization.md)<br>
The authorization details for accessing the Ujumbe SMS API.

`url` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The URL of the messaging API endpoint.

`onResponse` [Action&lt;HttpResponseMessage&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.action-1)<br>
An optional callback function to handle the response. You may leave this null if you don't need to inspect the raw Http response.

`countryCode` [Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The country code to prepend to the phone numbers (optional).

#### Returns

[Task&lt;UjumbeResponse&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
The Ujumbe response object.

### **SendMultipleMessagesAsync(List&lt;MessageBag&gt;, Authorization, String, Action&lt;HttpResponseMessage&gt;, Nullable&lt;Int32&gt;)**

Sends multiple messages using the Ujumbe SMS API.

```csharp
public Task<UjumbeResponse> SendMultipleMessagesAsync(List<MessageBag> messageBags, Authorization authorization, string url, Action<HttpResponseMessage> onResponse, Nullable<int> countryCode)
```

#### Parameters

`messageBags` [List&lt;MessageBag&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
The list of message bags containing the message details.

`authorization` [Authorization](./ujumbesmssdk.request.authorization.md)<br>
The authorization details for accessing the Ujumbe SMS API.

`url` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The URL of the messaging API endpoint.

`onResponse` [Action&lt;HttpResponseMessage&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.action-1)<br>
An optional callback function to handle the response. You may leave this null if you don't need to inspect the raw Http response.

`countryCode` [Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The country code to prepend to the phone numbers (optional).

#### Returns

[Task&lt;UjumbeResponse&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1)<br>
The Ujumbe response object.
