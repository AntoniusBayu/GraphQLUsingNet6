﻿namespace GraphQLNet6.Controllers
{
    [Route("graphql/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookBusiness _book { get; set; }
        public BookController(IServiceProvider serviceProvider) => _book = serviceProvider.GetRequiredService<IBookBusiness>();
        [Route("ReadData")]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var result = await _book.ReadData(query);

            if (result.Errors?.Count > 0)
                BadRequest();

            return Ok(result);
        }
    }

}
