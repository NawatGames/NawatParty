using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    private GameObject target;
    [SerializeField] private RhythmEnemy _rhythmEnemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = this.gameObject;
        StartCoroutine(UpdateCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.deltaTime + ": " + _rhythmEnemy.getRunning());
        if (_rhythmEnemy.getRunning())
        {
            _rhythmEnemy.activateSpell(target);
        }
    }

    private IEnumerator UpdateCoroutine()
    {
        yield return new WaitForSecondsRealtime(2);
        _rhythmEnemy.spawnSpell();
        yield return new WaitForSecondsRealtime(4);
        _rhythmEnemy.isRunning(true);
    }
    
        private void OnTriggerEnter(Collider other)
    {
        _rhythmEnemy.destroySpell();
    }
}
