using Cinemachine;
using UnityEngine;

namespace Managers
{
    public class CameraManager : MonoBehaviour
    {
        public CinemachineVirtualCamera playerCamera;
        public CinemachineVirtualCamera clockCamera;

        public void SetState(string newState)
        {
            switch (newState)
            {
                case "clock":
                    playerCamera.Priority = 1;
                    clockCamera.Priority = 60;
                    break;
                default:
                    playerCamera.Priority = 60;
                    clockCamera.Priority = 1;
                    break;
            }
        }
    }
}
