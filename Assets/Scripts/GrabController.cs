using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrabController : MonoBehaviour
{
    PlayerInputs inputs;

    public Transform grabDetect;
    public Transform holder;
    public float rayDist;
    public bool grabbed;
    public RaycastHit2D grabCheck;


    private void Awake()
    {
        inputs = new PlayerInputs();

        inputs.Player.Interact.performed += ctx => Grab();
    }

    
    // Start is called before the first frame update
    void Start()
    {
        grabbed = false;
    }

    private void OnEnable()
    {
        inputs.Player.Enable();
    }

    private void OnDisable()
    {
        inputs.Player.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.down, rayDist);

        
    }

    public void Grab()
    {
        if (grabCheck.collider != null && grabCheck.collider.tag == "Lantern")
        {
            if (!grabbed)
            {
                grabCheck.collider.gameObject.transform.parent = holder;
                grabCheck.collider.gameObject.transform.position = holder.position;
                Destroy(grabCheck.collider.gameObject.GetComponent<Rigidbody2D>());
                grabCheck.collider.gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                //grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbed = true;
            }
            else if (grabbed)
            {
                transform.GetChild(2).localScale =
                new Vector3(Mathf.Abs(transform.GetChild(2).localScale.x), transform.GetChild(2).localScale.y, transform.GetChild(2).localScale.z);

                grabCheck.collider.gameObject.transform.parent = null;
                //grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                grabCheck.collider.gameObject.AddComponent<Rigidbody2D>();
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
                grabbed = false;
            }
        }
    }

    


}
