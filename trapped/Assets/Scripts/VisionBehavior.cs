using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class VisionBehavior : MonoBehaviour {

    bool blind = false;
    int fullSightRadius = 50;
    int noSightRadius = 0;
    int blindSightRadius = 3;
    SpriteMask mask = null;
    bool mutex = false;
    float nextChange = 3f;

    void Start() {
        mask = GameObject.Find("PlayerMask").GetComponent<SpriteMask>();
        SetNextVisionChange();
    }

    void Update() {
        if (Time.time > this.nextChange) {
            ToggleVision();
        }
    }

    public bool GetVisionStatus() {
        return this.blind;
    }

    void SetNextVisionChange(float duration = -1f) {
        if (duration < 0f) {
            duration = Random.Range(8f, 20f);
        }
        // Debug.Log("Setting next vision change to be " + duration + " seconds from now.");
        this.nextChange = Time.time + duration;
    }

    /* 
     * Sets vision level to argument input, if that 
     * vision state was not already in place.
     * 
     * Returns boolean value indicating whether the 
     * transition could be completed.
     */
    public bool SetVision(bool isBlind, float duration = -1f) {
        if (mutex) 
            return false;
        mutex = true;
        if (this.blind == isBlind) {
            SetNextVisionChange(duration);
            mutex = false;
            return false;
        }
        if (isBlind) {
            StartCoroutine("FadeVisionOut");
        } else {
            StartCoroutine("FadeVisionIn");
        }
        this.blind = isBlind;
        SetNextVisionChange();
        mutex = false;
        return true;
    }

    /*
     * Inverts vision level based on existing state.
     * 
     * Returns boolean value indicating whether the 
     * transition could be completed.
     */
    public bool ToggleVision(float duration = -1f) {
        if (mutex) 
            return false;
        mutex = true;
        if (this.blind) {
            StartCoroutine("FadeVisionIn");
        } else {
            StartCoroutine("FadeVisionOut");
        }
        this.blind = !this.blind;
        SetNextVisionChange(duration);
        mutex = false;
        return true;
    }

    IEnumerator FadeVisionOut() {
        // fade from current mask size to mask size of 3 (or whatever blindSightRadius is)
        float size = mask.transform.localScale.x;
        // perform fade over 1 second.
        for (float sz = size; sz > blindSightRadius; sz -= ((size - blindSightRadius) / 20f)) {
            mask.transform.localScale = new Vector3(sz, sz, 1);
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator FadeVisionIn() {
        // fade from current mask size to mask size of 3 (or whatever blindSightRadius is)
        float size = mask.transform.localScale.x;
        // perform fade over 1 second.
        for (float sz = size; sz < fullSightRadius; sz -= ((size - fullSightRadius) / 20f)) {
            mask.transform.localScale = new Vector3(sz, sz, 1);
            yield return new WaitForSeconds(0.05f);
        }
    }

}
