﻿using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GaruffSolver.CNF;

public record Cnf(int VariableCount, int ClausesCount, IEnumerable<Dictionary<string, bool>> Clauses)
{
    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine("cnf");
        sb.AppendLine($"VariableCount: {VariableCount}");
        sb.AppendLine($"ClausesCount: {ClausesCount}");

        foreach (var clause in Clauses)
            sb.AppendLine(string.Join(" ", clause.Select(l => l.Value ? l.Key : "-" + l.Key)) + " 0");

        return sb.ToString();
    }
}