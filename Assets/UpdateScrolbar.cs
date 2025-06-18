using UnityEngine;
using UnityEngine.UI;
[ExecuteAlways]
public class UpdateScrolbar : MonoBehaviour
{
    void Update()
    {
        GetComponent<Scrollbar>().size += 0.0001f;
    }
}
