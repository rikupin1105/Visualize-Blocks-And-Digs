using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject ball;
    private bool isDisplay = true;
    private GameObject MeshObject;
    // Start is called before the first frame update
    void Start()
    {
        var shadePrefab = Resources.Load<GameObject>("Shade");
        var s = Instantiate(shadePrefab);
        var g = s.GetComponent<createMesh>();
        g.Create(ball, this.gameObject);

        MeshObject = s;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
