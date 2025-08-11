using UnityEngine;
using UnityEngine.InputSystem.Utilities;

public class Spell_IdleAnimation : MonoBehaviour
{
    float positionY = 0.001F;
    float checkValue = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = new Vector3(transform.position.x, transform.position.y + positionY, transform.position.z);
        transform.position = position;
        checkValue = checkValue + positionY;
        if (checkValue >= 0.1 || checkValue <= -0.1)
        {
            positionY = -positionY;
        }
    }
}
