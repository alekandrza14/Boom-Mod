using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DirecroryFindButtons : MonoBehaviour
{
    List<GameObject> list = new List<GameObject>();
    public GameObject CO;
    public Transform panel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ���������();
    }

    // Update is called once per frame
    public void ���������()
    {
        DirectoryInfo dif = new DirectoryInfo("�������");
        FileInfo[] tag = dif.GetFiles();
        foreach (GameObject item in list)
        {
            item.AddComponent<�������>();
        }
        list.Clear();
        foreach (FileInfo file in tag)
        {
            list.Add(Instantiate(CO, panel));
            list[list.Count - 1].GetComponent<ButtonSpawn>().spawnText.text = file.Name.Replace(".������","");
            if (file.Name.Contains(".������"))
            {
                list[list.Count - 1].gameObject.SetActive(false);
                list[list.Count - 1].gameObject.transform.parent = new GameObject("���").transform;
            }
            }
        }
}
