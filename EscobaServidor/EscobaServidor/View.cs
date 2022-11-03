namespace EscobaServidor;

public class View
{
    public void WelcomeMessage()
    {
        Console.WriteLine("Bienvenido al juego!");
        Console.WriteLine("");
    }
    
    public void Pause() => Console.ReadLine();
    
    public void TurnInfo(Player player, CardsInTable cardsInTable)
    {
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Juega Jugador " + player.Id);
        Console.Write("Mesa Actual: ");

        for (int i = 0; i < cardsInTable.GetCardsInTable().Count; i++)
        {
            Console.Write("(" + i + ")" + cardsInTable.GetCardsInTable()[i] + "  ");
        }
        
        Console.WriteLine();
        Console.Write("Mano jugador: ");
        
        for (int i = 0; i < player.Hand.Count; i++)
        {
            Console.Write("(" + i + ") " + player.Hand[i] + "  ");
        }
        Console.WriteLine("");
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

    public void BroomAnnouncement(Player player)
    {
        Console.Write("ESCOBA !************************************************** ");
        Console.Write("JUGADOR " + player.Id);
        Console.WriteLine("");
    }

    public int AskForCombinationToTake(List<List<Card>> combinations)
    {
        int minValue = 0;
        int maxValue = combinations.Count - 1;
        
        Console.WriteLine("");
        Console.WriteLine("Hay " + (maxValue + 1) + " jugadas en la mesa:");

        for (int i = 0; i < combinations.Count; i++)
        {
            Console.Write(i + "- ");
            foreach (var card in combinations[i])
            {
                Console.Write(card + "  ");
            }
            Console.WriteLine("");
        }
        
        Console.WriteLine("¿Cuál quieres usar?");
        int selectedValue = InputRange(minValue, maxValue);
        return selectedValue;
    }

    public void PlayerTakesCards(Player player, List<Card> cards)
    {
        Console.Write("Jugador " + player.Id + " se lleva las siguientes cartas: ");
        Console.Write("");
        foreach (var card in cards)
        {
            Console.Write(card + " ");
        }
        Console.WriteLine("");
    }

    private int InputRange(int minValue, int maxValue)
    {
        Console.WriteLine("(Ingresa un número entre " + minValue + " y " + maxValue + ")");
        int selectedValue = AskForNumber(minValue, maxValue);
        return selectedValue;
    }
    
    private static int AskForNumber(int minValue, int maxValue)
    {
        int number;
        bool wasParseSuccessful;
        do
        {
            string? userInput = Console.ReadLine();
            wasParseSuccessful = int.TryParse(userInput, out number);
            if (!wasParseSuccessful || number < minValue || number > maxValue)
            {
                Console.WriteLine("Input inválido. Intenta de nuevo");
            }
        } while (!wasParseSuccessful || number < minValue || number > maxValue);

        return number;
    }
}