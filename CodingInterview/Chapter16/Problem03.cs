using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Puzzles.CodingInterview.Chapter16
{
    internal class Chopstick
    {
        private readonly object sync = new object();

        public bool PickUp(int timeout)
        {
            return Monitor.TryEnter(sync, timeout);
        }

        public void Release()
        {
            Monitor.Exit(sync);
        }
    }

    internal class Philosopher
    {
        private readonly Chopstick leftChopstick;
        private readonly Chopstick rightChopstick;
        private readonly Random rng = new Random();
        public bool HasEaten { get; private set; }

        public Philosopher(Chopstick leftChopstick, Chopstick rightChopstick)
        {
            this.leftChopstick = leftChopstick;
            this.rightChopstick = rightChopstick;
        }

        public void Eat()
        {
            HasEaten = false;

            while(true)
            {
                Console.WriteLine("Waiting for left chopstick");
                if(leftChopstick.PickUp(250))
                {
                    WaitRandom();
                    Console.WriteLine("Waiting for right chopstick");
                    if(rightChopstick.PickUp(250))
                    {
                        Console.WriteLine("Eating");
                        WaitRandom();
                        HasEaten = true;

                        leftChopstick.Release();
                        rightChopstick.Release();
                        return;
                    }

                    leftChopstick.Release();
                }
            }
        }

        public void WaitRandom()
        {
            Thread.Sleep(rng.Next(250, 2000));
        }
    }

    internal class Problem03
    {
        private readonly IList<Chopstick> chopsticks; 
        public readonly IList<Philosopher> Philosophers; 

        public Problem03(int numberOfPhilosophers)
        {
            chopsticks = Enumerable.Range(1, numberOfPhilosophers)
                .Select(x => new Chopstick())
                .ToList();

            Philosophers = Enumerable.Range(0, numberOfPhilosophers)
                .Select(x => new Philosopher(chopsticks[x], chopsticks[(x + 1) % numberOfPhilosophers]))
                .ToList();
        }

        public CancellationToken Dine()
        {
            var token = new CancellationToken(false);

            foreach(var philosopher in Philosophers)
            {
                Task.Factory.StartNew(philosopher.Eat, token);
            }

            return token;
        }
    }

    [TestFixture]
    public class Problem03Tests
    {
        [Test]
        [Ignore("Threading")]
        public void Test()
        {
            var problem = new Problem03(3);
            problem.Dine();
            Thread.Sleep(10 * 1000);

            foreach(var philosopher in problem.Philosophers)
            {
                Assert.IsTrue(philosopher.HasEaten);
            }
        }
    }
}
