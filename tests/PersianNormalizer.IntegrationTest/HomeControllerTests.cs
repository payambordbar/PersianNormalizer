using System.Net.Http.Json;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;

using PersianNormalizer.Controllers;

namespace PersianNormalizer.UnitTest;

public class HomeControllerTests
{
    private readonly HttpClient _httpClient;

    public HomeControllerTests()
    {
        var appFactory = new WebApplicationFactory<Program>();
        _httpClient = appFactory.CreateClient();
    }

    [Theory]
    [InlineData("۰۱۲۳۴۵۶۷۸۹", "0123456789")]
    [InlineData("٠١٢٣٤٥٦٧٨٩", "0123456789")]
    [InlineData("سلام۱۲۳", "سلام123")]
    [InlineData("ھيكﮑﮐﮏ", "هیکککک")]
    public async Task FromRoute_Returns_Correct_String(string data, string expected)
    {
        // arrange

        var response = await _httpClient.GetAsync($"Home/" + data);

        // act

        var output = await response.Content.ReadAsStringAsync();

        // assert

        Assert.Equal(expected, output);
    }

    [Theory]
    [InlineData("۰۱۲۳۴۵۶۷۸۹", "0123456789")]
    [InlineData("٠١٢٣٤٥٦٧٨٩", "0123456789")]
    [InlineData("سلام۱۲۳", "سلام123")]
    [InlineData("ھيكﮑﮐﮏ", "هیکککک")]
    public async Task FromQuery_Returns_Correct_String(string data, string expected)
    {
        // arrange

        var response = await _httpClient.GetAsync($"Home?str=" + data);

        // act

        var output = await response.Content.ReadAsStringAsync();

        // assert

        Assert.Equal(expected, output);
    }

    [Theory]
    [InlineData("۰۱۲۳۴۵۶۷۸۹", "0123456789")]
    [InlineData("٠١٢٣٤٥٦٧٨٩", "0123456789")]
    [InlineData("سلام۱۲۳", "سلام123")]
    [InlineData("ھيكﮑﮐﮏ", "هیکککک")]
    public async Task FromBody_Returns_Correct_String(string data, string expected)
    {
        // arrange

        var body = new Input(data);

        var response = await _httpClient.PostAsync($"Home/body", JsonContent.Create(body));

        // act

        var output = await response.Content.ReadAsStringAsync();

        // assert

        Assert.Equal(expected, output);
    }

    [Theory]
    [InlineData("۰۱۲۳۴۵۶۷۸۹", "0123456789")]
    [InlineData("٠١٢٣٤٥٦٧٨٩", "0123456789")]
    [InlineData("سلام۱۲۳", "سلام123")]
    [InlineData("ھيكﮑﮐﮏ", "هیکککک")]
    public async Task FromForm_Returns_Correct_String(string data, string expected)
    {
        // arrange

        var body = new Input(data);
        var response = await _httpClient.PostAsync($"Home/body", JsonContent.Create(body));

        // act

        var output = await response.Content.ReadAsStringAsync();

        // assert

        Assert.Equal(expected, output);
    }
}