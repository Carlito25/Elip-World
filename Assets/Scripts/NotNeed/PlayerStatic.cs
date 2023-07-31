using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatic : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Finish")
        {
            Invoke("FreezePosition", .5f);
        }

    }
    public void FreezePosition()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
    }
    public void Dynamic()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
