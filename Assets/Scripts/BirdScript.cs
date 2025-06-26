using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class BirdScript : MonoBehaviour, Birdcontrol.IBirdActions
{

    public float flyStrength = 13f;
    public float birdSize = 0.55f;
    private Birdcontrol controls;
    private LogicScript logicScript;

    public Animator animator;


    private bool isAlive = true;

    void Start()
    {
        transform.localScale = new Vector3(birdSize, birdSize, birdSize);
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        flyStrength = 13f;
        isAlive = true;
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.right * 20;
    }

    public void IncreaseSize(float Scale)
    {
        birdSize *= Scale;
        transform.localScale = new Vector3(birdSize,birdSize,birdSize);
    }

    void Awake()
    {
        controls = new Birdcontrol();
        controls.Bird.SetCallbacks(this);
    }

    void OnEnable()
    {
        controls.Bird.Enable();
    }

    void OnDisable()
    {
        controls.Bird.Disable();
    }

    public void OnFly(InputAction.CallbackContext context)
    {
        if (context.performed && isAlive)
        {
            GetComponent<Rigidbody2D>().linearVelocity = Vector2.up * flyStrength;
        }

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        isAlive = false;
        animator.SetBool("isAlive", false);
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.left * 10;
        logicScript.GameOver(); 
    }
}
