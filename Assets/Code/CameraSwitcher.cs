using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera followCamera;
    public CinemachineVirtualCamera runwayCamera;
    public CinemachineVirtualCamera cockpitCamera;

    private void Start()
    {
        followCamera.Priority = 10;
        runwayCamera.Priority = 0;
        cockpitCamera.Priority = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchCamera();
        }
    }

    private void SwitchCamera()
    {
        if (followCamera.Priority == 10)
        {
            followCamera.Priority = 0;
            runwayCamera.Priority = 0;
            cockpitCamera.Priority = 10;
            
        }
        else if (runwayCamera.Priority == 10)
        {
            followCamera.Priority = 10;
            runwayCamera.Priority = 0;
            cockpitCamera.Priority = 0;
        }
        else
        {
            followCamera.Priority = 0;
            runwayCamera.Priority = 10;
            cockpitCamera.Priority = 0;
            
        }
    }
}
