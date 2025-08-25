namespace MingiSynchronos.Services;

//public record MingiProfileData(bool IsFlagged, bool IsNSFW, string Base64ProfilePicture, string Base64SupporterPicture, string Description)
//{
//    public Lazy<byte[]> ImageData { get; } = new Lazy<byte[]>(Convert.FromBase64String(Base64ProfilePicture));
//    public Lazy<byte[]> SupporterImageData { get; } = new Lazy<byte[]>(string.IsNullOrEmpty(Base64SupporterPicture) ? [] : Convert.FromBase64String(Base64SupporterPicture));
//}

public record MingiProfileData(bool IsFlagged, bool IsNSFW, string Base64ProfilePicture, string Base64SupporterPicture, string Description)
{
    public Lazy<byte[]> ImageData { get; } = new Lazy<byte[]>(() =>
        IsValidBase64(Base64ProfilePicture)
            ? Convert.FromBase64String(Base64ProfilePicture)
            : Array.Empty<byte>());

    public Lazy<byte[]> SupporterImageData { get; } = new Lazy<byte[]>(() =>
        IsValidBase64(Base64SupporterPicture)
            ? Convert.FromBase64String(Base64SupporterPicture)
            : Array.Empty<byte>());

    private static bool IsValidBase64(string s)
    {
        if (string.IsNullOrWhiteSpace(s)) return false;
        s = s.Trim();
        if (s.Length % 4 != 0) return false;

        return Convert.TryFromBase64String(s, new Span<byte>(new byte[s.Length]), out _);
    }
}