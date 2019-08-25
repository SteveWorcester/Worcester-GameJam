using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillDirection : MonoBehaviour
{
    public Slider slider;
    public PlayerPlatformerController player;
    private float turnSpeed = 1;
    public float sliderFloat;
    public float chargeSpeed = 1.75f;
    public Text text;
    public (float x, float y) mouseCoordinates;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        faceMouse();
        MoveToCharacter();
        GetChargeLevel();
        slider.value = sliderFloat;
        text.text = ("slider value = " + slider.value.ToString() + "\n " + "Mouse Position = " + Camera.main.ScreenToViewportPoint(Input.mousePosition) + "\n" + "Player position = " + player.transform.position + "\n");
    }

    public void faceMouse()
    {
        // Working off of main camera here. This may need to change when skills are implemented to work from incoming gameObject (or maybe original mouse cursor point?).
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y);

        transform.up = direction;
        transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

        mouseCoordinates = (mousePosition.x, mousePosition.y);
    }

    public void MoveToCharacter()
    {
        transform.position = player.transform.position;
    }

    /// <summary>
    /// Builds and releases charge value.
    /// </summary>
    /// <returns>sliderFloat Charge Level</returns>
    public float GetChargeLevel()
    {
        if (Input.GetMouseButton(0))  //don't forget a cooldown timer, or maybe a minimum charge level to restrict use?
        {
            sliderFloat += Time.deltaTime * chargeSpeed;
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            sliderFloat = 0;
        }

        return sliderFloat;
    }
}
