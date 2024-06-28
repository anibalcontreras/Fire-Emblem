using Fire_Emblem;
using Fire_Emblem_View;
using Fire_Emblem_GUI;
using Fire_Emblem.Views;

bool useGui = true;

if (useGui)
{
    FireEmblemWindow window = new FireEmblemWindow();
    window.Start(Main);

    void Main()
    {

        GraphicGameView graphicGameView = new GraphicGameView(window);
        UIGame uiGame = new UIGame(graphicGameView);
        uiGame.Play();
        
        
        // string team1Data = window.GetTeam1();
        // string team2Data = window.GetTeam2();
        //
        // string formattedTeam1 = "Player 1 Team\n" + team1Data + "\n";
        // string formattedTeam2 = "Player 2 Team\n" + team2Data;
        // string formattedTeams = formattedTeam1 + formattedTeam2;
        // Console.WriteLine(formattedTeams);
        //
        //
        
        
        
        
        
        // Unit[] team1 = [new Unit("Marth", "Sword", 54, 62, 53, 43, 37)];
        // Unit [] team2 = [
        //     new Unit("Seliph", "Sword", 55, 68, 27, 48, 39),
        // new Unit("Soren", "Magic", 49, 63, 41, 25, 53)]; window.UpdateTeams(team1, team2);
        // int idSelectedUnitTeam1 = window.SelectUnitTeam1();
        // Unit unitTeam1 = team1[idSelectedUnitTeam1];
        // int idSelectedUnitTeam2 = window.SelectUnitTeam2();
        // Unit unitTeam2 = team2[idSelectedUnitTeam2];
        // window.UpdateUnitsStatsDuringBattle(unitTeam1 , unitTeam2); window.ShowAttackFromTeam1(unitTeam1 , unitTeam2);
        // unitTeam2.Hp -= 20;
        // window.UpdateUnitsStatsDuringBattle(unitTeam1 , unitTeam2); window.ShowAttackFromTeam2(unitTeam1 , unitTeam2);
        // unitTeam1.Hp -= 15;
        // window.UpdateUnitsStatsDuringBattle(unitTeam1 , unitTeam2);
        // window.UpdateTeams(team1, team2); idSelectedUnitTeam2 = window.SelectUnitTeam2();
        // unitTeam2 = team2[idSelectedUnitTeam2]; idSelectedUnitTeam1 = window.SelectUnitTeam1();
        // unitTeam1 = team1[idSelectedUnitTeam1];
    }
}
else
{
    string testFolder = SelectTestFolder();
    string test = SelectTest(testFolder);
    string teamsFolder = testFolder.Replace("-Tests","");
    AnnounceTestCase(test);
    
    var view = View.BuildManualTestingView(test);
    var game = new Game(view, teamsFolder);
    game.Play();
    
    string SelectTestFolder()
    {
        Console.WriteLine("¿Qué grupo de test quieres usar?");
        string[] dirs = GetAvailableTestsInOrder();
        ShowArrayOfOptions(dirs);
        return AskUserToSelectAnOption(dirs);
    }
    
    string[] GetAvailableTestsInOrder()
    {
        string[] dirs = Directory.GetDirectories("data", "*-Tests", SearchOption.TopDirectoryOnly);
        Array.Sort(dirs);
        return dirs;
    }
    
    void ShowArrayOfOptions(string[] options)
    {
        for(int i = 0; i < options.Length; i++)
            Console.WriteLine($"{i}- {options[i]}");
    }
    
    string AskUserToSelectAnOption(string[] options)
    {
        int minValue = 0;
        int maxValue = options.Length - 1;
        int selectedOption = AskUserToSelectNumber(minValue, maxValue);
        return options[selectedOption];
    }
    
    int AskUserToSelectNumber(int minValue, int maxValue)
    {
        Console.WriteLine($"(Ingresa un número entre {minValue} y {maxValue})");
        int value;
        bool wasParsePossible;
        do
        {
            string? userInput = Console.ReadLine();
            wasParsePossible = int.TryParse(userInput, out value);
        } while (!wasParsePossible || IsValueOutsideTheValidRange(minValue, value, maxValue));
    
        return value;
    }
    
    bool IsValueOutsideTheValidRange(int minValue, int value, int maxValue)
        => value < minValue || value > maxValue;
    
    string SelectTest(string testFolder)
    {
        Console.WriteLine("¿Qué test quieres ejecutar?");
        string[] tests = Directory.GetFiles(testFolder, "*.txt" );
        Array.Sort(tests);
        return AskUserToSelectAnOption(tests);
    }
    
    void AnnounceTestCase(string test)
    {
        Console.WriteLine($"----------------------------------------");
        Console.WriteLine($"Replicando test: {test}");
        Console.WriteLine($"----------------------------------------\n");
    }    
}
