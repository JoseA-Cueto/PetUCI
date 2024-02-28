using AutoMapper;
using PetUci.InterfacesBussines;
using PetUci.InterfacesDataBase;
using PetUci.Models;
using PetUci.Repositories;
using PetUci.ViewModels;

namespace PetUci.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepositories _productRepository;
        private readonly IMapper _mapper;
        private readonly IImageFileService _imageFileService;

        public ProductService(IProductRepositories productRepository, IMapper mapper, IImageFileService imageFileService)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _imageFileService = imageFileService;
        }

        public async Task<IEnumerable<ProductViewModel>> GetProductsAsync()
        {
            var products = await _productRepository.GetProductsAsync();
            return _mapper.Map<IEnumerable<ProductViewModel>>(products);
        }

        public async Task<ProductViewModel> GetProductByIdAsync(int productId)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);
            return _mapper.Map<ProductViewModel>(product);
        }
        public async Task UpdateProductQuantityAsync(int productId, int quantityChange)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);
            if (product != null)
            {
                product.quantity += quantityChange;
                await _productRepository.UpdateProductAsync(product);
            }
            else
            {
                throw new ArgumentException("Product not found");
            }
        }


        public async Task<int> AddProductAsync(ProductViewModel productViewModel)
        {
            var product = _mapper.Map<Product>(productViewModel);
            return await _productRepository.AddProductAsync(product);
        }
        public async Task UpdateProductAsync(ProductViewModel productViewModel)
        {
            var existingProduct = await _productRepository.GetProductByIdAsync(productViewModel.id);

            if (existingProduct == null)
            {
                throw new Exception("Producto no encontrado");
            }

            _mapper.Map(productViewModel, existingProduct);

            await _productRepository.UpdateProductAsync(existingProduct);
        }


        public async Task DeleteProductAsync(int productId)
        {
            await _productRepository.DeleteProductAsync(productId);
        }
    }
}
