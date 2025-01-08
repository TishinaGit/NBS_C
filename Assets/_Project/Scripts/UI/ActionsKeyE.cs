using Cinemachine;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(AudioSource))]
public class ActionsKeyE : MonoBehaviour
{
    [SerializeField] private GameObject _uiObject; 
    [SerializeField] private AudioSource _audioSource; 
    [SerializeField] private GameObject _canvasActionEText;

    private CinemachineFreeLook _cinemachineFreeLook;

    [Inject]
    public void Construct(CinemachineFreeLook CinemachineFreeLook)
    {
        _cinemachineFreeLook = CinemachineFreeLook;  
    }

    private void OnTriggerStay(Collider other)
    {
        if (other != null)
        {
            _canvasActionEText.SetActive(true); 
            if (Input.GetKey(KeyCode.E))
            {
                _audioSource.Play();
                _cinemachineFreeLook.m_XAxis.m_MaxSpeed = 0f;
                _cinemachineFreeLook.m_YAxis.m_MaxSpeed = 0f;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;

                _uiObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other != null)
        {
            _cinemachineFreeLook.m_XAxis.m_MaxSpeed = 250f;
            _cinemachineFreeLook.m_YAxis.m_MaxSpeed = 1f;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            _canvasActionEText.SetActive(false);
            _uiObject.SetActive(false);
        }
    }
}
