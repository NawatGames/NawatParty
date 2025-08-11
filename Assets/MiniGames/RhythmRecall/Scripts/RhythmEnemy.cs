using System;
using System.Collections;
using UnityEngine;

public class RhythmEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemySpell;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private Quaternion spawnRotation;

    [SerializeField] private float spellSpeed = 1.0f;

    [SerializeField] private float spellAceleration = 2.0f;
    private Boolean running = false;
    private GameObject spell;
    private GameObject enemy;

    private Rigidbody rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemy = this.gameObject;
        rb = enemySpell.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnSpell()
    {
        spawnPosition = new Vector3(enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z);
        spell = Instantiate(enemySpell, spawnPosition, spawnRotation);
    }

    public void activateSpell(GameObject target)
    {
        this.spell.transform.position = Vector3.MoveTowards(spell.transform.position, target.transform.position, spellSpeed * Time.deltaTime);
        this.spellSpeed += spellAceleration;
    }

    public void isRunning(Boolean running)
    {
        this.running = running;
    }

    public Boolean getRunning()
    {
        return running;
    }

    public ref GameObject returnSpell()
    {
        return ref spell;
    }

    public void destroySpell()
    {
        Destroy(spell);
        isRunning(false);
    }
    

}
