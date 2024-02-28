using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetUci.InterfacesBussines;
using PetUci.ViewModels;

namespace PetUci.Controllers
{
    [Route("api/Product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger _logger;
        private readonly IImageFileService _imageFileService;

        public ProductController(IProductService productService, ILogger logger, IImageFileService imageFileService)
        {
            _productService = productService;
            _logger = logger;
            _imageFileService = imageFileService;
        }

        [HttpGet("GetAllProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetAllProducts()
        {
            try
            {
                var products = await _productService.GetProductsAsync();

                foreach (var product in products)
                {
                    try
                    {
                        var imageFile = await _imageFileService.GetImageByProductIdAsync(product.id);
                        if (imageFile != null)
                        {
                            product.ImagePath = imageFile.Path;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Manejo de errores si es necesario
                        _logger.LogError(ex, $"Error al asignar el Path de imagen para el producto {product.id}");
                    }
                }

                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los productos");
                return StatusCode(500); // Devuelve un código de estado 500 en caso de error
            }
        }

        [HttpGet("GetProductById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductViewModel>> GetProductById(int id)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(id);
                if (product != null)
                {
                    var imageFile = await _imageFileService.GetImageByProductIdAsync(product.id);
                    if (imageFile != null)
                    {
                        product.ImagePath = imageFile.Path;
                    }
                }
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el producto con ID: {id}");
                return StatusCode(500);
            }
        }
        [Authorize]
        [HttpPost("AddProduct")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> AddProductWithImage([FromForm] ProductViewModel productViewModel)
        {
            try
            {
                if (productViewModel.File == null || productViewModel.File.Length == 0)
                {
                    return BadRequest("No se ha proporcionado ninguna imagen.");
                }


                var productId = await _productService.AddProductAsync(productViewModel);
                productViewModel.id = productId;
                await _imageFileService.CreateImageFile(productViewModel);
                return StatusCode(201);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar un nuevo producto con imagen.");
                return StatusCode(500);
            }
        }
        [Authorize]
        [HttpPut("UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateProductWithImage([FromForm] ProductViewModel productViewModel)
        {
            try
            {
                if (productViewModel.File == null || productViewModel.File.Length == 0)
                {
                    return BadRequest("No se ha proporcionado ninguna imagen.");
                }

                await _productService.UpdateProductAsync(productViewModel);
                await _imageFileService.UpdateImageFile(productViewModel);

                return StatusCode(200);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar el producto con imagen.");
                return StatusCode(500);
            }
        }


        [Authorize]
        [HttpDelete("DeleteProduct/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            try
            {
                var existingProduct = await _productService.GetProductByIdAsync(id);
                var existingImage = await _imageFileService.GetImageByProductIdAsync(id);
                if (existingProduct == null)
                {
                    return NotFound();
                }

                await _productService.DeleteProductAsync(id);
                await _imageFileService.DeleteImageFileAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar el producto con ID: {id}");
                return StatusCode(500);
            }
        }
    }
}
