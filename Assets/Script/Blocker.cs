using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.EventSystems;

public class Blocker : MonoBehaviour
{
    [SerializeField] GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        var shadePrefab = Resources.Load<GameObject>("Shade");
        var s = Instantiate(shadePrefab);
        var g = s.GetComponent<createMesh>();
        g.Create(ball, this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
