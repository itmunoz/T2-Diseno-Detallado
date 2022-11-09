namespace EscobaServidor.Tests;

public class GameTests
{
    [Fact]
    public void ItShouldPlayGameWithoutFail()
    {
        Game game = Game.CreateWithRandomPlayer();

        game.Start();
    }
}