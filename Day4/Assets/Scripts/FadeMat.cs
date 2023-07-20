using UnityEngine;

public class FadeMat : MonoBehaviour
{
    public Material[] fade;

    private MeshRenderer mesh;
    public Present present;
    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mesh.material = fade[0];

        present = GetComponentInParent<Present>();
    }

    public void Update()
    {
        if (present.PresentAvailable)
        {
            mesh.material = fade[0];
        }
        else
        {
            mesh.material = fade[1];
        }
    }
}
