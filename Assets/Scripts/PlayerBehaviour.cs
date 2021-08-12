using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    private float vel = 0.02f;
    public Rigidbody2D rb;
    public Vector2 direção;

    void FixedUpdate()
    {
        Movement();
    }
    void Movement()
    {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = vel * direction.normalized;   
    }
}
