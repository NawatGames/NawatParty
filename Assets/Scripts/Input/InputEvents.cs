using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class InputEvents : MonoBehaviour
    {
        public delegate void AxisEvent(InputAction.CallbackContext context, Vector2 axis);
        public delegate void ButtonEvent(InputAction.CallbackContext context);

        public event AxisEvent OnMoveEvent;

        /// <summary>
        /// Input button event
        /// <para> Controller: South button </para>
        /// <para> Keyboard: H Key </para>
        /// </summary>
        public event ButtonEvent OnAction1Event;

        /// <summary>
        /// Input button event
        /// <para> Controller: West button </para>
        /// <para> Keyboard: J Key </para>
        /// </summary>
        public event ButtonEvent OnAction2Event;

        /// <summary>
        /// Input button event
        /// <para> Controller: East button </para>
        /// <para> Keyboard: K Key </para>
        /// </summary>
        public event ButtonEvent OnAction3Event;

        /// <summary>
        /// Input button event
        /// <para> Controller: South button </para>
        /// <para> Keyboard: L Key </para>
        /// </summary>
        public event ButtonEvent OnAction4Event;

        public void OnMove(InputAction.CallbackContext context){
            Vector2 axis = context.ReadValue<Vector2>();
            OnMoveEvent?.Invoke(context, axis);
        }

        public void OnAction1(InputAction.CallbackContext context)
        {
            OnAction1Event?.Invoke(context);
        }

        public void OnAction2(InputAction.CallbackContext context)
        {
            OnAction2Event?.Invoke(context);
        }

        public void OnAction3(InputAction.CallbackContext context)
        {
            OnAction3Event?.Invoke(context);
        }

        public void OnAction4(InputAction.CallbackContext context)
        {
            OnAction4Event?.Invoke(context);
        }
    }
}
