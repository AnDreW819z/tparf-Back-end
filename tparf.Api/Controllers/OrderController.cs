﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using tparf.Dto;
using tparf.Interfaces;
using tparf.Domain.Entites;
using tparf.Repository;

namespace tparf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepositories _userRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public OrderController(IOrderRepository orderRepository, 
            IUserRepositories userRepository, 
            IProductRepository productRepository, 
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet("{orderId}")]
        [ProducesResponseType(200, Type = typeof(Order))]
        [ProducesResponseType(400)]
        public IActionResult GetOrder(int orderId)
        {
            if (!_orderRepository.OrderExists(orderId))
                return NotFound();
            var order = _mapper.Map<ProductDto>(_orderRepository.GetOrder(orderId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(order);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Order>))]
        public IActionResult GetOrders()
        {
            var orders = _mapper.Map<List<OrderDto>>(_orderRepository.GetOrders());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(orders);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateOrder([FromQuery] string userEmail, [FromQuery] int productId, [FromBody] OrderDto orderCreate)
        {
            if (orderCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var orderMap = _mapper.Map<Order>(orderCreate);

            orderMap.User = _userRepository.GetUser(userEmail);
            orderMap.Product = _productRepository.GetProduct(productId);

            if (!_orderRepository.CreateOrder(userEmail, productId, orderMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Успешно создано!");
        }

    }
}
