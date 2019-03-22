using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlAudios : MonoBehaviour
{
    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private AudioClip[] audioCLips = null;

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
        int i = Random.RandomRange(0, 2);
        source.PlayOneShot(audioCLips[i], 1F);
    }

    public void PlayCharge()
    {
        source.PlayOneShot(audioCLips[2], 1F);
    }

    public void PlayDamage()
    {
        source.PlayOneShot(audioCLips[3], 1F);
    }

    public void PlayDefense()
    {
        source.PlayOneShot(audioCLips[4], 1F);
    }

    public void PlayEvade()
    {
        source.PlayOneShot(audioCLips[5], 1F);
    }
}
