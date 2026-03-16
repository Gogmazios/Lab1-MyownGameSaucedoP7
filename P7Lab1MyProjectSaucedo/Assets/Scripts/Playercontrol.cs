
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Playercontrol : MonoBehaviour
{
    //control part of this code
    Rigidbody2D rb;
    float inputHorizontal;
    float inputVertical;
    public float speed = 10f;
    float speedX, speedY;

    //The long part of this code
    public float hunger; 
    public float maxHunger = 1000f;
    public float hungerDecreaseRate = 50f;
    public float maxhealth = 100f;
    public float healthDecreaseRate = 10f;

    public Slider hungerSlider;
    public Slider healthSlider;

    public Text hungerPercentageText;
    public Text healthPercentageText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hungerSlider.maxValue = maxHunger;
        healthSlider.maxValue = maxhealth;

      
        UpdatePercentageText();


        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseHunger(hungerDecreaseRate * Time.deltaTime);
        CheckIfDead();
        dieing();
        UpdateUI();

        if (maxHunger <= 0)
        {
            DecreaseHealth(healthDecreaseRate * Time.deltaTime);
        }

        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        speedX = Input.GetAxisRaw("Horizontal") * speed;
        speedY = Input.GetAxisRaw("Vertical") * speed;
        rb.linearVelocity = new Vector2(speedX, speedY); 

        if (inputHorizontal != 0)
        {
            rb.AddForce(new Vector2(inputHorizontal * speed, 0f));
        }

        
    }


    void FixedUpdate()
    {
       
        if (inputHorizontal > 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1); 
        }

        if (inputHorizontal < 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1); 
        }
    }

    void DecreaseHunger(float amount)
    {
        maxHunger -= amount;
        maxHunger = Mathf.Clamp(maxHunger, 0f, 1000f); 
    }

    void UpdateUI()
    {
        hungerSlider.value = maxHunger;
        healthSlider.value = maxhealth;

        UpdatePercentageText();
    }
    void DecreaseHealth(float amount)
    {
        maxhealth -= amount;
        maxhealth = Mathf.Clamp(maxhealth, 0f, 100f);
    }

    void UpdatePercentageText()
    {
        hungerPercentageText.text = $"Hunger: {Mathf.RoundToInt((maxHunger / 1000f) * 100)}%";
        healthPercentageText.text = $"Health: {Mathf.RoundToInt((maxhealth / 100f) * 100)}%";
    }

    void dieing()
    {
        if (maxHunger <= 0)
        {
            void DecreaseHealth(float amount)
            {
                maxhealth -= amount;
                maxhealth = Mathf.Clamp(maxhealth, 0f, 100f);
            }
        }
    }

    void CheckIfDead()
    {
        if (maxhealth <= 0)
        {
            Debug.Log("Game Over!");

            //LoadScene("GameOver"); 
        }
    }

    public void Collect(Meatpart collectible)
    {
        maxHunger += collectible.hungerValue;
        maxHunger = Mathf.Clamp(hunger, 0f, maxHunger);
        UpdateUI(); 

    }

}