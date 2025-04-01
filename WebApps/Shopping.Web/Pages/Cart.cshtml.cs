namespace Shopping.Web.Pages
{
    public class CartModel(ILogger<CartModel> logger, IBasketService basketService)
        : PageModel
    {

        public ShoppingCartModel Cart {  get; set; }    = new ShoppingCartModel();

        public async Task<IActionResult> OnGetAsync()
        {
            Cart = await basketService.LoadUserBasket();

            return Page();
        }

        public async Task<IActionResult> OnPostRemoveToCartAsync(string productId)
        {
            logger.LogInformation($"Remove to cart button clicked");
            Cart = await basketService.LoadUserBasket();

            Cart.Items.RemoveAll(x => x.ProductId == productId);

            await basketService.StoreBasket(new StoreBasketRequest(Cart));

            return RedirectToPage();
        }
    }
}
