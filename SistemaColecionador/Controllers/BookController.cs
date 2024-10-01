using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaColecionador.Domain.Dto;
using SistemaColecionador.Domain.Entities;
using SistemaColecionador.Domain.Interfaces;
using SistemaColecionador.Domain.Queries;

namespace SistemaColecionador.Api.Controllers;

[Route("api/books")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpPost]
    public ActionResult Post([FromBody] BookDto book)
    {
        if (book == null) return BadRequest();

        var errors= _bookService.CreateBook(book);

        if(errors.Any()) return BadRequest(errors.ToString());
        return Ok();
    }

    [HttpGet]
    public ActionResult<List<Book>> List([FromQuery] ListBooksQuery query)
    {
        var response = _bookService.ListBooks(query.Filter);
        return Ok(response);
    }

    [HttpDelete("{id:guid}")]
    public ActionResult Delete(Guid id)
    {
        if (id == Guid.Empty) return NotFound();
        _bookService.DeleteBook(id);
        return Ok();
    }
}