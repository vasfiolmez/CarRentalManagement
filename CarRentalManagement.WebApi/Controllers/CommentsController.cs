using CarRentalManagement.Application.Features.Mediator.Commands.CommentCommands;
using CarRentalManagement.Application.Features.RepositoryPattern;
using CarRentalManagement.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _repository;
        private readonly IMediator _mediator;

        public CommentsController(IMediator mediator, IGenericRepository<Comment> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }


        [HttpGet]
        public IActionResult CommentList() 
        { 
        var value=_repository.GetAll();
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateComment(Comment comment) 
        { 
        _repository.Create(comment);
            return Ok("başarıyla eklendi.");
        }
        [HttpDelete]
        public IActionResult RemoveComment(int id)
        {
            var value=_repository.GetById(id);
            _repository.Delete(value);
            return Ok("başarıyla silindi.");
        }
        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {
            _repository.Update(comment);
            return Ok("başarıyla güncellendi.");
        }
        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
           var value= _repository.GetById(id);
            return Ok(value);
        }
        [HttpGet("GetCommentByBlogId")]
        public IActionResult GetCommentByBlogId(int id)
        {
            var value = _repository.GetCommentByBlogId(id);
            return Ok(value);
        }
        [HttpGet("GetCountCommentByBlog")]
        public IActionResult GetCountCommentByBlog(int id)
        {
            var value = _repository.GetCountCommentByBlog(id);
            return Ok(value);
        }
        [HttpPost("CreateCommentMediator")]
        public async Task<IActionResult> CreateCommentMediator(CreateCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Yorum eklendi");
        }
    }
}
