using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    [SerializeField] float screenWidthUnits = 16f;
    [SerializeField] float minXClamp = 1f;
    [SerializeField] float maxXClamp = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        float mousePositionUnits = Input.mousePosition.x / Screen.width * screenWidthUnits;
        Vector2 paddlePos = new Vector2(mousePositionUnits, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePositionUnits, minXClamp, maxXClamp);
        transform.position = paddlePos;
    }
}
