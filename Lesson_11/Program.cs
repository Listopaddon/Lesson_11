using System;

public enum Operation
{
    Sum,
    Subtract,
    Multiply
}

public class OperationManager
{
    private int _first;
    private int _second;
    ExecutionManager manager;


    public OperationManager(int first, int second)
    {
        _first = first;
        _second = second;
        manager = new ExecutionManager();
    }

    public int Execute(Operation operation)
    {
        return manager.FuncExecute[operation].Invoke(_first, _second);
    }
}

//Implement functionality
public class ExecutionManager
{
    public Dictionary<Operation, Func<int, int, int>> FuncExecute { get; set; }
    //Add delegates for sum, substrat and multiply here
    public ExecutionManager()
    {
        FuncExecute = new Dictionary<Operation, Func<int, int, int>>();
        PrepareExecution();
    }

    public void PrepareExecution()
    {
        FuncExecute.Add(Operation.Multiply, (a, b) => a * b);
        FuncExecute.Add(Operation.Subtract, (a, b) => a - b);
        FuncExecute.Add(Operation.Sum, (a, b) => a + b);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var opManager = new OperationManager(20, 10);
        var result = opManager.Execute(Operation.Subtract);
        Console.WriteLine($"The result of the operation is {result}");
        Console.ReadKey();
    }
}