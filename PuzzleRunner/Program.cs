﻿using System;
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
            var commandLine = "Puzzles.Euler.dll /include:Solution";
            Runner.Main(commandLine.Split(' '));
            Console.ReadLine();
        }
    }
}
