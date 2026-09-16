using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using TMPro;


public class PlayerController : MonoBehaviour
{
    private int count;
    private Rigidbody rb;
    private int playerLayer;
    private int obstacleLayer;

    private float movementX;
    private float movementY;
    
    // Variables for items
    private Vector3 originalScale; 
    private float originalSpeed;
    private bool isInvincible = false;
    private Renderer playerRenderer;
    private Color originalColor;

    public float speed = 0;

    public TextMeshProUGUI countText;
    public GameObject winTextObject;


    public Vector3 originalpos = new Vector3(0, 10, 0); // original position of player, for respawn

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()    // called on first frame
    {
        rb = GetComponent<Rigidbody>();
        playerLayer = LayerMask.NameToLayer("Player");
        obstacleLayer = LayerMask.NameToLayer("Obstacles");
        count = 0;
        originalScale = transform.localScale; 
        originalSpeed = speed;
        playerRenderer = GetComponent<Renderer>();
        originalColor = playerRenderer.material.color;
        SetCountText();
        winTextObject.SetActive(false);  
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>(); // gets 2D vector from input
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    
    void FixedUpdate()  // called just before physics. Put physics code here.
    {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY); //movementX is the x-axis, movementY is the z-axis
        rb.AddForce(movement * speed);
    }
    
    void Update()
    {
        if (transform.position.y < -5) 
        {
            transform.position = originalpos;
            rb.linearVelocity = Vector3.zero; 
        }
    }
    void OnTriggerEnter(Collider other) //called when player colliders with trigger
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);      //deactivates object that player collides with
            count ++;                         
            SetCountText();                             
        }

        // Sizeup
        else if (other.gameObject.CompareTag("SizeUp"))
        {
            // Increase ball's size for 10 seconds
            StartCoroutine(SizeUp());
            other.gameObject.SetActive(false);      
        }

        // Speedup
        else if (other.gameObject.CompareTag("SpeedUp"))
        {
            // Increase ball's speed for 10 seconds
            StartCoroutine(SpeedUp());
            other.gameObject.SetActive(false);      
        }

        // shield
        else if (other.gameObject.CompareTag("Shield"))
        {
            // Make player invincible for 10 seconds
            StartCoroutine(Invincibility());
            other.gameObject.SetActive(false);      
        }
        
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();  
        if (count >= 8)
        {
            winTextObject.SetActive(true);
            GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
            if (enemy != null)
            {
                enemy.SetActive(false);    
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false); // Deactivate player instead of destroying it to avoid errors
            winTextObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
            
        }
    }

    IEnumerator SizeUp()
    {
        transform.localScale = originalScale * 1.5f;
        yield return new WaitForSeconds(10f);
        transform.localScale = originalScale;
    }

    IEnumerator SpeedUp()
    {
        speed = originalSpeed * 2f;
        yield return new WaitForSeconds(10f);
        speed = originalSpeed;
    }

    IEnumerator Invincibility()
    {
        isInvincible = true;
        playerRenderer.material.color = Color.black; 
        Physics.IgnoreLayerCollision(playerLayer, obstacleLayer, true);
        yield return new WaitForSeconds(10f);
        playerRenderer.material.color = originalColor;
        Physics.IgnoreLayerCollision(playerLayer, obstacleLayer, false);
        isInvincible = false;
    }



}
