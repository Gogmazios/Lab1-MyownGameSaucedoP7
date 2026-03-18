using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PreyControl : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5f;
    public float HP;
    public float maxHP = 3;
    public GameObject enemy;
    public GameObject player;

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
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, wayPoint) < range)
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

        if (wayPoint.x < transform.position.x)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }


    }


   // private void OnTriggerEnter(Collider2D collision)
   // {
    //    if (collision.gameObject.CompareTag("Player"))
   //     {
    //        HP -= 1;

   //         if (HP <= 0)
    //        {
   //             Destroy(gameObject);
   //         }
   //     }
      

    
  //  }

} 