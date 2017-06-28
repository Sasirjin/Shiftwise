using NUnit.Framework;

namespace JudWendel_Shiftwise.Tests
{
    [TestFixture]
    public class CardsTests
    {
        private string[] FullDeck {
            get
            {
                string[] cardArray = new string[52];

                // Spades
                cardArray[0] = "K ♠";
                cardArray[1] = "Q ♠";
                cardArray[2] = "J ♠";
                cardArray[3] = "10♠";
                cardArray[4] = "9 ♠";
                cardArray[5] = "8 ♠";
                cardArray[6] = "7 ♠";
                cardArray[7] = "6 ♠";
                cardArray[8] = "5 ♠";
                cardArray[9] = "4 ♠";
                cardArray[10] = "3 ♠";
                cardArray[11] = "2 ♠";
                cardArray[12] = "A ♠";
                // Hearts
                cardArray[13] = "K ♥";
                cardArray[14] = "Q ♥";
                cardArray[15] = "J ♥";
                cardArray[16] = "10♥";
                cardArray[17] = "9 ♥";
                cardArray[18] = "8 ♥";
                cardArray[19] = "7 ♥";
                cardArray[20] = "6 ♥";
                cardArray[21] = "5 ♥";
                cardArray[22] = "4 ♥";
                cardArray[23] = "3 ♥";
                cardArray[24] = "2 ♥";
                cardArray[25] = "A ♥";
                // Clubs
                cardArray[26] = "K ♣";
                cardArray[27] = "Q ♣";
                cardArray[28] = "J ♣";
                cardArray[29] = "10♣";
                cardArray[30] = "9 ♣";
                cardArray[31] = "8 ♣";
                cardArray[32] = "7 ♣";
                cardArray[33] = "6 ♣";
                cardArray[34] = "5 ♣";
                cardArray[35] = "4 ♣";
                cardArray[36] = "3 ♣";
                cardArray[37] = "2 ♣";
                cardArray[38] = "A ♣";
                // Diamonds
                cardArray[39] = "K ♦";
                cardArray[40] = "Q ♦";
                cardArray[41] = "J ♦";
                cardArray[42] = "10♦";
                cardArray[43] = "9 ♦";
                cardArray[44] = "8 ♦";
                cardArray[45] = "7 ♦";
                cardArray[46] = "6 ♦";
                cardArray[47] = "5 ♦";
                cardArray[48] = "4 ♦";
                cardArray[49] = "3 ♦";
                cardArray[50] = "2 ♦";
                cardArray[51] = "A ♦";

                return cardArray;
            }
        }

        public CardsTests()
        {

        }

        [Test]
        public void ShuffledCardsTest()
        {
            // System Under Test
            var sut = new Cards();

            // Assert the collections differ
            CollectionAssert.AreNotEqual(sut.ShuffledCards(), FullDeck);
        }

        [Test]
        public void SortedCardsTest()
        {
            // System Under Test
            var sut = new Cards();

            // Assert the collections match
            CollectionAssert.AreEqual(sut.SortedCards(), FullDeck);
        }
    }
}
