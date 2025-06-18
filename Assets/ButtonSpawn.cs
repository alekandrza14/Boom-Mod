using UnityEngine;
using UnityEngine.UI;

public class ButtonSpawn : MonoBehaviour
{
    public GameObject spawnPrefab;
    public Text spawnText;
    public GameObject SpawnPoint;
    public void Spawn()
    {
         CustomObject obj = Instantiate(spawnPrefab, SpawnPoint.transform.position, SpawnPoint.transform.rotation).GetComponent<CustomObject>();
        obj.s = spawnText.text;
    }
}
