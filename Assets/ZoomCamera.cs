using System;
using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
    [SerializeField] private Camera TaregetCamera = null;

    [SerializeField] private float defaultFov = 60f;

    [SerializeField] private float LifeTimeSec = 2f;
    private float LifeFrame = 0f;


    [SerializeField] private float FoVDegresShiftPerSec = -2.5f;


    [SerializeField] private bool fpause;  //途中で一時停止するためのフラグ

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (TaregetCamera == null)
        {
            TaregetCamera = this.gameObject.GetComponent<Camera>();
            if (TaregetCamera = null)
            {
                Debug.LogError("カメラが見つかりません");
            }
        }
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        //ポーズフラグが立っているときは、何もしないでUpdateを打ち切る
        if (fpause) return;

        LifeTimeSec -= Time.deltaTime;

        if (LifeFrame > 0)
        {
            //zoom
            this.TaregetCamera.fieldOfView += FoVDegresShiftPerSec * Time.deltaTime;
        }
    }

    public void Initialize()
    {
        if (TaregetCamera != null)
        {
            TaregetCamera.fieldOfView = defaultFov;
        }

        LifeFrame = LifeTimeSec;
    }

    public void Pause()
    {
        fpause = !fpause;
    }
}