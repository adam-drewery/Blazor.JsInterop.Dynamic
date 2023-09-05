namespace Blazor.JsInterop.Dynamic;

public class Blob
{
    public Blob(byte[] bytes) => Bytes = bytes;

    // hack to be able to identify this in the JS side
    public string Identifier { get; } = "x568c8d7489ac46a1926565b18249fa9e";

    public byte[] Bytes { get; set; }
    
    public static implicit operator Blob(byte[] bytes) => new(bytes);
    
    public static implicit operator byte[](Blob blob) => blob.Bytes;
}