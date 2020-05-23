using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class VisionBehavior : MonoBehaviour {

    bool blind = false;
    Tilemap blindMap = null;
    bool mutex = false;
    float nextChange = 3f;

    void Start() {
        // give 1/3 chance that player is vision impaired at start
        blindMap = GameObject.Find("Blinder").GetComponent<Tilemap>();
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
        // fade from current alpha to alpha of 1 (full color, producing a black map)
        // Perform fade over half a second.

        float alpha = blindMap.color.a;
        for (float a = alpha; a <= 1f; a += ((1f - alpha) / 10f)) {
            Color c = new Color(0, 0, 0, a);
            blindMap.color = c;
            yield return new WaitForSeconds(0.05f);
        }
        blindMap.color = new Color(0, 0, 0, 1f);
    }

    IEnumerator FadeVisionIn() {
        // fade from current alpha to alpha of 0 (no color, producing a translucent map)
        // Perform fade over half a second.
        float alpha = blindMap.color.a;
        for (float a = alpha; a >= 0f; a -= (alpha / 10f)) {
            Color c = new Color(0, 0, 0, a);
            blindMap.color = c;
            yield return new WaitForSeconds(0.05f);
        }
        blindMap.color = new Color(0, 0, 0, 0f);
    }

}
