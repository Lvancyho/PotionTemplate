using UnityEngine;

namespace World.Game
{
    public class Cauldron : MonoBehaviour
    {
        /*TODO:
         1. Command Pattern (Stacks)
          - Add items into pot via onTriggerEnter
          - Get rid of the object temporarily
          - Slowly fill up the pot shader
          - On "undo" Spit the item back out and re-enable it
          - On "undo" disable adding items for 3 seconds
          - After cooldown ends, check if anything is still in volume, if it is the re-add it 
        2. Worldspace UI
          - Factory to make the UI
          - UI will show up on Ingredients, Potions and the Cauldron (Only if the Cauldron has items in it - Conditional)
          - The Cauldron UI will contain two buttons (Undo and Brew)
          - On brew, just spawn in some random basic potion
        */
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
