using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour{
    
    // Config
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    // References
    Level level;

    // State
    [SerializeField] int timesHits;

    private void Start() {
        level = FindObjectOfType<Level>();

        if(tag == "Breakable") {
            level.CountBreakableBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(tag == "Breakable") {
            timesHits++;
            int maxHits = hitSprites.Length + 1;
            if(timesHits >= maxHits) {
                DestroyBlock();
            } else {
                ShowNextHitSprite();
            }
        }
    }

    private void ShowNextHitSprite() {
        int spriteIndex = timesHits - 1;
        if(hitSprites[spriteIndex] != null) {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        } else {
            Debug.LogError("Block Sprite is Missing from Array :" + gameObject.name);
        }
    }

    private void DestroyBlock() {
        Destroy(gameObject);
        level.BlockDestroyed();
        FindObjectOfType<GameStatus>().AddToScore();
        TriggerSparklesVFX();
        PlayingBreakSFX();
    }

    private void PlayingBreakSFX() {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX() {
        Destroy(Instantiate(blockSparklesVFX, transform.position, transform.rotation), 1f);
    }
}
