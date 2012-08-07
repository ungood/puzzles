using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.ConsoleRunner;
using NUnit.Core;

namespace PuzzleRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var commandLine = "Puzzles.Euler.dll /run:Puzzles.Euler.Problem10.Problem010Tests"; // "Puzzles.Euler.dll /exclude:Slow";
            Runner.Main(commandLine.Split(' '));
            Console.ReadLine();
        }
    }
}
