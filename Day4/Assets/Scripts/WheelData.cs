using UnityEngine;

[System.Serializable]
public class WheelData
{
    public string name;
    public int amount;
    public Material mat;
    public bool Available;
    public WheelData(string name, int amount, Material mat, bool available)
    {
        this.name = name;
        this.amount = amount;
        this.mat = mat;
        Available = available;
    }
}