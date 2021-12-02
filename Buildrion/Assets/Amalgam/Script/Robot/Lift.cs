using UnityEngine;

public class Lift : MonoBehaviour
{
    [SerializeField] private Animator animator;

    void Start()
    {
        animator.SetBool("lift", true);
        Debug.Log("lift" + animator.GetBool("lift"));
    }
}
