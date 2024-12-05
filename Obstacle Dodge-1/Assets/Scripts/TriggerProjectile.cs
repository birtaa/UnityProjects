using UnityEngine;

public class TriggerProjectile : MonoBehaviour
{
    [SerializeField] GameObject Flyingabi;
    [SerializeField] GameObject Flyingabi1;
    [SerializeField] GameObject Flyingabi2;
    [SerializeField] GameObject Flyingabi3;
    [SerializeField] GameObject Flyingabi4;

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag=="Player")
        {
            Flyingabi.SetActive(true);
            Flyingabi1.SetActive(true);
            Flyingabi2.SetActive(true);
            Flyingabi3.SetActive(true);
            Flyingabi4.SetActive(true);
            Destroy(gameObject);
        }
    }
}
