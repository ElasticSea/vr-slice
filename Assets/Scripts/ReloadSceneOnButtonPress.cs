using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadSceneOnButtonPress : MonoBehaviour
{
    [SerializeField] private OVRInput.Button button = OVRInput.Button.Start;
    [SerializeField] private OVRInput.Controller controller = OVRInput.Controller.All;

    private void Update()
    {
        if (OVRInput.GetDown(button, controller))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}