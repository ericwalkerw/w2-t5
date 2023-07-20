using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerSpiner : MonoBehaviour
{
    [SerializeField] protected GameObject spiner;
    [SerializeField] protected float speed = 0.00001f;
    [SerializeField] protected float speedMax = 710f;
    [SerializeField] protected float slowDown = 7f;
    [SerializeField] protected string stopAt = "4";
    [SerializeField] protected bool stop = false;
    [SerializeField] protected bool spinning = true;

    public KeyCode[] keys;
    public Present[] presents;
    private int index = 0;

    public AnimationCurve curve;
    private float elapsedTime = 0f;

    private void Start()
    {
        spiner = GameObject.Find("Wheel");
    }
    protected void OnMouseDown()
    {
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
                index = i;
            }
        }
        CheckPresentsAvailability();
        if (stop && speed == 0)
        {
            SceneManager.LoadScene(index);
        }
    }

    protected void StartSpin()
    {
        this.speed = this.speedMax;
        this.spinning = true;
        this.stop = false;
        elapsedTime = 0;
    }

    protected void FixedUpdate()
    {
        this.Spinning();
    }

    protected void Spinning()
    {
        elapsedTime += Time.deltaTime;
        float curveValue = curve.Evaluate(elapsedTime);

        this.spiner.transform.Rotate(0, Time.deltaTime * speed * curveValue, 0);

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
            Present presentToGive = presents[index];
            if (presentToGive.PresentAvailable)
            {
                GivePresent(presentToGive);
                presentToGive.PresentAvailable = false;
            }
        }
    }

    protected void GivePresent(Present present)
    {
        Debug.Log($"Nhận được: {present.PresentAmount} {present.PresentName}");
    }

    private void CheckPresentsAvailability()
    {
        if (presents == null || presents.Length == 0)
        {
            return;
        }

        bool allPresentsUnavailable = true;
        for (int i = 0; i < presents.Length; i++)
        {
            if (presents[i] == null)
            {
                continue;
            }

            if (presents[i].PresentAvailable)
            {
                allPresentsUnavailable = false;
                break;
            }
        }

        if (allPresentsUnavailable)
        {
            ResetAllPresents();
        }
    }

    private void ResetAllPresents()
    {
        for (int i = 1; i < presents.Length; i++)
        {
            presents[i].PresentAvailable = true;
        }
    }
}
