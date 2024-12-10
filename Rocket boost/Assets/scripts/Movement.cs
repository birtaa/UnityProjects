using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction rotate;
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction nextLevelKey;
    [SerializeField] InputAction prevLevelKey;
    [SerializeField] float thrustStrength=100f;
    [SerializeField] float rotationStrength=1f;
    [SerializeField] AudioClip thrusterSound;
    [SerializeField] ParticleSystem mainEngine;
    [SerializeField] ParticleSystem leftEngine;
    [SerializeField] ParticleSystem rightEngine;
    AudioSource audioSource;
    Rigidbody rb;

    private void Start() 
    {
        rb=GetComponent<Rigidbody>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnEnable() 
    {
        thrust.Enable();
        rotate.Enable();
        nextLevelKey.Enable();
        prevLevelKey.Enable();
    }

    public void disableRocket() 
    {
        thrust.Disable();
        rotate.Disable(); 
    }

    void FixedUpdate()
    {
        Thruster();
        Rotator();
        RespondToDebugKeys();
    }

    private void RespondToDebugKeys()
    {
        if (prevLevelKey.IsPressed())
        {
            Debug.Log("basti abi");
            PrevLevel();
        }
        else if (nextLevelKey.IsPressed())
        {
            Debug.Log("basti abi");
            NextLevel();
        }
    }

    private void Thruster()
    {
        if (thrust.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);
            if(!audioSource.isPlaying)
            {
            audioSource.PlayOneShot(thrusterSound);
            }
            mainEngine.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }

    void Rotator()
    {
        float rotationInput = rotate.ReadValue<float>();
        if(rotationInput<0)
        {
            rb.freezeRotation=true;
            transform.Rotate(Vector3.forward*rotationStrength*Time.fixedDeltaTime);
            rb.freezeRotation=false;
            rightEngine.Play();
        }   
        else if(rotationInput>0)
        {
            rb.freezeRotation=true;
            transform.Rotate(Vector3.back*rotationStrength*Time.fixedDeltaTime);
            rb.freezeRotation=false;
            leftEngine.Play();
        }
    }

    void NextLevel()
    {   
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene +1;
        if(nextScene==SceneManager.sceneCountInBuildSettings)
        {
            nextScene=0;
        }    
        SceneManager.LoadScene(nextScene); 
    }

    void PrevLevel()
    {   
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene -1;
        if(nextScene==-1)
        {
            nextScene=SceneManager.sceneCountInBuildSettings-1;
        }    
        SceneManager.LoadScene(nextScene); 
    }
}