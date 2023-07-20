using UnityEngine;

public class Present : MonoBehaviour
{
    public WheelData data;

    [HideInInspector] public MeshRenderer mesh;
    [HideInInspector] public string PresentName;
    [HideInInspector] public int PresentAmount;
    [HideInInspector] public bool PresentAvailable;

    private void Start()
    {
        PresentName = data.name;
        PresentAmount = data.amount;
        PresentAvailable = data.Available;

        mesh = transform.GetChild(0).GetComponent<MeshRenderer>();

        mesh.material = data.mat;
    }
}
