using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Results;
using Entities;
using BLL;
using System;


namespace Service.Controllers
{
    [RoutePrefix("api/Products")]
    [Authorize] // Protege todo el controlador
    public class ProductsController : ApiController
    {
        // Crear producto
        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateProduct([FromBody] Products products)
        {
            if (products == null)
                return BadRequest("El producto no puede ser nulo.");

            var _productsLogic = new ProductsLogic();

            try
            {
                var createdProduct = _productsLogic.Create(products);
                return Created($"api/Products/{createdProduct.ProductID}", createdProduct);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear el producto: {ex.Message}");
            }
        }

        // Eliminar producto
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            var _productsLogic = new ProductsLogic();
            var result = _productsLogic.Delete(id);

            if (result)
                return Ok("Producto eliminado correctamente.");
            else
                return NotFound();
        }

        // Obtener todos los productos
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            var _productsLogic = new ProductsLogic();
            try
            {
                var products = _productsLogic.RetrieveAll();
                if (products == null || products.Count == 0)
                    return NotFound();

                return Ok(products);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // Obtener producto por ID
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            var _productsLogic = new ProductsLogic();
            try
            {
                var product = _productsLogic.RetrieveById(id);
                if (product == null)
                    return NotFound();

                var response = new
                {
                    product.ProductID,
                    product.ProductName,
                    product.CategoryID,
                    product.UnitPrice,
                    product.UnitsInStock
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // Actualizar producto
        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult UpdateProduct(int id, [FromBody] Products products)
        {
            if (products == null)
                return BadRequest("El producto no puede ser nulo.");

            if (id != products.ProductID)
                return BadRequest("El ID del producto no coincide con el ID de la URL.");

            var _productsLogic = new ProductsLogic();

            try
            {
                var updated = _productsLogic.Update(products);
                if (updated)
                    return Ok("Producto actualizado correctamente.");
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al actualizar el producto: {ex.Message}");
            }
        }
    }
}