using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject _player;
    void Start()
    {
        PhotonNetwork.Instantiate(_player.name, transform.position,Quaternion.identity);
    }
}
