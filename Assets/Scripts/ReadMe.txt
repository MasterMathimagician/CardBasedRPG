The requirements for the function of the scripts:

Menu Screen:

-New Game, Load Game and options.

	New Game:
		- creates a neccessay blank game with starting stats for the player character and loads the first scene for 
		the game, potentially with an intro that introduces the the player to the game (ex prof oaks intro)

	Load Game:
		-Loads character stats, decks, completion status and the current scene the character is in

	Options:
		- TBD, will probable include text speed (if necessary) and sound effects/music volume

OverWorld:

	-This is a series of scenes which represent the world the character is in, at any time the character should
	be able to open a menu that alows them to see their status, build decks, save, check and use items and set
	options
	-Ability to interact with the environment with talk/interact button plus potentially held items


Battle Scene:

	-This is the most complicated part of the game which requires loading character stats (enemy and player),
	character decks, controlling turn order, card draw, card use, stat changes, experience (if implemented), 
	running graphics for each action and switching to either a game over scene or back to the overworld scene
	as appropriate

	Turn order: either player could go first, probably base it on a speed stat, then players will alternate 
		(traditional rpg style) rather than both take turns at the same time (pokemon style)
	
	Interaction: There are good arguments for making turns non-interactive or somewhat interactive but for now
		turn interaction will be kept to a minimum, both for simplicity in implementation and for the ai
	
	The Turn: 
		Stage 1: mana regenerates (constant number of mp decided by stats and effects), cooldowns are decremented 
			and abilities taken off cooldown as appropriate and a set number of cards are drawn as appropriate (may
			be a choice between 2 decks, ex 2 cards from base deck or 1 from alt deck, still undecided)
		Stage 2: cards and abilities are played according to the player or AI's choices, mostly focused on buffing 
			the character for a single attack in stage 3 or debuffing the opponent
		Stage 3: The big attack player attacks opponent with weapon/mage power and all buffs/debuffs are taken into
			account including counter attacks
		Stage 4: Any final actions may be taken, cards played, abilities used, ai will avoid using abilities that
			are useless (ex turn end buff/debuffs) and then the turn may be ended by the active player

	Victory/defeat: either health reaches 0 for one character or an alternate win con is acheived (potential 
		for later implementations, such as a trap laid or a character imobilized)