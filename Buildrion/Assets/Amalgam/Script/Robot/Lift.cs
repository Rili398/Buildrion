using UnityEngine;

public class Lift : MonoBehaviour
{
    [SerializeField] private Animator animator;

    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        animator.SetBool("lift", true);
    }


}
