using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using FluentValidation.Results;

namespace Domain.Entities
{
    public abstract class BaseEntity<T> : AbstractValidator<T>
    {
        protected BaseEntity()
        {
            ValidationResult = new ValidationResult();
        }

        public int Id { get; set; }

        [NotMapped] public ValidationResult ValidationResult { get; set; }

        protected abstract bool EhValido();
    }
}