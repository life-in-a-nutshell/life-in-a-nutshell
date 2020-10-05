using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeLog : MonoBehaviour
{
    public GameObject treeLogPrefab;
    Rigidbody2D rb;
    public float startForce = 15f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D col)   
    {        
        if (col.tag == "Chainsaw")
        {
            //Vector2 direction = (col.transform.position - transform.position).normalized;
            //Quaternion rotation = Quaternion.LookRotation(direction);
            GameObject treeLog = Instantiate(treeLogPrefab, transform.position, transform.rotation);
            Destroy(treeLog, 3f);
            Destroy(gameObject);
        }
    }
}
