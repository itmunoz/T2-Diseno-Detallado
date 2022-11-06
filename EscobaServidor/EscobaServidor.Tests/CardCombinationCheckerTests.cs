namespace EscobaServidor.Tests;

public class CardCombinationCheckerTests
{
    [Fact]
    public void DoesReturnTwoValidCombinations()
    {
        List<Card> cards = PrepareTwoValidCombinations();
        CardCombinationChecker checker = new CardCombinationChecker();
        
        List<List<Card>> validCombinations = checker.GetCombinationsThatSum15(cards);

        Assert.Equal(2, validCombinations.Count);
    }

    private List<Card> PrepareTwoValidCombinations()
    {
        List<Card> cards = new List<Card>();
        cards.Add(new Card("oro", "5"));
        cards.Add(new Card("espada", "rey"));
        cards.Add(new Card("bastos", "rey"));
        return cards;
    }
}