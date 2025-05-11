using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace MiniGame
{
    public class MiniGameCountdown : MonoBehaviour
    {
        [SerializeField] private TMP_Text textMesh;

        public IEnumerator Countdown()
        {
            for (int i = 3; i > 0; i--)
            {
                textMesh.text = i.ToString();
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
