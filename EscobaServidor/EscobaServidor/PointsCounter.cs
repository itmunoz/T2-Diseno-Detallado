namespace EscobaServidor;

public class PointsCounter
{
    public void AssignPoints(Player[] players)
    {
        foreach (var player in players)
        {
            AssignBroomsPoints(player);
            AssignSevenOfGoldPoints(player);
        }

        AssignNumberOfCardsPoints(players);
        AssignNumberOfSevensPoints(players);
        AssignNumberOfGoldPoints(players);
    }

    private void AssignNumberOfGoldPoints(Player[] players)
    {
        foreach (var player in players)
            player.CountGolds();
        
        DetermineWhoWinsNumberOfGolds(players);
    }

    private void DetermineWhoWinsNumberOfGolds(Player[] players)
    {
        if (players[0].NumberOfGolds >= players[1].NumberOfGolds)
            players[0].AddPoints(1);
        
        if (players[0].NumberOfGolds <= players[1].NumberOfGolds)
            players[1].AddPoints(1);
        
        ClearNumberOfGolds(players);
    }

    private void ClearNumberOfGolds(Player[] players)
    {
        foreach (var player in players)
            player.ResetNumberOfGolds();
    }

    private void AssignNumberOfSevensPoints(Player[] players)
    {
        foreach (var player in players)
            player.CountSevens();
        
        DetermineWhoWinsNumberOfSevens(players);
    }

    private void DetermineWhoWinsNumberOfSevens(Player[] players)
    {
        if (players[0].NumberOfSevens >= players[1].NumberOfSevens)
            players[0].AddPoints(1);
        
        if (players[0].NumberOfSevens <= players[1].NumberOfSevens)
            players[1].AddPoints(1);
        
        ClearNumberOfSevens(players);
    }

    private void ClearNumberOfSevens(Player[] players)
    {
        foreach (var player in players)
            player.ResetNumberOfSevens();
    }

    private void AssignNumberOfCardsPoints(Player[] players)
    {
        if (players[0].WonCards.Count >= players[1].WonCards.Count)
            players[0].AddPoints(1);
        
        if (players[0].WonCards.Count <= players[1].WonCards.Count)
            players[1].AddPoints(1);
    }

    private void AssignBroomsPoints(Player player)
    {
        player.AddPoints(player.Escobas);
        player.ResetBrooms();
    }

    private void AssignSevenOfGoldPoints(Player player)
    {
        foreach (var card in player.WonCards)
        {
            if (card.Suit == "oro" && card.Value == "7")
            {
                player.AddPoints(1);
                return;
            }
        }
    }
}