using System.Collections;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>(); 
        StartCoroutine(ToggleSpikeEvery10Seconds());  
    }

    IEnumerator ToggleSpikeEvery10Seconds()
    {
        while (true)
        {
            ToggleSpikeState(); 
            yield return new WaitForSeconds(5f); 
        }
    }

  
    public void ToggleSpikeState()
    {
        bool isRetracted = animator.GetBool("isRetracted");  
        animator.SetBool("isRetracted", !isRetracted);  
    }

    public bool IsSpikeUp()
    {
        bool isSpikeUp = !animator.GetBool("isRetracted");  
        return isSpikeUp;
    }
}
