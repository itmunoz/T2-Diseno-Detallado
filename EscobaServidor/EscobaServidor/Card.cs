namespace EscobaServidor;

public class Card
{
    private string _suit;
    private string _value;
    
    private IDictionary<string, int> _intValues = new Dictionary<string, int>()
    {
        {"1", 1}, {"2", 2}, {"3", 3}, {"4", 4}, {"5", 5}, {"6", 6}, 
        {"7", 7}, {"sota", 8}, {"caballo", 9}, {"rey", 10}
    };

    public string Suit
    {
        get { return _suit; }
    }
    
    public string Value
    {
        get { return _value; }
    }

    public int GetIntValue()
    {
        return _intValues[_value];
    }
    
    public Card(string suit, string value)
    {
        _suit = suit;
        _value = value;
    }
    
    public override string ToString() => _suit + "_" + _value;
}