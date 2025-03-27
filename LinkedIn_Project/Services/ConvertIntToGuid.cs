namespace LinkedIn_Project.Services;

public static class ConvertIntToGuid   // bunu lazim olmusdu yazmisdim, silecem
{
    public static Guid Convert(int value)
    {
        byte[] bytes = BitConverter.GetBytes(value);
        return new Guid(bytes.Concat(new byte[12]).ToArray());
    }
}
