using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace GameManagement
{
    public class GameStateMachine : Singleton<GameStateMachine>
    {
        [SerializeField] private GameState initialGameState;

        private GameState _currentGameState;
        public Dictionary<string, GameState> States { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            States = new Dictionary<string, GameState>();
            foreach (GameState state in GetComponentsInChildren<GameState>())
            {
                States.Add(state.name, state);
            }
        }

        private void Start()
        {
            ChangeState(initialGameState);
            _currentGameState.EnterState();
        }

        public void ChangeState(GameState newState)
        {
            _currentGameState?.ExitState();
            _currentGameState = newState;
            _currentGameState.EnterState();
        }
    }
}
