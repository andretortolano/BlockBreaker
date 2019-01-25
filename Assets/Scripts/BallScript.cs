using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] PaddleScript paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;


    bool isLaunched;

    Vector2 paddleToBallVector;

    // Cached component References
    AudioSource mAudioSource;
    Rigidbody2D mRigidBody2D;



    // Start is called before the first frame update
    void Start() {
        paddleToBallVector = transform.position - paddle1.transform.position;
        isLaunched = false;
        mAudioSource = GetComponent<AudioSource>();
        mRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isLaunched) {
            LockBallToPaddle();
            LaunchOnMouseClick();
        } 
    }

    private void LockBallToPaddle() {
        Vector2 paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePosition + paddleToBallVector;
    }

    private void LaunchOnMouseClick() {

        if(Input.GetMouseButtonDown(0)) {
            mRigidBody2D.velocity = new Vector2(xPush, yPush);
            isLaunched = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Vector2 velocityRandom = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
        if(isLaunched) {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            mAudioSource.PlayOneShot(clip);
            mRigidBody2D.velocity += velocityRandom;
        }
    }
}
