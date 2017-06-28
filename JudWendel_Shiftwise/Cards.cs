using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudWendel_Shiftwise
{
    public class Cards
    {
        #region -   Members     -
        private Random shuffleRandom = new Random();

        private string[] SortedArray = new string[52];
        #endregion

        #region -   Constructor -
        public Cards()
        {
            InitMembers();
        }
        #endregion

        #region -   Methods     -
        private void InitMembers()
        {
            // Add the sorted cards
            // Spades
            SortedArray[0] = "K ♠";
            SortedArray[1] = "Q ♠";
            SortedArray[2] = "J ♠";
            SortedArray[3] = "10♠";
            SortedArray[4] = "9 ♠";
            SortedArray[5] = "8 ♠";
            SortedArray[6] = "7 ♠";
            SortedArray[7] = "6 ♠";
            SortedArray[8] = "5 ♠";
            SortedArray[9] = "4 ♠";
            SortedArray[10] = "3 ♠";
            SortedArray[11] = "2 ♠";
            SortedArray[12] = "A ♠";
            // Hearts
            SortedArray[13] = "K ♥";
            SortedArray[14] = "Q ♥";
            SortedArray[15] = "J ♥";
            SortedArray[16] = "10♥";
            SortedArray[17] = "9 ♥";
            SortedArray[18] = "8 ♥";
            SortedArray[19] = "7 ♥";
            SortedArray[20] = "6 ♥";
            SortedArray[21] = "5 ♥";
            SortedArray[22] = "4 ♥";
            SortedArray[23] = "3 ♥";
            SortedArray[24] = "2 ♥";
            SortedArray[25] = "A ♥";
            // Clubs
            SortedArray[26] = "K ♣";
            SortedArray[27] = "Q ♣";
            SortedArray[28] = "J ♣";
            SortedArray[29] = "10♣";
            SortedArray[30] = "9 ♣";
            SortedArray[31] = "8 ♣";
            SortedArray[32] = "7 ♣";
            SortedArray[33] = "6 ♣";
            SortedArray[34] = "5 ♣";
            SortedArray[35] = "4 ♣";
            SortedArray[36] = "3 ♣";
            SortedArray[37] = "2 ♣";
            SortedArray[38] = "A ♣";
            // Diamonds
            SortedArray[39] = "K ♦";
            SortedArray[40] = "Q ♦";
            SortedArray[41] = "J ♦";
            SortedArray[42] = "10♦";
            SortedArray[43] = "9 ♦";
            SortedArray[44] = "8 ♦";
            SortedArray[45] = "7 ♦";
            SortedArray[46] = "6 ♦";
            SortedArray[47] = "5 ♦";
            SortedArray[48] = "4 ♦";
            SortedArray[49] = "3 ♦";
            SortedArray[50] = "2 ♦";
            SortedArray[51] = "A ♦";
        }

        public string[] ShuffledCards()
        {
            // Copy input array and shuffle the copy
            var shuffledArray = new string[52];
            Array.Copy(SortedArray, shuffledArray, 52);
            var n = shuffledArray.Length;
            for (int i = 0; i < n; i++)
            {
                // Fisher-Yates style 
                var r = i + (int)(shuffleRandom.NextDouble() * (n - i));
                var t = shuffledArray[r];
                shuffledArray[r] = shuffledArray[i];
                shuffledArray[i] = t;
            }

            return shuffledArray;
        }

        public string[] SortedCards()
        {
            return SortedArray;
        }
        #endregion
    }
}
