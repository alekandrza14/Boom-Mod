using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SkinManager : MonoBehaviourPun
{
    public GameObject[] skins;
    public PhotonView ismine;
    public void MultyPlayerStart()
    {

        if (ismine.IsMine)
        {
            skins[0].layer = 1;
            skins[1].layer = 1;
            skins[2].layer = 1;
        }
        if (!ismine.IsMine)
        {
            skins[0].layer = 0;
            skins[1].layer = 0;
            skins[2].layer = 0;
        }
        if (VarSave.GetString("Skin") == "" || VarSave.GetString("Skin") == "2D")
        {
            skins[0].SetActive(true);
            skins[1].SetActive(false);
            skins[2].SetActive(false);
        }
        if (VarSave.GetString("Skin") == "2D[1]")
        {
            skins[0].SetActive(false);
            skins[1].SetActive(false);
            skins[2].SetActive(false);
            skins[3].SetActive(true);
        }
        if (VarSave.GetString("Skin") == "2D[2]")
        {
            skins[0].SetActive(false);
            skins[1].SetActive(false);
            skins[2].SetActive(false);
            skins[4].SetActive(true);
        }
        else if (VarSave.GetString("Skin") == "3D")
        {

            skins[0].SetActive(false);
            skins[1].SetActive(true);
            skins[2].SetActive(false);
        }
        else if (VarSave.GetString("Skin") == "3Di")
        {

            skins[0].SetActive(false);
            skins[1].SetActive(false);
            skins[2].SetActive(true);
        }
    }
    void Start()
    {
        if (!PhotonNetwork.IsConnected)
        {
            skins[0].layer = 1;
            skins[1].layer = 1;
            skins[2].layer = 1;
            if (VarSave.GetString("Skin") == "" || VarSave.GetString("Skin") == "2D")
            {
                skins[0].SetActive(true);
            }
            if (VarSave.GetString("Skin") == "" || VarSave.GetString("Skin") == "2D[1]")
            {
                skins[0].SetActive(false);
                skins[3].SetActive(true);
            }
            if (VarSave.GetString("Skin") == "2D[2]")
            {
                skins[0].SetActive(false);
                skins[4].SetActive(true);
            }
            else if (VarSave.GetString("Skin") == "3D")
            {

                skins[0].SetActive(false);
                skins[1].SetActive(true);
            }
            else if (VarSave.GetString("Skin") == "3Di")
            {

                skins[0].SetActive(false);
                skins[2].SetActive(true);
            }
        }
        else
        {
            MultyPlayerStart();
        }
    }
}
