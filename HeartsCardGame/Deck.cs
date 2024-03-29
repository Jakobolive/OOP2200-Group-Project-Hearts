﻿// Names: Jakob Olive, 
// Start Date: 2024-03-13
// File Desc: This file will contain the class that will build the current hand for each player. This class
// will contain a list of card objects and possibly have a string name attached to it to identify the player who owns
// this hand.
#region Using
using HeartsCardGame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace HeartsCardGame
{
    internal class Deck
    {
        #region List
        // Creating the list that will be used to carry the deck of cards.
        public List<Card> cardDeck = new List<Card>();
        #endregion

        #region Build Method
        /// <summary>
        /// Function that will build a list of 52 cards based off the standard card deck with variables that 
        /// suit the requirements of the points system within Hearts.
        /// </summary>
        public virtual void BuildDeck()
        {
            // Values that represent the suits and values for a standard deck of playing cards.
            string[] standardSuits = { "Hearts", "Clubs", "Diamonds", "Spades" };
            string[] standardValues = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
            // Additional variables for the point system.
            bool danger;
            int points;

            // Foreach loop nested inside another that loops the suits and values to create the cards.
            foreach (var suit in standardSuits)
            {
                foreach (var value in standardValues)
                {
                    // Validation to check if either the suit is Hearts, or if card is the Queen of Spades.
                    if (suit == "Hearts")
                    {
                        danger = true;
                        points = 1;
                    }
                    if (suit == "Spades" && value == "Queen")
                    {
                        danger = true;
                        points = 13;
                    }
                    else
                    {
                        danger = false;
                        points = 0;
                    }
                    // Adding a new card(Calling Parameterized Constructor) to cardDeck.
                    cardDeck.Add(new Card(suit, value, danger, points));
                }
            }
        }
        #endregion

        #region List Functions
        /// <summary>
        /// Function that will take a Card object and add it to the cardDeck list.
        /// </summary>
        /// <param name="card"></param>
        public void AddCardToList(Card card)
        {
            // Adding the Card to the List.
            cardDeck.Add(card);
        }

        /// <summary>
        /// Function that will delete the top index from a list. (Used In Shuffle)
        /// </summary>
        public void DeleteCardFromList()
        {
            // Remove Card at index of List.
            cardDeck.RemoveAt(0);
        }

        /// <summary>
        /// This function will get the list and return it for use in the form.
        /// </summary>
        /// <returns></returns>
        public List<Card> GetDeck()
        {
            // Return the list.
            return cardDeck;
        }

        /// <summary>
        /// This function will set the values of the current list to the values of a new list. (Used In Shuffle And Deck Creation)
        /// </summary>
        /// <param name="newDeck"></param>
        public void SetDeck(List<Card> newDeck)
        {
            // Setting the cardDeck to the values of a newDeck.
            cardDeck = newDeck;
        }
        #endregion
    }
}
