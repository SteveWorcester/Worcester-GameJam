using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDirection : MonoBehaviour
{
    void Start()
    {
        faceMouse();
    }

    void Update()
    {
        faceMouse();
    }

    void faceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        // Working off of main camera here. This may need to change when skills are implemented to work from incoming gameObject (or maybe original mouse cursor point?).
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y);

        transform.up = direction;
    }
}
