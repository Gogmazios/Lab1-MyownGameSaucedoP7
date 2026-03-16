using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class Meatpart : MonoBehaviour
{
    public float hungerValue = 25f;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player)
        {
            player.GetComponent<Playercontrol>().Collect(this); 
            Destroy(gameObject);
        }
    }







    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
