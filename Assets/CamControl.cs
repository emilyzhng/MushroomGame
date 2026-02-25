using UnityEngine;
using Unity.Cinemachine;

public class CameraController : MonoBehaviour
{
    public GameObject cam1Prefab;
    public GameObject cam2Prefab;
    private CinemachineCamera cam1;
    private CinemachineCamera cam2;
    private bool usingCam1 = true;

    void Start()
    {
        cam1 = Instantiate(cam1Prefab).GetComponent<CinemachineCamera>();
        cam2 = Instantiate(cam2Prefab).GetComponent<CinemachineCamera>();
    }

    public void ToggleCamera()
    {
        if (usingCam1)
        {
            cam1.Priority.Value = 0;
            cam2.Priority.Value = 10;
        }
        else
        {
            cam1.Priority.Value = 10;
            cam2.Priority.Value = 0;
        }
        usingCam1 = !usingCam1;
    }
}