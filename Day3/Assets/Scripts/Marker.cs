using UnityEngine;

public class Marker : MonoBehaviour
{
    public static Marker Instance;

    public string number;
    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        this.number = other.name;
    }
}
