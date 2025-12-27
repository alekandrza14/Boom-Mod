using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cliker : MonoBehaviour
{
    public int работа;
    public Text work;
    public Animator animator;
    private void Start()
    {
        int s = Random.Range(0, 6);
        if (s == 1)
        {
            animator.SetTrigger("attack");
            работа -= 400;
        }
    }

    public void Click()
    {
        работа++;
        work.text = работа + "\\100";
        if (работа >= 100)
        {
            VarSave.SetInt("ХП", 6);
            SceneManager.LoadScene("GoldMineSovet");
        }
    }
}
