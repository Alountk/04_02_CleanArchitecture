using System;
using Blog.Domain.Exceptions;
using Blog.Domain.Entities;
namespace Blog.Domain.ValueObjects
{
    public record PostsName : IEquatable<PostsName>
    {
        public string Value { get; }
        public PostsName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Value cannot be empty", nameof(value));
            }
            Value = value;
        }
        public static implicit operator string(PostsName name) => name.Value;
        public static implicit operator PostsName(string name) => new(name);

    }
}