using UnityEngine;

namespace GameManagement.StateScripts
{
    public class StateScript : MonoBehaviour
    {
        [SerializeField] private GameState state;
        protected virtual void OnEnable()
        {
            state.onStateEnter.AddListener(OnStateEnter);
            state.onStateExit.AddListener(OnStateExit);
        }

        protected virtual void OnDisable()
        {
            state.onStateEnter.RemoveListener(OnStateEnter);
            state.onStateExit.RemoveListener(OnStateExit);
        }

        protected virtual void OnStateEnter()
        {

        }

        protected virtual void OnStateExit()
        {

        }
    }
}
