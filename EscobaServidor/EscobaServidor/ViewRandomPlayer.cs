namespace EscobaServidor;

public class ViewRandomPlayer : View
{
    private Random _rnd = new Random();
    
    protected override int AskForNumber(int minValue, int maxValue) 
        => _rnd.Next(minValue, maxValue + 1);
}