using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColliderChanger : MonoBehaviour {


	// Array of images for the snake's animation.
	// This is loaded in the Inspector.
	public Sprite[] aImages;
	
	// Dictionary containing an integer frame (sprite) index
	// and the associated polygon collider.
	private Dictionary<int, PolygonCollider2D> olFrameColliders;
	
	// tracks the current frame
	private int curFrame;
	
	// tracks the previous frame
	private int oldFrame;

	private Sprite oldSprite;
	private Sprite curSprite;
	private int spriteCount;
	
	// a reference to this game object's Sprite Renderer
	private SpriteRenderer oSpriteRenderer;

	private Animator animator;
	private string oldAnimation;
	private string currentAnimation;

	// Use this for initialization
	void Awake () {
//		animator = GetComponent<Animator>();
//		currentAnimation = animator.GetCurrentAnimatorStateInfo (0);
//
//		int size = animator.GetClipCount();
//		string[] ani_names = new string[size];
//		int counter = 0;
//		foreach (AnimationState states in _animation) {
//			ani_names[counter++] = states.name;
//		}

		oSpriteRenderer = this.GetComponent<SpriteRenderer>();

		oldSprite = null;
		curSprite = oSpriteRenderer.sprite;
		spriteCount = 0;

		// This section creates the colliders for this snake
		// First we need to instantiate the Dictionary.
		olFrameColliders = new Dictionary<int, PolygonCollider2D>();
		
		// loop through each Sprite (image) in our Images array
		for(int index = 0; index < aImages.Length; index++)
		{
			// switch to the current image we are processing
			oSpriteRenderer.sprite = aImages[index];
			
			// create the polygon collider and add it to the Dictionary
			olFrameColliders.Add(index, gameObject.AddComponent<PolygonCollider2D>());
			
			// disable the collider
			olFrameColliders[index].enabled = false;
			
			// set this as a Trigger.
			// May or may not apply to YOUR case depends on how you are doing collisions.
			olFrameColliders[index].isTrigger = true;
		}
		
		// Now initialize to the correct image the snake should start out displaying
		curFrame = 0;
		oldFrame = -1;
		oSpriteRenderer.sprite = aImages[curFrame];
		
		// Enable the collider associated with the current frame
		EnableCollider(true);

	}
	
	// Update is called once per frame
	void Update () {

		curSprite = oSpriteRenderer.sprite;

		// if the current frame is different from the frame displayed last update
//		if (curFrame != oldFrame)
		if(curSprite != oldSprite)
		{

			curFrame = spriteCount;
			// display the current sprite (frame)
			oSpriteRenderer.sprite = aImages[curFrame];
			
			// enable the associated polygon collider
			EnableCollider(true);
			
			// update the old frame to the current frame
			// so we can detect the next change in the image
			oldFrame = curFrame;

			oldSprite = curSprite;
			spriteCount++;
		}
	}

	private void EnableCollider(bool trueOrFalse)
	{
		PolygonCollider2D temp = null;
		// always disable the old collider
		if(olFrameColliders.TryGetValue(oldFrame, out temp))
			olFrameColliders[oldFrame].enabled = false;

		
		// enable or disable the current collider as requested
		olFrameColliders[curFrame].enabled = trueOrFalse;
	}
}
