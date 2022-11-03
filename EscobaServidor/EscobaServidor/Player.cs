namespace EscobaServidor;

public class Player
{
    private List<Card> _hand = new List<Card>();
    private List<Card> _wonCards = new List<Card>();
    private int _escobas = 0;
    private int _id;

    public Player(int id)
    {
        _id = id;
    }

    public int Id
    {
        get { return _id; }
    }

    public List<Card> Hand
    {
        get { return _hand; }
    }
    public List<Card> WonCards
    {
        get { return _wonCards; }
    }
    public int Escobas
    {
        get { return _escobas; }
    }

    public void AddCardToHand(Card card)
    {
        _hand.Add(card);
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
    
    
}