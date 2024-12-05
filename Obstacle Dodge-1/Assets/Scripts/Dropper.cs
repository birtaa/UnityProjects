using UnityEngine;

public class Dropper : MonoBehaviour
{

    [SerializeField] int timeToWait=3;
    MeshRenderer mr;
    Rigidbody rb;

    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time>timeToWait)
        {
            rb.useGravity=true;
        }
    }
}
