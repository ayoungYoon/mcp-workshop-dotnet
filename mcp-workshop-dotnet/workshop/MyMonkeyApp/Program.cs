
using System;
using System.Threading.Tasks;
using MyMonkeyApp.Helpers;
using MyMonkeyApp.Models;
using System.Collections.Generic;

namespace MyMonkeyApp;

internal class Program
{
	private static readonly List<string> asciiArts = new()
	{
		@"  (\__/)

	private static void ShowRandomAsciiArt()
		@"   w  c( ..)o   (
	{
		var random = new Random();
		@"   _/\__
		var art = asciiArts[random.Next(asciiArts.Count)];
		Console.WriteLine(art);
	}

	};
	public static async Task Main(string[] args)
	{
		while (true)
		{
			ShowRandomAsciiArt();
			Console.WriteLine("\n===== Monkey Menu =====");
			Console.WriteLine("1. List all monkeys");
			Console.WriteLine("2. Get details for a specific monkey by name");
			Console.WriteLine("3. Get a random monkey");
			Console.WriteLine("4. Exit app");
			Console.Write("Select an option: ");
			var input = Console.ReadLine();
			Console.WriteLine();

			switch (input)
			{
				case "1":
					var monkeys = await MonkeyHelper.GetMonkeysAsync();
					Console.WriteLine("Name\tLocation\tPopulation");
					foreach (var m in monkeys)
					{
						Console.WriteLine($"{m.Name}\t{m.Location}\t{m.Population}");
					}
					break;
				case "2":
					Console.Write("Enter monkey name: ");
					var name = Console.ReadLine();
					var monkey = await MonkeyHelper.GetMonkeyByNameAsync(name ?? "");
					if (monkey != null)
					{
						Console.WriteLine($"Name: {monkey.Name}\nLocation: {monkey.Location}\nPopulation: {monkey.Population}\nDetails: {monkey.Details}\nImage: {monkey.Image}\nLatitude: {monkey.Latitude}\nLongitude: {monkey.Longitude}");
					}
					else
					{
						Console.WriteLine("Monkey not found.");
					}
					break;
				case "3":
					var randomMonkey = await MonkeyHelper.GetRandomMonkeyAsync();
					if (randomMonkey != null)
					{
						Console.WriteLine($"Random Monkey: {randomMonkey.Name}\nLocation: {randomMonkey.Location}\nPopulation: {randomMonkey.Population}\nDetails: {randomMonkey.Details}\nImage: {randomMonkey.Image}\nLatitude: {randomMonkey.Latitude}\nLongitude: {randomMonkey.Longitude}");
						Console.WriteLine($"Random monkey accessed {MonkeyHelper.GetRandomMonkeyAccessCount()} times.");
					}
					else
					{
						Console.WriteLine("No monkeys available.");
					}
					break;
				case "4":
					Console.WriteLine("Goodbye!");
					return;
			}
			Console.WriteLine();
		}
	}
