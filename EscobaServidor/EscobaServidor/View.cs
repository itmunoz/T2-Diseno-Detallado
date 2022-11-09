namespace EscobaServidor;

public class View
{
    public void CardsWonByPlayer(Player[] players)
    {
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Cartas ganadas en esta ronda");
        foreach (var player in players)
            CardsWonByEachPlayer(player);
    }

    private void CardsWonByEachPlayer(Player player)
    {
        Console.Write("    Jugador " + player.Id + ": ");
        foreach (var card in player.WonCards)
            Console.Write(card + "  ");
            
        Console.WriteLine("");
    }

    public void AnnounceWinner(Player player)
    {
        Console.WriteLine("");
        Console.WriteLine("**************************");
        Console.WriteLine("El juego ha terminado!");
        Console.WriteLine("El ganador es el jugador " + player.Id + " con " + player.Points + " puntos!");
    }

    public void AnnounceTie()
    {
        Console.WriteLine("");
        Console.WriteLine("**************************");
        Console.WriteLine("¡El juego ha terminado!");
        Console.WriteLine("¡Ha ocurrido un empate entre los dos jugadores!");
    }

    public void PointsWonByPlayer(Player[] players)
    {
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Total puntos ganados");
        foreach (var player in players)
            Console.WriteLine("    Jugador " + player.Id + ": " + player.Points);
        Console.WriteLine("-----------------------------------");
    }

    public void TurnInfo(Player player, CardsInTable cardsInTable)
    {
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Juega Jugador " + player.Id);
        
        TableInfo(cardsInTable);
        PlayerHandInfo(player);
    }

    private void PlayerHandInfo(Player player)
    {
        Console.WriteLine("");
        Console.Write("Mano jugador: ");
        
        for (int i = 0; i < player.Hand.Count; i++)
            Console.Write("(" + i + ") " + player.Hand[i] + "  ");
        
        Console.WriteLine("");
    }

    private void TableInfo(CardsInTable cardsInTable)
    {
        Console.Write("Mesa Actual: ");

        for (int i = 0; i < cardsInTable.GetCardsInTable().Count; i++)
            Console.Write("(" + i + ")" + cardsInTable.GetCardsInTable()[i] + "  ");
    }

    public int ChooseCard(Player player)
    {
        Console.WriteLine("¿Qué carta quieres bajar?");
        int selectedValue = InputRange(0, player.Hand.Count - 1);
        return selectedValue;
    }

    public void NoCombinationSums15()
    {
        Console.WriteLine("No hay combinación que sume 15. Se pasa al siguiente turno");
    }

    public void AnnounceNewRound()
    {
        Console.WriteLine("Ambos jugadores se quedaron sin cartas.");
        Console.WriteLine("Se repartiran nuevas cartas y partirá una nueva ronda.");
    }

    public void BroomAnnouncement(Player player)
    {
        Console.Write("ESCOBA !************************************************** ");
        Console.Write("JUGADOR " + player.Id);
        Console.WriteLine("");
    }

    public int AskForCombinationToTake(List<List<Card>> combinations)
    {
        AmountOfCombinations(combinations);
        ShowAvailableCombinations(combinations);

        Console.WriteLine("¿Cuál quieres usar?");
        int selectedValue = InputRange(0, combinations.Count - 1);
        return selectedValue;
    }

    private void AmountOfCombinations(List<List<Card>> combinations)
    {
        Console.WriteLine("");
        Console.WriteLine("Hay " + (combinations.Count) + " jugadas en la mesa:");
    }

    private void ShowAvailableCombinations(List<List<Card>> combinations)
    {
        for (int i = 0; i < combinations.Count; i++)
        {
            Console.Write(i + "- ");
            foreach (var card in combinations[i])
                Console.Write(card + "  ");
            
            Console.WriteLine("");
        }
    }

    public void PlayerTakesCards(Player player, List<Card> cards)
    {
        Console.Write("Jugador " + player.Id + " se lleva las siguientes cartas: ");
        Console.Write("");
        foreach (var card in cards)
            Console.Write(card + " ");
        
        Console.WriteLine("");
    }

    private int InputRange(int minValue, int maxValue)
    {
        Console.WriteLine("(Ingresa un número entre " + minValue + " y " + maxValue + ")");
        int selectedValue = AskForNumber(minValue, maxValue);
        return selectedValue;
    }
    
    protected virtual int AskForNumber(int minValue, int maxValue)
    {
        int number;
        bool wasParseSuccessful;
        do
        {
            string? userInput = Console.ReadLine();
            wasParseSuccessful = int.TryParse(userInput, out number);
            PrintIfInputIsInvalid(wasParseSuccessful, number, minValue, maxValue);
        } while (!wasParseSuccessful || number < minValue || number > maxValue);

        return number;
    }

    private void PrintIfInputIsInvalid(bool wasParseSuccessful, int number, int minValue, int maxValue)
    {
        if (!wasParseSuccessful || number < minValue || number > maxValue)
        {
            Console.WriteLine("Input inválido. Intenta de nuevo");
        }
    }
}