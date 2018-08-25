dotnet-hash
===========

[main-nuget]: https://www.nuget.org/packages/TheBlueSky.DotNet.Tools.SwiftHash/
[main-nuget-badge]: https://img.shields.io/nuget/v/TheBlueSky.DotNet.Tools.SwiftHash.svg?style=flat-square&label=nuget

A simple dotnet tool to calculate hashes for the given file.

The tool calculates MD5, SHA-1, SHA-256, SHA-384, and SHA-512 hashes for any file and outputs the result as Base64 or Hex string.

## Installation

To install the tool you need to install .NET Core 2.1 SDK [v2.1.300](https://www.microsoft.com/net/download/dotnet-core/sdk-2.1.300) or newer. Once installed, run this command:

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
dotnet hash readme.md --algorithm sha1 --out hex
```

Valid `algorithm`:

* `md5`
* `sha1`
* `sha256`
* `sha384`
* `sha512`

Valid `out`:

* `base64`
* `hex`.
