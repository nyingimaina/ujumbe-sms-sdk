# PhoneNumberFormatter

Namespace: UjumbeSmsSdk

Utility class for formatting phone numbers with optional country codes.

```csharp
public class PhoneNumberFormatter
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [PhoneNumberFormatter](./ujumbesmssdk.phonenumberformatter.md)

## Constructors

### **PhoneNumberFormatter()**

```csharp
public PhoneNumberFormatter()
```

## Methods

### **FormatPhoneNumber(String, Nullable&lt;Int32&gt;)**

Formats the provided phone number with an optional country code.

```csharp
public string FormatPhoneNumber(string phoneNumber, Nullable<int> countryCode)
```

#### Parameters

`phoneNumber` [String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The phone number to format.

`countryCode` [Nullable&lt;Int32&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.nullable-1)<br>
The country code to prepend (optional).

#### Returns

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
The formatted phone number.
