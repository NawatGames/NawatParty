using UnityEngine;
using UnityEngine.Events;

namespace Generic
{
    [RequireComponent(typeof(Collider))]
    public class TriggerCounter : MonoBehaviour
    {
        [SerializeField] private string objectTag;

        public int ObjectCount { get; private set; } = 0;
        public UnityEvent<int> onCountUpdate;

        private void OnTriggerEnter(Collider collider)
        {
            if (!collider.gameObject.CompareTag(objectTag)) return;
            ObjectCount++;
            onCountUpdate.Invoke(ObjectCount);
        }

        private void OnTriggerExit(Collider collider)
        {
            if (!collider.gameObject.CompareTag(objectTag)) return;
            ObjectCount--;
            onCountUpdate.Invoke(ObjectCount);
        }
    }
}
