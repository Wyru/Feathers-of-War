using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxAudios : MonoBehaviour
{
    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private AudioClip[] fxClips;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAttack()
    {
        source.PlayOneShot(fxClips[0]);
    }

    public void PlayCharge()
    {
        source.PlayOneShot(fxClips[1]);
    }

    public void PlayDefense()
    {
        source.PlayOneShot(fxClips[2]);
    }

    public void PlayEvade()
    {
        source.PlayOneShot(fxClips[3]);
    }
}
