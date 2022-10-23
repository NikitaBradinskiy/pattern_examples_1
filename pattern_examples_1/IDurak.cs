using System;
using System.Collections.Generic;

namespace PracticeTime3
{
    internal interface IPlayer<T, G>
    {
        List<T> PlayerCards { get; set; }
        G CollectionCardOverall { get; set; }
        Stack<T> GetCollectionOfCards();

        event Action TakingCard;
        event Action DroppingCard;
        T ChooseCard(int id_card);
    }
    internal interface IDurak<T, G>
    {
        IPlayer<T, G> GetPlayer();
    }
  
}
