
using UnityEngine;

public class ActionController : MonoBehaviour
{
    public Animator animator;
    private void Start() {
        // render("ATTACK_ATK");
    }
    public void render(string animation)
    {
        Debug.Log("render " + animation);
        animator.Play(animation);
    }
}