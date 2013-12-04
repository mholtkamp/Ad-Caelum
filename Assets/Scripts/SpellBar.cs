using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpellBar{
	
	public Spell[] currentSpells;
	public int selectedSpell;
	public List<Spell> spellPool;
	selectedClassScript scs;

	public SpellBar()
	{
		currentSpells = new Spell[3];
		selectedSpell = 0;
		
		scs = GameObject.Find ("selectedClass").GetComponent(typeof(selectedClassScript)) as selectedClassScript;
		if(scs.selectedClass == 0)
			setUpWarriorSpells();
		else if(scs.selectedClass == 1)
			setUpArcherSpells();
		else
			setUpWizardSpells();	
		//setUpSpellPool();
		drawSpells();
	}
	
	public bool activate()
	{
		if(currentSpells[selectedSpell] != null)
		{
			currentSpells[selectedSpell].activate();
			currentSpells[selectedSpell] = null;
			cycleSelectedSpell();
			return true;
		}
		else
			return false;
	}
	
	public void cycleSelectedSpell()
	{
		if((currentSpells[0] == null)&&(currentSpells[1] == null)&&(currentSpells[2] == null))
		{
		
		}
		else
		{
			selectedSpell++;
			if(selectedSpell > 2)
			{
				selectedSpell = 0;
			}
			if(currentSpells[selectedSpell] == null)
			{
				selectedSpell++;
				if(selectedSpell > 2)
				{
					selectedSpell = 0;
				}
				if(currentSpells[selectedSpell] == null)
				{
					selectedSpell++;
					if(selectedSpell > 2)
					{
						selectedSpell = 0;
					}
				}	
			}			
		}
		
	}
	
	private void setUpSpellPool()
	{
		spellPool = new List<Spell>();
		//Put starting Spell Pool here. 
		//Add variation for different classes once they get implemented.
		spellPool.Add (new FireBall());
		spellPool.Add (new FireBall());
		spellPool.Add (new FireBall());
		spellPool.Add (new FireBall());
		spellPool.Add (new FrostWall());
		spellPool.Add (new Speed());
		spellPool.Add (new FrostWall());
		spellPool.Add (new Speed());
		spellPool.Add (new FrostWall());
		spellPool.Add (new Detonate());
		spellPool.Add (new Detonate());
		spellPool.Add (new Detonate());
		spellPool.Add (new Detonate());
		spellPool.Add (new IceBall());
		spellPool.Add (new IceBall());
		spellPool.Add (new IceBall());
		spellPool.Add (new IceBall());
			spellPool.Add (new Familiar());
		spellPool.Add (new Familiar());
		spellPool.Add (new Familiar());
		spellPool.Add (new Familiar());
				spellPool.Add (new Charge());
		spellPool.Add (new Charge());
		spellPool.Add (new Charge());
		spellPool.Add (new Charge());
				spellPool.Add (new Barrier());
		spellPool.Add (new Barrier());
		spellPool.Add (new Barrier());
		spellPool.Add (new Barrier());
			spellPool.Add (new Swords());
		spellPool.Add (new Swords());
		spellPool.Add (new Swords());
		spellPool.Add (new Swords());









	}
	
	private void setUpWarriorSpells()
	{
		spellPool = new List<Spell>();
		spellPool.Add (new Barrier());
		spellPool.Add (new Barrier());
		spellPool.Add (new Barrier());
		spellPool.Add (new Charge());
		spellPool.Add (new Charge());
		spellPool.Add (new Charge());
		spellPool.Add (new Swords());
		spellPool.Add (new Swords());
		spellPool.Add (new Swords());
		spellPool.Add (new Speed());
		spellPool.Add (new Speed());
		spellPool.Add (new FireBall());
		spellPool.Add (new FireBall());
		spellPool.Add (new Detonate());
		spellPool.Add (new FrostWall());
		spellPool.Add (new Familiar());
		spellPool.Add (new IceBall());
	}
	
	private void setUpArcherSpells()
	{
		spellPool = new List<Spell>();
		spellPool.Add (new Familiar());
		spellPool.Add (new Familiar());
		spellPool.Add (new Familiar());
		spellPool.Add (new Speed());
		spellPool.Add (new Speed());
		spellPool.Add (new Speed());
		spellPool.Add (new Detonate());
		spellPool.Add (new Detonate());
		spellPool.Add (new Detonate());
		spellPool.Add (new Swords());
		spellPool.Add (new Swords());
		spellPool.Add (new Barrier());
		spellPool.Add (new Barrier());
		spellPool.Add (new FrostWall());
		spellPool.Add (new FrostWall());
		spellPool.Add (new IceBall());
		spellPool.Add (new FireBall());
		spellPool.Add (new Charge());
	}
	
	public void setUpWizardSpells()
	{
		spellPool = new List<Spell>();
		spellPool.Add (new IceBall());
		spellPool.Add (new IceBall());
		spellPool.Add (new IceBall());
		spellPool.Add (new FireBall());
		spellPool.Add (new FireBall());
		spellPool.Add (new FireBall());
		spellPool.Add (new Barrier());
		spellPool.Add (new Barrier());
		spellPool.Add (new Barrier());
		spellPool.Add (new Detonate());
		spellPool.Add (new Detonate());
		spellPool.Add (new FrostWall());
		spellPool.Add (new FrostWall());
		spellPool.Add (new Familiar());
		spellPool.Add (new Familiar());
		spellPool.Add (new Swords());
		spellPool.Add (new Swords());
		spellPool.Add (new Speed());
		spellPool.Add (new Charge());











	}
	
	public void drawSpells()
	{
		for(int i = 0; i < 3; i++)
			currentSpells[i] = spellPool[Random.Range(0,spellPool.Count)];
	}
	
}
