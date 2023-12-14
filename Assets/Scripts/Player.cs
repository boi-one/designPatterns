using System.Linq;
using UnityEngine;

/*
 *TODO:input system,
 * code meer generic
 */

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


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
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
            Debug.Log("Bruh");
            bulletCooldown = Time.time + cooldownTime;
            
            Debug.Log(ManagePools.bulletPool.active.Count);
            Debug.Log(ManagePools.bulletPool.inactive.Count);
            
            if (ManagePools.bulletPool.inactive.Count == 0) return;
            IPoolObject currentBullet = ManagePools.bulletPool.inactive[0];
            ManagePools.bulletPool.active.Add(currentBullet);
            ManagePools.bulletPool.inactive.Remove(currentBullet);
            currentBullet.SetObjectActive();
            Debug.Log(currentBullet.body.GetComponent<Rigidbody2D>().velocity);
        }
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
