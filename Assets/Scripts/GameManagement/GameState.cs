using UnityEngine;
using UnityEngine.Events;

namespace GameManagement
{
    public class GameState : MonoBehaviour
    {
        public UnityEvent onStateEnter;
        public UnityEvent onStateExit;

        public virtual void EnterState()
        {
            onStateEnter.Invoke();
        }

        public virtual void ExitState()
        {
            onStateExit.Invoke();
        }
    }
}
