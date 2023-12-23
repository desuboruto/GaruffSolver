﻿using GaruffSolver.Values;

namespace GaruffSolver.Solver.DPLL;

public sealed class DpllBackTracker : IBackTracker
{
    public BackTrackerFactory BackTrack => (formula, literal, model, solve) =>
    {
        foreach (var value in new[] { true, false })
        {
            var newModel = new Model(model);
            newModel.Assign(literal.Value, value);

            var newFormula = new Formula(formula);
            var newLiteral = value ? literal : literal.Negative();
            newFormula.AddLast(new Clause(new[] { newLiteral }));

            var resultModel = solve(newFormula, newModel);
            if (resultModel.IsSatisfied) return resultModel;
        }

        return model;
    };
}