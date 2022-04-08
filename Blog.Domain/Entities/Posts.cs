using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Shared.Abstractions.Domain;
using Blog.Domain.ValueObjects;
namespace Blog.Domain.Entities
{
    public class Posts : AggregateRoot<PostId>
    {
        public PostId Id { get; private set; }
        private string _title;
        private string _content;
        private DateTime _createdAt;
        private DateTime _updatedAt;
        private Guid _userId;
        private Guid _categoryId;
        private Guid? _imageId;
        private Guid? _videoId;
        private Guid? _audioId;
        private Guid? _documentId;
        private List<Comments> _comments = new();
        internal Posts(Guid id, string title, string content, DateTime createdAt,
                        DateTime updatedAt, Guid userId, Guid categoryId, Guid? imageId,
                        Guid? videoId, Guid? audioId, Guid? documentId, List<Comments> comments)
        {
            Id = id;
            _title = title;
            _content = content;
            _createdAt = createdAt;
            _updatedAt = updatedAt;
            _userId = userId;
            _categoryId = categoryId;
            _imageId = imageId;
            _videoId = videoId;
            _audioId = audioId;
            _documentId = documentId;
            _comments = comments;
        }
        public void AddComment(Comments comments)
        {
            var alreadyExists = _comments.Any(x => x.Id == comments.Id);
            if (alreadyExists)
            {
                throw new InvalidOperationException("Comment already exists");
            }
            _comments.AddLast(comments);
        }
    }
}