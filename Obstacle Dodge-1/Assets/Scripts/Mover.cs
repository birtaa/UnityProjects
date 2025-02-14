using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]float moveSpeed=5;

    void Start()
    {
    }

    void Update()
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float yValue = 0f;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(xValue,yValue,zValue);
    }
}
