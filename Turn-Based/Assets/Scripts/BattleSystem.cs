using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState { Start, PlayerTurn, EnemyTurn, Won, Lost }
public class BattleSystem : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private Transform playerBattleStation;
    [SerializeField] private Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public BattleHud playerHUD;
    public BattleHud enemyHUD;

    public BattleState State;

    [SerializeField] private TextMeshProUGUI dialougeText;

    // Start is called before the first frame update
    void Start()
    {
        State = BattleState.Start;
        SetupBattle();
    }

    private void SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialougeText.text = "A Strong " + enemyUnit.unitName + " approches....";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);
    }
}
