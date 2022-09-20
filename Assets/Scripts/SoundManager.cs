using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
   public static SoundManager instance;

   public AudioSource klavyeSource;

   private void Awake() 
   {
        instance=this;
   }

   public void KlavyeSesiCikar(AudioClip clip)
   {
        //klavyeSource.Stop();
        klavyeSource.clip=clip;
        klavyeSource.Play();
   }
}
