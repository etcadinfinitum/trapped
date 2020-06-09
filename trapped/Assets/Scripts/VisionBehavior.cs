using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class VisionBehavior : MonoBehaviour {

    bool blind = false;
    float fullSightRadius = 50f;
    float minSightRadius = 10f;
    float noSightRadius = 0f;
    float blindSightRadius = 3f;
    float currSightRadius;
    SpriteMask mask = null;
    bool mutex = false;
    float nextChange = 3f;

    void Start() {
        currSightRadius = fullSightRadius;
        mask = GameObject.Find("PlayerMask").GetComponent<SpriteMask>();
    }

    void Update() {
        if (this.blind && Time.time > this.nextChange) {
            this.blind = false;
            StartCoroutine("FadeVisionIn");
        }
    }

    public void SetCurrentRadius(float difference, float max) {
        currSightRadius = currSightRadius + ((difference / max) * (fullSightRadius - minSightRadius));
    }

    public void BlindTemporarily(float duration) {
        this.blind = true;
        this.nextChange = Time.time + 5f;
        StartCoroutine("FadeVisionOut");
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
        // perform fade over 2 seconds.
        for (float sz = size; sz < currSightRadius; sz -= ((size - currSightRadius) / 20f)) {
            mask.transform.localScale = new Vector3(sz, sz, 1);
            yield return new WaitForSeconds(0.1f);
        }
    }

}
