using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinShootScript : MonoBehaviour 
{
	PenguinData penguinData;

    //bullets
	public GameObject projectileBasic;
    public GameObject projectileSlimey;
    public GameObject projectileFrozen;
    public GameObject projectileInferno;
    public GameObject projectileCrusty;

    public GameObject target = null;

	// Use this for initialization
	void Start () 
	{
        Time.timeScale = 1;
        penguinData = (gameObject.GetComponent<PenguinData> ());
	}
	
	// Update is called once per frame
	void Update () 
	{
		TargetAtCursor ();
	}

	void TargetAtCursor()
	{
		if (Input.GetButtonDown("Fire1")/* && MouseOn == true */)
		{
            
            RaycastHit hitInfo = new RaycastHit();
			bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

            //Aim check
            if (hit)
			{
				Debug.Log("Hit " + hitInfo.transform.gameObject.name);
				if (hitInfo.transform.gameObject.tag == "Target" || hitInfo.transform.gameObject.tag == "B_Target" && hitInfo.transform.gameObject.tag != null)
				{
                    
                    if (penguinData.isInferno == false && penguinData.isSlimey == false && penguinData.isFrozen == false && penguinData.isCrusty == false)
                    {
                        
                        target = hitInfo.collider.gameObject;
                        Instantiate(projectileBasic, transform.position, Quaternion.identity);
                        Debug.Log("Basic Fish Shot");
                    }

                    if (penguinData.isFrozen == true)
                    {
                        target = hitInfo.collider.gameObject;
                        Instantiate(projectileFrozen, transform.position, Quaternion.identity);
                    }
                    if (penguinData.isSlimey == true)
                    {                       
                        target = hitInfo.collider.gameObject;
                        Instantiate(projectileSlimey, transform.position, Quaternion.identity);
                    }
                    if (penguinData.isCrusty == true)
                    {
                        target = hitInfo.collider.gameObject;
                        Instantiate(projectileCrusty, transform.position, Quaternion.identity);
   
                    }
                    if (penguinData.isInferno == true)
                    {
                        target = hitInfo.collider.gameObject;
                        Instantiate(projectileInferno, transform.position, Quaternion.identity);
                        
                    }
				if (hitInfo.transform.gameObject.tag == null)
                    {

                    }
                    //Instantiate (projectileObj, penguin.transform.position, penguin.transform.rotation);

                    Debug.Log ("Object Clicked");
				} else {
					Debug.Log ("nopz");
				}
			} else {
				Debug.Log("No hit");
			}
			Debug.Log("Mouse is down");
		}
	}



}
