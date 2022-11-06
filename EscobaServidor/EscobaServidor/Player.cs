namespace EscobaServidor;

public class Player
{
    private List<Card> _hand = new List<Card>();
    private List<Card> _wonCards = new List<Card>();
    private int _escobas = 0;
    private int _points = 0;
    private int _numberOfSevens = 0;
    private int _id;
    private int _numberOfGolds = 0;

    public Player(int id)
    {
        _id = id;
    }

    public int NumberOfGolds
    {
        get { return _numberOfGolds; }
    }

    public int Id
    {
        get { return _id; }
    }

    public List<Card> Hand
    {
        get { return _hand; }
    }
    
    public void AddCardToHand(Card card)
    {
        _hand.Add(card);
    }
    
    public List<Card> WonCards
    {
        get { return _wonCards; }
    }
    
    public int Escobas
    {
        get { return _escobas; }
    }

    public int NumberOfSevens
    {
        get { return _numberOfSevens; }
    }

    public Card DiscardCardFromHand(int cardId)
    {
        Card selectedCard = _hand[cardId];
        _hand.Remove(selectedCard);
        return selectedCard;
    }

    public void AddCardsToWonCards(List<Card> cards)
    {
        _wonCards.AddRange(cards);
    }
    
    public void AddEscoba()
    {
        _escobas += 1;
    }

    public void ResetBrooms()
    {
        _escobas = 0;
    }

    public void AddPoints(int newPoints)
    {
        _points += newPoints;
    }
    
    public void CountGolds()
    {
        foreach (var card in WonCards)
        {
            if (card.Suit == "oro")
                _numberOfGolds += 1;
        }
    }
    
    public void ResetNumberOfGolds()
    {
        _numberOfGolds = 0;
    }

    public void CountSevens()
    {
        foreach (var card in WonCards)
        {
            if (card.Value == "7")
                _numberOfSevens += 1;
        }
    }

    public void ResetNumberOfSevens()
    {
        _numberOfSevens = 0;
    }

    public int Points
    {
        get { return _points; }
    }

    public void ResetWonCards()
    {
        _wonCards.Clear();
    }
}