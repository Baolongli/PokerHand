using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace PokerHand
{
    [TestFixture()]
    public class HandTest
    {
  //-----------------Constructer test-------------------------      
        [Test()]
        public void TestHand_Success()
        {
            List<Card> cardList = new List<Card> {
                    new Card(CardSuit.Hearts, CardRank.Ace),
                    new Card(CardSuit.Hearts, CardRank.Jack),
                    new Card(CardSuit.Hearts, CardRank.Eight),
                    new Card(CardSuit.Hearts, CardRank.Three),
                    new Card(CardSuit.Diamonds, CardRank.Three)
            };
            Hand hand = new Hand(cardList);
        }

        [Test()]
        public void TestHand_TooLessCardHand_ThrowException()
        {
            try
            {
                List<Card> cardList = new List<Card> {
                    new Card(CardSuit.Hearts, CardRank.Ace),
                    new Card(CardSuit.Hearts, CardRank.Jack),
                    new Card(CardSuit.Hearts, CardRank.Eight),
                    new Card(CardSuit.Hearts, CardRank.Three)
                };
                Hand hand = new Hand(cardList);
                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is Exception);
            }
        }
        [Test()]
        public void TestHand_FiveSameRank_ThrowException()
        {
            try
            {
                List<Card> cardList = new List<Card> {
                    new Card(CardSuit.Hearts, CardRank.Ace),
                    new Card(CardSuit.Spades, CardRank.Ace),
                    new Card(CardSuit.Diamonds, CardRank.Ace),
                    new Card(CardSuit.Spades, CardRank.Ace),
                    new Card(CardSuit.Hearts, CardRank.Ace)
                };
                Hand hand = new Hand(cardList);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is Exception);
                return;
            }
            Assert.Fail();
        }
        [Test()]
        public void TestHand_DuplicatedCard_ThrowException()
        {
            try
            {
                List<Card> cardList = new List<Card> {
                    new Card(CardSuit.Hearts, CardRank.Ace),
                    new Card(CardSuit.Hearts, CardRank.Ace),
                    new Card(CardSuit.Hearts, CardRank.Eight),
                    new Card(CardSuit.Hearts, CardRank.Three),
                    new Card(CardSuit.Hearts, CardRank.Nine)
                };
                Hand hand = new Hand(cardList);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is Exception);
                return;
            }
            Assert.Fail();
        }

        [Test()]
        public void TestHand_TooManyCardHand_ThrowException()
        {
            try
            {
                List<Card> cardList = new List<Card> {
                    new Card(CardSuit.Hearts, CardRank.Ace),
                    new Card(CardSuit.Hearts, CardRank.Jack),
                    new Card(CardSuit.Hearts, CardRank.Eight),
                    new Card(CardSuit.Diamonds, CardRank.Three),
                    new Card(CardSuit.Spades, CardRank.Three),
                    new Card(CardSuit.Hearts, CardRank.Three)
                };
                Hand hand = new Hand(cardList);
                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is Exception);
            }
        }
        //-----------------Constructer test-------------------------      
        //-----------------Sort test-------------------------      
        [Test()]
        public void TestSort() {
            List<Card> cardList = new List<Card> {
                    new Card(CardSuit.Hearts, CardRank.Ace),
                    new Card(CardSuit.Hearts, CardRank.Jack),
                    new Card(CardSuit.Hearts, CardRank.Three),
                    new Card(CardSuit.Hearts, CardRank.Eight),
                    new Card(CardSuit.Diamonds, CardRank.Three)
                };
            Hand hand = new Hand(cardList);

            List<Card> sortedCardList = new List<Card> {
                    new Card(CardSuit.Hearts, CardRank.Three),
                    new Card(CardSuit.Diamonds, CardRank.Three),
                    new Card(CardSuit.Hearts, CardRank.Ace),
                    new Card(CardSuit.Hearts, CardRank.Jack),
                    new Card(CardSuit.Hearts, CardRank.Eight)
                };

            cardList = hand.Cards;
            for (int i = 0; i < sortedCardList.Count; i++){
                Card card1 = sortedCardList[i];
                Card card2 = cardList[i];
                Assert.AreEqual(card1.Rank, card2.Rank);
                Assert.AreEqual(card1.Suit, card2.Suit);
            }
        }
        //-----------------Sort test-------------------------      
        //-----------------IsFlush test-------------------------      
        [Test()]
        public void TestIsFlushTest_true()
        {
            List<Card> list = new List<Card> {
                new Card(CardSuit.Clubs, CardRank.Ace),
                new Card(CardSuit.Clubs, CardRank.Jack),
                new Card(CardSuit.Clubs, CardRank.King),
                new Card(CardSuit.Clubs, CardRank.Eight),
                new Card(CardSuit.Clubs, CardRank.Nine)
            };
            Hand hand = new Hand(list);
            Assert.IsTrue(hand.IsFlush());
        }
        [Test()]
        public void TestIsFlushTest_false()
        {
            List<Card> list = new List<Card> {
                new Card(CardSuit.Clubs, CardRank.Ace),
                new Card(CardSuit.Clubs, CardRank.Jack),
                new Card(CardSuit.Diamonds, CardRank.Queen),
                new Card(CardSuit.Clubs, CardRank.Eight),
                new Card(CardSuit.Clubs, CardRank.Nine)
            };
            Hand hand = new Hand(list);
            Assert.IsFalse(hand.IsFlush());
        }
        //-----------------IsFlush test-------------------------      
        //-----------------IsThreeOfAKind test-------------------------      
        [Test()]
        public void TestIsThreeOfAKind_true()
        {
            List<Card> list = new List<Card> {
                new Card(CardSuit.Hearts, CardRank.Ace),
                new Card(CardSuit.Clubs, CardRank.Ace),
                new Card(CardSuit.Diamonds, CardRank.Ace),
                new Card(CardSuit.Clubs, CardRank.Eight),
                new Card(CardSuit.Clubs, CardRank.Ten)
            };
            Hand hand = new Hand(list);
            Assert.IsTrue(hand.IsThreeOfAKind());
        }
        //-----------------IsOnePair test-------------------------      
        [Test()]
        public void TestIsOnePair_true()
        {
            List<Card> list = new List<Card> {
                new Card(CardSuit.Clubs, CardRank.Ace),
                new Card(CardSuit.Diamonds, CardRank.Ace),
                new Card(CardSuit.Clubs, CardRank.King),
                new Card(CardSuit.Clubs, CardRank.Two),
                new Card(CardSuit.Clubs, CardRank.Ten)
            };
            Hand hand = new Hand(list);
            Assert.IsTrue(hand.IsOnePair());
        }

        [Test()]
        public void TestIsOnePair_false_allDifferent()
        {
            List<Card> list = new List<Card> {
                new Card(CardSuit.Clubs, CardRank.Ace),
                new Card(CardSuit.Diamonds, CardRank.Five),
                new Card(CardSuit.Clubs, CardRank.King),
                new Card(CardSuit.Clubs, CardRank.Two),
                new Card(CardSuit.Clubs, CardRank.Ten)
            };
            Hand hand = new Hand(list);
            Assert.IsFalse(hand.IsOnePair());
        }
        [Test()]
        public void TestIsOnePair_false_isThreeOfAKind()
        {
            List<Card> list = new List<Card> {
                new Card(CardSuit.Clubs, CardRank.Ace),
                new Card(CardSuit.Diamonds, CardRank.Ace),
                new Card(CardSuit.Hearts, CardRank.Ace),
                new Card(CardSuit.Clubs, CardRank.Two),
                new Card(CardSuit.Clubs, CardRank.Ten)
            };
            Hand hand = new Hand(list);
            Assert.IsFalse(hand.IsOnePair());
        }
        //-----------------IsOnePair test-------------------------      


        //-----------------GetHandType test-------------------------      
        [Test()]
        public void TestGetHandType_IsFlush() {
            Hand hand = TestHelper.GoodFlushHand();
            Assert.AreEqual(hand.GetHandType(),HandType.Flush);
        }
        [Test()]
        public void TestGetHandType_IsThreeOfAKind()
        {
            Hand hand = TestHelper.GoodThreeOfAKindHand();
            Assert.AreEqual(hand.GetHandType(), HandType.ThreeOfKind);
        }
        [Test()]
        public void TestGetHandType_IsOnePair()
        {
            List<Card> list = new List<Card> {
                new Card(CardSuit.Clubs, CardRank.Ace),
                new Card(CardSuit.Diamonds, CardRank.Ace),
                new Card(CardSuit.Clubs, CardRank.King),
                new Card(CardSuit.Clubs, CardRank.Two),
                new Card(CardSuit.Clubs, CardRank.Ten)
            };
            Hand hand = new Hand(list);
            Assert.AreEqual(hand.GetHandType(), HandType.OnePair);
        }
        [Test()]
        public void TestGetHandType_IsHighCard()
        {
            List<Card> list = new List<Card> {
                new Card(CardSuit.Clubs, CardRank.Nine),
                new Card(CardSuit.Diamonds, CardRank.Ace),
                new Card(CardSuit.Clubs, CardRank.King),
                new Card(CardSuit.Clubs, CardRank.Two),
                new Card(CardSuit.Clubs, CardRank.Ten)
            };
            Hand hand = new Hand(list);
            Assert.AreEqual(hand.GetHandType(), HandType.HighCard);
        }
        //-----------------GetHandType test-------------------------      

        //-----------------CompareTo test-------------------------      
        //Flush
        [Test()]
        public void TestCompareTo_FlushToBiggerFlush()
        {
            Hand flushHand = TestHelper.GoodFlushHand();
            List<Card> list = new List<Card> {
                new Card(CardSuit.Clubs, CardRank.Queen),
                new Card(CardSuit.Clubs, CardRank.Ace),
                new Card(CardSuit.Clubs, CardRank.King),
                new Card(CardSuit.Clubs, CardRank.Two),
                new Card(CardSuit.Clubs, CardRank.Ten)
            };
            Hand biggerFlushHand = new Hand(list);

            int result = flushHand.CompareTo(biggerFlushHand);
            Assert.AreEqual(result, -1);
        }
        [Test()]
        public void TestCompareTo_Same_Flush()
        {
            Hand flushHand = TestHelper.GoodFlushHand();
            Hand flushHand2 = TestHelper.GoodFlushHand();
            int result = flushHand.CompareTo(flushHand2);
            Assert.AreEqual(result, 0);
        }
        [Test()]
        public void TestCompareTo_FlushToThreeOfAKind()
        {
            Hand flushHand = TestHelper.GoodFlushHand();
            Hand threeOfAKindHand = TestHelper.GoodThreeOfAKindHand();
            int result = flushHand.CompareTo(threeOfAKindHand);
            Assert.AreEqual(result,1);
        }
        [Test()]
        public void TestCompareTo_FlushToOnePair()
        {
            Hand flushHand = TestHelper.GoodFlushHand();
            Hand onePairHand = TestHelper.GoodOnPairHand();
            int result = flushHand.CompareTo(onePairHand);
            Assert.AreEqual(result, 1);
        }
        [Test()]
        public void TestCompareTo_FlushToHighCard()
        {
            Hand flushHand = TestHelper.GoodFlushHand();
            Hand highCardHand = TestHelper.GoodHighCardHand();
            int result = flushHand.CompareTo(highCardHand);
            Assert.AreEqual(result, 1);
        }
        //one pair to other
        [Test()]
        public void TestCompareTo_OnePairToThreeOfAKind()
        {
            Hand onePairHand = TestHelper.GoodOnPairHand();
            Hand threeOfAKingHand = TestHelper.GoodThreeOfAKindHand();
            int result = onePairHand.CompareTo(threeOfAKingHand);
            Assert.AreEqual(result, -1);
        }
        public void TestCompareTo_OnePairToSmallerOnePair()
        {
            Hand onePairHand = TestHelper.GoodOnPairHand();
            List<Card> list = new List<Card> {
                new Card(CardSuit.Hearts, CardRank.Queen),
                new Card(CardSuit.Clubs, CardRank.Queen),
                new Card(CardSuit.Diamonds, CardRank.Nine),
                new Card(CardSuit.Clubs, CardRank.Eight),
                new Card(CardSuit.Clubs, CardRank.Ten)
            };
            Hand smallerOnePairHand = new Hand(list);
            int result = onePairHand.CompareTo(smallerOnePairHand);
            Assert.AreEqual(result, 1);
        }
        public void TestCompareTo_Same_OnePair()
        {
            Hand onePairHand = TestHelper.GoodOnPairHand();
            Hand onePairHand2 = TestHelper.GoodOnPairHand();
            int result = onePairHand.CompareTo(onePairHand2);
            Assert.AreEqual(result, 0);
        }
        [Test()]
        public void TestCompareTo_OnePairToHighCard()
        {
            Hand onePairHand = TestHelper.GoodOnPairHand();
            Hand highCardHand = TestHelper.GoodHighCardHand();
            int result = onePairHand.CompareTo(highCardHand);
            Assert.AreEqual(result, 1);
        }
        //three of a kind
        [Test()]
        public void TestCompareTo_ThreeOfAKindToSmallerThreeOfAKind()
        {
            Hand threeOfAKind = TestHelper.GoodThreeOfAKindHand();
            List<Card> list = new List<Card> {
                new Card(CardSuit.Hearts, CardRank.Eight),
                new Card(CardSuit.Clubs, CardRank.Ace),
                new Card(CardSuit.Diamonds, CardRank.Eight),
                new Card(CardSuit.Clubs, CardRank.Eight),
                new Card(CardSuit.Clubs, CardRank.Ten)
            };
            Hand smallerHand = new Hand(list);
            int result = threeOfAKind.CompareTo(smallerHand);
            Assert.AreEqual(result, 1);
        }
        [Test()]
        public void TestCompareTo_Same_ThreeOfAKind()
        {
            Hand threeOfAKind = TestHelper.GoodThreeOfAKindHand();
            Hand threeOfAKind2 = TestHelper.GoodThreeOfAKindHand();
            int result = threeOfAKind.CompareTo(threeOfAKind2);
            Assert.AreEqual(result, 0);
        }
        [Test()]
        public void TestCompareTo_ThreeOfAKindToHighCard()
        {
            Hand threeOfAKind = TestHelper.GoodThreeOfAKindHand();
            Hand highCardHand = TestHelper.GoodHighCardHand();
            int result = threeOfAKind.CompareTo(highCardHand);
            Assert.AreEqual(result, 1);
        }
        //high card hand
        [Test()]
        public void TestCompareTo_HighCardToGreaterHighCard()
        {
            Hand highCardHand = TestHelper.GoodHighCardHand();
            List<Card> list = new List<Card> {
                new Card(CardSuit.Hearts, CardRank.Ace),
                new Card(CardSuit.Clubs, CardRank.King),
                new Card(CardSuit.Diamonds, CardRank.Nine),
                new Card(CardSuit.Clubs, CardRank.Eight),
                new Card(CardSuit.Clubs, CardRank.Ten)
            };
            Hand greaterHand = new Hand(list);
            int result = highCardHand.CompareTo(greaterHand);
            Assert.AreEqual(result, -1);
        }
        [Test()]
        public void TestCompareTo_Same_HighCard()
        {
            Hand highCardHand = TestHelper.GoodHighCardHand();
            Hand highCardHand2 = TestHelper.GoodHighCardHand();
            int result = highCardHand.CompareTo(highCardHand2);
            Assert.AreEqual(result, 0);
        }
    }
}
