using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class PlayerController : NetworkBehaviour {

    public GameObject dotPrefab;
    public Transform dotSpawn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (!isLocalPlayer)
        {
            return;
        }

        if (Input.GetButton("Fire1"))
        {
            CmdFire();
        }

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, 0, -x);
        transform.Translate(z, 0, 0);
	}

    [Command]
    void CmdFire()
    {
        var dot = (GameObject)Instantiate(dotPrefab, dotSpawn.position, dotSpawn.rotation);

        dot.GetComponent<Rigidbody2D>().velocity = dot.transform.forward * 6;
        NetworkServer.Spawn(dot);
    }

    public override void OnStartLocalPlayer()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
    }
}
