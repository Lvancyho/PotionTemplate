using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    private static CommandManager _instance;

    public static CommandManager Instance
    {
        get
        {
            if (_instance == null)
            {
                // Create a new GameObject to hold the CommandManager if one doesn't exist
                GameObject obj = new GameObject("CommandManager");
                _instance = obj.AddComponent<CommandManager>();
            }
            return _instance;
        }
    }

    private Stack<ICommand> undoStack = new Stack<ICommand>();
    private Stack<ICommand> redoStack = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        undoStack.Push(command);
        redoStack.Clear(); // Clear the redo stack after a new action
    }

    public void Undo()
    {
        if (undoStack.Count > 0)
        {
            ICommand command = undoStack.Pop();
            command.Undo();
            redoStack.Push(command);
        }
    }

    public void Redo()
    {
        if (redoStack.Count > 0)
        {
            ICommand command = redoStack.Pop();
            command.Execute();
            undoStack.Push(command);
        }
    }
}
