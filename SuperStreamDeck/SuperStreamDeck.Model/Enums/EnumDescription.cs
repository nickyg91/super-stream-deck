namespace SuperStreamDeck.Model.Enums;

public class EnumDescription<T> where T : Enum
{
    public T Value { get; set; }
    public string Description { get; set; }
}