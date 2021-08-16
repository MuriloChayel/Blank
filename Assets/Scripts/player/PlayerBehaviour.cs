using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    private float vel = 0.02f;
    public Rigidbody2D rb;

    public float coolDownSteps;
    public float timeBump;
    //trocar os passos
    public bool first;
    public bool BumpCntr;

    private Animator an;

    [SerializeField] private Vector2 direction;

    public AudioSource audioSource;
    /*
        0 - concreto
        1 - madeira
        2 - tecido
        3 - bump
    */
    [SerializeField] 
    private AudioClip[] clips;

    bool controller = false;

    private void Start()
    {
        an = GetComponent<Animator>();
    }
    private void Update()
    {
        Animations();
        if(!controller && direction != Vector2.zero && !BumpCntr)
        {
            controller = true;
            StartCoroutine(WalkCoroutine());
        }
    }
    void FixedUpdate()
    {
        Movement();
    }
    void Movement()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = vel * direction.normalized;   
    }
    //AUDIO SETUP
    void Walk(AudioClip clip)
    {
        if(clip != audioSource.clip)
            audioSource.clip = clip;
        
        audioSource.Play();
    }
    private IEnumerator WalkCoroutine()
    {
        first = !first;

        if (direction != Vector2.zero)
        {
            Walk(first? clips[0] : clips[1]);
        }
        yield return new WaitForSeconds(coolDownSteps);

        controller = false;
    }
    IEnumerator BumpController()
    {
        audioSource.clip = clips[3];
        audioSource.Play();
        yield return new WaitForSeconds(timeBump);
        BumpCntr = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!BumpCntr && collision.transform.tag == "walls")
        {
            BumpCntr = true;
            StartCoroutine(BumpController());
        }
    }
    public void Animations()
    {
        if(direction == Vector2.zero)
        {
            an.SetFloat("x", 0);
        }
        else if(direction.y != 0)
        {
            an.SetFloat("x", 1);
        }
        if(direction.x != 0)
        {
            an.SetFloat("x", -1);
            SetDirectionScale();
        }
    }
    private void SetDirectionScale()
    {
        transform.localScale = direction.x > 0 ? transform.localScale = new Vector3(-.7f, .7f, 1) : direction.x < 0 ? 
            new Vector3(.7f, .7f, 1) : transform.localScale;
    }
}
