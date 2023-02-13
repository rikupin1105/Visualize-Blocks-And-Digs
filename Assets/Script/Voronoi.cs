using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Voronoi : MonoBehaviour
{
    // Start is called before the first frame update
    private List<GameObject> _players = new();
    private List<GameObject> _square = new();
    void Start()
    {
        _players.Add(GameObject.Find("Player (1)"));
        _players.Add(GameObject.Find("Player (2)"));
        _players.Add(GameObject.Find("Player (3)"));
        _players.Add(GameObject.Find("Player (4)"));
        _players.Add(GameObject.Find("Player (5)"));
        _players.Add(GameObject.Find("Player (6)"));

        var prefab = Resources.Load<GameObject>("Square");
        for (double i = 0; i < 9; i += 0.2)
        {
            for (double j = -4.5; j <= 4.5; j+=0.2)
            {
                var s = Instantiate(prefab) as GameObject;
                s.transform.position = new Vector3((float)((float)i+0.1f), (float)j+0.1f);

                _square.Add(s);

                //var renderer = s.GetComponent<Renderer>();

                //var color = new Color(255/o, 100, 255/o);
                //Debug.Log(color);
                //renderer.material.color = color;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in _square)
        {
            var o = NearObject(item.transform.position.x, item.transform.position.y);

            Debug.Log(o);
            item.GetComponent<SpriteRenderer>().material.color = GetColor(o);
        }
    }
    Color GetColor(int i)
    {
        Color.HSVToRGB(0.8f, 1f, 1f);

        switch (i)
        {
            case 1:
                return Color.HSVToRGB(0.8f, 0.5f, 1f);
            case 2:
                return Color.HSVToRGB(0.7f, 0.5f, 1f);
            case 3:
                return Color.HSVToRGB(0.5f, 0.5f, 1f);
            case 4:
                return Color.HSVToRGB(0.3f, 0.5f, 1f);
            case 5:
                return Color.HSVToRGB(0.1f, 0.5f, 1f);
            case 6:
                return Color.HSVToRGB(0.0f, 0.5f, 1f);
            default:
                return Color.HSVToRGB(0.2f, 0.5f, 1f);
        }
    }

    int NearObject(double x, double y)
    {
        var ans = 10;
        var minDis = double.MaxValue;

        for (int i = 0; i < 6; i++)
        {
            var dis = Math.Sqrt((Math.Pow(x-_players[i].transform.position.x, 2))+(Math.Pow(y-_players[i].transform.position.y, 2)));
            if (dis < minDis)
            {
                minDis = dis;
                ans = i+1;
            }
        }
        return ans;
    }
}
