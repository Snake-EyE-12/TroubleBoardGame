using System.Collections.Generic;
using UnityEngine;

public class BoardCreator : MonoBehaviour
{
    public int PlayerCount { get; set; }
    [SerializeField] private Sector sectorPrefab;
    [SerializeField] private Peg pegPrefab;
    private List<Sector> sectors = new();

	public bool diceRollable = true;
	private List<Peg> pegs = new();
	private int currentPlayerTurn = 3;

	public void Build()
    {   
        BuildBoard();
        BuildPlayers();
	}

    private void BuildPlayers()
    {
        for (int i = 0; i < PlayerCount; i++)
        {
            int sectorIndex = GetSectorIndexForPlayerCount(i);
            BuildPegs(sectorIndex, (PlayerColors)i);
        }
    }

    public void ReturnPieceHome(Peg peg)
    {
        sectors[(int)peg.color].ReturnToHome(peg);
    }
    private int GetSectorIndexForPlayerCount(int index)
    {
        if (PlayerCount == 2 && index == 1) return 2;
        return index;
    }

    private void BuildPegs(int sectorIndex, PlayerColors color)
    {
        for(int i = 0; i < 4; i++)
        {
            Peg peg = Instantiate(pegPrefab, transform.position, Quaternion.identity);
            peg.color = color;
            peg.boardReference = this;
            sectors[sectorIndex].CreatePegs(peg, i);
            pegs.Add(peg);
        }
        
    }

    public int AdvancementAmount { get; set; }
    public bool AdvancePegPosition(Peg peg)
    {
        Slot newSlot = FindNextSlot(peg.slotReference, peg.color, AdvancementAmount);
        if (newSlot == null) return false;
        if (newSlot.HasPiece)
        {
            if (newSlot.GetPeg().color == peg.color) return false;
            newSlot.SendPegHome();
        }
        newSlot.SetPeg(peg);

        ChangeTurn();
        SetClickablePegs();

		return true;
    }

    private Slot FindNextSlot(Slot slot, PlayerColors color, int amount)
    {
        for(int i = 0; i < sectors.Count; i++)
        {
            if(sectors[i].Contains(slot, amount, color, GetFollowingSector(i), out Slot newPlacement))
            {
                return newPlacement;
            }
        }

        return null;
    }

    private Sector GetFollowingSector(int currentSectorIndex)
    {
        int index = currentSectorIndex + 1;
        if (index >= sectors.Count)
        {
            return sectors[0];
        }

        return sectors[index];
    }
    private void BuildBoard()
    {
        for (int i = 0; i < 4; i++)
        {
            BuildSector(i * -90);
        }
    }
    private void BuildSector(float angle)
    {
        Sector sector = Instantiate(sectorPrefab, transform.position, Quaternion.Euler(0, 0, angle));
        sector.sectorIndex = sectors.Count;
        sectors.Add(sector);
    }

	public void SetClickablePegs()
	{

		foreach (Peg peg in pegs)
		{
            peg.clickable = (int)peg.color == currentPlayerTurn;
		}
	}

	public void ChangeTurn()
    {
        diceRollable = true;
        if (AdvancementAmount == 6) return;
		currentPlayerTurn++;
		if (currentPlayerTurn > 3) currentPlayerTurn = 0;
        turnRenderer.SetColor(Utils.PlayerColorToRGB((PlayerColors)currentPlayerTurn));
	}
    [SerializeField] private TurnRenderer turnRenderer;
}