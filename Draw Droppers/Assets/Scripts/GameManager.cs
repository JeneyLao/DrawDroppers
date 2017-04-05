using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour {

    /*
    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
     */

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CmdChangeColor(NetworkInstanceId playerNetID, GameObject np)
    {
        /*
        GameObject op = NetworkServer.FindLocalObject(playerNetID);

        Vector3 pos = op.transform.position;
        Quaternion rot = op.transform.rotation;

        var conn = op.GetComponent<NetworkIdentity>().connectionToClient;
        GameObject newPlayer = Instantiate(np, pos, rot);
        Debug.Log("op: " + op);
        Debug.Log("conn: " + conn.connectionId);
        //Destroy(op.gameObject);

        Debug.Log("In ChangeColor, np.name is: " + np.name);
        Debug.Log("In ChangeColor, newPlayer: " + newPlayer.name);
        

        NetworkServer.ReplacePlayerForConnection(conn, newPlayer, 0);
         * */
    }
}
