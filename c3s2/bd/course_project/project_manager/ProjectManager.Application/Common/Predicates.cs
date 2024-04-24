using ProjectManager.Application.Common.Exceptions;
using ProjectManager.Application.Services;
using ProjectManager.Domain;

namespace ProjectManager.Application.Common;

public static class Predicates
{
    public static class Attachments
    {
        public static Func<Attachment, bool> GetById(Guid id) => x => x.Id == id;
    }

    public static class FileTypes
    {
        public static Func<FileType, bool> GetById(Guid id) => x => x.Id == id;
        public static Func<FileType, bool> GetByName(string name) => x => x.Name == name;
        public static Func<FileType, bool> GetByExtension(string extension) => x => x.Extension == extension;
    }

    public static class Users
    {
        public static Func<User, bool> GetById(Guid id) => x => x.Id == id;
    }

    public static class Repositories<T>
    {
        public static async Task<T> ThrowIfNullFromPredicateAsync(IRepository<T> repository, Func<T, bool> predicate)
        {
            var entity = await repository.GetByPredicateAsync(predicate);

            if (entity is null)
            {
                throw new NotFoundException(typeof(T).Name, predicate.Method.GetParameters()[0].Name ?? "NOT_FOUND");
            }
            
            return entity;
        }
    }

    public static class Comments
    {
        public static Func<Comment, bool> GetById(Guid id) => x => x.Id == id;
    }
}