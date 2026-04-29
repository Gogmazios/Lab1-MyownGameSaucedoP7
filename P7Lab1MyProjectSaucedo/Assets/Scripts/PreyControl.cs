using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UI;

public class PreyControl : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5f;
    public float HP;
    public float maxHP = 3;
    public GameObject enemy;
    public GameObject player;
    public GameObject Meat;
    // public float hungerValue = 50f;
    public int MeatAmount = 1;

    [SerializeField]
    float range;

    [SerializeField]
    float maxDistance;

    Vector2 wayPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetNewDestination();
        HP = maxHP;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(Vector2.MoveTowards(rb.position, wayPoint, speed * Time.fixedDeltaTime));

        if (Vector2.Distance(rb.position, wayPoint) < range)
        {
            SetNewDestination();
        }
    }

    void SetNewDestination()
    {
        wayPoint = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance));

        if (wayPoint.x > transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

        else if (wayPoint.x < transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            HP -= 1;

            if (HP <= 0)
            {
                Endlife();
            }
        }
    }

    void Endlife()
    {
        for (int i = 0; i < MeatAmount; i++)
        {
            Instantiate(Meat, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

}
