namespace EscobaServidor;

public class Game
{
    private Player _player1 = new Player(1);
    private Player _player2 = new Player(2);
    
    private Deck _deck = new Deck();
    private CardsInTable _cardsInTable = new CardsInTable();
    private CardCombinationChecker _cardChecker = new CardCombinationChecker();
    private View _view = new View();

    private int _currentPlayerTurn = 1;

    public Game()
    {
        GiveCardsToPlayers();
    }

    public void Start()
    {
        while (!IsGameFinished())
        {
            PlayTurn();
            // _view.Pause();
        }
    }

    private void PlayTurn()
    {
        if (_player1.Id == _currentPlayerTurn)
            PlayPlayerTurn(_player1);
        else
            PlayPlayerTurn(_player2);
        ChangeTurn();
    }

    private void ChangeTurn()
    {
        if (_currentPlayerTurn == 1)
            _currentPlayerTurn = 2;
        else
            _currentPlayerTurn = 1;
    }

    private void PlayPlayerTurn(Player player)
    {
        _view.TurnInfo(player, _cardsInTable);
        int cardId = _view.ChooseCard(player);
        LowerCardToTable(player, cardId);
        CheckForAvailableCombinations(player);
    }

    private void LowerCardToTable(Player player, int cardId)
    {
        Card loweredCard = player.DiscardCardFromHand(cardId);
        _cardsInTable.ReceiveCard(loweredCard);
    }

    private void CheckForAvailableCombinations(Player player)
    {
        List<Card> cardsInTable = _cardsInTable.GetCardsInTable();
        List<List<Card>> validCombinations = _cardChecker.GetCombinationsThatSum15(cardsInTable);

        if (validCombinations.Any())
        {
            List<Card> wonCards = new List<Card>();
            if (validCombinations.Count == 1)
            {
                wonCards = validCombinations[0];
            }
            else
            {
                int combinationId = _view.AskForCombinationToTake(validCombinations);
                wonCards = validCombinations[combinationId];
            }
            _view.PlayerTakesCards(player, wonCards);
            PlayerGetsCards(player, wonCards);
            CheckBroom(player);
        }
        else
        {
            _view.NoCombinationSums15();
        }
    }

    private void PlayerGetsCards(Player player, List<Card> cards)
    {
        _cardsInTable.RemoveCardsFromTable(cards);
        player.AddCardsToWonCards(cards);
    }

    private void CheckBroom(Player player)
    {
        if (_cardsInTable.GetCardsInTable().Count == 0)
        {
            _view.BroomAnnouncement(player);
            player.AddEscoba();
        }
    }

    private void GiveCardsToPlayers()
    {
        _deck.GiveCards(_player1, 3);
        _deck.GiveCards(_player2, 3);
    }

    private bool IsGameFinished()
    {
        
        return false;
    }
}