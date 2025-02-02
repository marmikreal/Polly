namespace Polly.Retry;

internal static class RetryConstants
{
    public const string OnRetryEvent = "OnRetry";

    public const RetryBackoffType DefaultBackoffType = RetryBackoffType.Constant;

    public const int DefaultRetryCount = 3;

    public const int MaxRetryCount = int.MaxValue;

    public static readonly TimeSpan DefaultBaseDelay = TimeSpan.FromSeconds(2);
}
