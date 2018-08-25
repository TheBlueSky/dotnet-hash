using System;
using System.Threading.Tasks;

using McMaster.Extensions.CommandLineUtils;

using static TheBlueSky.DotNet.Tools.SwiftHash.ReturnCode;

namespace TheBlueSky.DotNet.Tools.SwiftHash
{
	internal static class Program
	{
		private static async Task<int> Main(string[] args)
		{
			try
			{
				return await CommandLineApplication.ExecuteAsync<DotNetHash>(args);

			}
			catch (Exception ex)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.Error.WriteLine($"Unexpected error: {ex.Message}");
				Console.ResetColor();

				return EXCEPTION;
			}
		}
	}
}
