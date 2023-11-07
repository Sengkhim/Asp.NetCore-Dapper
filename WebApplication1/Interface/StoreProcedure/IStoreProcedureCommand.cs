namespace WebApplication1.Interface.StoreProcedure;

public interface IStoreProcedureCommand
{
    IStoreProcedureAsync Procedure { get; }
}