using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetPaused(!animator.GetBool("opened"));
        }
    }

    public void SetPaused (bool paused)
    {
        animator.SetBool("opened", paused);
    }
}
