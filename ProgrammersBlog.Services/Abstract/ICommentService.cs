using ProgrammersBlog.Entities.Dtos.Comments;
using ProgrammersBlog.Shared.Utilities.Results.Abstract;

namespace ProgrammersBlog.Services.Abstract
{
    public interface ICommentService
    {
        Task<IDataResult<int>> CountAsync();
        Task<IDataResult<int>> CountByNonDeletedAsync();
        Task<IDataResult<CommentDto>> GetAsync(Guid commentId);
        Task<IDataResult<CommentUpdateDto>> GetCommentUpdateDtoAsync(Guid commentId);
        Task<IDataResult<CommentListDto>> GetAllAsync();
        Task<IDataResult<CommentDto>> ApproveAsync(Guid commentId, string modifiedByName);
        Task<IDataResult<CommentListDto>> GetAllByDeletedAsync();
        Task<IDataResult<CommentListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<CommentListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IDataResult<CommentDto>> AddAsync(CommentAddDto commentAddDto);
        Task<IDataResult<CommentDto>> UpdateAsync(CommentUpdateDto commentUpdateDto, string modifiedByName);
        // Comment nesnesini doğrudan güncellemek için yeni metot
        Task<IDataResult<CommentDto>> UpdateCommentAsync(ProgrammersBlog.Entities.Concrete.Comment comment, string modifiedByName);
        Task<IDataResult<CommentDto>> DeleteAsync(Guid commentId, string modifiedByName);
        Task<IResult> HardDeleteAsync(Guid commentId);
        Task<IDataResult<CommentDto>> UndoDeleteAsync(Guid commentId, string modifiedByName);

    }
}
