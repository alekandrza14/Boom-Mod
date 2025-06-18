using UnityEngine;
using UnityEngine.UI;

public class ПодсказкиПреключение : MonoBehaviour
{
    public Sprite[] спрайт;
    public Image ОкноСПодскаоками;
    public int НомерВМасивеСпайтовДляОкна;
    public void Next()
    {
        НомерВМасивеСпайтовДляОкна++;
        ОкноСПодскаоками.sprite = спрайт[НомерВМасивеСпайтовДляОкна];
    }
    public void Back()
    {
        НомерВМасивеСпайтовДляОкна++;
        ОкноСПодскаоками.sprite = спрайт[НомерВМасивеСпайтовДляОкна];
    }
}
