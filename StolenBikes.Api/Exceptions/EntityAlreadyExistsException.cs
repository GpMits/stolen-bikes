using System;

namespace StolenBikes.Api.Exceptions
{
    public class EntityAlreadyExistsException : Exception
    {
        public EntityAlreadyExistsException() : base("Entity already exists!")
        {
        }
    }
}