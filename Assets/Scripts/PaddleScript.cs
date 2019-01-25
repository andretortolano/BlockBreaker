using UnityEngine;

public class PaddleScript : MonoBehaviour{
    [SerializeField] float screenWidthUnits = 16f;
    [SerializeField] float minXClamp = 1f;
    [SerializeField] float maxXClamp = 15f;

    GameStatus theGame;
    BallScript theBall;

    // Start is called before the first frame update
    void Start()
    {
        theGame = FindObjectOfType<GameStatus>();
        theBall = FindObjectOfType<BallScript>();
    }

    // Update is called once per frame
    void Update(){
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minXClamp, maxXClamp);
        transform.position = paddlePos;
    }

    private float GetXPos() {
        if(theGame.IsAutoPlayEnabled()) {
            return theBall.transform.position.x;
        } else {
            return Input.mousePosition.x / Screen.width * screenWidthUnits;
        }
    }
}
