namespace EscobaServidor.Tests;

public class PointsCounterTests
{
    [Fact]
    public void ItShouldGive3And2PointsRespectively()
    {
        Player[] players = PreparePlayers();

        PointsCounter counter = new PointsCounter();
        counter.AssignPoints(players);

        Assert.Equal(3, players[0].Points);
        Assert.Equal(2, players[1].Points);
    }

    private Player[] PreparePlayers()
    {
        Player[] players = new[] { new Player(1), new Player(2) };
        PointsForPlayer1(players[0]);
        PointsForPlayer2(players[1]);
        
        return players;
    }

    private void PointsForPlayer1(Player player)
    {
        GiveGoldCards(player);
        GiveSevenCards(player);
    }
    
    private void PointsForPlayer2(Player player)
    {
        GiveSevenOfGold(player);
        player.AddEscoba();
    }

    private void GiveGoldCards(Player player)
    {
        List<Card> cards = new List<Card>();
        cards.Add(new Card("oro", "1"));
        cards.Add(new Card("oro", "2"));
        cards.Add(new Card("oro", "3"));
        player.AddCardsToWonCards(cards);
    }

    private void GiveSevenCards(Player player)
    {
        List<Card> cards = new List<Card>();
        cards.Add(new Card("espada", "7"));
        cards.Add(new Card("copa", "7"));
        cards.Add(new Card("bastos", "7"));
        player.AddCardsToWonCards(cards);
    }

    private void GiveSevenOfGold(Player player)
    {
        List<Card> cards = new List<Card>();
        cards.Add(new Card("oro", "7"));
        player.AddCardsToWonCards(cards);
    }
}