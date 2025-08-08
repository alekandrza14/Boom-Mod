using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class ButtonSpawn : MonoBehaviourPun
{
    public GameObject spawnPrefab;
    public Text spawnText;
    public GameObject SpawnPoint;
    public fristPersonControler main;
    public GameObject FromEditor;
    private void Start()
    {
        SpawnPoint = FindAnyObjectByType<fristPersonControler>().gameObject;
    }

    
    public void Spawn()
    {
        if (FromEditor == null)
        {
            Ray r = Camera.main.ScreenPointToRay(new Vector2(Screen.width/2, Screen.height / 2));
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
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
        }
        if (FromEditor != null)
        {
            Ray r = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
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
        }
    }
}
