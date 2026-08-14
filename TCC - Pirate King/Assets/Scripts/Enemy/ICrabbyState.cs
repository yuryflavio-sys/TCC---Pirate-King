public interface ICrabbyState
{
    void Enter(Crabby enemy);
    void Execute(Crabby enemy);
    void Exit(Crabby enemy);
}