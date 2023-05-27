using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomCanvas : MonoBehaviour
{
    [SerializeField] Transform endCanvas;
    [SerializeField] AudioClip clip;
    
    public IEnumerator DoEnd(){
        foreach(Image image in endCanvas.GetComponentsInChildren<Image>()){
            image.enabled = true;
            AudioSource source = FindObjectOfType<AudioSource>();
            source.volume = 0.03f;
            source.PlayOneShot(clip);
            yield return new WaitForSeconds(1.5f);
        }
    }
}
