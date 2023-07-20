using TMPro;
using UnityEngine;

public class ChangeNumber : MonoBehaviour
{
    private TMP_Text numberText;
    // Start is called before the first frame update
    void Start()
    {
        numberText = GetComponent<TMP_Text>();
        numberText.text = transform.name;
    }
}
