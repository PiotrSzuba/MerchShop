namespace MerchShop.Api.Controllers;

public static class ControllersAdder
{
    public static void AddControllers(this WebApplication app)
    {
        app.AddItemController();
    }
}
