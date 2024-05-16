using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem ParticleSystem;

    public void PlayPlayerWinEffect()
    {
        if (ParticleSystem != null)
        {
            ParticleSystem.Play(); 
        }
    }

}
