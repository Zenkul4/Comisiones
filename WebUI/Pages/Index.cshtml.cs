using WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Net.Http.Json;

namespace WebUI.Pages;

public class IndexModel : PageModel
{
    private readonly HttpClient _httpClient;

    public IndexModel(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ComisionesAPI");
    }

    [BindProperty]
    public CalculateRequestDto RequestDto { get; set; } = new();

    public decimal? Comision { get; set; }
    public string? ErrorMessage { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/commission/calcular", RequestDto);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<CalculateResponseDto>();
                Comision = result?.ComisionCalculada;
            }
            else
            {
                ErrorMessage = "Error en el cálculo. Verifique que el código de país sea válido (IN, US, UK).";
            }
        }
        catch (Exception)
        {
            ErrorMessage = "No se pudo conectar con la API. Asegúrese de que esté en ejecución.";
        }

        return Page();
    }
}