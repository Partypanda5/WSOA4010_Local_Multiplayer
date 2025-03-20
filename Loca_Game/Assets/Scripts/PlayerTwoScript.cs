using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTwoScript : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeedAgain = 5f;
    public float jumpForce = 7f;
    private Vector3 cubeDirection;
    private Rigidbody rb;
    private Animator anim; //this

    [Header("Shooting Settings")]
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float projectileSpeed = 10f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>(); //this
    }

    private void Start()
    {
        if (gameObject.name == "PlayerTwo")
        {
            GetComponent<PlayerInput>().SwitchCurrentControlScheme("Keyboard02", Keyboard.current);
        }
    }


    public void MovePlayerTwo(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Vector2 playerInput = ctx.ReadValue<Vector2>();
            cubeDirection.x = playerInput.x;
            cubeDirection.z = playerInput.y;
        }
        else if (ctx.canceled)
        {
            cubeDirection = Vector2.zero;
        }
    }

    public void JumpPlayerTwo (InputAction.CallbackContext ctx)
    {
        if (ctx.performed && Mathf.Abs(rb.linearVelocity.y) < 0.01f) // Ensures jumping only when on the ground
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetTrigger("Jump"); //this
        }
    }

    public void ShootPlayerTwo(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
            Rigidbody projRb = projectile.GetComponent<Rigidbody>();
            projRb.linearVelocity = transform.right * projectileSpeed; // Shoots in the forward direction

            Destroy(projectile, 3f); // Destroy the projectile after 3 seconds
        }
    }

    private void Update()
    {
        Vector3 movement = new Vector3(cubeDirection.x, 0, cubeDirection.z) * moveSpeedAgain * Time.deltaTime;
        transform.Translate(movement);
    }
}
