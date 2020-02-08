using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_HeavenBOSSS : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private GameObject[] spawners;

    [SerializeField]
    private int health;

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
        if (health <= 0) Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            DecreaseHealth(1);
        }
    }

    public void DecreaseHealth(int index)
    {
        health -= 1;
    }
}
