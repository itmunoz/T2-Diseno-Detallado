namespace EscobaServidor.Tests;

public class PlayerTests
{
    [Fact]
    public void ItShouldGetId()
    {
        Player player = new Player(1);
        int id = player.Id;
        
        Assert.Equal(1, id);
    }
    
    [Fact]
    public void PlayerShouldReceiveOneCard()
    {
        Player player = new Player(1);
        Card card = new Card("oro", "1");
        
        player.AddCardToHand(card);
        List<Card> hand = player.Hand;

        Assert.Equal(card, hand[0]);
    }
    
    [Fact]
    public void PlayerShouldDiscardCard()
    {
        Player player = new Player(1);
        Card card = new Card("oro", "1");
        player.AddCardToHand(card);

        Card discardedCard = player.DiscardCardFromHand(0);

        Assert.Equal(card, discardedCard);
    }
    
    [Fact]
    public void ItShouldGetNumberOfBrooms()
    {
        Player player = new Player(1);
        player.AddEscoba();
        int brooms = player.Escobas;

        Assert.Equal(1, brooms);
    }
    
    [Fact]
    public void ItShouldGetResetBrooms()
    {
        Player player = new Player(1);
        player.AddEscoba();
        player.ResetBrooms();
        int brooms = player.Escobas;

        Assert.Equal(0, brooms);
    }
    
    [Fact]
    public void ItShouldClearWonCards()
    {
        Player player = new Player(1);
        List<Card> cards = new List<Card>();
        cards.Add(new Card("oro", "4"));
        player.AddCardsToWonCards(cards);
        player.ResetWonCards();

        Assert.Empty(player.WonCards);
    }
}