using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeLog : MonoBehaviour
{
    public GameObject treeSawedPrefab;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D col)
    {        
        if (col.tag == "Chainsaw")
        {
            Instantiate(treeSawedPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
