using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private const int zombiePushForce = 10;

    private const float minInitialYZombiePosition = 0.02f;
    private const float maxInitialYZombiePosition = 5.02f;

    private int selectedZombieIndex = 0;
    private int numberOfZombies;

    public GameObject selectedZombie;

    public List<GameObject> zombies;

    public Vector3 selectedSize;
    public Vector3 defaultSize;

	void Start () {
        InitializeZombiesYPosition();
        SelectedZombie(selectedZombie);
        numberOfZombies = zombies.Count;
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("left")) {
            ChangeSelectedZombie(-1);
        }

        if (Input.GetKeyDown("right")) {
            ChangeSelectedZombie(1);
        }

        if (Input.GetKeyDown("up")) {
            PushUpZombie();
        }
    }

    void ChangeSelectedZombie(int modifier) {
        selectedZombieIndex = (selectedZombieIndex + (modifier)) % numberOfZombies;
        if(selectedZombieIndex < 0) {
            selectedZombieIndex = 0;
        }

        NotSelectedZombie(selectedZombie);
        selectedZombie = zombies[selectedZombieIndex];
        SelectedZombie(selectedZombie);
    }

    void SelectedZombie(GameObject newZombie) {
        newZombie.transform.localScale = selectedSize;
    }

    void NotSelectedZombie(GameObject newZombie) {
        newZombie.transform.localScale = defaultSize;
    }
     
    void PushUpZombie() {
        Rigidbody zombieRB = selectedZombie.GetComponent<Rigidbody>();

        zombieRB.AddForce(0, 0, zombiePushForce, ForceMode.Impulse);

    }

    void InitializeZombiesYPosition() {
        foreach(GameObject zombie in zombies) {
            zombie.transform.position = new Vector3(zombie.transform.position.x , Random.Range(minInitialYZombiePosition, maxInitialYZombiePosition), zombie.transform.position.z);
        }
    }


}
