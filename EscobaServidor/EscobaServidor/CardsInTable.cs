namespace EscobaServidor;

public class CardsInTable
{
    private List<Card> _cardsInTable = new List<Card>();

    public List<Card> GetCardsInTable()
    {
        return _cardsInTable;
    }

    public void ReceiveCard(Card card)
    {
        _cardsInTable.Add(card);
    }

    public void RemoveCardsFromTable(List<Card> cards)
    {
        foreach (var card in cards)
        {
            _cardsInTable.Remove(card);
        }
    }
}