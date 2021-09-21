using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator anim;
    public GameObject thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        JumpAnimationHandler();
    }
    public void JumpAnimationHandler()
    {
        Bounce bounceScript = thePlayer.GetComponent<Bounce>();
        if (bounceScript.justJump == true)
        {
            anim.SetBool("jump", true);
        }
        else
        {
            anim.SetBool("jump", false);
        }
    }

}
