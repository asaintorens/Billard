using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanneScript : MonoBehaviour
{

    public bool isRolling;
    public GameObject gameObject;
    public bool isPlaced;
    public int force;
    void Start()
    {
        isRolling = false;
        isPlaced = false;
        this.gameObject = GameObject.Find("canne");
        this.force = 100;
    }

    // Update is called once per frame
    void Update()
    {

        GameObject game = GameObject.Find("Table");
        game.SendMessage("IsRolling", this);

        if (!isRolling)
        {
            this.PlacerCanne();

        }
        else
        {
            this.HideCanne();
            
        }

        this.GetForce();
    }

    private void GetForce()
    {
                

                GameObject go = GameObject.Find("InputForce");
                InputFieldScript text = (InputFieldScript)go.GetComponent(typeof(InputFieldScript));
                try
                {
                    this.force = int.Parse(text.text.text);
                }
                catch (System.Exception)
                {

                    this.force = 100;
                }
               
     //  string toto = text.guiText.text;
       
    }

    private void HideCanne()
    {
        this.gameObject.renderer.enabled = false;
        this.isPlaced = false;
    }

    private void PlacerCanne()
    {
        if (!this.isPlaced)
        {
            GameObject maBille = GameObject.Find("BilleBlanche");
            Vector3 billePosition = maBille.rigidbody.position;
            this.gameObject.transform.position = new Vector3(billePosition.x + 95, billePosition.y, billePosition.z);
            this.gameObject.transform.rotation = new Quaternion(0, 0, 0.7f, 0.7f);
            // this.gameObject.transform.rotation.SetEulerRotation(new Vector3(0, 0, 90));
            this.gameObject.renderer.enabled = true;
            this.isPlaced = true;
        }
    }

    public void RotateLeft()
    {
        GameObject maBille = GameObject.Find("BilleBlanche");

        // this.gameObject.transform.Rotate((Vector3.right * Time.deltaTime)*5);
        this.gameObject.transform.RotateAround(maBille.rigidbody.position, Vector3.down, Time.deltaTime * 100);
    }
    public void RotateRight()
    {
        GameObject maBille = GameObject.Find("BilleBlanche");

        // this.gameObject.transform.Rotate((Vector3.right * Time.deltaTime)*5);
        this.gameObject.transform.RotateAround(maBille.rigidbody.position, Vector3.up, Time.deltaTime * 100);
    }
    public void Hit()
    {
        if (!this.isRolling)
        {
            GameObject maBille = GameObject.Find("BilleBlanche");

            Vector3 vecteurBille = maBille.transform.position;
            Vector3 vecteurCanne = GameObject.Find("canne").transform.position;
            /*
           

          

            float nouveauX = 0;
            float nouveauZ = 0;

            nouveauX = (maBille.transform.position.x - this.gameObject.transform.position.x) + vecteurBille.x;
            nouveauZ = (maBille.transform.position.z - this.gameObject.transform.position.z) + vecteurBille.z;

            Vector3 ImpacBalle = new Vector3(nouveauX , 0, nouveauZ) ;

         //   maBille.rigidbody.velocity = ImpacBalle;
            maBille.rigidbody.AddForce(ImpacBalle, ForceMode.Impulse);
             * */

            var dir = vecteurBille - vecteurCanne ;
            dir = dir.normalized;
            maBille.rigidbody.velocity = dir*this.force;
        }
    }
    public void OnDrawGizmos()
    {
        GameObject maBille = GameObject.Find("BilleBlanche");

        Vector3 vecteurBille = maBille.transform.position;
        Vector3 vecteurCanne = GameObject.Find("canne").transform.position;
        float nouveauX = 0;
        float nouveauZ = 0;

        nouveauX = (maBille.transform.position.x - this.gameObject.transform.position.x) + vecteurBille.x;
        nouveauZ = (maBille.transform.position.z - this.gameObject.transform.position.z) + vecteurBille.z;

        Vector3 ImpacBalle = new Vector3(nouveauX, maBille.transform.position.y, nouveauZ);



      //  Gizmos.DrawLine(this.gameObject.transform.position, maBille.transform.position);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(maBille.transform.position, ImpacBalle);

    }
}
