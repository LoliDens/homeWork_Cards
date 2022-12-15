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

        
        public Card(string benefit, string suit)
        {        
            Value = $"{suit} {benefit}";
        }
    }

    class Deck
    {
        private List<Card> _cards = new List<Card>();

        public Deck()
        {
            string[] benefits = new string[] { "6", "7", "8", "9", "10", "В", "Д", "К", "Т" };
            string[] suits = new string[] { "Чреви", "Буби", "Руби", "Крести" };

            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < benefits.Length; j++)
                {
                    Card card = new Card(suits[i], benefits[j]);
                    _cards.Add(card);
                }
            }

            Shuffle();
        }

        public Card GiveCard() 
        {
            Card card = null;

            if (_cards.Count != 0) 
            {
                card = _cards[0];
                _cards.Remove(card);
            }

            return card;
        }

        private void Shuffle() 
        {
            Random random = new Random();

            for (int i = 0; i < _cards.Count; i++) 
            {
                int randomIndex = random.Next(_cards.Count);
                Card temporaryCard = _cards[randomIndex];
                _cards[randomIndex] = _cards[i];
                _cards[i] = temporaryCard;
            }
        }
    }

    class Player 
    {
        private List<Card> _cards = new List<Card>();
        private Deck _deck = new Deck();

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
                        DrawCard();                       
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

        private void DrawCard() 
        {
            Card card = _deck.GiveCard();

            if (card == null)
            {
                Console.WriteLine("Карт больше нет");
            }
            else 
            {
                _cards.Add(card);
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
