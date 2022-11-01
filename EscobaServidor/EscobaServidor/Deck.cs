namespace EscobaServidor;

using System.Text.Json;

public class Deck
{
    public List<Card> _cards;
    private Random _rnd = new Random();

    public Deck()
    {
        _cards = GenerateCards();
        _cards = _cards.OrderBy(carta => GeneradorNumerosAleatorios.Generar()).ToList();
    }

    public void GiveCards(Player player, int cardQuantity)
    {
        for (int i = 0; i < cardQuantity; i++)
        {
            player.AddCardToHand(DrawTopCard());
        }
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

        foreach (var suit in suits)
        {
            for (int i = 1; i < 8; i++)
            {
                Card card = new Card(suit, i.ToString());
                cardsList.Add(card);
            }

            foreach (var higherCard in higherCards)
            {
                Card card = new Card(suit, higherCard);
                cardsList.Add(card);
            }
        }
        return cardsList;
    }
}