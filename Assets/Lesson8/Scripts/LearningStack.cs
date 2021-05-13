using System.Collections.Generic;
using UnityEngine;

namespace Learning
{
    
    public struct Card {
        string name;
        int value;
    }
    public class LearningStack : MonoBehaviour
    {
        public Stack<Card> cards = new Stack<Card>();

        private void Start()
        {

        }

        public void AddCard(Card card) {
            cards.Push(card);
        }
        public Card? Draw()
        {
            if(cards.Count == 0) {
                return null;
            }
            return cards.Pop();
        }


    }
}
