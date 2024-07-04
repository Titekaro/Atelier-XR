using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nokia_3310_Manager : MonoBehaviour
{
    public Material[] material;
    private Renderer rend;
    private float flashSpeed = 1.5f;
    private AudioSource audioSource;
    public AudioClip soundClip;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.sharedMaterial = material[0];
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(ChangeMaterial());

    }

    IEnumerator ChangeMaterial() 
    {
        while (true) // Boucle infinie pour continuer à changer les matériaux
        {
            rend.sharedMaterial = material[0];
            yield return new WaitForSeconds(flashSpeed);
            rend.sharedMaterial = material[1];
            audioSource.Play();
            yield return new WaitForSeconds(flashSpeed);

        }
    }
}
