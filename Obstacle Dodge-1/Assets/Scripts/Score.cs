using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField]int score=0;
    void OnCollisionEnter(Collision other){

        if(other.gameObject.tag!="Hit")
        score++;
    }
}
