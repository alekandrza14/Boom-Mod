using UnityEngine;
using UnityEngine.UI;

public class ButtonSpawn : MonoBehaviour
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
                CustomObject obj = Instantiate(spawnPrefab, hit.point, SpawnPoint.transform.rotation).GetComponent<CustomObject>();
                obj.s = spawnText.text;

            }
        }
        if (FromEditor != null)
        {
            Ray r = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                Instantiate(FromEditor, hit.point, SpawnPoint.transform.rotation);

            }
        }
    }
}
