using Helpers;
using System;
using System.Net.Http.Headers;

namespace Behaviours
{
    class GameStateController : BaseStateController, IEventListener<ChangeGameStateEvent>,
        IEventSubscription, IDisposable
    {
        private IState _menuState;
        private IState _pauseState;
        private IState _gameState;
        private IState _loadGameState;
        private IState _exitGameState;
        private IState _endLevelState;

        public GameStateController()
        {
            InitializeStates();
            StartState(MenuState);
            Subscribe();
        }
        public void Dispose()
        {
            Unsubscribe();
        }

        public IState MenuState => _menuState;
        public IState PauseState => _pauseState;
        public IState GameState => _gameState;
        public IState LoadGameState => _loadGameState;
        public IState ExitGameState => _exitGameState;
        public IState EndLevelState => _endLevelState;

        protected override void InitializeStates()
        {
            _menuState = new MenuState(this);
            _pauseState = new PauseState(this);
            _gameState = new GameState(this);
            _loadGameState = new LoadGameState(this);
            _exitGameState = new ExitGameState(this);
            _endLevelState = new EndLevelState(this);
        }


        public void OnEventTrigger(ChangeGameStateEvent eventType)
        {
            switch (eventType.NextGameState)
            {
                case GameStateType.None:
                    throw new System.Exception("State is unknown");
                case GameStateType.ManuState:
                    ChangeState(_menuState);
                    break;
                case GameStateType.GameState:
                    ChangeState(_gameState);
                    break;
                case GameStateType.PauseState:
                    ChangeState(_pauseState);
                    break;
                case GameStateType.LoadGameState:
                    ChangeState(_loadGameState);
                    break;
                case GameStateType.ExitGameState:
                    ChangeState(_exitGameState);
                    break;
                    case GameStateType.EndLevelState:
                    ChangeState(_endLevelState);
                    break;
            }
        }

        public void Subscribe()
        {
            this.EventStartListening<ChangeGameStateEvent>();
        }

        public void Unsubscribe()
        {
            this.EventStopListening<ChangeGameStateEvent>();
        }
    }
}