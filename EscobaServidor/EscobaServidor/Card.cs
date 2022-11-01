namespace EscobaServidor;

public class Card
{
    private string _suit;
    private string _value;
    
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
        if (_value == "sota")
        {
            return 8;
        }
        
        if (_value == "caballo")
        {
            return 9;
        }
        
        if (_value == "rey")
        {
            return 10;
        }
        
        return Int32.Parse(_value);
    }
    
    public Card(string suit, string value)
    {
        _suit = suit;
        _value = value;
    }
    
    public override string ToString() => "[" + _suit + "," + _value + "]";
}