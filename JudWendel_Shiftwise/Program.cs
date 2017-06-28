using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JudWendel_Shiftwise
{
    class Program
    {
        #region -   Members         -
        private const int lineWidth = 75;
        private static Cards FullDeck;
        private static Dictionary<char, string> MenuItems = new Dictionary<char, string>();
        #endregion

        #region -   Properties      -
        private static bool keepRunning { get; set; }
        #endregion

        #region -   Entry           -
        static void Main(string[] args)
        {
            try
            {
                // Set the console color
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;

                // Set to Unicode so we can display card suit charaters
                Console.OutputEncoding = System.Text.Encoding.UTF8;

                // Set the console size
                var origWidth = Console.WindowWidth;
                var origHeight = Console.WindowHeight;
                Console.SetWindowSize((origWidth + 20), (origHeight * 2) + 10);

                // Set the title
                Console.Title = "Jud Wendel Assessment";
            }
            catch (Exception ex)
            {
                // Explain the issue
                Console.WriteLine("Some setting caused a problem:");
                WriteTextToMultipleLines(ex.Message);
            }

            // Initialize local variable members
            InitMembers();

            // If keepRunning continue to prompt with menu
            while (keepRunning)
            {
                // Write the menu prompt and capture selection
                var menuSelection = MenuPrompt();
                switch (menuSelection)
                {
                    case 'c':
                        WriteContactInfo();
                        break;

                    case 'q':
                        Console.Clear();
                        Console.WriteLine(" ");
                        Console.WriteLine("     Thank you for your time.");
                        keepRunning = false;
                        Thread.Sleep(1500);
                        break;

                    case 'r':
                        WriteCards(FullDeck.ShuffledCards());
                        break;

                    case 's':
                        WriteCards(FullDeck.SortedCards());
                        break;
                }
            }
        }
        #endregion

        #region -   Methods         -
        public static void InitMembers()
        {
            // Keep the menu prompt coming 
            keepRunning = true;

            // Add menu items
            MenuItems.Add('c', "to view contact information");
            MenuItems.Add('s', "to view sorted cards");
            MenuItems.Add('r', "to view shuffled cards");
            MenuItems.Add('q', "to close the application");

            // Instantiate the cards
            FullDeck = new Cards();
        }

        private static char MenuPrompt()
        {
            // Setup so only menu selections are valid
            ConsoleKeyInfo selection = new ConsoleKeyInfo();

            // Enclosure Start
            WriteBreakingLine();

            // Write prompts
            foreach (var menuItem in MenuItems)
            {
                Console.WriteLine($"press \"{ menuItem.Key }\" { menuItem.Value }");
            }

            // Enclosure End
            WriteBreakingLine();

            while (!MenuItems.ContainsKey(selection.KeyChar))
            {
                // Capture the key selection
                selection = Console.ReadKey(true);
            }

            // Return the character string
            return selection.KeyChar;
        }

        private static void WriteCardWithColor(string card)
        {
            // Change the card face color
            if (card.Contains("♥") || card.Contains("♦"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }

            // Write the card
            Console.Write(card);
            Console.ForegroundColor = ConsoleColor.Black;
        }

        private static void WriteBreakingLine()
        {
            Console.WriteLine(" ");
            Console.WriteLine("".PadLeft(lineWidth, '='));
            Console.WriteLine(" ");
        }

        private static void WriteCards(string[] cards)
        {
            if (cards.Length < 52)
            {
                Console.WriteLine("We seem to have lost some cards in the shuffle. Try it again.");
                return;
            }

            // Move through the suits and display 4 columns of cards
            for (int i = 0; i < 13; i++)
            {
                // Get the cards
                var A = cards[i];
                var B = cards[i + 13];
                var C = cards[i + 26];
                var D = cards[i + 39];

                // Top of cards
                Console.WriteLine("       _________         _________         _________         _________");
                Console.Write("       | ");
                
                // First Column
                WriteCardWithColor(A);
                Console.Write("   |         | ");
                
                // Second Column
                WriteCardWithColor(B);
                Console.Write("   |         | ");

                // Third Column
                WriteCardWithColor(C);
                Console.Write("   |         | ");

                // Second Column
                WriteCardWithColor(D);
                Console.WriteLine("   |");
                Console.WriteLine("       |       |         |       |         |       |         |       |");

                if (i == 12)
                {
                    // The last card is the top card
                    //Console.WriteLine( "       _________         _________         _________         _________");
                    //Console.WriteLine($"       | {A}   |         | {B}   |         | {C}   |         | {D}   |");
                    //Console.WriteLine( "       |       |         |       |         |       |         |       |");
                    Console.WriteLine( "       |       |         |       |         |       |         |       |");
                    Console.WriteLine( "       |       |         |       |         |       |         |       |");
                    Console.WriteLine( "       ---------         ---------         ---------         ---------");
                }
            }
        }

        private static void WriteContactInfo()
        {
            Console.WriteLine(" Jud R. Wendel");
            Console.WriteLine(" 8802 N. Burrage Ave.");
            Console.WriteLine(" Portland, OR 97217");
            Console.WriteLine(" ");
            Console.WriteLine(" e-mail: ozgreatandterrible@gmail.com");
            Console.WriteLine(" mobile: 503.329.5420");
        }
        
        private static void WriteTextToMultipleLines(string text)
        {
            var message = text.Split(new char[] { ' ' });
            var line = string.Empty;

            foreach (var word in message)
            {
                // Test the line width, plus the space and next word
                if (((line.Length + 1) + word.Length) > lineWidth)
                {
                    // If wider, write the line and move the word to the next row
                    Console.WriteLine(line);
                    line = word;
                }
                else
                {
                    // If not wider, add the word to the existing line
                    line += $" { word }";
                }
            }

            // Write the final line
            Console.WriteLine(line);
        }
        #endregion
    }
}
