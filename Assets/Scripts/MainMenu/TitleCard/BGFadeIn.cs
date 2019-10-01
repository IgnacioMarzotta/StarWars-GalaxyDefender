using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGFadeIn : MonoBehaviour
{
	public Image Info;

    void Start()
    {
        Info.canvasRenderer.SetAlpha(0.0f);
		FadeIn();
    }

    void FadeIn()
    {
        Info.CrossFadeAlpha(1,2,false);
    }
}
