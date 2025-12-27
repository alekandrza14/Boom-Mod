using UnityEngine;

using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using ObjParser;
public class PUNchat : MonoBehaviourPun
{
    public InputField chat;
    public Toggle chatToggle;
    public Text cahtobj;
    public GameObject main;
    public GameObject main2;
    public static bool input;
    [PunRPC]
    void chating(string a)
    {
        cahtobj.text += "\n" + a;
    }
    public void send()
    {
       GetComponent<PhotonView>().RPC("chating", RpcTarget.All, chat.text);
       
    }
    private void Update()
    {
            main2.SetActive(chatToggle.isOn);
        input = ! chatToggle.isOn;
    }

}
