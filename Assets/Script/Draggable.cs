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
        //�}�E�X�J�[�\���y�уI�u�W�F�N�g�̃X�N���[�����W���擾
        Vector3 objectScreenPoint =
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1);

        //�X�N���[�����W�����[���h���W�ɕϊ�
        Vector3 objectWorldPoint = Camera.main.ScreenToWorldPoint(objectScreenPoint);

        //�I�u�W�F�N�g�̍��W��ύX����
        transform.position = objectWorldPoint;
        //Vector3 thisPosition = Input.mousePosition;

        //Vector3 worldPosition = Camera.main.ScreenToWorldPoint(thisPosition);

        //this.transform.position = worldPosition;

        //Debug.Log(thisPosition.x);
    }
}