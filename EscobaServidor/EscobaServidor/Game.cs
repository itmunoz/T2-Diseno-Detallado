namespace EscobaServidor;

public class Game
{
    private Player _player1 = new Player(1);
    private Player _player2 = new Player(2);
    
    private Deck _deck = new Deck();
    private CardsInTable _cardsInTable = new CardsInTable();
    private CardCombinationChecker _cardChecker = new CardCombinationChecker();
    private PointsCounter _pointsCounter = new PointsCounter();
    private View _view = new View();

    private int _currentPlayerTurn = 2;
    private int _lastPlayerToWinCards;

    public Game()
    {
        GiveCardsToPlayers();
        PlaceInitialCardsOnTable();
    }

    public void Start()
    {
        CheckStartOfHandBroom();
        while (!IsGameFinished())
        {
            if (_deck.Cards.Count == 0 && _player1.Hand.Count == 0 && _player2.Hand.Count == 0)
            {
                EndOfHand();
                
                Player[] players = { _player1, _player2 };
                bool are16PointsReached = CheckPoints(players);
                if (are16PointsReached)
                    break;
                
                NextHand(players);

            }
            if (_player1.Hand.Count == 0 && _player2.Hand.Count == 0)
                StartNewRound();
            PlayTurn();
        }
    }

    private void EndOfHand()
    {
        Player[] players = { _player1, _player2 };
        GiveCardsInTableToLastWinner(players);
        _view.CardsWonByPlayer(players);
        _pointsCounter.AssignPoints(players);
        _view.PointsWonByPlayer(players);
    }

    private bool CheckPoints(Player[] players)
    {
        if (players[0].Points >= 16 || players[1].Points >= 16)
        {
            GameFinished(players);
            return true;
        }
        
        return false;
    }

    private void GameFinished(Player[] players)
    {
        if (players[0].Points > players[1].Points)
            PlayerWin(players[0]);
        
        else if (players[0].Points < players[1].Points)
            PlayerWin(players[1]);
        
        else
            PlayersTie();
    }

    private void PlayerWin(Player player)
    {
        _view.AnnounceWinner(player);
    }

    private void PlayersTie()
    {
        _view.AnnounceTie();
    }

    private void GiveCardsInTableToLastWinner(Player[] players)
    {
        foreach (var player in players)
        {
            if (player.Id == _lastPlayerToWinCards)
            {
                player.AddCardsToWonCards(_cardsInTable.GetCardsInTable());
                return;
            }
        }
    }

    private void NextHand(Player[] players)
    {
        foreach (var player in players)
            player.ResetWonCards();

        _cardsInTable.ResetWonCards();
        _deck.PrepareDeck();
        GiveCardsToPlayers();
        PlaceInitialCardsOnTable();
        CheckStartOfHandBroom();
    }

    private void CheckStartOfHandBroom()
    {
        List<Card> cardsInTable = _cardsInTable.GetCardsInTable();
        List<List<Card>> validCombinations = _cardChecker.GetCombinationsThatSum15(cardsInTable);
        
        
        if (_player1.Id != _currentPlayerTurn)
        {
            
        }
    }

    private void CheckIfThereIsInitialBroom(List<List<Card>> validCombinations)
    {
        CheckInitialBroomOfFourCards(validCombinations);
    }

    private void CheckInitialBroomOfFourCards(List<List<Card>> validCombinations)
    {
        foreach (var combination in validCombinations)
        {
            if (combination.Count == 4)
            {
                
            }
        }
    }

    private void PlaceInitialCardsOnTable()
    {
        _deck.PlaceCardInTable(_cardsInTable);
    }

    private void StartNewRound()
    {
        _view.AnnounceNewRound();
        GiveCardsToPlayers();
        ChangeTurn();
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
                wonCards = validCombinations[0];
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
            _view.NoCombinationSums15();
    }

    private void PlayerGetsCards(Player player, List<Card> cards)
    {
        _cardsInTable.RemoveCardsFromTable(cards);
        player.AddCardsToWonCards(cards);
        UpdateLastPlayerToWinCards(player);
    }

    private void UpdateLastPlayerToWinCards(Player player)
    {
        _lastPlayerToWinCards = player.Id;
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