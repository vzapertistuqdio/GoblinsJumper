using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour,ISubject {

    private HatShopMode hatShopMode;
    private BodyShopMode bodyShopMode;
    private IShopMode currentShopmode;

    private List<IObserver> observers = new List<IObserver>();

    int mode = 0;

    private void Start () {
        hatShopMode = GetComponent<HatShopMode>();
        bodyShopMode = GetComponent<BodyShopMode>();
        SetShopMode(2);     
    }
	
	private void Update () {
      
    }

    public IShopMode GetCurrentMode()
    {
        return currentShopmode;
    }

    public void RegisterObserver(IObserver o)
    {
        observers.Add(o);
    }

    public void RemoveObserver(IObserver o)
    {
        observers.Remove(o);
    }

    public void NotifyObsevers()
    {
        for (int i = 0; i < observers.Count; i++)
        {
            IObserver observer = observers[i];
            observer.UpdateObservers(currentShopmode);

        }
    }
    public void MeasuremetsChanged()
    {
        NotifyObsevers();
    }

    public void SetShopMode(int i)
    {
        if(i==1 && mode!=1)
        {
            mode = 1;
            currentShopmode = hatShopMode;
            MeasuremetsChanged();
        }
        if (i == 2 && mode != 2)
        {
            mode = 2;
            currentShopmode = bodyShopMode;
            MeasuremetsChanged();
        }

    }
}
