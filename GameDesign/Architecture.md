
>[!info] Observer Pattern
>The Observer Pattern is designed to minimise coupling by placing observers on objects.
>Observers are programs that activate when there is a relevant change that requires an action
>- E.g The food observing the cameras observation and changing its cook time based on this rather than having the camera call and function on the food through a raycast

>[!info] Elements
	==Food==
>- There will be multiple foods. To start, soup and grilled cheese. The foods have internal timers to 'cook' over time, varying based on player observing.
>- Food will have a start state and end state with stages of 'cooked' in-between
	 ==Camera==
>- The camera will act as the player, allowing them to move between foods.
>- This movement can happen through lerping sideways movement or allow a freelook style movement.
	==Score Board==
>- Overall Score increases based on amount of levels completed and score achieved within each level
>- Score in each level increases based on speed level completed


>[!info] Structure
> | Scenes | Content |
> | --- | --- |
> | StartScreen | - Play button - Controls - Quit Button |
> | Main | - Food select menu - Instructions - Score record - Begin |


> 



