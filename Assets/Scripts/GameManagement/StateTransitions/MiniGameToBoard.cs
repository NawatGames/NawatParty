using UnityEngine;

namespace GameManagement.StateTransitions
{
    public class MiniGameToBoard : StateTransition
    {
        [SerializeField] private MiniGameManager miniGameManager;
        private void OnEnable()
        {
            miniGameManager.onMiniGameEnd.AddListener(Transition);
        }

        private void OnDisable()
        {
            miniGameManager.onMiniGameEnd.RemoveListener(Transition);
        }
    }
}
