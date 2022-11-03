namespace EscobaServidor;

public class CardCombinationChecker
{
    public List<List<Card>> GetCombinationsThatSum15(List<Card> cardList)
    {
        List<List<Card>> combinationsThatSum15 = new List<List<Card>>();
        List<List<Card>> totalCombinations = GetCombinations(cardList);
        
        foreach (var combination in totalCombinations)
        {
            int combinationSum = GetCombinationSum(combination);
            if (combinationSum == 15)
                combinationsThatSum15.Add(combination);
        }

        return combinationsThatSum15;
    }

    private int GetCombinationSum(List<Card> combination)
    {
        int totalSum = 0;
        foreach (var card in combination)
            totalSum += card.GetIntValue();

        return totalSum;
    }

    // Bibliografía: https://stackoverflow.com/questions/7802822/all-possible-combinations-of-a-list-of-values
    private List<List<Card>> GetCombinations(List<Card> cardList)
    {
        List<List<Card>> combinations = new List<List<Card>>();
        
        double count = Math.Pow(2, cardList.Count);
        for (int i = 1; i <= count - 1; i++)
        {
            List<Card> currentCombination = new List<Card>();
            string str = Convert.ToString(i, 2).PadLeft(cardList.Count, '0');
            for (int j = 0; j < str.Length; j++)
            {
                if (str[j] == '1')
                {
                    currentCombination.Add(cardList[j]);
                }
            }
            combinations.Add(currentCombination);
        }
        
        return combinations;
    }
}