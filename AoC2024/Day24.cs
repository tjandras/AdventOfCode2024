namespace AoC2024;

public class Day24
{
    public void GetOutput(string input)
    {
        var inputParts = input.Split("\n\n");

        var inputs = new Dictionary<string, int>();
        foreach (var line in inputParts.First().Split("\n"))
        {
            var values = line.Split(": ");
            inputs.Add(values.First(), int.Parse(values.Last()));
        }
        var gates = inputParts.Last().Split("\n").Select(i => new Operation(i)).ToList();
        var calculatedOutputs = 0;

        while (calculatedOutputs < gates.Count)
        {
            foreach (var gate in gates.Where(g => !g.Done).ToList())
            {
                if (inputs.TryGetValue(gate.Input1, out var value1) && inputs.TryGetValue(gate.Input2, out var value2))
                {
                    gate.CalculateOutputValue(value1, value2);
                    gate.Done = true;
                    calculatedOutputs++;
                    inputs.Add(gate.Output, gate.OutputValue);
                }
            }
        }

        gates = gates.OrderByDescending(x => x.Output).ToList();
        var finalOutputs = gates.Where(g => g.Output.StartsWith('z')).ToList();
        Console.WriteLine(Convert.ToInt64(string.Concat(finalOutputs.Select(o => o.OutputValue.ToString())), 2));
    }
    
    
}

public class Operation
{
    public Operation(string input)
    {
        var parts = input.Split(" ");
        Input1 = parts[0];
        Input2 = parts[2];
        Gate = parts[1];
        Output = parts.Last();
    }
    
    public string Input1 { get; set; }

    public string Input2 { get; set; }

    public string Gate { get; set; }

    public string Output { get; set; }

    public int OutputValue { get; set; } = -1;

    public bool Done { get; set; }

    public void CalculateOutputValue(int input1, int input2)
    {
        switch (Gate)
        {
            case "OR":
                OutputValue = input1 == 1 || input2 == 1 ? 1 : 0;
                break;
            case "AND":
                OutputValue = input1 == 1 && input2 == 1 ? 1 : 0;
                break;
            case "XOR":
                OutputValue = input1 != input2 ? 1 : 0;
                break;
        }
    }
}