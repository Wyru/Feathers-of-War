using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomeSoundsController : MonoBehaviour
{

    private AudioSource source;


    public AudioClip readyClip;
    public AudioClip fightClip;
    public AudioClip comebackClip;
    public AudioClip OwlClip;
    public AudioClip PigeonClip;


    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

   public void Ready(){
       source.PlayOneShot(readyClip);
   }

   public void Fight(){
       source.Stop();
       source.PlayOneShot(fightClip);
       GameLogic.Instance.StartGame();
       GameLogic.Instance.EnableTimer();
   }

   public void ComeBack(){
       GameLogic.Instance.DisabelTimer();
       source.PlayOneShot(comebackClip);
   }

   public void OwlWins(){
       source.PlayOneShot(OwlClip);
   }

   public void PigeonWins(){
       source.PlayOneShot(PigeonClip);
   }
}
