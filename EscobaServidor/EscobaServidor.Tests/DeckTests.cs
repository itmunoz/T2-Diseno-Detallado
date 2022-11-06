namespace EscobaServidor.Tests;

public class DeckTests
{
    [Fact]
    public void IsNumberOfCardsInDeck40()
    {
        Deck deck = new Deck();
        List<Card> cards = deck.Cards;
        
        Assert.Equal(40, cards.Count);
    }
    
    [Fact]
    public void Are4CardsPlacedInTable()
    {
        Deck deck = new Deck();
        CardsInTable cardsInTable = new CardsInTable();
        
        deck.PlaceCardInTable(cardsInTable);
        List<Card> cards = cardsInTable.GetCardsInTable();
        
        Assert.Equal(4, cards.Count);
    }
    
    [Fact]
    public void DoesPlayerReceive3Cards()
    {
        Deck deck = new Deck();
        Player player = new Player(1);
        
        deck.GiveCards(player, 3);
        
        Assert.Equal(3, player.Hand.Count);
        Assert.Equal(37, deck.Cards.Count);
    }
}