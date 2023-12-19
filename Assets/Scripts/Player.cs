using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public GameObject mouse;
    public static Vector2 mousePosition;
    public static Vector2 playerPosition;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    public float jumpforce;
    public float movementSpeed;
    private float bulletCooldown = 0f;
    private float cooldownTime = .15f;
    public static Vector3 screenBorder;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        screenBorder = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));
        playerPosition = transform.position;
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mouse.transform.position = mousePosition;
            
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
            Jump();
        if(Input.GetKey(KeyCode.A))
            Move(new Vector2(-1, 0));
        if(Input.GetKey(KeyCode.D))
            Move(new Vector2(1, 0));
        if ((Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) && isGrounded)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > bulletCooldown)
        {
            
        }
    }

    public static Vector2 GetDirection(Vector2 playerPosition)
    {
        return (mousePosition - new Vector2(playerPosition.x, playerPosition.y)).normalized;
    }

    void Move(Vector2 movement)
    {
        rb.velocity = new Vector2(movement.x * movementSpeed, rb.velocity.y);
    }
    public void Jump()
    {
        isGrounded = false;
        rb.AddForce(new Vector2(0, 1) * jumpforce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        isGrounded = true;
    }
}
