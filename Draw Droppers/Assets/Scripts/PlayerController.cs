using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{

    public GameObject dotPrefab;
    public Transform dotSpawn;

    public GameObject circlePrefab;
    public Transform circleSpawn;

    private GameObject[] g;

    // Use this for initialization
    void Start()
    {
        g = new GameObject[2];
    }

    // Update is called once per frame
    void Update()
    {

        if (!isLocalPlayer)
        {
            return;
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
            

    }

    [Command]
    void CmdFire()
    {
        var dot = (GameObject)Instantiate(dotPrefab, dotSpawn.position, dotSpawn.rotation);

        dot.GetComponent<Rigidbody2D>().velocity = dot.transform.forward * 6;
        NetworkServer.Spawn(dot);

    }

    [Command]
    void CmdDraw()
    {
        foreach (GameObject s in g)
            Destroy(s);

        var dot = (GameObject)Instantiate(circlePrefab, circleSpawn.position, circleSpawn.rotation);

        dot.GetComponent<Rigidbody2D>().velocity = dot.transform.forward * 6;
        NetworkServer.Spawn(dot);

        Destroy(dot, 0.05f);
    }

    [Command]
    void CmdDraw2()
    {
        foreach (GameObject s in g)
            Destroy(s);


        var dot = (GameObject)Instantiate(circlePrefab, circleSpawn.position, circleSpawn.rotation);

        dot.GetComponent<Rigidbody2D>().velocity = dot.transform.forward * 6;
        NetworkServer.Spawn(dot);
        g[0] = dot;
    }

    void CmdUp()
    {
        this.transform.Translate(0, Time.deltaTime * 3.0f, 0);
    }

    void CmdLeft()
    {
        this.transform.Rotate(0, 0, Time.deltaTime * 150.0f);
    }

    void CmdDown()
    {
        this.transform.Translate(0, Time.deltaTime * -3.0f, 0);
    }

    void CmdRight()
    {
        this.transform.Rotate(0, 0, Time.deltaTime * -150.0f);
    }

    public override void OnStartLocalPlayer()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
    }
}
