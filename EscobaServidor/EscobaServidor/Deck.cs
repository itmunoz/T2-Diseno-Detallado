namespace EscobaServidor;

using System.Text.Json;

public class Deck
{
    private List<Card> _cards = new List<Card>();
    private Random _rnd = new Random();

    public Deck()
    {
        PrepareDeck();
    }

    public void PrepareDeck()
    {
        _cards = GenerateCards();
        _cards = _cards.OrderBy(carta => GeneradorNumerosAleatorios.Generar()).ToList();
    }

    public List<Card> Cards
    {
        get { return _cards; }
    }

    public void PlaceCardInTable(CardsInTable table)
    {
        for (int i = 0; i < 4; i++)
            table.ReceiveCard(DrawTopCard());
    }

    public void GiveCards(Player player, int cardQuantity)
    {
        for (int i = 0; i < cardQuantity; i++)
            player.AddCardToHand(DrawTopCard());
    }

    private Card DrawTopCard()
    {
        int idTopCard = _cards.Count - 1;
        Card drawnCard = _cards[idTopCard];
        _cards.Remove(drawnCard);
        return drawnCard;
    }

    private List<Card> GenerateCards()
    {
        string[] suits = {"oro", "espada", "copa", "bastos"};
        string[] higherCards = { "sota", "caballo", "rey" };
        
        List<Card> cardsList = new List<Card>();

        CreateCards(suits, cardsList, higherCards);
        
        return cardsList;
    }

    private void CreateCards(string[] suits, List<Card> cardsList, string[] higherCards)
    {
        foreach (var suit in suits)
        {
            CreateNumberedCards(suit, cardsList);
            CreateWordedCards(higherCards, suit, cardsList);
        }
    }

    private void CreateWordedCards(string[] higherCards, string suit, List<Card> cardsList)
    {
        foreach (var higherCard in higherCards)
        {
            Card card = new Card(suit, higherCard);
            cardsList.Add(card);
        }
    }

    private void CreateNumberedCards(string suit, List<Card> cardsList)
    {
        for (int i = 1; i < 8; i++)
        {
            Card card = new Card(suit, i.ToString());
            cardsList.Add(card);
        }
    }
}