using Microsoft.AspNetCore.Mvc;
using SistemaColecionador.Domain.Dto;
using SistemaColecionador.Domain.Entities;
using SistemaColecionador.Domain.Interfaces.Services;
using SistemaColecionador.Domain.Queries;
using System.Text;

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
        if (book == null) return NotFound();

        var errors = _bookService.CreateBook(book);

        var errorMessage = new StringBuilder();

        errors.ForEach(error => errorMessage.AppendLine(error));

        if(errors.Any()) return BadRequest(errorMessage.ToString());
        return Ok();
    }

    [HttpGet]
    public ActionResult<List<Book>> List([FromQuery] ListBooksQuery query)
    {
        var response = _bookService.ListBooks(query.Filter);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(string id)
    {
        if (string.IsNullOrWhiteSpace(id)) return NotFound();
        _bookService.DeleteBook(new Guid(id));
        return Ok();
    }
}