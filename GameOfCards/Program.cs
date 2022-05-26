using NavBlue_PlayingCardLibrary;

//Initialize deck

    Console.WriteLine("Creating 52 card deck...\n");
    Thread.Sleep(1000);

    Deck deck = new Deck();
    deck = deck.Create52Deck(); 

    Console.WriteLine("Deck created...\n");
    Thread.Sleep(1000);

//Display created deck

    foreach (var card in deck.cards) 
    {
        Console.WriteLine(card.rank + " of " + card.suit);
    }

//Shuffle deck

    Console.WriteLine("\nShuffling deck...\n");

    deck.cards = deck.ShuffleDeck(); 

    Thread.Sleep(1000);

//Display shuffled deck

    foreach (var card in deck.cards)
    {
        Console.WriteLine(card.rank + " of " + card.suit);
    }

    Thread.Sleep(1000);

//Generate hands

    Console.WriteLine("\nGenerating four hands...\n");

    List<Hand> hands = deck.CreateEqualHands(4, 6);

    foreach(var hand in hands)
    {
        Thread.Sleep(500);
        Console.WriteLine("\nDisplaying hand no. " + hand.id + "\n");

        foreach(var card in hand.cards)
        {
            Console.WriteLine(card.rank + " of " + card.suit);
        }

        Console.WriteLine("\nHand (" + hand.id + ") rank strength: " + hand.GetHandRankStrength());
        Console.WriteLine("Hand (" + hand.id + ") suit strength: " + hand.GetHandSuitStrength());
    }

    Thread.Sleep(1000);
    Console.WriteLine("\nDeck now only has " + deck.cards.Count + " cards left...");

//Sort remaining deck

    Console.WriteLine("\nSorting remaining deck...");

    deck.cards = deck.SortDeckClassic();

//Deciding winner by sorting which hand is stronger by Suit

    Console.WriteLine("\nRanking hands based on Suit strength...\n");

    hands = hands.OrderBy(h => h.GetHandRankStrength()).ToList();  

    for(int i = 1; i < hands.Count + 1; i++)
    {
        Console.WriteLine("Hand " + hands[i-1].id + " ranks " + i + " in rank strength, with a score of " + hands[i - 1].GetHandRankStrength() + "...");
    }

//Deciding winner by sorting which hand is stronger by Rank

    Console.WriteLine("\nRanking hands based on Rank strength...\n");

    hands = hands.OrderBy(h => h.GetHandSuitStrength()).ToList();
    
    for (int i = 1; i < hands.Count + 1; i++)
    {
        Console.WriteLine("Hand " + hands[i-1].id + " ranks " + i + " in suit strength, with a score of " + hands[i - 1].GetHandSuitStrength() + " ...");
    }

    Thread.Sleep(5000);

//Creating new deck to use for single hand

    Console.WriteLine("\nNow creating a new deck and shuffling it...");

    deck = deck.Create52Deck();
    deck.cards = deck.ShuffleDeck();

//Creating single hand with 21 cards (1/2 the deck)

    Hand singleHand = deck.CreateHand(1, 21);

    Thread.Sleep(500);
    Console.WriteLine("Single hand (Id: " + singleHand.id + ") contains the following cards: \n");
    
    foreach (var card in singleHand.cards)
    {
        Console.WriteLine(card.rank + " of " + card.suit);
    }

    Console.WriteLine("\nThe hand has a suit strength of " + singleHand.GetHandSuitStrength() + " and a rank strength of " + singleHand.GetHandRankStrength() + "...");

