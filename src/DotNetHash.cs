using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;

using McMaster.Extensions.CommandLineUtils;

using static TheBlueSky.DotNet.Tools.SwiftHash.ReturnCode;

namespace TheBlueSky.DotNet.Tools.SwiftHash
{
	[Command(
		Name = "dotnet hash",
		FullName = "TheBlueSky.DotNet.Tools.SwiftHash",
		Description = "Calculates the hash for the given file using the specified algorithm",
		ExtendedHelpText = @"
The tool calculates MD5, SHA-1, SHA-256, SHA-384, and SHA-512 hashes
for any file and outputs the result as Base64 or Hex string.
The bigger the file is, the longer it takes to calculate the hash.
")]
	[HelpOption]
	internal sealed class DotNetHash
	{
		[Required(ErrorMessage = "You must specify the path to a file to calculate the hash for")]
		[Argument(0, Name = "path", Description = "Path to the file to calculate the hash for")]
		[FileExists]
		public string Path { get; }

		[Option(CommandOptionType.SingleValue, Description = "The hashing algorithm", LongName = "algorithm", ShortName = "a")]
		public Algorithm Algorithm { get; }

		[Option(CommandOptionType.SingleValue, Description = "The output format", LongName = "out", ShortName = "o")]
		public OutputFormat Output { get; }

		public async Task<int> OnExecuteAsync(CommandLineApplication app, IConsole console)
		{
			var algorithm = GetHashAlgorithm(this.Algorithm);

			if (algorithm == null)
			{
				console.Error.WriteLine($"Hashing algorithm {this.Algorithm} is not supported");
				app.ShowHelp();

				return ERROR;
			}

			byte[] hashBytes;

			using (var fs = File.OpenRead(this.Path))
			{
				hashBytes = algorithm.ComputeHash(fs);
			}

			algorithm.Dispose();

			var hashString = GetHashString(hashBytes, this.Output);

			if (hashString == null)
			{
				console.Error.WriteLine($"Output format {this.Output} is not supported");
				app.ShowHelp();

				return ERROR;
			}

			console.WriteLine(hashString);

			return await Task.FromResult(0);
		}

		private static HashAlgorithm GetHashAlgorithm(Algorithm algorithm)
		{
			HashAlgorithm hashAlgorithm = null;

			switch (algorithm)
			{
				case Algorithm.MD5:
					hashAlgorithm = MD5.Create();
					break;

				case Algorithm.SHA1:
					hashAlgorithm = SHA1.Create();
					break;

				case Algorithm.SHA256:
					hashAlgorithm = SHA256.Create();
					break;

				case Algorithm.SHA384:
					hashAlgorithm = SHA384.Create();
					break;

				case Algorithm.SHA512:
					hashAlgorithm = SHA512.Create();
					break;

				default:
					break;
			}

			return hashAlgorithm;
		}

		private static string GetHashString(byte[] hashBytes, OutputFormat output)
		{
			string hashString = null;

			switch (output)
			{
				case OutputFormat.Base64:
					hashString = hashBytes.ToBase64String();
					break;

				case OutputFormat.Hex:
					hashString = hashBytes.ToHexString();
					break;

				default:
					break;
			}

			return hashString;
		}
	}
}
