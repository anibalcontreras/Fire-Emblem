using Fire_Emblem.Views;

namespace Fire_Emblem;

public class FileManager
{
    private readonly IView _consoleGameView;

    public FileManager(IView consoleGameView)
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
