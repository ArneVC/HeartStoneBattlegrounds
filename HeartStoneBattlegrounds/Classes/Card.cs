﻿using HeartStoneBattlegrounds.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeartStoneBattlegrounds.classes
{
    public enum TierType { Tier1=1, Tier2, Tier3};
    public enum CategoryType { Beast, Demon, Dragon, Elemental, Mech, Murloc, Pirate, Quilboar };
    //bron: https://playhearthstone.com/en-us/cards/
    class Card
    {
        public string Title { get; set; }
        public string[] Abilities { get; set; } //Todo property Abilities zal klasse Ability nodig hebben
        private int attack; //instantievariabele

        public int Attack
        {
            get { return attack; }
            set
            {
                if (value >= 0)
                {
                    attack = value;
                }
                else
                {
                    throw new Exception("Attack can never be less than 0");
                }
            }
        }
        public int MaxHealth { get; set; }
        public TierType Tier { get; set; }
        public CategoryType TribeType { get; set; }
        public string ImagePath { get; set; }

        internal void Draw(int x, int y)
        {
            //cardart: https://asciiflow.com/#/
            string card = @"┌──┬─────┬──┐
│  │     │  │
├──┴─────┴──┤
│           │
├───────────┤
│           │
│           │
│           │
│           │
│           │
│           │
└───────────┘";/*kaartomlijning*/
            var lines = card.Split(Environment.NewLine);
            for (int i = 0; i < lines.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write(lines[i]);
            }
            //Attack
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(x + 1, y + 1);
            Console.Write(Attack);
            Console.ResetColor();
            //Health
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(x + 10, y + 1);
            Console.Write(MaxHealth);
            Console.ResetColor();
            //Tier
            Console.SetCursorPosition(x + 4, y + 1);
            for (int i = 0; i < (int) Tier; i++)
            {
                Console.Write("*");
            }
            //Title
            Console.SetCursorPosition(x + 1, y + 3);
            if (Title.Length > 12){ Console.Write(Title.Substring(0, 11)); }
            else { Console.Write(Title); }
        }
        public Minion Summon()
        {
            Minion toSpawn = new Minion();
            toSpawn.Abilities = Abilities;
            toSpawn.ActualHealth = MaxHealth;
            toSpawn.Attack = Attack;
            toSpawn.ImagePath = ImagePath;
            toSpawn.MaxHealth = MaxHealth;
            toSpawn.Tier = Tier;
            toSpawn.Title = "M_"+Title;
            toSpawn.TribeType = TribeType;
            return toSpawn;
        }
    }
}
