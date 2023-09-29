# DotNetPluginWebAPI
A web API created to move controller and business logic into separate libraries from core service.

## Motivation
Work-related experiences have brought to my attention many legacy systems that utilize code intended to accomplish the same task but may be written in different ways even if the code base is written in the same programming language.

Ultimately this results in new and existing developers inadvertently reinventing the wheel for components and systems that have already been developed previously. Therefore, I have created a single Web API and migrated the business logic into separate libraries that can be loaded on application startup.

By doing this, new developers can focus on core business logic and refrain from re-developing common cross-cutting concerns such as logging, infrastructure access (i.e. data persistence), authorization and authentication.

[//]: # (## Build status)

## Code style
[![js-standard-style](https://img.shields.io/badge/code%20style-standard-brightgreen.svg?style=flat)](https://github.com/feross/standard)
 
[//]: # (## Screenshots)

## Tech/framework used

<b>Built with</b>

- C# 
- .NET 6
- [Swagger](https://www.nuget.org/packages/swashbuckle.aspnetcore.swagger/)
- [Scrutor]([google.com](https://www.nuget.org/packages/Scrutor))

## Features
This library is intended to be extendable by creating individual class libraries containing Web API controlers, dependency registries, and business logic.

```csharp
using Plugin.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public class IndividualPluginRegistry : IRegister
{
    public void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IRepository, InMemoryRepository>();
        services.AddHttpClient<UspsHttpClient>((sp, client) =>
        {
          var endpoints = sp.GetRequiredServices<IOptions<ProviderSettings>>().value;
          client.BaseAddress = new Uri(endpoints.Provide["Uri"];

          var apiId = endpoints.Provider["ApiId"];
          var apiKey = endpoints.Provider["ApiKey"];
          var apiToken = Convert.ToBase64String(Encoding.Default.GetBytes($"{apiId}:{apiKey}"));
          
          client.DefaultRequestHeaders.Add("Authorization", $"Basic {apiToken}");
        }
    }

```

[//]: # (## Code Example)
[//]: # (## Installation)
[//]: # (Provide step by step series of examples and explanations about how to get a development env running.)
[//]: # (## API Reference)

[//]: # (Depending on the size of the project, if it is small and simple enough the reference docs can be added to the README. For medium size to larger projects it is important to at least provide a link to where the API reference docs live.)

## Tests
Tests have been created as part of the GreenHorn.NameParser project using the Microsoft Testing Framework.

Example: 
```csharp

```

## How to use?

1. Start by cloning this project into Visual Studio. 
2. Build the project.
   - Terminal `dotnet clean && dotnet build` 
4. Copy the resulting Plugin.Example1.dll into your Plugin.API prject executing directory under the "Plugins" directory.
5. Debug the project Plugin.API
6. If your browser does not opnen on its own: Navigate to `https://localhost:7050/swagger/index.html`

## Contribute

Contributions are not expected but always welcome!
 
### Contribution Guidelines
Please ensure your pull request adheres to the following guidelines:

- Alphabetize your entry.
- Search previous suggestions before making a new one, as yours may be a duplicate.
- Suggested READMEs should be beautiful or stand out in some way.
- Make an individual pull request for each suggestion.
- New categories, or improvements to the existing categorization are welcome.
- Keep descriptions short and simple, but descriptive.
- Start the description with a capital and end with a full stop/period.
- Check your spelling and grammar.
- Make sure your text editor is set to remove trailing whitespace.

Thank you for your suggestions!
