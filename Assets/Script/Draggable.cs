using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDrag()
    {
        //マウスカーソル及びオブジェクトのスクリーン座標を取得
        Vector3 objectScreenPoint =
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);

        //スクリーン座標をワールド座標に変換
        Vector3 objectWorldPoint = Camera.main.ScreenToWorldPoint(objectScreenPoint);

        //オブジェクトの座標を変更する
        transform.position = objectWorldPoint;
        //Vector3 thisPosition = Input.mousePosition;

        //Vector3 worldPosition = Camera.main.ScreenToWorldPoint(thisPosition);

        //this.transform.position = worldPosition;

        //Debug.Log(thisPosition.x);
    }
}
