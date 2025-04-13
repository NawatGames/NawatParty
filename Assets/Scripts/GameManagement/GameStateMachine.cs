using UnityEngine;
using Utils;

namespace GameManagement
{
    public class GameStateMachine : Singleton<GameStateMachine>
    {
        [SerializeField] private GameState initialGameState;

        private GameState _currentGameState;

        private void Start()
        {
            _currentGameState.EnterState();
        }

        private void ChangeState(GameState newState)
        {
            _currentGameState.ExitState();
            _currentGameState = newState;
            _currentGameState.EnterState();
        }
    }
}
