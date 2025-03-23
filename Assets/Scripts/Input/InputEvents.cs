using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class InputEvents : MonoBehaviour
    {
        public delegate void AxisEvent(InputAction.CallbackContext context, Vector2 axis);
        public delegate void ButtonEvent(InputAction.CallbackContext context);

        public event AxisEvent OnMoveEvent;
        public event ButtonEvent OnJumpEvent;
        public event ButtonEvent OnSprintEvent;
        public event ButtonEvent OnAction1Event;
        public event ButtonEvent OnAction2Event;

        public void OnMove(InputAction.CallbackContext context){
            Vector2 axis = context.ReadValue<Vector2>();
            OnMoveEvent?.Invoke(context, axis);
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            OnJumpEvent?.Invoke(context);
        }

        public void OnSprint(InputAction.CallbackContext context)
        {
            OnSprintEvent?.Invoke(context);
        }

        public void OnAction1(InputAction.CallbackContext context)
        {
            OnAction1Event?.Invoke(context);
        }

        public void OnAction2(InputAction.CallbackContext context)
        {
            OnAction2Event?.Invoke(context);
        }
    }
}
