using ProductManagement.Blazor.Data;

namespace ProductManagement.Blazor.Services
{

    public class ProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Product>?> GetProductsAsync()
        {
            return await _http.GetFromJsonAsync<List<Product>>("api/Product");
        }

        // future: AddProduct, DeleteProduct, UpdateProduct etc.

        public async Task CreateProductAsync(Product product)
        {
            var response = await _http.PostAsJsonAsync("api/Product", product);
            response.EnsureSuccessStatusCode(); // throws if not 200 OK
        }

        // Add the UpdateProductAsync method
        public async Task UpdateProductAsync(Product product)
        {
            var response = await _http.PutAsJsonAsync($"api/Product/{product.Id}", product); // Assuming your API expects the product ID in the URL
            response.EnsureSuccessStatusCode(); // throws if not 200 OK
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            var product = await _http.GetFromJsonAsync<Product>($"api/Product/{id}");
            return product; // Returns the product if found, or null if not found
        }
        // Add DeleteProductAsync method
        public async Task DeleteProductAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/Product/{id}"); // Assuming your API expects the product ID in the URL
            response.EnsureSuccessStatusCode(); // throws if not 200 OK
        }
    }
}
