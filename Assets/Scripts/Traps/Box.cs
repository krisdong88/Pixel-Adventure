using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Interactable,IBreakable
{

    private int Hits = 0;

    [SerializeField] private int maxHits = 1;
    [SerializeField] private int friutsNum = 3;

    [SerializeField] private GameObject[] parts;
    [SerializeField] private FruitsData fruitsData;
    private List<GameObject> summonedFruits;

    public IEnumerator Break()
    {
        GameObject[] fruits = fruitsData.fruits;
        yield return new WaitForSeconds(0.1f);

        summonedFruits = new List<GameObject>();
        for (int i = 0; i < friutsNum; i++)
        {
            GameObject fruit = Instantiate(fruits[Random.Range(0,8)],transform.position,Quaternion.identity,transform.parent.transform);
            fruit.GetComponent<Fruit>().SetIstantiated();
            summonedFruits.Add(fruit);
        }
        this.gameObject.SetActive(false);
        this.gameObject.transform.parent.GetChild(0).gameObject.SetActive(true);

        foreach(GameObject part in parts)
        {
            part.GetComponent<Rigidbody2D>().AddForce((this.transform.position-part.transform.position).normalized*Random.Range(300,600));
            part.GetComponent<Rigidbody2D>().AddTorque(Random.Range(0,50)*Random.Range(-1,1));
        }
        for(int i=0;i<summonedFruits.Count;i++)
            summonedFruits[i].GetComponent<Rigidbody2D>().AddForce(Vector2.right*Random.Range(-1,1)*Random.Range(300,500));
    
    }

    public override void Interact(Collision2D other)
    {
        shake = true;
        base.Interact(other);
        
        playerRB = other.gameObject.GetComponent<Rigidbody2D>();
        
            Hits++;
            GetComponent<Animator>().Play("Hit");

            if(IfBelow(other.transform.position))
                playerRB.velocity = new Vector2(playerRB.velocity.x,0);
            else if (IfAbove(other.transform.position))
                playerRB.AddForce(Vector2.up*1200);

            if(Hits >= maxHits)
                StartCoroutine(Break());
    }
}
