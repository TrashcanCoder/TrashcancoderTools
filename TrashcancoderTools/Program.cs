// Copyright (c) 2024 Trashcancoder
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// Official source and repository: https://github.com/trashcancoder/TrashcancoderTools

namespace TrashcancoderTools;

using System;
using System.Text.RegularExpressions;

public partial class Program
{
    /// <summary>
    /// The main entry point for the Trashcancoder Tools application.
    /// </summary>
    /// <param name="args">An array of command-line arguments.</param>
    /// <returns>An integer representing the exit code of the application. Returns 0 if the command is executed successfully; otherwise, returns 1.</returns>
    public static Task<int> Main(string[] args)
    {
        Console.WriteLine("Trashcancoder Tools v0.1");
        Console.WriteLine("------------------------");
        Console.WriteLine("Copyright (c) 2024 Trashcancoder");
        Console.WriteLine("Licensed under the MIT License. See LICENSE file in the project root for full license information.");
        Console.WriteLine("Official source and repository: https://github.com/trashcancoder/TrashcancoderTools");
        Console.WriteLine();

            switch (args.Length)
        {
            // Check if at least one argument is given.
            case < 1:
                DisplayInvalidArgumentMessage();
                // Indicate an Error.
                return 1;
            // Check if the number of arguments is greater than 3.
            case > 3:
                Console.WriteLine("Error: Too many arguments provided. Maximum allowed is 3.");
                DisplayInvalidArgumentMessage();
                // Indicate an Error.
                return 1;
        }

        //  Check if any argument contains invalid characters.
        var argumentPosition = 1;
        foreach (var arg in args)
        {
            if (InvalidChars().IsMatch(arg))
            {
                argumentPosition++;
                continue;
            }

            Console.WriteLine($"Error: Argument at index {argumentPosition} contains invalid characters.");
            Console.WriteLine("Allowed characters are: a-z, A-Z, 0-9, /, -.");
            DisplayInvalidArgumentMessage();
            // Indicate an Error.
            return 1;
        }

        // Check if any argument has more than 10 characters.
        argumentPosition = 1;
        foreach (var arg in args)
        {
            if (arg.Length <= 10)
            {
                argumentPosition++;
                continue;
            }

            Console.WriteLine(
                $"Error: Argument at index {argumentPosition} exceeds the maximum length of 10 characters.");
            DisplayInvalidArgumentMessage();
            // Indicate an Error.
            return 1;
        }

        // Handle arguments.
        switch (args[0])
        {
            case "/help":
            case "/?":
            case "--help":
            case "-h":
                ShowHelp();
                // Successful execution when displaying help.
                return 0;
            default:
                DisplayInvalidArgumentMessage();
                // Indicate an Error.
                    return 1;
        }

        void DisplayInvalidArgumentMessage()
        {
            Console.WriteLine("No valid argument provided. Use /help or --help for more information.");
        }
    }

    /// <summary>
    /// Displays the help message for the Trashcancoder Tools application.
    /// </summary>
    private static void ShowHelp()
    {
        Console.WriteLine("\nAvailable Commands:");
        Console.WriteLine("  Help Commands:");
        Console.WriteLine("    /help  : Displays this help message.");
        Console.WriteLine("    /?     : Displays this help message.");
        Console.WriteLine("    --help : Displays this help message.");
        Console.WriteLine("    -h     : Displays this help message.");
        Console.WriteLine("\nUsage:");
        Console.WriteLine("  Trashcancoder Tools v0.1 [command]");
        Console.WriteLine("\nExample:");
        Console.WriteLine("  TrashcancoderTools --help\n");
    }

    [GeneratedRegex("^[a-zA-Z0-9/-]+$")]
    private static partial Regex InvalidChars();
}