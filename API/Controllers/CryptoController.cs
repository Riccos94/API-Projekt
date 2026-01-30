using Microsoft.AspNetCore.Mvc;

namespace CryptoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CryptoController : ControllerBase
{
    public record CryptoRequest(string Text, int Shift);
    public record CryptoResponse(string Result);

    [HttpPost("encrypt")]
    public ActionResult<CryptoResponse> Encrypt([FromBody] CryptoRequest req)
        => Ok(new CryptoResponse(Caesar(req.Text, req.Shift)));

    [HttpPost("decrypt")]
    public ActionResult<CryptoResponse> Decrypt([FromBody] CryptoRequest req)
        => Ok(new CryptoResponse(Caesar(req.Text, -req.Shift)));

    private static string Caesar(string input, int shift)
    {
        if (string.IsNullOrEmpty(input)) return input;

        shift %= 26;
        char ShiftChar(char c, char a)
        {
            int offset = c - a;
            int shifted = (offset + shift + 26) % 26;
            return (char)(a + shifted);
        }

        return new string(input.Select(c =>
        {
            if (c >= 'a' && c <= 'z') return ShiftChar(c, 'a');
            if (c >= 'A' && c <= 'Z') return ShiftChar(c, 'A');
            return c;
        }).ToArray());
    }
}
