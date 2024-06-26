using Fire_Emblem.Views;

namespace Fire_Emblem;

public class FileManager
{
    private readonly ConsoleGameView _consoleGameView;

    public FileManager(ConsoleGameView consoleGameView)
    {
        _consoleGameView = consoleGameView;
    }

    public string[] GetFileOptions()
    {
        return _consoleGameView.DisplayFiles();
    }

    public string SelectFile(string[] files)
    {
        return _consoleGameView.AskUserToSelectAnOption(files);
    }

    public string ReadFileContent(string filePath)
    {
        return File.ReadAllText(filePath);
    }
}