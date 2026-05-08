using UnityEngine;

public enum Direction
{
    Left,
    Right
}
public class FireColumn : Damage
{
    Rigidbody2D rb;
    public Direction dir;
    [SerializeField] float speed;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Debug.Log(transform.rotation);
        rb.linearVelocity = (transform.right * speed) * Time.fixedDeltaTime;
        if(transform.rotation.y == 0 && transform.position.x >= AttackSequence.Instance.fireCSpawn[1].position.x)
        {
            gameObject.SetActive(false);
        }
        if(transform.rotation.y == 1 && transform.position.x <= AttackSequence.Instance.fireCSpawn[0].position.x)
        {
            gameObject.SetActive(false);
        }
    }
}
