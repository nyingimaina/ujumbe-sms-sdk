# Ujumbe SMS SDK

The Ujumbe SMS SDK provides a convenient interface for .Net developers to easily send SMS messages using the Ujumbe SMS API. It is built in C# and handles all of the work required to dispatch SMS and only requires you provide the recipients, the message and your API key

## Features

- Easy to use.
- Send single or multiple SMS messages using the Ujumbe SMS API.
- Specify authorization details for accessing the API.
- Optional callback function to handle the raw HTTP response.
- Prepend country code to phone numbers (optional).
- Validation of inputs
- Error handling with descriptive error information messages
- Well documented and includes concise examples

## Installation

You can install the UjumbeMessenger package via the NuGet Package Manager or by using the dotnet CLI.

### Package Manager

```bash
PM> Install-Package ujumbe-sms-sdk
```

### .NET CLI

```bash
dotnet add package ujumbe-sms-sdk
```

## Usage

To use the UjumbeMessenger package, follow the steps below:

1. import the **UjumbeSmsSdk** namespace into your code

   ```csharp
   using UjumbeSmsSdk;
   ```

2. Send single message

```csharp
// Create a MessageBag object with the message details
var messageBag = new MessageBag
{
    PhoneNumbers = new HashSet<string> { "+1234567890" }, // Replace with the recipient's phone number(s)
    Message = "Hello, world!", // Replace with your desired message content
    SenderId = "YourSenderID" // Replace with your desired sender ID
};

// Create an Authorization object with the necessary credentials
var authorization = new Authorization
{
    ApiKey = "your-api-key", // Replace with your Ujumbe SMS API key
    YourEmail = "your-email@example.com" // Replace with your email associated with the API key
};

// Initialize an instance of Messenger
var messenger = new Messenger();

try
{
    // Send the single message
    UjumbeResponse response = await messenger.SendSingleMessageAsync(messageBag, authorization);

    // Handle the response
    if (response.Success)
    {
        Console.WriteLine("Message sent successfully!");
    }
    else
    {
        Console.WriteLine("Failed to send the message.");
    }
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred while sending the message.");
    Console.WriteLine($"Error: {ex.Message}");
}

```

3. Send Multiple Messages

```csharp
// Create a list of MessageBag objects with the message details
List<MessageBag> messageBags = new List<MessageBag>
{
    new MessageBag
    {
        PhoneNumbers = new HashSet<string> { "+1234567890" }, // Replace with the recipient's phone number(s)
        Message = "Hello, world!", // Replace with your desired message content
        SenderId = "YourSenderID" // Replace with your desired sender ID
    },
    new MessageBag
    {
        PhoneNumbers = new HashSet<string> { "+9876543210" }, // Replace with the recipient's phone number(s)
        Message = "This is another message.", // Replace with your desired message content
        SenderId = "YourSenderID" // Replace with your desired sender ID
    }
};

// Create an Authorization object with the necessary credentials
Authorization authorization = new Authorization
{
    ApiKey = "your-api-key", // Replace with your Ujumbe SMS API key
    YourEmail = "your-email@example.com" // Replace with your email associated with the API key
};

// Initialize an instance of Messenger
var messenger = new Messenger();

try
{
    // Send the multiple messages
    UjumbeResponse response = await messenger.SendMultipleMessagesAsync(messageBags, authorization);

    // Handle the response
    if (response.Success)
    {
        Console.WriteLine("Messages sent successfully!");
    }
    else
    {
        Console.WriteLine("Failed to send the messages.");
    }
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred while sending the messages.");
    Console.WriteLine($"Error: {ex.Message}");
}
```

## API Reference

[Api Reference](https://github.com/nyingimaina/ujumbe-sms-sdk/blob/master/docs/index.md)

## License

This project is licensed under the [MIT License] (https://opensource.org/license/mit/).

## Contributions

Contributions to this project are welcome. If you find any issues or have suggestions for improvements, please open an issue or submit a pull request on the GitHub repository.

## Disclaimer

This package is not officially affiliated with Ujumbe SMS, but is built based on their REST API specs to ease coding in .Net
