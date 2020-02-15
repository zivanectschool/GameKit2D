using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_HeavenBOSSS : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private GameObject[] spawners;

    [SerializeField]
    private int health;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float speed;


    private float waitTime;
    private float chargeTime;

    private float index = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        spawners = GameObject.FindGameObjectsWithTag("Spawn");

        int rand = UnityEngine.Random.Range(0, spawners.Length);

        transform.position = spawners[rand].transform.position + new Vector3(0.0f, 5.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = player.transform.position;

        if (waitTime <= 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            waitTime = chargeTime;;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }

        if (health <= 0)
        {
            SceneManager.LoadScene("JonasScene");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            DecreaseHealth(1);
        }
        else if (collision.gameObject.CompareTag("Ellen"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void DecreaseHealth(int index)
    {
        health -= 1;
    }
}
