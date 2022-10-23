using System;
using System.Collections;
using System.Collections.Generic;

namespace PracticeTime3
{
    public enum TypeCards
    {
        Hearts,
        Spades,
        Diamonds,
        Clubs
    }
    public sealed class Card
    {
        public static int AmountOfOneTypeCards = 13;
        public int NumberPowerOfCard { get; private set; }
        public TypeCards? TypeOfCard { get; private set; }
        public Card(int numberCard, TypeCards? TypeOfCard)
        {
            NumberPowerOfCard = numberCard;
            this.TypeOfCard = TypeOfCard;
        }
    }
    public sealed class CardCollection : IEnumerable<Card>
    {
        Stack<Card> CardsCollectionAll;
        const int typeNumbers = 4;
        const int minCardNum = 6;
        const int macCardNum = 13;
        void CreateCardCollection()
        {        
            TypeCards typeCard;
            for(int typeCardID = 0; typeCardID< typeNumbers; typeCardID++)
            {
                for(int numCard = minCardNum; numCard < macCardNum +1; numCard++)
                {
                    switch (typeCardID)
                    {
                        case 0:
                            typeCard = TypeCards.Clubs;
                            break;
                        case 1:
                            typeCard = TypeCards.Diamonds;
                            break;
                        case 2:
                            typeCard = TypeCards.Hearts;
                            break;
                        case 3:
                            typeCard = TypeCards.Spades;
                            break;
                    }                 
                    CardsCollectionAll.Push(new Card(numCard, TypeCards.Clubs));
                }
            }
        }
        public CardCollection()
        {
            CreateCardCollection();
        }
        public IEnumerator<Card> GetEnumerator()
        {
            return CardsCollectionAll.GetEnumerator(); // edit sooner
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public Stack<Card> GetCollectionCards() => CardsCollectionAll;
    } 

    public class Player : IPlayer <Card, CardCollection>
    {
        public static int AmountOfCardsHolding = 7;
        public List<Card> PlayerCards { get ; set ; }
        public CardCollection CollectionCard{ get; set; }
        CardCollection IPlayer<Card, CardCollection>.CollectionCardOverall { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event Action TakingCard;
        public event Action DroppingCard;

        Stack<Card> CollectionCardOverall;
        void Start()
        {
            CollectionCardOverall = CollectionCard.GetCollectionCards();
            for (int i = 0; i < AmountOfCardsHolding; i++)
            {
                PlayerCards.Add(CollectionCardOverall.Pop());
            }
        }
        public Player(CardCollection cardsOverall)
        {
            CollectionCard = cardsOverall;
            InitializeEvents();
            Start();
        }
        void InitializeEvents()
        {
            
        }
        public Card ChooseCard(int id_card)
        {
            return PlayerCards[id_card];
        }

        public Stack<Card> GetCollectionOfCards()
        {
            throw new NotImplementedException();
        }
    }
}
