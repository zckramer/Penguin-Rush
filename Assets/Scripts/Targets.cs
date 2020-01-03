using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour 
{

	//Object References
	[SerializeField]
	GameObject targetingSphere;

	//Script References

	//Boolean Variables
	public bool mouseOn = false;
	public bool isclicked = false;
	public bool isTarget = false;

	//Rendering Variables
	MeshRenderer meshRenderer;

    // Use this for initialization
    void Start () 
	{
		targetingSphere = transform.Find ("Targeting").gameObject;
		meshRenderer = (targetingSphere.GetComponent<MeshRenderer> ());
	}
		
    // Update is called once per frame
    void Update () 
	{
		
    }

	void OnMouseEnter()
	{
//		targetingSphere.SetActive(true);
		meshRenderer.enabled = true;
		mouseOn = true;
	}

	void OnMouseExit()
    {
//		targetingSphere.SetActive(false);
		meshRenderer.enabled = false;
		mouseOn = false;

    }
}
