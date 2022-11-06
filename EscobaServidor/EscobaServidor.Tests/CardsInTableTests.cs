namespace EscobaServidor.Tests;

public class CardsInTableTests
{
    [Fact]
    public void DoesReceiveCards()
    {
        CardsInTable table = new CardsInTable();
        List<Card> cards = PrepareCards();
        foreach (var card in cards)
            table.ReceiveCard(card);

        Assert.Equal(3, table.GetCardsInTable().Count);
    }
    
    [Fact]
    public void RemoveCards()
    {
        CardsInTable table = new CardsInTable();
        List<Card> cards = PrepareCards();
        foreach (var card in cards)
            table.ReceiveCard(card);
        
        table.RemoveCardsFromTable(cards);
        
        Assert.Empty(table.GetCardsInTable());
    }
    
    [Fact]
    public void ResetCards()
    {
        CardsInTable table = new CardsInTable();
        List<Card> cards = PrepareCards();
        foreach (var card in cards)
            table.ReceiveCard(card);
        
        table.ResetWonCards();
        
        Assert.Empty(table.GetCardsInTable());
    }

    private List<Card> PrepareCards()
    {
        List<Card> cards = new List<Card>();
        cards.Add(new Card("oro", "rey"));
        cards.Add(new Card("bastos", "4"));
        cards.Add(new Card("copas", "5"));
        return cards;
    }
}