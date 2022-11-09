namespace EscobaServidor;

public class CardCombinationChecker
{
    public List<List<Card>> GetCombinationsThatSum15(List<Card> cardList)
    {
        List<List<Card>> combinationsThatSum15 = new List<List<Card>>();
        List<List<Card>> totalCombinations = GetCombinations(cardList);
        
        foreach (var combination in totalCombinations)
            CheckIfCombinationSums15(combinationsThatSum15, combination);

        return combinationsThatSum15;
    }

    private void CheckIfCombinationSums15(List<List<Card>> combinationsThatSum15, List<Card> combination)
    {
        int combinationSum = GetCombinationSum(combination);
        if (combinationSum == 15)
            combinationsThatSum15.Add(combination);
    }

    private int GetCombinationSum(List<Card> combination)
    {
        int totalSum = 0;
        foreach (var card in combination)
            totalSum += card.GetIntValue();

        return totalSum;
    }
    
    private List<List<Card>> GetCombinations(List<Card> cardList)
    {
        List<List<Card>> combinations = new List<List<Card>>();
        double count = Math.Pow(2, cardList.Count);

        CreateCurrentCombination(cardList, combinations, count);
        
        return combinations;
    }

    private void CreateCurrentCombination(List<Card> cardList, List<List<Card>> combinations, double count)
    {
        for (int i = 1; i <= count - 1; i++)
        {
            List<Card> currentCombination = new List<Card>();
            string str = Convert.ToString(i, 2).PadLeft(cardList.Count, '0');
            CheckIfCombinationIsValid(str, currentCombination, cardList);
            combinations.Add(currentCombination);
        }
    }

    private void CheckIfCombinationIsValid(string str, List<Card> currentCombination, List<Card> cardList)
    {
        for (int j = 0; j < str.Length; j++)
        {
            if (str[j] == '1')
                currentCombination.Add(cardList[j]);
        }
    }
}