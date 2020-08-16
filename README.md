# TextIsekai
 Text Version of Isekai Adventure

You've been reborn into a fantasy world, and with no connections or relationships you've decided to become an adventurer for financial reasons. You find yourself close to a settlement of sorts and head towards it. Welcome to <town name>, your adventure begins here.
 
Start of the game

Character “creation”
	Name
		One time, cannot change
	Gender
		Optional
	
	**** If you can get a nice artist to draw
	Face
		Eyes
		Mouth
	Hair
	Body --- then you can sell cosmetic costumes
		Body type
			Slim
			Muscular
			Wide

Game Tutorial
	Player is shown how to use the map; goes to the closest town
	Player is then introduced to the guilds and accepts first quest
	Player then heads out to the forest zone and learns the differences between gathering/hunting/etc
	Player returns back to the town and hands in the quest and gets the reward.
End of tutorial I guess, after that they can do whatever they want and explore the rest of the game elements like shops and stuff.

More Details

Towns/Cities
	Each town/city has a different assortment of buildings, e.g. guilds, shops, etc
	Some goods are regional, so you can only get them from places in a certain area of the world.
	## Could have Town Square, a place where the player can go and have a chance for a random event to happen.
	## Purchase properties??? If we have an actual inventory system this can be like a personal storage
	Any city/town with an adventurer’s guild building or outpost will have a questboard
Inn
		Rest to regen HP/MP over time
	Go to marketplace
	Weapon Shop
	Armour Shop
	Consumables (food/potions) Shops
	Materials Shop
	Guilds
		Adventurers
		Merchant
		Blacksmiths
		Magician
		etc
		For crafting, you need materials and to go to the right guild
	Marketplace
		Lists stuff to buy in a button array that is scrollable
	Can purchase multiples
	Auto sell
	Can sell multiples

Questboard
	Shows quests
		In a table, the table will show
			Quest Name
			Short Description
			Difficulty
				Measured in stars up to 10 (being the hardest e.g.fighting a god)	
			Issuer
			Rank requirement
				Higher difficulty = higher rank needed
				If requirement is not met it will be greyed out
			Reward
				Money
				Items
				Weapons/Armour
				Skills??
				etc
			## Maybe?? Deadline
				Time frame in which a quest must be complete or it is assumed you have abandoned it --- could eventually add a relationships system/prestige system, that is failing to do quests will lower your credibility and your rank will go down
	Quests selected by you will have a little icon to mark them

Quest Types
Gathering
Herbs
Ores
Hunting
Small animals
Medium sized animals
	Kill
		Smaller groups of goblins/orcs
		Groups of lesser insects
		Basically “go thin out the population of xx at xx”
Subjugations
Goblin villages
Orc encampments
Dragons
Giant Birds
Griffons
Wyverns
Giant Insects
Ogres
Nagas
etc

Travel
	Travel to new places for questing, exploring, for better crafting/markets or gathering purposes
Drop down list to go to specific locations faster, faster than scrolling the map	
	Has sorting/listing buttons	
	## Legacy but is cooler -Opens up map, tap on location circle and then choose between the actions available
		E.g. for a city options are enter or view info
		E.g. forest that has low numbers of hazards options are gather, hunt, gather/hunt, view info, 
	Dungeons
		Undead Dungeon
		Ice Dungeon
		Fire Dungeon
		Ocean Dungeon
		Forest Dungeon
Cave Dungeon
etc
Forests
		Goblins
		Orcs
		Gathering flowers/herbs/mushrooms
		Hunting wild animals
		Giant Insects
		Big Boars
etc
	Mountains
		Caves
	Swamp
	Cursed Land
		Undead
	Other biomes

Combat
	Note the following will apply if I dont do gathering AND hunting zones
Gathering
	No mob encounters
Hunting
	Mob encounters, but no need to actually battle as they are small wildlife or medium sized wildlife that are easy to kill

Out in the field - fighting intent
	Mob encounters, player will be able to manually activate skills or auto battle.
Player will auto dismantle mobs after fight when it is safe, unless the user cancels and proceeds to move on or leave the area
Dungeons
When you go to a dungeon you will run into mobs 100% and they get stronger as you progress through the dungeon; mob density is random and differs every floor
Deeper = better rewards

Menu
	Titles
	Book of knowledge
		Encyclopedia
		Title list

Shop
	Watch Ads
		Decrease <subject> timer by x amount of seconds or x% (1-8%)
	Use real currency
		Increased exp gains for x amount of time
		Increased chance of loot drops for x amount of times you gather/hunt/kill
		Decrease <Subject> timer by 50%
		
		etc

Gathering
Go to a location to look for herbs/fruits/plants/flowers/etc
Not every location has the same stuff

Hunting
Go to a location to hunt animals for their body parts (meat, bones, etc)
Not every location has the same animals
After a mob is killed the player walks up to the corpse and spends some time dismantling it
Hunt & Gather
Does both, gives less of each but get stuff from both

Offline aspects
	Currently selected quest is done repeatedly, max up to 5 times
	If player has no quest selected before closing game, no offline rewards will be got
	Money reward is reduced by 50%, for each time
	Loot gain is reduced by 40%, for each time
	No dismantling can happen(you dont get corpses to dismantle)
Crafting times continue through offline
Resting at an Inn while offline increases regen rates by 50%
Offline Skill Training
	You can select a skill to train while you’re offline if you are not questing or resting
Skill progression is reduced by 70% (does it very slowly offline, but still does it)

Biomes
	Grassland
	Desert
	Tundra
	Swamp
	Enchanted Forests
	Plains
	Forests
	Deadlands
	Badlands
	Decaying Forests
	

Enemies
	Hoi

Gathering Materials
	Konmlk


 
More About Character Stats and shit
Currency

HP/MP/SP are all restored by using items or resting at an inn
Any shit about damage calculation is subject to change, I want it to be fair, but only if the player puts in effort, like in real life. Nobody starting out with OP stats here boi

Character sheet format:

Name:
Level:
	You gain experience from killing mobs, after getting a certain amount you level up; as you level up it takes more exp to get to the next level; every level grants stat points which you use to increase your stats
Titles:
Age:
Gender:
Guild Rank:

Health Points (HP)
	Your base health pool
Mana Points (MP)
	Your base mana pool
If you choose more magical orientated for character, you have more MP than SP
Constitution
Increases HP by a % per point 
Wisdom
Increases MP by a % per point
Strength
	Affects your total physical damage output
Total strength value is multiplied by weapon/physical skill effectiveness against enemies for  Physical Damage
Intelligence
	Affects your total ability damage output
Total intelligence value is multiplied by magic effectiveness against enemies for Ability Damage
Dexterity
Affects speed that deals with physical movements
	Speed of swinging weapons or applying skills are reduced the more you have of this stat
Wits
	Affects speed that deals with magic
		Spell cast times are decreased the more you have of this stat
Skills
	Skills are obtained through reading skill books (which can be bought from vendors or from killing special mobs or conquering dungeons), or through training with specific weapons or by doing specific things
		E.g. sword users will learn blade technique and swords skills as they continue to use the sword
		E.g. mages will learn basic magic from skill books or trainers, and as they use that they will eventually learn more advanced magic or they can get them from skill books (skill books only provide skills up till intermediate class 1 tier
	Skills start off as a low rank (beginner) and progressively get better as you train and use them all the way to Heroic rank
		Beginner > Intermediate class 2 > Intermediate class 1 > Proficient class 2 > proficient class 1 > advanced > master > grandmaster > apex master > heroic 
		Names subject to become more cringy
		It takes longer to advance ranks the higher you go
	Skills have rank requirements as well as stat requirements
		Higher rank skills = you need to be a higher guild rank and have the minimum stats to use them
	Every won battle adds to your skills’ experience and gives points, getting to a certain amount will let you rank up your skill at the cost of money at the guild
	Physical Skills
		E.g. skill that increases constitution for a duration or buffs your defence for a duration
	Magical Skills
		E.g. elemental magic
Titles
Pretty much achievements that grant small buffs related to the title
They have 5 types
Some are easy some are hard
You can equip one title to display at top of character sheet
e.g. you kill x number of skeletons you get Bone Crusher level 1 title which increases your damage against skeletons by x% which increases as you level that title up
Armour
Grants Defence value
Physical Armour
Magical Armour
Damage reduction = def value * armour rank value / 2
Durability
Some armours are enchanted
Weapon
	Enhances your damage output
	Types
		Swords
		Axes
		Spears
		Bows
		Clubs
		Knuckles
Stats
Sharpness
	Swords, axes, 
Bluntness
	clubs
Piercing
	Bows, spears, knuckles
Durability
	Can be repaired at blacksmiths guild
Total Physical Damage with weapon = STR * stat value (always above 1)
Some weapons are imbued with magical energies and do magic damage as well

Items
Consumables
Potions / Elixirs
HP
MP
Stat increase Elixirs
Other


Ideas for future
Non combat/utility skills e.g. cooking or digging magic
food/hunger system for travelling
Random events
Extra ways to Train stats e.g. running laps around town increases your endurance
Day night cycle
