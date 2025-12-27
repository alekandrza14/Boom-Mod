
using UnityEngine;

public class RandomActive : MonoBehaviour
{
    public GameObject[] rand;
    void Start()
    {
        int i = Random.Range(0, rand.Length);
        rand[i].SetActive(true);
    }
}
