dotnet-hash
===========

[![Build](https://img.shields.io/azure-devops/build/thebluesky/c81281f3-f29c-4f59-87e5-dca12f44d979/2)][1] ![NuGet](https://img.shields.io/nuget/v/TheBlueSky.DotNet.Tools.SwiftHash) [![NuGet](https://img.shields.io/nuget/dt/TheBlueSky.DotNet.Tools.SwiftHash)][2]

A simple dotnet tool to calculate hashes for the given file.

The tool calculates MD5, SHA-1, SHA-256, SHA-384, and SHA-512 hashes for any file and outputs the result as Base64 or Hex string.

## Installation

To install the tool you need to install [.NET 6.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0), [.NET 7.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0), [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0), or [.NET 9.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0). Once installed, run this command:

```powershell
dotnet tool install TheBlueSky.DotNet.Tools.SwiftHash --global
```

## Usage

```
Usage: dotnet hash [arguments] [options]

Arguments:
  path                        Path to the file to calculate the hash for

Options:
  -?|-h|--help                Show help information
  -a|--algorithm <ALGORITHM>  The hashing algorithm
  -o|--out <OUTPUT>           The output format

The tool calculates MD5, SHA-1, SHA-256, SHA-384, and SHA-512 hashes
for any file and outputs the result as Base64 or Hex string.
The bigger the file is, the longer it takes to calculate the hash.
```

For example:

```powershell
dotnet hash readme.md --algorithm sha256 --out hex
```

Valid `algorithm`:

* `md5`
* `sha1`
* `sha256`
* `sha384`
* `sha512`

Valid `out`:

* `base64`
* `hex`

[1]: https://thebluesky.visualstudio.com/dotnet-hash/_build/latest?definitionId=2&branchName=master
[2]: https://www.nuget.org/packages/TheBlueSky.DotNet.Tools.SwiftHash/
