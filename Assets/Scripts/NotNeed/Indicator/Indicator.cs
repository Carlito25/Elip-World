using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public GameObject IndicatorObject;
    public GameObject Target;
    private Renderer rb;
    void Start()
    {
        rb = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.isVisible == false)
        {
            if (!IndicatorObject.activeSelf)
            {
                Debug.Log("1");
                IndicatorObject.SetActive(true);
            }

            Vector2 direction = Target.transform.position - transform.position;
            RaycastHit2D ray = Physics2D.Raycast(transform.position, direction);
            if (ray.collider != null)
            {
                Debug.Log("3");
                IndicatorObject.transform.position = ray.point;
            }
        }
        else
        {
            if (IndicatorObject.activeSelf)
            {
                Debug.Log("2");
                IndicatorObject.SetActive(false);
            }
        }
    }

}

