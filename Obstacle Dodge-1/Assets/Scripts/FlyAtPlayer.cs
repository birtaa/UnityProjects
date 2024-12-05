using UnityEngine;

public class FlyAtPlayer : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector3 playerPosition;
    [SerializeField]float moveSpeed=1f;

    void Awake() 
    {
        gameObject.SetActive(false);
    }

    void Start()
    {
        playerPosition=player.transform.position;
    }

    void Update()
    {
        transform.position= Vector3.MoveTowards(transform.position,playerPosition,moveSpeed*Time.deltaTime);
        if(playerPosition==gameObject.transform.position)
            DestroyWhenReached();
    }

    void DestroyWhenReached()
    {
        Destroy(gameObject);
    }
}
