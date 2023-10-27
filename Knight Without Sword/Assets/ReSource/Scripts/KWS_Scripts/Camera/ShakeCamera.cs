using UnityEngine;
using Cinemachine;

public class ShakeCamera : Singleton<ShakeCamera>
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float shakeIntensity = 1f;
    private float shakeTime = 0.2f;

    private float timer;
    private CinemachineBasicMultiChannelPerlin m_MultiChannelPerlin;

    private void Awake()
    {
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        m_MultiChannelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void Start()
    {
        StopShake();
    }

    public void CameraShaking()
    {
        m_MultiChannelPerlin.m_AmplitudeGain = shakeIntensity;
        timer = shakeTime;
    }

    void StopShake()
    {
        if(timer >0)
        {
            timer -= Time.deltaTime;
            if(timer <=0)
            {
                m_MultiChannelPerlin.m_AmplitudeGain = 0f;
                timer = 0f;
            }
           
        }
       
    }

    private void Update()
    {
        StopShake();
    }
}
