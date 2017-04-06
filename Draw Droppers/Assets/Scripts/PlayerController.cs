using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{

    public GameObject dotPrefab;
    public Transform dotSpawn;

    public GameObject whiteCircle;
    public GameObject blackCircle;
    public GameObject redCircle;
    public GameObject orangeCircle;
    public GameObject yellowCircle;
    public GameObject greenCircle;
    public GameObject darkGreenCircle;
    public GameObject blueCircle;
    public GameObject cyanCircle;
    public GameObject purpleCircle;
    public GameObject pinkCircle;



    public GameObject circlePrefab;
    public Transform circleSpawn;

    public GameObject ballPrefab;
    public Transform ballSpawn;

    private GameObject[] g;

    public GameObject o;
    private GameObject p;

    GameObject c;

    int count = 0;
    [SyncVar] Color color;

    // Use this for initialization
    void Start()
    {
        c = dotPrefab;
        g = new GameObject[2];
        color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
            //GameObject.FindGameObjectWithTag("Egg").GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
    }

    // Update is called once per frame
    void Update()
    {

        if (!isLocalPlayer)
        {
            return;
        }

        if (count == 0)
        {
            p = (GameObject)Instantiate(o, circleSpawn.position, circleSpawn.rotation);
            NetworkServer.Spawn(p);
            count = 1;
        }

        //var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        //var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        //this.transform.Rotate(0, 0, -x);
        //this.transform.Translate(z, 0, 0);

        if (Input.GetButton("Fire1"))
        {
            CmdFire();
        }
        if (Input.GetKey(KeyCode.W))
        {
            CmdUp();
            CmdDraw();

        }
        if (Input.GetKey(KeyCode.A))
        {
            CmdLeft();
            CmdDraw();

        }
        if (Input.GetKey(KeyCode.S))
        {
            
            CmdDown();            
            CmdDraw();

        }
        if (Input.GetKey(KeyCode.D))
        {
            CmdRight();
            CmdDraw();
        }
        if ((Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
            && !(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            //CmdDraw2();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject[] g = GameObject.FindGameObjectsWithTag("Ball");
            if (g.Length == 0)
                CmdDrop();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            CmdDeleteDrop();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("Pressed Y");
            CmdDeleteDot();
        }
            

    }
    [Command]
    void CmdDrop()
    {
        var ball = (GameObject)Instantiate(ballPrefab, ballSpawn.position, ballSpawn.rotation);
        NetworkServer.Spawn(ball);
    }

    [Command]
    void CmdDeleteDot()
    {
        Debug.Log("went in here");
        GameObject[] a = GameObject.FindGameObjectsWithTag("Dot");
        foreach (GameObject go in a)
        {
            NetworkServer.Destroy(go.gameObject);
        }
    }

    [Command]
    void CmdDeleteDrop()
    {
        GameObject[] g = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject go in g)
        {
            NetworkServer.Destroy(go.gameObject);
        }
    }

    [Command]
    void CmdFire()
    {
        var dot = (GameObject)Instantiate(c, dotSpawn.position, dotSpawn.rotation);
        NetworkServer.Spawn(dot);
    }

    [Command]
    void CmdDraw()
    {
        foreach (GameObject s in g)
            Destroy(s);

        var dot = (GameObject)Instantiate(circlePrefab, circleSpawn.position, circleSpawn.rotation);
        NetworkServer.Spawn(dot);

        Destroy(dot, 0.05f);
    }

    [Command]
    void CmdDraw2()
    {
        foreach (GameObject s in g)
            Destroy(s);

        var dot = (GameObject)Instantiate(circlePrefab, circleSpawn.position, circleSpawn.rotation);
        NetworkServer.Spawn(dot);
        g[0] = dot;
    }

    void CmdUp()
    {
        p.transform.Translate(0, Time.deltaTime * 3.0f, 0);
        this.transform.Translate(0, Time.deltaTime * 3.0f, 0);
    }

    void CmdLeft()
    {
        p.transform.Rotate(0, 0, Time.deltaTime * 150.0f);
        this.transform.Rotate(0, 0, Time.deltaTime * 150.0f);
    }

    void CmdDown()
    {
        p.transform.Translate(0, Time.deltaTime * -3.0f, 0);
        this.transform.Translate(0, Time.deltaTime * -3.0f, 0);
    }

    void CmdRight()
    {
        p.transform.Rotate(0, 0, Time.deltaTime * -150.0f);
        this.transform.Rotate(0, 0, Time.deltaTime * -150.0f);
    }

    public override void OnStartLocalPlayer()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "BlackCircle")
            c = blackCircle;
        if (col.name == "WhiteCircle")
            c = whiteCircle;
        if (col.name == "RedCircle")
            c = redCircle;
        if (col.name == "OrangeCircle")
            c = orangeCircle;
        if (col.name == "YellowCircle")
            c = yellowCircle;
        if (col.name == "GreenCircle")
            c = greenCircle;
        if (col.name == "DarkGreenCircle")
            c = darkGreenCircle;
        if (col.name == "BlueCircle")
            c = blueCircle;
        if (col.name == "CyanCircle")
            c = cyanCircle;
        if (col.name == "PurpleCircle")
            c = purpleCircle;
        if (col.name == "PinkCircle")
            c = pinkCircle;
    }
}
