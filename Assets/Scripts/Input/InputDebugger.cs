using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class InputDebugger : MonoBehaviour
    {
        [SerializeField] private InputEvents inputEvents;

        private void OnEnable()
        {
            inputEvents.OnMoveEvent += OnAxisEvent;
            inputEvents.OnJumpEvent += OnButtonEvent;
            inputEvents.OnSprintEvent += OnButtonEvent;
            inputEvents.OnAction1Event += OnButtonEvent;
            inputEvents.OnAction2Event += OnButtonEvent;
        }

        private void OnDisable()
        {
            inputEvents.OnMoveEvent -= OnAxisEvent;
            inputEvents.OnJumpEvent -= OnButtonEvent;
            inputEvents.OnSprintEvent -= OnButtonEvent;
            inputEvents.OnAction1Event -= OnButtonEvent;
            inputEvents.OnAction2Event -= OnButtonEvent;
        }

        private void OnButtonEvent(InputAction.CallbackContext context)
        {
            string actionName = context.action.name;
            Debug.Log($"Button pressed: {actionName}, phase: {context.phase.ToString()}");
        }

        private void OnAxisEvent(InputAction.CallbackContext context, Vector2 value)
        {
            string actionName = context.action.name;
            Debug.Log($"Axis event: {actionName}, axisValue: {value}");
        }
    }
}
