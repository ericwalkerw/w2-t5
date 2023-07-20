using UnityEngine;

public class TriggerSpiner : MonoBehaviour
{
    [SerializeField] protected Transform spiner;
    [SerializeField] protected float speed = 0f;
    [SerializeField] protected float speedMax = 710f;
    [SerializeField] protected float slowDown = 7f;
    [SerializeField] protected string stopAt = "4";
    [SerializeField] protected bool stop = false;
    [SerializeField] protected bool spinning = true;

    public KeyCode[] keys;
    protected void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
        this.StartSpin();
    }

    private void Update()
    {
        for (int i = 0; i < keys.Length; i++)
        {
            if (Input.GetKeyDown(keys[i]))
            {
                stopAt = i.ToString();
                stop = true;
            }
        }
    }
    protected virtual void StartSpin()
    {
        this.speed = this.speedMax;
        this.spinning = true;
        this.stop = false;

    }

    protected void FixedUpdate()
    {
        this.Spinning();
    }

    protected void Spinning()
    {
        this.spiner.Rotate(0, Time.deltaTime * this.speed, 0);

        this.Stoping();
    }

    protected void Stoping()
    {
        if (!this.stop) return;
        if (this.stopAt == Marker.Instance.number) this.spinning = false;
        if (this.spinning) return;

        this.speed -= this.slowDown;
        if (this.speed < 0)
        {
            this.speed = 0;
            Debug.Log("get reward");
        }
    }
}
