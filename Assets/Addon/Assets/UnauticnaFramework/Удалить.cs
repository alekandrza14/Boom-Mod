using UnityEngine;

public class Удалить : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
        gameObject.transform.parent = new GameObject("Дам").transform;
    }
}
