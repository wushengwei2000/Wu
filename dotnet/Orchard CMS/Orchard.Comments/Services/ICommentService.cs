using System;
using Orchard.Comments.Models;
using Orchard.ContentManagement;

namespace Orchard.Comments.Services {
    public interface ICommentService : IDependency {
        IContentQuery<CommentPart, CommentPartRecord> GetComments();
        IContentQuery<CommentPart, CommentPartRecord> GetComments(CommentStatus status);
        IContentQuery<CommentPart, CommentPartRecord> GetCommentsForCommentedContent(int id);
        IContentQuery<CommentPart, CommentPartRecord> GetCommentsForCommentedContent(int id, CommentStatus status);
        CommentPart GetComment(int id);
        ContentItemMetadata GetDisplayForCommentedContent(int id);
        ContentItem GetCommentedContent(int id);
        void ProcessCommentsCount(int commentsPartId);
        void ApproveComment(int commentId);
        void UnapproveComment(int commentId);
        void DeleteComment(int commentId);
        bool CommentsDisabledForCommentedContent(int id);
        void DisableCommentsForCommentedContent(int id);
        void EnableCommentsForCommentedContent(int id);
        bool DecryptNonce(string nonce, out int id);
        string CreateNonce(CommentPart comment, TimeSpan delay);
        bool CanStillCommentOn(CommentsPart commentsPart);
        bool CanCreateComment(CommentPart commentPart);

        //New Comments UI Changes
        IContentQuery<CommentPart, CommentPartRecord> GetComments(string url);
        IContentQuery<CommentPart, CommentPartRecord> GetCommentsForUrl(CommentStatus status, string url);
        IContentQuery<CommentPart, CommentPartRecord> GetCommentsForCommentedContent(int id, string url);
        IContentQuery<CommentPart, CommentPartRecord> GetCommentsForCommentedContent(int id, CommentStatus status,
            string url);
        void ProcessCommentsCount(int commentsPartId, string url);
    }
}