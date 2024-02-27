using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float ForwardForce;
    public float Horiforce;
    public float jump;
    //[SerializeField]bool onGround;
    [SerializeField]Vector3 velovity;
    [SerializeField] GameObject GameOver;
    float halfWidth = Screen.width / 2;
    float tophight = Screen.height* 0.7f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
         rb.velocity = new Vector3(0,0,8);
    }
    
 
    private void Update()
    {
        Debug.Log(Physics.gravity);
        if(transform.position.y>15) 
        {
            Physics.gravity =new Vector3(0, -100,0);
        }
        else
        {
            Physics.gravity = new Vector3(0, -9.8f, 0);
        }
        velovity=rb.velocity;
        rb.AddForce(Vector3.forward *Time.deltaTime* ForwardForce*Time.deltaTime, ForceMode.Acceleration);
        
        float key = Input.GetAxisRaw("Horizontal");
        if (key != 0)
        {
            if ((transform.position.x > 20) && (transform.position.x < 120))
            {
                rb.AddForce(Horiforce * Time.deltaTime * key, 0, 0, ForceMode.Impulse);
                //rb.velocity=new Vector3(key*xforce,rb.velocity.y,rb.velocity.z);
            }
        }


        var touch = Input.GetTouch(0);
        var touchPos = touch.position;

        if ((touchPos.x < halfWidth- Screen.width * 0.3)&&(touchPos.y<tophight))
        {
            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                if ((transform.position.x > 20) && (transform.position.x < 120))
                {
                    rb.AddForce(Horiforce * Time.deltaTime * -1, 0, 0, ForceMode.Impulse);

                }
            }
        }
        else if ((touchPos.x > halfWidth+ Screen.width*0.3)&& (touchPos.y < tophight))
        {
            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                if ((transform.position.x > 20) && (transform.position.x < 120))
                {
                    rb.AddForce(Horiforce * Time.deltaTime, 0, 0, ForceMode.Impulse);
                    //rb.velocity=new Vector3(key*xforce,rb.velocity.y,rb.velocity.z);
                }
            }
        }

        /*if (Input.GetKeyDown(KeyCode.Space)&&onGround)
        {
            onGround = false;
            rb.AddForce(Vector3.up * 10 * jump, ForceMode.Impulse);
        }*/



        if (transform.position.y < -5)
        {
            Time.timeScale = 0;
            GameOver.SetActive(true);
            Debug.Log("gameOver");
        }
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        onGround = true;
       
    }*/
    /*private void OnCollisionExit(Collision collision)
    {
        onGround = false;
    }*/
}
