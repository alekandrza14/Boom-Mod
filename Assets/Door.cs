using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject[] door;
    public AudioSource audioSource;
    void Update()
    {
        Ray r = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        if (Physics.Raycast(r, out hit))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                audioSource.Play();
                if (hit.collider!= null)   if (hit.collider.gameObject == gameObject)
                    {
                        door[0].gameObject.SetActive(!door[0].activeSelf);
                        door[1].gameObject.SetActive(!door[1].activeSelf);
                    }
            }
        }
    }
}
