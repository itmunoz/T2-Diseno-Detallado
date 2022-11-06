namespace EscobaServidor.Tests;

public class CardTests
{
    [Fact]
    public void GetSuit()
    {
        Card card = new Card("oro", "5");
        
        Assert.Equal("oro", card.Suit);
    }
    
    [Fact]
    public void GetValue()
    {
        Card card = new Card("oro", "5");
        
        Assert.Equal("5", card.Value);
    }
    
    [Fact]
    public void GetValueOfNormalNumber()
    {
        Card card = new Card("oro", "5");
        
        Assert.Equal(5, card.GetIntValue());
    }
    
    [Fact]
    public void GetValueOfSota()
    {
        Card card = new Card("oro", "sota");
        
        Assert.Equal(8, card.GetIntValue());
    }
    
    [Fact]
    public void GetValueOfCaballo()
    {
        Card card = new Card("oro", "caballo");
        
        Assert.Equal(9, card.GetIntValue());
    }
    
    [Fact]
    public void GetValueOfRey()
    {
        Card card = new Card("oro", "rey");
        
        Assert.Equal(10, card.GetIntValue());
    }
}