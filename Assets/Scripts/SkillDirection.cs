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
    private TimeDilation td;

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
        Time.timeScale += Time.unscaledDeltaTime * (1f / td.dilationTimerInRealtimeSeconds);
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }

    public void faceMouse()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y);

        transform.up = direction;
        transform.Rotate(Vector2.up, -turnSpeed * Time.deltaTime);

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
        // TODO: cooldown timer/min charge?
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))  
        {
            sliderFloat += Time.unscaledDeltaTime * chargeSpeed;
        }
        
        if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))
        {
            sliderFloat = 0;
        }

        return sliderFloat;
    }
}
