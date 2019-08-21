using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField]
    private float torque;
    [SerializeField]
    private float speed;


    private Rigidbody2D rb2d;
    private Renderer rend;

    [SerializeField]
    public GameObject projectile;
    public float fireDelta = 0.5f;

    private float nextFire = 0.5f;
    private float myTime = 0.0f;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);

        pos.x = Mathf.Clamp(pos.x, 0, Screen.width - rend.bounds.size.x);
        pos.y = Mathf.Clamp(pos.y, 0, Screen.height - rend.bounds.size.y);

        transform.position = Camera.main.ScreenToWorldPoint(pos);

        // It would also be possible to change the transform, instead of using physics/rigidbody:

        // Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        // pos.x = Mathf.Clamp01(pos.x);
        // pos.y = Mathf.Clamp01(pos.y);
        // transform.position = Camera.main.ViewportToWorldPoint(pos);
        // Vector2 position = transform.position;
        // position.x = position.x + 0.1f * horizontal * Time.deltaTime;
        // position.y = position.y + 0.1f * vertical * Time.deltaTime;
        // transform.position = position;

        myTime = myTime + Time.deltaTime;

        if (Input.GetKey(KeyCode.Mouse0) && myTime > nextFire)
        {
            nextFire = myTime + fireDelta;
            
            GameObject newProjectile = Instantiate(projectile, transform.position, transform.rotation);
            Projectile bullet = newProjectile.GetComponent<Projectile>();

            Vector3 direction = transform.up;
            bullet.Fire(new Vector2(direction.x, direction.y));

            nextFire = nextFire - myTime;
            myTime = 0.0f;
        }
    }

    void FixedUpdate()
    {
        // Sustained input, so should be okay. See https://www.reddit.com/r/Unity3D/comments/7267yi/player_inputs_update_or_fixedupdate/
        float turn = Input.GetAxis("Horizontal");
        float thrust = Input.GetAxis("Vertical");

        rb2d.AddTorque(turn * torque * Time.deltaTime);
        rb2d.AddForce(transform.up * thrust * speed * Time.deltaTime);
    }
}
