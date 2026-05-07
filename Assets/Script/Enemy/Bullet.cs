using UnityEngine;

public class Bullet : Damage
{
    Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] int layerIndex;
    [SerializeField] int layerIndex2;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    new private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        GameObject CollObj;
        CollObj = other.gameObject;
        if (CollObj.layer== layerIndex) return;
        gameObject.SetActive(false);
    }
    private void FixedUpdate()
    {        
        rb.linearVelocity = (transform.up * speed) * Time.fixedDeltaTime;
    }
}
