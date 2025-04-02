using UnityEngine;
using UnityEngine.SceneManagement;


public class DoorTrigger : MonoBehaviour
{
    public string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
