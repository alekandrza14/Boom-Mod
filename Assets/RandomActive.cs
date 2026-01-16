
using UnityEngine;

public class RandomActive : MonoBehaviour
{
    public GameObject[] rand;
    GameObject newo;
    void Start()
    {
        
        // int i = Random.Range(0, rand.Length);
        // rand[i].SetActive(true);
        int i = VarSave.LoadInt("antirand", 1) % rand.Length;
        newo = rand[i];
        newo.SetActive(true);
        foreach (GameObject oldo in rand)
        {
            if (oldo != newo) oldo.SetActive(false);
        }

    }
    public void add()
    {

        // int i = Random.Range(0, rand.Length);
        // rand[i].SetActive(true);
        int i = VarSave.LoadInt("antirand", 1) % rand.Length;
        newo = rand[i];
        newo.SetActive(true);
        foreach (GameObject oldo in rand)
        {
            if (oldo != newo) oldo.SetActive(false);
        }

    }
    public void sub()
    {
        // int i = Random.Range(0, rand.Length);
        // rand[i].SetActive(true);
        int i = VarSave.LoadInt("antirand", -1) % rand.Length;
        newo = rand[i];
        newo.SetActive(true);
        foreach (GameObject oldo in rand)
        {
           if(oldo!= newo) oldo.SetActive(false);
        }

    }
}
