using UnityEngine;
using System.Collections.Generic;

public interface ICommand
{
    void Execute();
    void Undo();
}