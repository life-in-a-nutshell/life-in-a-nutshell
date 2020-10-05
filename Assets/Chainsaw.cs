using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chainsaw : MonoBehaviour
{

    public GameObject sawTrailPrefab;
    public float minCuttingVelocity = 0.001f;
    bool isSawing = false;

    Vector2 previousPosition;

    GameObject currentSawTrail;

    Rigidbody2D rb;
    Camera cam;
    CircleCollider2D circleCollider;

    private void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //0 for Left Click
        {
            StartSawing();
        } else if (Input.GetMouseButtonUp(0))
        {
            StopSawing();
        }

        if (isSawing)
        {
            UpdateSaw();
        }
    }

    void UpdateSaw()
    {
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPosition;

        float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;
        if (velocity > minCuttingVelocity)
        {
            circleCollider.enabled = true;
        } else
        {
            circleCollider.enabled = false;
        }

        previousPosition = newPosition;
    }

    void StartSawing()
    {
        isSawing = true;
        currentSawTrail = Instantiate(sawTrailPrefab, transform);
        previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        circleCollider.enabled = false;

    }

    void StopSawing()
    {
        isSawing = false;
        currentSawTrail.transform.SetParent(null);
        Destroy(currentSawTrail, 2f);
        circleCollider.enabled = false;
    }
}
