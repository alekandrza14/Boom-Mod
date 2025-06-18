using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fristPersonControler : MonoBehaviour
{
    public Rigidbody rb;
    public Collider col;
    public GameObject[] g;
    bool noClip;
    float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.useGravity = !noClip;
        rb.isKinematic = noClip;
        if (noClip)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += g[1].transform.forward * speed * Time.deltaTime * 20;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position -= g[1].transform.forward * speed * Time.deltaTime * 20;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += g[1].transform.right * speed * Time.deltaTime * 20;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= g[1].transform.right * speed * Time.deltaTime * 20;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                transform.position += g[1].transform.up * speed * Time.deltaTime * 20;
            }
            if (Input.GetKey(KeyCode.LeftAlt))
            {
                transform.position -= g[1].transform.up * speed * Time.deltaTime * 20;
            }
            if (Input.GetKey(KeyCode.KeypadMinus))
            {
                speed += 0.001f;
                speed /= 2;
            }
            if (Input.GetKey(KeyCode.KeypadPlus))
            {
                speed += 0.001f;
                speed *= 2;
            }
        }
        Ray r = new Ray(transform.position,Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(r,out hit))
        {
            if (hit.distance <= 1.5f && Input.GetKey(KeyCode.Space))
            {
                rb.AddForce(Vector3.up*(50 * Time.deltaTime), ForceMode.Impulse);
            }
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            noClip = !noClip;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            g[2].SetActive(!g[2].activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            transform.position = new Vector3(-8, 19, 2);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            g[3].SetActive(!g[3].activeSelf);
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
           

                g[0].transform.Rotate(0, Input.GetAxisRaw("Mouse X") * (150f * Time.fixedDeltaTime), 0);
                g[1].transform.Rotate(-Input.GetAxisRaw("Mouse Y") * (150f * Time.fixedDeltaTime), 0, 0);
           
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        if (!noClip) if ((rb.linearVelocity.x+ rb.linearVelocity.z) <= 1) rb.MovePosition( ((transform.right * Input.GetAxisRaw("Horizontal")+ transform.forward * Input.GetAxisRaw("Vertical"))/6)+transform.position);
      
    }
}
