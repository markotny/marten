using System;
using JasperFx.CodeGeneration;
using JasperFx.CodeGeneration.Frames;
using JasperFx.CodeGeneration.Model;

namespace Marten.Events.CodeGeneration;

internal class DeclareLocalAggregateFrame: SyncFrame
{
    public DeclareLocalAggregateFrame(Type aggregateType, string localVarName, Variable sourceVariable)
    {
        LocalVariable = new Variable(aggregateType, localVarName, this);
        SourceVariable = sourceVariable;
    }

    public Variable LocalVariable { get; }
    public Variable SourceVariable { get; }

    public override void GenerateCode(GeneratedMethod method, ISourceWriter writer)
    {
        writer.WriteLine($"{LocalVariable.VariableType.FullNameInCode()} {LocalVariable.Usage} = {SourceVariable.Usage};");
        Next?.GenerateCode(method, writer);
    }
}
