using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherPlayerBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public Sprite zombieFace;
    public Sprite face;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        spriteRenderer = GetComponent<SpriteRenderer>();
        //status = GameObject.Find("Player").GetComponent<PlayerDeath>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MakeDead()
    {
        //Play death jingle
        FindObjectOfType<AudioManager>().Play("PlayerDeath");
        Debug.Log("Otherplayer died");
        spriteRenderer.sprite = zombieFace;
    }

    public void MakeAlive()
    {
        spriteRenderer.sprite = face;
        //spriteRenderer.color = new Color(51, 94, 255, 255);
    }
}
