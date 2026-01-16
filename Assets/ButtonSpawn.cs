using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Unity.Burst.CompilerServices;

public class ButtonSpawn : MonoBehaviourPun
{
    public GameObject spawnPrefab;
    public Text spawnText;
    public GameObject SpawnPoint;
    public fristPersonControler main;
    public GameObject FromEditor;
    public bool Placat;
    RaycastHit hit3;
    public Vector3 old;
    private void Start()
    {
        SpawnPoint = FindAnyObjectByType<fristPersonControler>().gameObject;
    }
    private void OnGUI()
    {
        Debug.DrawRay(hit3.point, hit3.normal, Color.red,999999f);
    }

    public void Spawn()
    {
        if (FromEditor == null)
        {
            Ray r = Camera.main.ScreenPointToRay(new Vector2(Screen.width/2, Screen.height / 2));
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (!Placat)
                {
                    if (!PhotonNetwork.IsConnected)
                    {
                        CustomObject obj = Instantiate(spawnPrefab, hit.point, SpawnPoint.transform.rotation).GetComponent<CustomObject>();
                        obj.s = spawnText.text;
                    }
                    if (PhotonNetwork.IsConnected)
                    {

                        GameObject g = Resources.Load<GameObject>(spawnPrefab.name);
                        CustomObject obj = PhotonNetwork.Instantiate(g.name, hit.point, SpawnPoint.transform.rotation).GetComponent<CustomObject>();
                        obj.GetComponent<PhotonView>().RPC("ChangeObject", RpcTarget.All, spawnText.text);
                        //  obj.s = spawnText.text;

                    }
                }
                if (Placat)
                {
                    hit3 = hit;
                    if (!PhotonNetwork.IsConnected)
                    {
                        GameObject obj = Instantiate(spawnPrefab, hit.point, Quaternion.FromToRotation(Vector3.forward, -hit.normal));
                        
                        old = hit.normal;
                        if (obj.transform.rotation.x > 0.2)
                        {
                            obj.transform.Rotate(0, 0, 180);
                        }
                        else
                        {

                        }
                    }
                    if (PhotonNetwork.IsConnected)
                    {

                        old = hit.normal;
                        GameObject g = Resources.Load<GameObject>(spawnPrefab.name);
                        CustomObject obj = PhotonNetwork.Instantiate(g.name, hit.point, Quaternion.FromToRotation(Vector3.forward, -hit.normal)).GetComponent<CustomObject>();
                        if (obj.transform.rotation.x > 0.2)
                        {
                            obj.transform.Rotate(0, 0, 180);
                        }
                        else
                        {

                        }
                        obj.GetComponent<PhotonView>().RPC("ChangeObject", RpcTarget.All, spawnText.text);
                        //  obj.s = spawnText.text;

                    }
                }
            }
        }
        if (FromEditor != null)
        {
            Ray r = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (!Placat)
                {
                    if (!PhotonNetwork.IsConnected)
                    {
                        Instantiate(FromEditor, hit.point, SpawnPoint.transform.rotation);
                    }
                    if (PhotonNetwork.IsConnected)
                    {

                        GameObject g = Resources.Load<GameObject>(FromEditor.name);
                        PhotonNetwork.Instantiate(g.name, hit.point, SpawnPoint.transform.rotation);

                    }
                }
                if (Placat)
                {
                    hit3 = hit;
                    if (!PhotonNetwork.IsConnected)
                    {
                        old = hit.normal;
                        GameObject obj = Instantiate(FromEditor, hit.point, Quaternion.FromToRotation(Vector3.forward, -hit.normal));
                        if (obj.transform.rotation.x > 0.2)
                        {
                            obj.transform.Rotate(0, 0, 180);
                        }
                        else
                        {

                        }
                      
                    }
                    if (PhotonNetwork.IsConnected)
                    {

                        old = hit.normal;
                        GameObject g = Resources.Load<GameObject>(FromEditor.name);
                        GameObject obj = PhotonNetwork.Instantiate(g.name, hit.point, SpawnPoint.transform.rotation);
                        if (obj.transform.rotation.x > 0.2)
                        {
                            obj.transform.Rotate(0, 0, 180);
                        }
                        else
                        {

                        }
                    }
                }

            }
        }
    }
}
