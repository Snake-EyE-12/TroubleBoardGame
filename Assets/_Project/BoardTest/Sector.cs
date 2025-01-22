using System.Collections.Generic;
using UnityEngine;

public class Sector : MonoBehaviour
{
    [SerializeField] private List<Slot> homePositions;
    [SerializeField] private List<Slot> goalPositions;
    [SerializeField] private List<Slot> loopPositions;

    public int sectorIndex { get; set; }
    public void CreatePegs(Peg peg, int homePos)
    {
        homePositions[homePos].SetPeg(peg);
    }

    public bool Contains(Slot slot, int amount, PlayerColors currentPegColor, Sector nextSector, out Slot placement)
    {
        if (homePositions.Contains(slot))
        {
            placement = GetTargetSlot();
            return true;
        }

        if (goalPositions.Contains(slot))
        {
            int index = goalPositions.IndexOf(slot);
            int nextPosIfPossible = index + amount;
            if (nextPosIfPossible < goalPositions.Count)
            {
                placement = goalPositions[nextPosIfPossible];
                return true;
            }
            placement = null;
            return false;
        }

        if (loopPositions.Contains(slot))
        {
            int index = loopPositions.IndexOf(slot);
            int nextPosIfPossible = index + amount;
            int nextPosOnNewSector = nextPosIfPossible - loopPositions.Count;
            
            //Going into goal
            //Going into same sector Slot
            //Going into new sector slot

            if (index >= 3) //Standing On Target or further
            {
                if (nextPosOnNewSector >= 0) //In next sector
                {
                    placement = nextSector.Step(nextPosOnNewSector, currentPegColor);
                }
                else
                {
                    placement = loopPositions[nextPosIfPossible];
                }
                return true;
            }

            if (nextPosIfPossible >= 3) //Would go into goal
            {
                if ((int)currentPegColor == sectorIndex) //Into goal
                {
                    if (nextPosIfPossible < 7) //Can fit
                    {
                        placement = goalPositions[nextPosIfPossible - goalPositions.Count + 1];
                        return true;
                    }

                    placement = null;
                    return false;
                }
                else
                {
                    if (nextPosIfPossible < 7) // Within same sector
                    {
                        placement = loopPositions[nextPosIfPossible];
                        return true;
                    }

                    placement = nextSector.Step(nextPosOnNewSector, currentPegColor);
                    return true;

                }
            }

            placement = loopPositions[nextPosIfPossible];
            return true;
        }
        
        placement = null;
        return false;
    }

    public Slot Step(int amount, PlayerColors color)
    {
        if (sectorIndex == (int)color)
        {
            if (amount > 2)
            {
                return goalPositions[amount - goalPositions.Count + 1];
            }
        }
        return loopPositions[amount];
    }
    private Slot GetTargetSlot()
    {
        return loopPositions[3];
    }

    public void ReturnToHome(Peg peg)
    {
        FindOpenSlotInHome().SetPeg(peg);
    }

    private Slot FindOpenSlotInHome()
    {
        foreach (var homePos in homePositions)
        {
            if (!homePos.HasPiece)
            {
                return homePos;
            }
        }
        throw new System.ArgumentException("Home Impossibly Filled");
    }
}