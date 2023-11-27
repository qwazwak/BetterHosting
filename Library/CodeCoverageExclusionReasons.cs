//namespace BetterHosting.Internal;

internal static class CodeCoverageExclusionReasons
{
    public const string DSharpSealed = "DSharp does not allow for unit tests involving their classes/methods.";
    public const string SimpleWrapperExtension = "Simple extension methods wrapping pre-tested methods";
    public const string SimpleWrapper = "Simple wrapper of pre-tested methods";
    public const string LambdaWrapper = "Simple lambda wrapper does not need coverage";
}
