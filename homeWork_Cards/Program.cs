using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace homeWork_Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            player.Play();
        }
    }

    class Card
    {
        public string Value { get; private set; }

        private string[] _benefits = new string[] { "6", "7", "8", "9", "10", "В", "Д", "К", "Т" };
        private string[] _suit = new string[] {"Чреви","Буби","Руби","Крести" };

        public Card(int indexSuit, int indexBenefit)
        {        
            Value = _benefits[indexBenefit] + " " + _suit[indexSuit];
        }
    }

    class Deck
    {
        private List<Card> _cards = new List<Card>();

        private int _amountBenefits = 9;
        private int _amountSuit = 4;

        public Deck()
        {
            for (int i = 0; i < _amountSuit; i++)
            {
                for (int j = 0; j < _amountBenefits; j++)
                {
                    Card card = new Card(i,j);
                    _cards.Add(card);
                }
            }

            Shuffle(_cards);
        }

        public Card GetCard() 
        {
            Card gerValue = null;

            if (_cards.Count != 0) 
            {
                gerValue = _cards[0];
                _cards.RemoveAt(0);
            }

            return gerValue;
        }

        private void Shuffle(List<Card> cards) 
        {
            Random random = new Random();
            Card temporaryCard = null;

            for (int i = 0; i < cards.Count; i++) 
            {
                int randomIndex = random.Next(cards.Count);
                temporaryCard = cards[randomIndex];
                cards[randomIndex] = cards[i];
                cards[i] = temporaryCard;
            }
        }
    }

    class Player 
    {
        private List<Card> _cards = new List<Card>();
        private Deck deck = new Deck();

        public void Play() 
        {
            const string CommandGetCard = "1";
            const string CommandShowCard = "2";
            const string CommandExit = "0";

            bool isExit = false;

            while (isExit == false) 
            {
                Console.WriteLine($"{CommandGetCard} - Взять карту " +
                    $"\n{CommandShowCard} - показать краты в руке" +
                    $"\n{CommandExit} - выйти");
                string userInput = Console.ReadLine();

                switch (userInput) 
                {
                    case CommandGetCard:
                        DrowCard();                       
                        break;

                    case CommandShowCard:
                        ShowCards();
                        break;

                    case CommandExit:
                        isExit = true;
                        break;

                    default:
                        Console.WriteLine("Комманда не распознана");
                        break;                       
                }
                
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void DrowCard() 
        {
            Card valueCard =  deck.GetCard();

            if (valueCard == null)
            {
                Console.WriteLine("Карт больше нет");
            }
            else 
            {
                _cards.Add(valueCard);
                Console.WriteLine("Вы получили карту");
            }
        }

        private void ShowCards()
        {
            if (_cards.Count == 0)
            {
                Console.WriteLine("У вас нет карт");
            }
            else 
            {
                Console.Write("\nВыши карты: ");    

                foreach (var card in _cards) 
                {
                    Console.Write(card.Value + "|");
                }
            }

            Console.WriteLine();
        }
    }
}
