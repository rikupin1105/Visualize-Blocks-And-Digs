using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createMesh : MonoBehaviour
{
    public Material material;
    private GameObject _ball;
    private GameObject _player;

    public Mesh mesh;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Create(GameObject ball, GameObject player)
    {
        _ball = ball;
        _player = player;

        MeshFilter mf = GetComponent<MeshFilter>();
        MeshRenderer mr = GetComponent<MeshRenderer>();

        Vector3[] verts = new Vector3[4];
        int[] trinangles = { 0, 1, 3, 1, 2, 3 };

        verts[0] = new Vector3(-2, 5, -1);
        verts[1] = new Vector3(5, 5, -1);
        verts[2] = new Vector3(5, -5, -1);
        verts[3] = new Vector3(-5, -5, -1);

        mesh = new Mesh();
        mesh.vertices = verts;
        mesh.triangles = trinangles;
        mesh.RecalculateNormals();

        mf.sharedMesh = mesh;
        mr.sharedMaterial = material;
    }

    // Update is called once per frame
    void Update()
    {
        if(_ball is null || _player is null)
        {
            return;
        }

        float dis = Vector3.Distance(_player.transform.position, _ball.transform.position);
        
        //ボールの上部とプレーヤーの
        var ang1 = GetAngle(new Vector2(_player.transform.position.x, (float)(_player.transform.position.y + 0.5)),
            new Vector2((float)(_ball.transform.position.x), (float)(_ball.transform.position.y-0.25)));

        var ang2 = GetAngle(new Vector2(_player.transform.position.x, (float)(_player.transform.position.y - 0.5)),
            new Vector2((float)(_ball.transform.position.x), (float)(_ball.transform.position.y+0.25)));

        var a = 9 - _ball.transform.position.x;
        var h = a * Math.Tan(ToRadian(ang1));
        var h1 = a * Math.Tan(ToRadian(ang2));

        Vector3[] verts = new Vector3[4];
        int[] trinangles = { 0, 1, 3, 1, 2, 3 };

        verts[0] = new Vector3((float)(_player.transform.position.x), (float)(_player.transform.position.y - 0.5), -1);
        verts[1] = new Vector3((float)(_player.transform.position.x), (float)(_player.transform.position.y + 0.5), -1);
        verts[2] = new Vector3(9, (float)(_ball.transform.position.y + h), -1);
        verts[3] = new Vector3(9, (float)(_ball.transform.position.y + h1), -1);

        mesh.vertices = verts;
        mesh.triangles = trinangles;
        mesh.RecalculateNormals();
    }
    public void DestroyCommand()
    {
        Destroy(this.gameObject);
    }
    
    public double ToRadian(double deg)
    {
        return deg * Math.PI / 180.0;
    }
    public double ToDeg(double rad)
    {
        return rad * 180 / Math.PI;
    }
    float GetAngle(Vector2 start, Vector2 target)
    {
        Vector2 dt = target - start;
        float rad = Mathf.Atan2(dt.y, dt.x);
        float degree = rad * Mathf.Rad2Deg;

        degree = (degree + 180) % 360;
        if(degree < 0)
        {
            degree += 360;
        }
        return degree;
    }
}
