using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json;
using System.Text.Json.Serialization;
using ProgrammersBlog.Mvc.Models;
using ProgrammersBlog.Services.Abstract;
using ProgrammersBlog.Shared.Utilities.Extensions;
using ProgrammersBlog.Shared.Utilities.Results.ComplexTypes;
using ProgrammersBlog.Entities.Dtos.Comments;
using ProgrammersBlog.Entities.Concrete;

namespace ProgrammersBlog.Mvc.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            ReferenceHandler = ReferenceHandler.Preserve
        };

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]  // CSRF koruması
        public async Task<JsonResult> Add([FromForm] CommentAddDto commentAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _commentService.AddAsync(commentAddDto);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var commentAddAjaxViewModel = JsonSerializer.Serialize(new CommentAddAjaxViewModel
                    {
                        CommentDto = result.Data,
                        CommentAddPartial = await this.RenderViewToStringAsync("_CommentAddPartial", commentAddDto)
                    }, _jsonOptions);
                    return Json(commentAddAjaxViewModel);
                }
                ModelState.AddModelError("", result.Message);
            }
            var commentAddAjaxErrorModel = JsonSerializer.Serialize(new CommentAddAjaxViewModel
            {
                CommentAddDto = commentAddDto,
                CommentAddPartial = await this.RenderViewToStringAsync("_CommentAddPartial", commentAddDto)
            });
            return Json(commentAddAjaxErrorModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> AddReply([FromForm] string ParentCommentId, [FromForm] string ArticleId, [FromForm] string CreatedByName, [FromForm] string Text)
        {
            try
            {
                Console.WriteLine($"AddReply: ParentCommentId={ParentCommentId}, ArticleId={ArticleId}, CreatedByName={CreatedByName}, Text={Text}");
                
                if (string.IsNullOrEmpty(ParentCommentId) || string.IsNullOrEmpty(ArticleId) || 
                    string.IsNullOrEmpty(CreatedByName) || string.IsNullOrEmpty(Text))
                {
                    return Json(new { success = false, message = "Lütfen tüm alanları doldurun." });
                }
                
                // Guid'leri parse et
                if (!Guid.TryParse(ParentCommentId, out Guid parentCommentGuid) || 
                    !Guid.TryParse(ArticleId, out Guid articleGuid))
                {
                    return Json(new { success = false, message = "Geçersiz ID formatı." });
                }
                
                // CommentAddDto oluştur
                var commentAddDto = new CommentAddDto
                {
                    ParentCommentId = parentCommentGuid,
                    ArticleId = articleGuid,
                    CreatedByName = CreatedByName,
                    Text = Text,
                    IsActive = false // Yanıt olduğu için admin onayı gerekiyor
                };
                
                var result = await _commentService.AddAsync(commentAddDto);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    return Json(new { 
                        success = true, 
                        message = "Yanıtınız başarıyla eklendi ve onay için gönderildi.", 
                        commentId = result.Data.Comment.Id 
                    });
                }
                return Json(new { success = false, message = result.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"AddReply Exception: {ex.Message}");
                return Json(new { success = false, message = "Bir hata oluştu: " + ex.Message });  
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LikeComment([FromForm] string commentId)
        {
            try
            {
                Console.WriteLine($"LikeComment: CommentId={commentId}");
                if (string.IsNullOrEmpty(commentId) || !Guid.TryParse(commentId, out Guid commentGuid))
                {
                    Console.WriteLine($"LikeComment: Geçersiz yorum ID'si: {commentId}");
                    return BadRequest(new { success = false, message = "Geçersiz yorum ID'si." });
                }
                
                var result = await _commentService.GetAsync(commentGuid);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var comment = result.Data.Comment;
                    Console.WriteLine($"LikeComment: Şu anki beğeni sayısı: {comment.LikeCount}");
                    comment.LikeCount += 1;
                    Console.WriteLine($"LikeComment: Yeni beğeni sayısı: {comment.LikeCount}");
                    var updateResult = await _commentService.UpdateCommentAsync(comment, "System");
                    if (updateResult.ResultStatus == ResultStatus.Success)
                    {
                        Console.WriteLine($"LikeComment: Başarılı, beğeni sayısı: {comment.LikeCount}");
                        return Ok(new { success = true, likeCount = comment.LikeCount });
                    }
                    Console.WriteLine($"LikeComment: Güncelleme başarısız: {updateResult.Message}");
                    return BadRequest(new { success = false, message = updateResult.Message });
                }
                Console.WriteLine($"LikeComment: Yorum bulunamadı: {commentGuid}");
                return NotFound(new { success = false, message = "Yorum bulunamadı." });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"LikeComment Error: {ex.Message}");
                return StatusCode(500, new { success = false, message = $"Hata: {ex.Message}" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> UnlikeComment(string commentId)
        {
            try
            {
                Console.WriteLine($"UnlikeComment: CommentId={commentId}");
                if (string.IsNullOrEmpty(commentId) || !Guid.TryParse(commentId, out Guid commentGuid))
                {
                    Console.WriteLine($"UnlikeComment: Geçersiz yorum ID'si: {commentId}");
                    return Json(new { success = false, message = "Geçersiz yorum ID'si." });
                }
                
                var result = await _commentService.GetAsync(commentGuid);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var comment = result.Data.Comment;
                    Console.WriteLine($"UnlikeComment: Şu anki beğeni sayısı: {comment.LikeCount}");
                    if (comment.LikeCount > 0)
                    {
                        comment.LikeCount -= 1;
                        Console.WriteLine($"UnlikeComment: Yeni beğeni sayısı: {comment.LikeCount}");
                        var updateResult = await _commentService.UpdateCommentAsync(comment, "System");
                        if (updateResult.ResultStatus == ResultStatus.Success)
                        {
                            Console.WriteLine($"UnlikeComment: Başarılı, beğeni sayısı: {comment.LikeCount}");
                            return Json(new { success = true, likeCount = comment.LikeCount });
                        }
                        Console.WriteLine($"UnlikeComment: Güncelleme başarısız: {updateResult.Message}");
                        return Json(new { success = false, message = updateResult.Message });
                    }
                    Console.WriteLine($"UnlikeComment: Beğeni sayısı zaten 0");
                    return Json(new { success = true, likeCount = 0 });
                }
                Console.WriteLine($"UnlikeComment: Yorum bulunamadı: {commentGuid}");
                return Json(new { success = false, message = "Yorum bulunamadı." });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"UnlikeComment Error: {ex.Message}");
                return Json(new { success = false, message = $"Hata: {ex.Message}" });
            }
        }
    }
}
