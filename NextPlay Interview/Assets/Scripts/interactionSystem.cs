using UnityEngine;
public class interactionSystem : MonoBehaviour
{
    [SerializeField] Animator anim;

    public void Action(int index)
    {
        anim.SetTrigger("Action_"+index);
    }
}
