namespace TeamWeekClient.Models
{
  public class TokenResponse
  {
    public string Token { get; set; } = default!;
    public string RefreshToken { get; set; } = default!;
    public string Success { get; set; } = default!;
    public string Errors { get; set; } = default!;
  }
}