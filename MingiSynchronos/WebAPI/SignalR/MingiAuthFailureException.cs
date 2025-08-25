namespace MingiSynchronos.WebAPI.SignalR;

public class MingiAuthFailureException : Exception
{
    public MingiAuthFailureException(string reason)
    {
        Reason = reason;
    }

    public string Reason { get; }
}