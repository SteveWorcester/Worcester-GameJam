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
    // test area



    void Start()
    {
        slider = GetComponent<Slider>();
        faceMouse();
    }

    void Update()
    {
        faceMouse();
        MoveToCharacter();
        GetChargeLevel();
        slider.value = sliderFloat;  //update slider value with current charge value
        text.text = ("slider value = " + slider.value.ToString() + "\n " + "Mouse Position = " + Camera.main.ScreenToViewportPoint(Input.mousePosition) + "\n" + "Player position = " + player.transform.position + "\n");
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
        transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
    }

    public void MoveToCharacter()  //Make the slider move on top of the player?
    {
        transform.position = player.transform.position;
    }

    public void GetChargeLevel()  //only builds and releases charge value.
    {
        //let it charge up when jump is pressed
        if (Input.GetMouseButton(0))  //don't forget a cooldown timer, or maybe a minimum charge level to restrict use?
        {
            sliderFloat += Time.deltaTime * chargeSpeed;
        }
        
        //make something happen when jump is released, based on the charge value
        if (Input.GetMouseButtonUp(0))
        {
            sliderFloat = 0;
        }
    }
}
