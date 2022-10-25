using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingMiniGame : MonoBehaviour
{
    [Header("Fishing Area")]
    [SerializeField] Transform topBounds;
    [SerializeField] Transform bottomBounds;

    [Header("Fish Settings")]
    [SerializeField] Transform fish;
    [SerializeField] float smoothMotion = 3f; // smooth out fish movement
    [SerializeField] float fishTimeRandomizer = 3f; // how often the fish moves
    float fishPosition;
    float fishSpeed;
    float fishTimer;
    float fishTargetPosition;

    [Header("Hook Settings")]
    [SerializeField] Transform hook;
    [SerializeField] float hookSize = .18f;
    [SerializeField] float hookSpeed = .1f;
    [SerializeField] float hookGravity = .05f;
    float hookPosition;
    float hookPullVelocity;

    [Header("Progress Bar Settings")]
    [SerializeField] Transform progressBarContainer;
    [SerializeField] float hookPower;
    [SerializeField] float progressBarDecay;
    float catchProgress;

    // public inventories playerInventory;

    private void Start() {
        catchProgress = .2f;
    }


    private void FixedUpdate() {
        MoveFish();
        MoveHook();
        CheckProgress();
    }


    private void MoveFish() {
        // Based on a timer, pick random position
        //Move fish to that position smoothly
        fishTimer -= Time.deltaTime;
        if (fishTimer < 0) {
            fishTimer = Random.value * fishTimeRandomizer; // Reset the timer
            fishTargetPosition = Random.value; // Pick a new target position
        }
        fishPosition = Mathf.Clamp(fishPosition, hookSize / 2, 1 - (hookSize / 2));
        fishPosition = Mathf.SmoothDamp(fishPosition, fishTargetPosition, ref fishSpeed, smoothMotion); // Calculate the current fish position
        fish.position = Vector3.Lerp(bottomBounds.position, topBounds.position, fishPosition); // Move between bottomBounds and topBounds to the new fish position

    }


    private void MoveHook() {
        // If the mouse button is clicked, increase the pull velocity
        if (Input.GetMouseButton(0)) {
            hookPullVelocity += hookSpeed * Time.deltaTime; // raise the hook
        }
        hookPullVelocity -= hookGravity * Time.deltaTime; // gravity lowers the hook
        hookPosition += hookPullVelocity; // change the hook position

        // The current position of the hook
        float minPosition = hookPosition - (hookSize / 2);
        float maxPosition = hookPosition + (hookSize / 2);

        // Prevent the velocity from change when the hook is at the bottom or top
        if ((minPosition <= 0) && hookPullVelocity < 0) {
            hookPullVelocity = 0;
        }
        if ((maxPosition >= 1) && hookPullVelocity > 0) {
            hookPullVelocity = 0;
        }

        hookPosition = Mathf.Clamp(hookPosition, hookSize / 2, 1 - (hookSize / 2)); // Keep the hook in bounds
        hook.position = Vector3.Lerp(bottomBounds.position, topBounds.position, hookPosition); // Move between bottomBounds and topBounds to the new hook position


    }


    private void CheckProgress() {
        Vector3 progressBarScale = progressBarContainer.localScale; // Get the y value of the progress bar
        progressBarScale.y = catchProgress; // 
        progressBarContainer.localScale = progressBarScale; // Update the Y value of the parent object (progress bar)

        // Edges of the hook
        float bottomEdge = hookPosition - hookSize / 2;
        float topEdge = hookPosition + hookSize / 2;

        // If the fish is contained within the edges of the hook increase the progress bar, if not, decrease it
        if ((bottomEdge < fishPosition) && (topEdge > fishPosition)) {
            catchProgress += hookPower * Time.deltaTime;
            
            // Catch the fish if progress bar is full
            if (catchProgress >= 1) {
                // Should replace with an animation?
                // playerInventory.itemList.Add();
                Debug.Log("You win!");
            }
        } else {
            catchProgress -= progressBarDecay * Time.deltaTime;

            // Don't catch the fish if the progress bar is empty
            if (catchProgress <= 0) {
                Debug.Log("You lose");
            }
        }
        
        catchProgress = Mathf.Clamp(catchProgress, 0, 1);
    }









}
