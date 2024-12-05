using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField]float spinSpeedX=0f;
    [SerializeField]float spinSpeedY=0f;
    [SerializeField]float spinSpeedZ=0f;


    void Update()
    {
        transform.Rotate(spinSpeedX,spinSpeedY,spinSpeedZ);
    }
}
