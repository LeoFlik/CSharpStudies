using System.Numerics;
namespace DiceRoll.Entities;

    public class Dice
    {
        private const int MinValue = 1;
        private const int MaxValue = 6;
        private readonly Random _random = new Random();

        public int Roll()=> _random.Next(MinValue, MaxValue + 1);

        override public string ToString() =>$"Dice rolled: {Roll()}";
     
    }
