using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using Unity.Burst.CompilerServices;
public enum person
{
    first, trid
}
public class fristPersonControler : MonoBehaviour
{
    public Rigidbody rb;
    public Collider col;
    public GameObject[] g;
    public GameObject chat;
    public person camRejime;
    bool noClip;
    float speed = 1; Camera _camera;
    public int hp;
    public Text hptext;
    float Oldvelosyty; 
    public LayerMask layerMask;
    public LayerMask layerMask1;
    public GameObject manipulation;
    // Start is called before the first frame update
    void Start()
    {
        if (VarSave.CreateEvent("первые ХП"))
        {
            VarSave.SetInt("ХП", 6);
        }
        hp = VarSave.GetInt("ХП");
       if(PhotonNetwork.IsConnected) if (!GetComponent<PhotonView>().IsMine)
            {
                g[1].GetComponent<Camera>().enabled = false;
                hptext.enabled = false;
        }
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (Oldvelosyty <= -18)
        {
            hp--;
            Oldvelosyty = 0;
            VarSave.SetInt("ХП", hp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.linearVelocity.y < -10) Oldvelosyty = rb.linearVelocity.y;
        if (hp<=0)
        {
            SceneManager.LoadScene("Отработка");
        }
        hptext.text = "";
        if (PhotonNetwork.IsConnected)
        {

        }
        for (int i = 0; i < hp; i++)
        {

            hptext.text += "♣";
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            g[1].transform.rotation = g[4].transform.rotation;
            if (camRejime == person.first)
            {
                camRejime = person.trid;
            }
            else if (camRejime == person.trid)
            {
                camRejime = person.first;
            }
        }
        if (camRejime == person.first)
        {
            _camera = g[1].GetComponent<Camera>();
            _camera.cullingMask = layerMask;
        }
        if (camRejime == person.trid)
        {
            _camera = g[1].GetComponent<Camera>();
            _camera.cullingMask = layerMask1;
        }

        rb.useGravity = !noClip;
        rb.isKinematic = noClip;
        if (PhotonNetwork.IsConnected)
        {
            if (PUNchat.input) if (noClip)
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
        }
        else
        {
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
        }
        Ray r = new Ray(transform.position,Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(r,out hit))
        {
            if (PhotonNetwork.IsConnected)
            {
                if (PUNchat.input) if (hit.distance <= 1.5f && Input.GetKey(KeyCode.Space))
                    {
                        rb.AddForce(Vector3.up * (50 * Time.deltaTime), ForceMode.Impulse);
                    }
            }
            else
            {
                if (hit.distance <= 1.5f && Input.GetKey(KeyCode.Space))
                {
                    rb.AddForce(Vector3.up * (50 * Time.deltaTime), ForceMode.Impulse);
                }
            }
        }
        if (PhotonNetwork.IsConnected)
        {
            if (PUNchat.input) if (Input.GetKeyDown(KeyCode.K))
                {
                    noClip = !noClip;
                }
            if (PUNchat.input) if (Input.GetKeyDown(KeyCode.G))
                {
                    g[2].SetActive(!g[2].activeSelf);
                }
            if (PUNchat.input) if (Input.GetKeyDown(KeyCode.N))
                {
                    transform.position = new Vector3(-8, 19, 2);
                }
            if (PUNchat.input) if (Input.GetKeyDown(KeyCode.H))
                {
                    g[3].SetActive(!g[3].activeSelf);
                }
            if (PUNchat.input) if (Input.GetKey(KeyCode.Mouse1))
                {


                    g[0].transform.Rotate(0, Input.GetAxisRaw("Mouse X") * (150f * Time.fixedDeltaTime), 0);
                    g[1].transform.Rotate(-Input.GetAxisRaw("Mouse Y") * (150f * Time.fixedDeltaTime), 0, 0);

                    Cursor.lockState = CursorLockMode.Locked;
                }
            if (PUNchat.input) if (Input.GetKeyUp(KeyCode.Mouse1))
                {
                    Cursor.lockState = CursorLockMode.None;
                }
            if (PUNchat.input) if (!noClip) if ((rb.linearVelocity.x + rb.linearVelocity.z) <= 1) rb.MovePosition(((transform.right * Input.GetAxisRaw("Horizontal") + transform.forward * Input.GetAxisRaw("Vertical")) / 6) + transform.position);
        }
        else
        {
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
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (!manipulation)
                {


                    Ray r1 = new(g[1].transform.position, g[1].transform.forward);
                    RaycastHit hit1;

                    if (UnityEngine.Physics.Raycast(r1, out hit1))
                    {
                        if (hit1.collider != null)
                        {

                            hit1.collider.transform.SetParent(transform);
                            manipulation = hit1.collider.gameObject;
                        }
                    }
                }
                else
                {
                    manipulation.transform.SetParent(new GameObject("gameObject").transform);
                    manipulation = null;
                }
            }
            if (manipulation)
            {
                manipulation.transform.localScale = manipulation.transform.localScale * (1 + (Input.GetAxisRaw("Mouse ScrollWheel")*0.5f));
            }
            if (Input.GetKeyDown(KeyCode.F6))
            {
                g[1].transform.Rotate(0, 0, 180);
            }
            if (Input.GetKey(KeyCode.Mouse1))
            {

                g[0].transform.Rotate(0, Input.GetAxisRaw("Mouse X") * (150f * Time.fixedDeltaTime), 0);
                if (camRejime == person.first)
                    g[1].transform.Rotate(-Input.GetAxisRaw("Mouse Y") * (150f * Time.fixedDeltaTime), 0, 0);
                if (camRejime == person.trid)
                    g[4].transform.Rotate(-Input.GetAxisRaw("Mouse Y") * (150f * Time.fixedDeltaTime), 0, 0);
                if (camRejime == person.first)
                {
                    g[1].transform.position = g[4].transform.position;
                }
                if (camRejime == person.trid)
                {
                    Ray r1 = new(g[4].transform.position, -g[4].transform.forward);
                    RaycastHit hit1;
                    float distcam = 0;
                    // CamDistanceMult
                    float dist = (6 + distcam) * transform.localScale.y;
                    
                    if (UnityEngine.Physics.Raycast(r1, out hit1))
                    {
                        if (hit1.collider != null)
                        {
                            if (hit1.distance < dist)
                            {

                                g[1].transform.position = hit1.point;
                            }
                            if (hit1.distance > dist)
                            {

                                g[1].transform.position = g[4].transform.position - g[4].transform.forward * (dist);
                            }
                        }
                        else
                        {
                            g[1].transform.position = g[4].transform.position - g[4].transform.forward * (dist);
                        }
                    }
                    else
                    {
                        g[1].transform.position = g[4].transform.position - g[4].transform.forward * (dist);
                    }
                }

                Cursor.lockState = CursorLockMode.Locked;
            }
            if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                Cursor.lockState = CursorLockMode.None;
            }


            // if (Input.GetKey(KeyCode.Mouse1))
            //     {
            //
            //
            //         g[0].transform.Rotate(0, Input.GetAxisRaw("Mouse X") * (150f * Time.fixedDeltaTime), 0);
            //         g[1].transform.Rotate(-Input.GetAxisRaw("Mouse Y") * (150f * Time.fixedDeltaTime), 0, 0);
            //
            //         Cursor.lockState = CursorLockMode.Locked;
            //     }
            //  if (Input.GetKeyUp(KeyCode.Mouse1))
            //     {
            //         Cursor.lockState = CursorLockMode.None;
            //     }
            if (!noClip) if ((rb.linearVelocity.x + rb.linearVelocity.z) <= 1) rb.MovePosition(((transform.right * Input.GetAxisRaw("Horizontal") + transform.forward * Input.GetAxisRaw("Vertical")) / 6) + transform.position);

        }
    }
}
