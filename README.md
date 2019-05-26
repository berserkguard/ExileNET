# ExileNET
A C# Wrapper for the Path of Exile Public API

## Installation
> Install-Package ExileNet
## Requirements
* .Net Core >= 2.2
* Newtonsoft.Json >= 12.0.2

## Usage and Examples
The ExileNet API and Functions are all called from a Client. These functions are async and awaitable. 
Note: These examples only show a select few methods. Additional methods are present.

### Public Stashes
```csharp
Client client = new Client();

var publicStash = await client.Api.GetPublicStashesAsync();
```
This returns a Stash Object, which contains the Next Change ID and a List of Stash Tabs. You can optionally supply a Next Change ID parameter in the GetPublicStashesAsync method to supply a Next Change ID.

### Leagues
```csharp
var leagues = await client.Api.GetAllLeaguesAsync(Platform.Pc);
```
This returns a List of All Current Leagues on the given Platform. Platform parameter is an enum, with Pc, Xbox and Sony respectively. 

### Ladders
```csharp
var ladder = await client.Api.GetLadderByIdAsync("Standard", Platform.Xbox);
```
This returns a Ladder Object for the given Ladder ID and Platform, which contains a cache date and a list of Ladder Entries.

### PvP
```csharp
var pvpList = await client.Api.GetPvPSeasonById("EUPvPSeason01", Platform.Pc);
```
This returns a List which contains information about the given season.

