using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductController : MonoBehaviour {

    private List<ProductMenuController> products;

    /// <summary>
    /// This will force all products to update thei gui.
    /// </summary>
    public void UpdateProducts()
    {
        foreach (ProductMenuController product in products)
        {
            product.InitProductMenuGUI();
        }
        Debug.Log("Updated Values for Products.");
    }

    /// <summary>
    /// This will register a product and add to this local list.
    /// </summary>
    /// <param name="pmc"></param>
    public void RegisterProduct(ProductMenuController pmc)
    {
        products.Add(pmc);
    }

	// Use this for initialization
	void Start ()
    {
        products = new List<ProductMenuController>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
