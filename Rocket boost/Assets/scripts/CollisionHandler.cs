using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float nextLevelDelay;
    [SerializeField] AudioClip crushSound;
    [SerializeField] AudioClip successSound;
    [SerializeField] ParticleSystem successParticle;
    [SerializeField] ParticleSystem bumParticle;
    AudioSource audioSource;
    bool isControllable = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        CollisionOnOff();
    }

    private void CollisionOnOff()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            isControllable = !isControllable;
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(isControllable)
        {
            switch(other.gameObject.tag)
            {
                case "Friendly":
                    Debug.Log("abisa");
                    isControllable=true;
                    break;
                case "Finish":
                    audioSource.Stop();
                    audioSource.PlayOneShot(successSound);
                    successParticle.Play();
                    gameObject.GetComponent<Movement>().enabled=false;
                    isControllable=false;
                    Invoke("NextScene",nextLevelDelay);
                    break;
                default:
                    Debug.Log("gaza");
                    audioSource.Stop();
                    audioSource.PlayOneShot(crushSound);
                    bumParticle.Play();
                    gameObject.GetComponent<Movement>().enabled=false;
                    isControllable=false;
                    Invoke("ReloadScene",1.5f);
                    break;
            }
        }
    }

    void ReloadScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
    void NextScene()
    {   
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene +1;
        if(nextScene==SceneManager.sceneCountInBuildSettings)
        {
            nextScene=0;
        }    
        SceneManager.LoadScene(nextScene); 
    }
}
