using TMPro;
using UnityEngine;

public class Present : MonoBehaviour
{
    public WheelData data;

    private TMP_Text PresentTXT;
    private void Start()
    {
        PresentTXT = GetComponent<TMP_Text>();
        PresentTXT.text = data.name;
    }
}
