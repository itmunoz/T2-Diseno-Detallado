namespace EscobaServidor;

public class Game
{
    private Player _player1 = new Player();
    private Player _player2 = new Player();
    
    

    private Deck _deck = new Deck();
    
    private View _view = new View();

    public void Start()
    {
        foreach (var card in _deck._cards)
        {
            Console.WriteLine(card);
        }
        Console.WriteLine(_deck._cards.Count);
    }
}