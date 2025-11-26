using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour
{
    public float moveforward = 5f;
    public float moveside = 2f;
    public float jumpforce = 5f;
    Rigidbody rb;
    public RestartGame uiManager;
    public GameObject ragdollPrefab;
    public Transform spawnPoint;
    public float explosionForce = 500f;
    public float explosionRadius = 3f;


    public Transform groundcheck;
    public float grounddistance = 0.2f;
    public LayerMask groundlayer;
    private bool isgrounded;
    private bool jumprequest = false;
    private bool wasGrounded;

  
    private Quaternion targetrotation;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {
          jumprequest = true;
            targetrotation = transform.rotation * Quaternion.Euler(179.09f, 0f, 0f);
        }
    }

    private void FixedUpdate()
    {
        
        isgrounded = Physics.CheckSphere(groundcheck.position, grounddistance, groundlayer);
        float moveX = Input.GetAxis("Horizontal");

        Vector3 newVelocity = new Vector3(moveX * moveside, rb.linearVelocity.y, moveforward);



        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -2f, 2f);
        transform.position = clampedPosition;

        if (isgrounded && wasGrounded && jumprequest == true)
        {
            newVelocity.y = jumpforce;
          
            jumprequest = false;
            
        }
        rb.linearVelocity = newVelocity;

        wasGrounded = isgrounded;

        Debug.Log($"IsGrounded: {isgrounded} | GroundCheck Pos: {groundcheck.position}");

        if (!isgrounded && jumprequest == false)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation,targetrotation,4f * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trap"))
        {
            

            uiManager.FadeAndRestart();
            GameObject ragdoll = Instantiate(ragdollPrefab, transform.position, Quaternion.identity);

            
            foreach (Rigidbody part in ragdoll.GetComponentsInChildren<Rigidbody>())
            {
                part.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }

           
            Destroy(gameObject);
        }
    }
    private void LateUpdate()
    {
    

        if (transform.position.z > 300f && transform.position.z < 550)
        {
            jumpforce = 12f;
        }
        else
        {
            jumpforce = 6.5f;
        }
    }
}
