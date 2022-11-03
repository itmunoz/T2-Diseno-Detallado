namespace EscobaServidor;

public class Players
{
    private List<Player> _players;

    public Players(int playersNumber)
    {
        _players = new List<Player>();
        for(int i = 0; i < playersNumber; i++)
            _players.Add(new Player(i));
    }
    
    public Player GetPlayer(int idPlayer) => _players[idPlayer];
}