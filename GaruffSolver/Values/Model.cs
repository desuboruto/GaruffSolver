﻿using GaruffSolver.CNF;

namespace GaruffSolver.Values;

public class Model : Dictionary<ushort, bool>
{
    public Model()
    {
    }

    public Model(Model model) : base(model)
    {
    }

    public bool IsSatisfied { get; set; }

    public void Assign(ushort variable, bool value)
    {
        this[variable] = value;
    }

    public bool Verify(Cnf cnf)
    {
        return cnf.Clauses
            .All(clause => clause.Any(literal => this[literal.Key] == literal.Value));
    }

    public bool Verify(Formula formula)
    {
        return formula
            .All(clause => clause.Any(literal => this[literal.Value] == literal.IsPositive));
    }

    public void Fill(IEnumerable<ushort> variables)
    {
        foreach (var variable in variables)
            if (!ContainsKey(variable))
                this[variable] = false;
    }

    public override string ToString()
    {
        return string.Join(", ", this.Select(kv => $"{kv.Key}={kv.Value}"));
    }
}